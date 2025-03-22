using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPresencesProfesseursISI
{
    internal class EmailTemplate
    {
        public static string GenerateEmailSubject()
        {
            return "Nouvelle programmation de cours - ISI";
        }
        public static string GenerateEmailSubjectAddcours()
        {
            return "Bienvenue à ISI - Votre compte a été créé avec succès";
        }
        public static string GenerateEmailSubjectEmargementEnAttente()
        {
            return "Émargement en attente de validation - ISI";
        }
        public static string GenerateEmailSubjectEmargementValide()
        {
            return "Émargement validé avec succés - ISI";
        }
        public static string GenerateEmailBody(string fullName, string email)
        {
            return $@"
                    <html>
                    <head>
                        <style>
                            body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                            .container {{ max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px; }}
                            .header {{ font-size: 24px; color: #0056b3; margin-bottom: 20px; }}
                            .footer {{ margin-top: 20px; font-size: 12px; color: #777; }}
                            a {{ color: #0056b3; text-decoration: none; }}
                            a:hover {{ text-decoration: underline; }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <div class='header'>Bienvenue à ISI</div>
                            <p>Bonjour {fullName},</p>
                            <p>Votre compte a été créé avec succès sur notre plateforme. Voici vos informations de connexion :</p>
                            <ul>
                                <li><strong>Email :</strong> {email}</li>
                                <li><strong>Mot de passe temporaire :</strong> <b>passer</b></li>
                            </ul>
                            <p>Pour accéder à votre compte, veuillez accédé à notre application ISI ProfControl</p>
                            <p>Nous vous recommandons de changer votre mot de passe temporaire dès votre première connexion.</p>
                            <p>Si vous avez des questions ou besoin d'assistance, n'hésitez pas à nous contacter à l'adresse ISIedusup@gmail.com</p>
                            <div class='footer'>
                                Cordialement,<br>
                                 Admin-ISI<br>
                                Tél : +33 1 23 45 67 89
                            </div>
                        </div>
                    </body>
                    </html>";
        }

        public static string GenerateEmailBodyAddCours(string fullName, string nomCours, string salle, string heureDebut, string heureFin)
        {
            return $@"
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                    .container {{ max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px; }}
                    .header {{ font-size: 24px; color: #0056b3; margin-bottom: 20px; }}
                    .footer {{ margin-top: 20px; font-size: 12px; color: #777; }}
                    a {{ color: #0056b3; text-decoration: none; }}
                    a:hover {{ text-decoration: underline; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>Nouveau cours programmé</div>
                    <p>Bonjour {fullName},</p>
                    <p>Un nouveau cours a été ajouté à votre emploi du temps.</p>
                    <ul>
                        <li><strong>Cours :</strong> {nomCours}</li>
                        <li><strong>Salle :</strong> {salle}</li>
                        <li><strong>Heure :</strong> {heureDebut} - {heureFin}</li>
                    </ul>
                    <p>Merci de vérifier votre emploi du temps et de nous signaler toute anomalie.</p>
                    <p>Pour toute question, veuillez nous contacter à l'adresse ISIedusup@gmail.com</p>
                    <div class='footer'>
                        Cordialement,<br>
                        Admin-ISI<br>
                        Tél : +33 1 23 45 67 89
                    </div>
                </div>
            </body>
            </html>";
        }

        public static string GenerateEmailBodyEmargementEnAttente(string fullName, string nomCours, string salle, string heureDebut, string heureFin)
        {
            return $@"
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                    .container {{ max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px; }}
                    .header {{ font-size: 24px; color: #0056b3; margin-bottom: 20px; }}
                    .footer {{ margin-top: 20px; font-size: 12px; color: #777; }}
                    a {{ color: #0056b3; text-decoration: none; }}
                    a:hover {{ text-decoration: underline; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>Émargement en attente de validation</div>
                    <p>Bonjour {fullName},</p>
                    <p>Votre émargement pour le cours suivant est en attente de validation :</p>
                    <ul>
                        <li><strong>Cours :</strong> {nomCours}</li>
                        <li><strong>Salle :</strong> {salle}</li>
                        <li><strong>Heure :</strong> {heureDebut} - {heureFin}</li>
                    </ul>
                    <p>Vous serez informé une fois que votre émargement aura été validé.</p>
                    <p>Pour toute question, veuillez nous contacter à l'adresse ISIedusup@gmail.com</p>
                    <div class='footer'>
                        Cordialement,<br>
                        Admin-ISI<br>
                        Tél : +33 1 23 45 67 89
                    </div>
                </div>
            </body>
            </html>";
        }
        public static string GenerateEmailBodyEmargementValide(string fullName, string nomCours, string salle, string heureDebut, string heureFin)
        {
            return $@"
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
                    .container {{ max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px; }}
                    .header {{ font-size: 24px; color: #0056b3; margin-bottom: 20px; }}
                    .footer {{ margin-top: 20px; font-size: 12px; color: #777; }}
                    a {{ color: #0056b3; text-decoration: none; }}
                    a:hover {{ text-decoration: underline; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <div class='header'>Émargement validé avec succés</div>
                    <p>Bonjour {fullName},</p>
                    <p>Votre émargement pour le cours suivant à été validé avec succés:</p>
                    <ul>
                        <li><strong>Cours :</strong> {nomCours}</li>
                        <li><strong>Salle :</strong> {salle}</li>
                        <li><strong>Heure :</strong> {heureDebut} - {heureFin}</li>
                    </ul>
                    <p>Merci de votre engament à l'endroit de notre institut.</p>
                    <p>Pour toute question, veuillez nous contacter à l'adresse ISIedusup@gmail.com</p>
                    <div class='footer'>
                        Cordialement,<br>
                        Admin-ISI<br>
                        Tél : +33 1 23 45 67 89
                    </div>
                </div>
            </body>
            </html>";
        }


    }
}
