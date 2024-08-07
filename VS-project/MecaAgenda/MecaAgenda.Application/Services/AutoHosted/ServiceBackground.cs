using MecaAgenda.Application.Services.Interfaces;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MecaAgenda.Application.Services.AutoHosted
{
    public class ServiceBackground : BackgroundService
    {
        private readonly ILogger<ServiceBackground> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ServiceBackground(ILogger<ServiceBackground> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Log that Task Schedule has been started
            _logger.LogInformation("Tasks have been started at: {time}", DateTime.Now.ToString());

            while (!stoppingToken.IsCancellationRequested)
            {
                // Calculate next 8AM
                var now = DateTime.Now;
                var nextRunTime = now.Date.AddHours(8).AddMinutes(0);

                if (now >= nextRunTime)
                    nextRunTime.AddDays(1);

                var delay = nextRunTime - now;

                // Wait until next 8AM
                await Task.Delay(delay, stoppingToken);

                // Execute customer reminder
                await remindCustomerOfServiceAsync();
            }
        }

        private async Task remindCustomerOfServiceAsync()
        {
            // Log that the Task started
            _logger.LogInformation("Reminding customers started at: {time}", DateTime.Now.ToString());

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _serviceAppointment = scope.ServiceProvider.GetRequiredService<IServiceAppointment>();
                var _repositoryMailer = scope.ServiceProvider.GetRequiredService<IRepositoryMailer>();
                var _serviceMailTemplates = scope.ServiceProvider.GetRequiredService<IServiceMailTemplates>();

                // Obtain Todays and Tomorrow dates
                DateOnly today = DateOnly.Parse(DateTime.Now.Date.ToString().Split(" ")[0]);
                DateOnly tomorrow = DateOnly.Parse(DateTime.Now.Date.AddDays(1).ToString().Split(" ")[0]);

                // Obtain the appointments for today and tomorrow
                var appointments = await _serviceAppointment.ListAsync(null, null, today, tomorrow);

                // Create an send emails for each one of the appointments

                foreach (var appointment in appointments)
                {
                    string subject = "Reminder for Appointment at " + appointment.Date + " from " + appointment.StartTime + " to " + appointment.EndTime;
                    List<string> to = new List<string>(new string[] { appointment.Client.Email });

                    string template = await _serviceMailTemplates.GetEmailTemplate("appointment-reminder.html");

                    string body = template
                        .Replace("{{BRANCH_NAME}}", appointment.Branch.Name)
                        .Replace("{{BRANCH_EMAIL}}", appointment.Branch.Email)
                        .Replace("{{BRANCH_PHONE}}", appointment.Branch.Phone)
                        .Replace("{{BRACH_ADDRESS}}", appointment.Branch.Address)
                        .Replace("{{APPOINTMENT_DATE}}", appointment.Date.ToString())
                        .Replace("{{APPOINTMENT_START}}", appointment.StartTime.ToString())
                        .Replace("{{APPOINTMENT_END}}", appointment.EndTime.ToString())
                        .Replace("{{APPOINTMENT_TYPE}}", appointment.Service.Name);

                    try
                    {
                        _repositoryMailer.SendEmail(subject, body, to);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Error while sending email: {error}", ex.Message);
                    }

                }
            }

            // Log that the Task finished
            _logger.LogInformation("Reminding customers finished at: {time}", DateTime.Now.ToString());
        }
    }
}
