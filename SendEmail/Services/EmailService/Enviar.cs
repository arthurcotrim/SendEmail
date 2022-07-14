using SendEmail.Model;
using System.Net;
using System.Net.Mail;

namespace SendEmail.Services.EmailService
{
    public class Enviar
    {
        public async Task<string> SendEmail(Email? email)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            if (email == null) return "Dados incorretos. Tente novamente";

            message.From = new MailAddress("from", "from name");
            message.To.Add(new MailAddress(email.To, email.ToName));
            message.Subject = email.Subject;
            message.IsBodyHtml = true;
            message.Body = email.Body;

            smtp.Port = 587;
            smtp.Host = "";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("email login", "email pwd");

            try
            {
                smtp.Send(message);
                return "Email enviado com sucesso";
            }
            catch (Exception e)
            {
                return "Erro: <b>" + e.Message + "</b> " + e.InnerException?.Message;
            }
        }
    }
}