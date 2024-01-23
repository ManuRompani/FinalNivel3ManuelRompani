using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Email
    {
        private SmtpClient server;
        private MailMessage mail;

        public Email()
        {
            this.server = new SmtpClient("smtp.gmail.com");
            this.server.Credentials = new NetworkCredential("", "");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void crearCorreo(string correo, string mensaje, string titulo)
        {
            mail = new MailMessage();
            mail.From = new MailAddress("");
            mail.To.Add(correo);
            mail.Subject = titulo;
            mail.IsBodyHtml = true;
            mail.Body = "<h1>" + titulo + "</h1><p>" + mensaje + "</p>";

        }

        public void enviarCorreo()
        {
            try
            {
                server.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
