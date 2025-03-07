using System.Net;
using System.Net.Mail;

namespace Aula03Blog.Services;

public class EmailService {
    public bool Send(
        string toName,
        string toEmail,
        string subject,
        string body,
        string fromName = "Equipe Balta.io",
        string fromEmail = "gabrielfl1997@gmail.com") //para colocar esse Email aqui eu precisei ir em "https://app.sendgrid.com/settings/sender_auth"
                                                      //e logo após clicar no botão "Verify a Single Sender" em "Single Sender Verification" e logo em seguida preencher o
                                                      //formulario com as informações do Email que esta sendo enviado o campo "from email address" e "verify to"
                                                      //posso colocar o mesmo Email que no meu caso seria o "gabrielfl1997@gmail.com"
        {
        var smtpClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port);
        smtpClient.Credentials = new NetworkCredential(Configuration.Smtp.Username, Configuration.Smtp.Password);
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;

        var mail = new MailMessage();

        mail.From = new MailAddress(fromEmail, fromName);
        mail.To.Add(new MailAddress(toEmail, toName));
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = true; // isso habilita que eu consiga mandar código html

        try {
            smtpClient.Send(mail);
            return true;
        }
        catch (Exception e) {
            return false;
        }
    }
}