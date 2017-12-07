using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace Team4Talent
{
    public class email
    {
        //Maak variabelen aan om te gebruiken
        private string tmpFrom = "t4t.dvh@gmail.com";
        public string tmpTo;
        private string tmpCC;
        private string tmpBCC;
        private string tmpSubject = "Bevestiging bestelling";
        private string tmpBody;
        public string tmpOrder;

        public void SendMessage(string tTo, string tnaam, string tOrder)
        {
            //email van HTML overgeven naar Email service
            tmpTo = tTo;
            //opmaak email
            tmpBody = "Beste " + tnaam + ", " + " uw bestelling is geplaatst. " + tOrder;
            SendMailMessage(tmpFrom, tmpTo, tmpCC, tmpBCC, tmpSubject, tmpBody, true);
        }
        private static void SendMailMessage(string from, string to, string cc, string bcc, string subject, string body, bool isHTML)
        {
            MailMessage tMailMessage = new MailMessage();

            tMailMessage.From = (new MailAddress(from));
            tMailMessage.To.Add(new MailAddress(to));
            if (cc != null && cc != "")
                tMailMessage.CC.Add(new MailAddress(cc));
            if (bcc != null && bcc != "")
                tMailMessage.Bcc.Add(new MailAddress(bcc));
            tMailMessage.Subject = subject;
            tMailMessage.Body = body;
            tMailMessage.IsBodyHtml = isHTML;

            tMailMessage.Priority = MailPriority.Normal;
            tMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            tMailMessage.BodyEncoding = System.Text.Encoding.UTF8;

            SmtpClient tSmtpClient = new SmtpClient("smtp.gmail.com", 587);
            tSmtpClient.EnableSsl = true;
            tSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            tSmtpClient.UseDefaultCredentials = false;
            tSmtpClient.Credentials = new System.Net.NetworkCredential("t4t.dvh@gmail.com", "Team4Talent");
            tSmtpClient.Send(tMailMessage);
        }

        private void clearAll()
        {
        }
    }
}