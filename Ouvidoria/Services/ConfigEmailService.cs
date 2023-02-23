using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Ouvidoria.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ouvidoria.Services
{
    public class ConfigEmailService : IConfigEmail
    {
        private readonly IConfiguration _configuration;
        public ConfigEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            try
            {
                var smtpServer = _configuration.GetValue<string>("Email:SmtpServer");
                var smtpPort = _configuration.GetValue<int>("Email:SmtpPort");
                var smtpPassword = _configuration.GetValue<string>("Email:Senha");
                var senderEmail = _configuration.GetValue<string>("Email:E-mail");

                using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(senderEmail, smtpPassword);
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(senderEmail, "OuvidoriaUGB"),
                        Subject = assunto,
                        Body = mensagem
                    };
                    mailMessage.To.Add(destinatario);

                    await smtpClient.SendMailAsync(mailMessage);
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
