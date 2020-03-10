using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringGenie.Api.Services.Emails
{
    public interface IEmailsService
    {
        Task SendEmailAsync(string[] to, string from, string subject, string body, 
            bool isHTML = false, string[] cc = null, string attachmentAddress = null);
    }
}
