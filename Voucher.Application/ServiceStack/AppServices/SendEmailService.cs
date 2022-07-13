using Voucher.Application.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;

namespace Voucher.Application.ServiceStack.AppServices
{

    public class SendEmailService : ISendEmailService
    {
        //private readonly IAccommodationVoucherAppService _repo;
        private readonly VoucherContext _context;
        public SendEmailService(VoucherContext context /*IAccommodationVoucherAppService repo*/)
        {
            //_repo = repo;
            _context = context;
        }

        public void SendEmail(SendEmailRequest request)
        {

            //string from = request.from;
            //string fromName = request.fromName;
            //string to = request.to;
            //string toName = request.toName;
            //string subject = request.subject;
            //string body = request.body;
            //string password = request.password;
            //string user = request.user;
            //string mailServer = request.mailServer;
            //int port = request.port;

            //from = "ocaedu3@gmail.com";
            //fromName = "Voe Junto";
            //to = "karlos_ap@yahoo.com.br";
            //toName = "Carlos";
            //subject = "Test Subject";
            //password = "60602612";
            //user = "ocaedu3@gmail.com";
            //mailServer = "smtp.gmail.com";
            //port = 587;

            //AccommodationVoucher voucher = new AccommodationVoucher();
            ////{
            ////    DailyAmount = 1,
            ////    IsActive = 1,
            ////    CanceledBy = "",
            ////    CanceledDate = DateTime.Now,
            ////    CreatedBy = "Carlos",
            ////    CreatedDate = DateTime.Now,
            ////    Discriminator = ""
            ////}

            //voucher = _context.accommodationVouchers.Find(25);

            //body = _repo.AcomodationEmail(voucher);
            //body = body + "<img src=http://wstrackingssr.voegol.com.br/Images/imgpsh_fullsize.png>";


            //var message = new MimeMessage();
            //var bodyBuilder = new BodyBuilder();

            //// from
            //message.From.Add(new MailboxAddress(fromName, from));
            //// to
            //message.To.Add(new MailboxAddress(toName, to));
            //// reply to
            ////message.ReplyTo.Add(new MailboxAddress("reply_name", "reply_email@example.com"));

            //message.Subject = subject;
            //bodyBuilder.HtmlBody = body;
            //message.Body = bodyBuilder.ToMessageBody();

            //var client = new SmtpClient();

            ////client.Connect(mailServer, 587, SecureSocketOptions.SslOnConnect);
            //client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            //client.Connect(mailServer, port, false);
            //client.Authenticate(user, password);
            //client.Send(message);
            //client.Disconnect(true);
        }

        public string creatBody()
        {
            //_context.AccommodationProviderSpecialServices
            return "Teste";
        }
    }
}
