using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System;
using MailKit.Security;

namespace HondaDealership.Pages
{
    public class SuccessModel : PageModel
    {
        public string exception = "";
        public string customersEmail = CheckOutModel.setValueForEmail;

        public void OnGet()
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("Tester", "devseanmcpadden@yahoo.com"));

            message.To.Add(MailboxAddress.Parse(customersEmail));

            message.Subject = "Thank you for your purchase.";

            message.Body = new TextPart("Plain")
            {
                Text = @"Thank you for your order.
                         Your order has been recieved and we are happily
                         proccessing your order to get it to you as soon as
                         we can."
            };

            string emailAddress = "devseanmcpadden@yahoo.com";
            string password = "IWillTryNotToForget";

            SmtpClient client = new SmtpClient();
            //using SmtpClient client = new ProtocolLogger("smtp.log");
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;


            try
            {

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                //client.Connect("smtp.mail.yahoo.com", 465, true);
                client.Connect("smtp.mail.yahoo.com", 587, SecureSocketOptions.StartTls);

                client.Authenticate(emailAddress, password);
                client.Send(message);
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
            finally
            {
                client.Disconnect(true);

                client.Dispose();
            }
        }
    }
}
