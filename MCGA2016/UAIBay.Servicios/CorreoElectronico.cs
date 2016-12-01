using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace UAIBay.Servicios
{
   public class CorreoElectronico
    {
        public static void Bienvenida(string e, string nombre)
        {
            MailMessage msj = new MailMessage();
            SmtpClient cli = new SmtpClient();

            String email = e;

            msj.From = new MailAddress(e);
            msj.To.Add(new MailAddress(e));
            msj.Subject = "¡Bienvenido a UAIBay " + nombre + "!";
            msj.Body = "A partir de ahora podrás comenzar a utilizar todas las funcionalidades de la página. Esperamos que disfrutes de la gran variedad de productos que tenemos para tí.";
            msj.IsBodyHtml = false;

            cli.Host = "smtp.gmail.com";
            cli.Port = 587;
            cli.Credentials = new NetworkCredential("uaibooklppa@gmail.com", "lppa2016");
            cli.EnableSsl = true;
            cli.Send(msj);
        }

        public static void EnviarCorreo(string e, string n, string mensaje, string asunto)
        {
            MailMessage msj = new MailMessage();
            SmtpClient cli = new SmtpClient();

            String email = e;
            String name = n;

            msj.From = new MailAddress("uaibooklppa@gmail.com");
            msj.To.Add(new MailAddress("uaibooklppa@gmail.com"));
            msj.Subject = "Asunto: " + asunto + " - " + n + " - " + e;
            msj.Body = mensaje;
            msj.IsBodyHtml = false;

            cli.Host = "smtp.gmail.com";
            cli.Port = 587;
            cli.Credentials = new NetworkCredential("uaibooklppa@gmail.com", "lppa2016");
            cli.EnableSsl = true; cli.Send(msj);
        }

        public static void RecuperarContraseña(string e, string newpw)
        {
            MailMessage msj = new MailMessage();
            SmtpClient cli = new SmtpClient();

            String email = e;

            msj.From = new MailAddress(e);
            msj.To.Add(new MailAddress(e));
            msj.Subject = "Contraseña provisoria";
            msj.Body = "Por favor utilice la siguiente password provisoria para ingresar al sistema: " + newpw;
            msj.IsBodyHtml = false;

            cli.Host = "smtp.gmail.com";
            cli.Port = 587;
            cli.Credentials = new NetworkCredential("uaibooklppa@gmail.com", "lppa2016");
            cli.EnableSsl = true; cli.Send(msj);
        }
    }
}
