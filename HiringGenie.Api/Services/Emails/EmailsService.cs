using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Emails
{
    public class EmailsService : IEmailsService
    {
        private readonly IConfiguration _configuration;
        public EmailsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string[] to, string from, string subject, string body, 
            bool isHTML = false, string[] cc = null, string attachmentAddress = null)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(from);
            foreach(var address in to)
            {
                mail.To.Add(address);
            }

            if (cc.Length > 0)
            {
                foreach (var address in cc)
                {
                    mail.CC.Add(address);
                }
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isHTML;

            if (!string.IsNullOrEmpty(attachmentAddress))
            {
                // read file from address
                //var item = new Attachment();
                //mail.Attachments.Add(item);
            }

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]);
            SmtpServer.EnableSsl = true;

            await SmtpServer.SendMailAsync(mail);
        }
    }
}
