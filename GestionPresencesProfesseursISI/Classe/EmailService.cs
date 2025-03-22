using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPresencesProfesseursISI
{
    internal class EmailService
    {
        private const string SmtpServer = "in-v3.mailjet.com";
        private const int SmtpPort = 587;
        private const string SmtpUsername = "f4dfe8514f40b252a6cd2c9eb6a78084"; // Remplacez par votre clé API Mailjet
        private const string SmtpPassword = "7a0a7e12f4e9c534b21593d284ed3a0b"; // Remplacez par votre clé secrète 

        public static void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                // Configuration SMTP
                using (var smtpClient = new SmtpClient(SmtpServer, SmtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
                    smtpClient.EnableSsl = true;

                    // Création du message
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("ISIedusup@gmail.com"), // Remplacez par l'e-mail de l'expéditeur
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(toEmail);

                    // Envoi de l'e-mail
                    smtpClient.Send(mailMessage);

                    Console.WriteLine("E-mail envoyé avec succès !");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'envoi de l'e-mail : " + ex.Message);
            }
        }
    }
}



