using Voucher.Application.DTO;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Voucher.Application.ServiceStack.Interfaces
{
    public interface ISendEmailService
    {
        void SendEmail(SendEmailRequest request);
        //void Send(string from, string formDisplay, string to, string subject, string body);
        //void Send(string from, string formDisplay, List<string> to, string subject, string body, Attachment attachment);
        //void Send(string to, string subject, string body);
        //void Send(string subject, string body);
        //void Send(List<string> to, string subject, string body, Attachment attachment);
    }
}
