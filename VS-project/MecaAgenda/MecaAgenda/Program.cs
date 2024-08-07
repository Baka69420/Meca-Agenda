using MecaAgenda.Infraestructure.Data;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using System.Text;
using MecaAgenda.Web.Middleware;
using MecaAgenda.Infraestructure.Repository.Interfaces;
using MecaAgenda.Infraestructure.Repository.Implementations;
using MecaAgenda.Application.Services.Interfaces;
using MecaAgenda.Application.Services.Implementations;
using MecaAgenda.Application.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// *** DEPENDENCY INJECTION ***
// Repository
builder.Services.AddTransient<IRepositoryAppointment, RepositoryAppointment>();
builder.Services.AddTransient<IRepositoryBill, RepositoryBill>();
builder.Services.AddTransient<IRepositoryBillItem, RepositoryBillItem>();
builder.Services.AddTransient<IRepositoryBranch, RepositoryBranch>();
builder.Services.AddTransient<IRepositoryBranchSchedule, RepositoryBranchSchedule>();
builder.Services.AddTransient<IRepositoryCategory, RepositoryCategory>();
builder.Services.AddTransient<IRepositoryProduct, RepositoryProduct>();
builder.Services.AddTransient<IRepositoryScheduleException, RepositoryScheduleException>();
builder.Services.AddTransient<IRepositoryService, RepositoryService>();
builder.Services.AddTransient<IRepositoryUser, RepositoryUser>();

builder.Services.AddTransient<IRepositoryMailer, RepositoryMailer>();

// Services
builder.Services.AddTransient<IServiceAppointment, ServiceAppointment>();
builder.Services.AddTransient<IServiceBill, ServiceBill>();
builder.Services.AddTransient<IServiceBillItem, ServiceBillItem>();
builder.Services.AddTransient<IServiceBranch, ServiceBranch>();
builder.Services.AddTransient<IServiceBranchSchedule, ServiceBranchSchedule>();
builder.Services.AddTransient<IServiceCategory, ServiceCategory>();
builder.Services.AddTransient<IServiceProduct, ServiceProduct>();
builder.Services.AddTransient<IServiceScheduleException, ServiceScheduleException>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IServiceUser, ServiceUser>();

// AutoMapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<AppointmentProfile>();
    config.AddProfile<BillItemProfile>();
    config.AddProfile<BillProfile>();
    config.AddProfile<BranchProfile>();
    config.AddProfile<BranchScheduleProfile>();
    config.AddProfile<CategoryProfile>();
    config.AddProfile<ProductProfile>();
    config.AddProfile<ScheduleExceptionProfile>();
    config.AddProfile<ServiceProfile>();
    config.AddProfile<UserProfile>();
});

// SQL DB Connection
builder.Services.AddDbContext<MecaAgendaContext>(options =>
{
    // Read from appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDataBase"));

    // Enable sensitive datalogging if in dev
    if(builder.Environment.IsDevelopment()) options.EnableSensitiveDataLogging();
});

// *** INCLUDE SERILOG ***
var logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Error).Enrich.FromLogContext()
    .WriteTo.Console(LogEventLevel.Information)
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
        .WriteTo.File(@"Logs\Info-.log", shared: true, encoding:Encoding.ASCII, rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug)
        .WriteTo.File(@"Logs\Debug-.log", shared: true, encoding: System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning)
        .WriteTo.File(@"Logs\Warning-.log", shared: true, encoding: System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
        .WriteTo.File(@"Logs\Error-.log", shared: true, encoding: Encoding.ASCII, rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal)
        .WriteTo.File(@"Logs\Fatal-.log", shared: true, encoding: Encoding.ASCII, rollingInterval: RollingInterval.Day))
    .CreateLogger();

builder.Host.UseSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // Error control Middleware
    app.UseMiddleware<ErrorHandlingMiddleware>();
}

// Active Serilog logging
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Activate Antiforgery
app.UseAntiforgery();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
