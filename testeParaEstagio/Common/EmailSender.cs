using System.Net;
using System.Net.Mail;

namespace Controllers.Common
{
    public class EmailSender
    {
        public void EnviarEmail(string assunto, string corpo, string toEmail)
        {
            //dispara email
            var fromEmail = "robertpaulson241@zohomail.com";
            var fromPassword = "Paulson241@";
            var fromHost = "smtp.zoho.com";
            var fromPort = 587;

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(fromEmail);

            mail.To.Add(new MailAddress(toEmail));

            mail.Subject = assunto;

            mail.Body = corpo;

            using (SmtpClient smtp = new SmtpClient(fromHost, fromPort))
            {
                smtp.UseDefaultCredentials = false;
                
                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);

                smtp.EnableSsl = true;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(mail);
            }          
        }
    }
}