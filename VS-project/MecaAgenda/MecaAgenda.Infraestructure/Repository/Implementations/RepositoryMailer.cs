using MecaAgenda.Infraestructure.Repository.Interfaces;
using System.Net.Mail;
using System.Net;

namespace MecaAgenda.Infraestructure.Repository.Implementations
{
    public class RepositoryMailer : IRepositoryMailer
    {
        private readonly string fromEmail = "tbot69420@gmail.com";
        private readonly string emailPass = "xpkh xtvk egif oeup";

        public void SendEmail(string subject, string body, List<string> to)
        {
            if (fromEmail == null || emailPass == null)
            {
                throw new Exception("Sender Credentials not found");
            }
            
            if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(subject) || to.Count <= 0)
            {
                throw new Exception("Email information missing");
            }

            MailMessage message = new MailMessage();

            message.IsBodyHtml = true;
            message.Subject = subject;
            message.Body = body;
            message.From = new MailAddress(fromEmail);
            to.ForEach(x => message.To.Add(x));

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(fromEmail, emailPass);
            smtp.EnableSsl = true;

            smtp.Send(message);
        }
    }
}
