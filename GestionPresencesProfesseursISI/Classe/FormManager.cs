using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPresencesProfesseursISI
{
    internal class FormManager
    {
        public static FormLogin formlogin { get; set; }
        public static FormHome formhome { get; set; }
        public static FormResetRequest formResetRequest { get; set; }
        public static FormOTPVerification formtotpverification { get; set; }
        public static FormNewPassword formnewpassword { get; set; }
        public static void ShowFormLogin()
        {
            if (formlogin == null || formlogin.IsDisposed) {
                formlogin = new FormLogin();
            }
            formhome?.Hide();
            formnewpassword?.Hide();
            formResetRequest?.Hide();
            formtotpverification?.Hide();
            formlogin.Show();

        }

        public static void ShowFormHome()
        {
            if (formhome == null || formlogin.IsDisposed)
            {
                formhome = new FormHome();
            }
            formlogin?.Hide();
            formnewpassword?.Hide();
            formhome.Show();

        }

        public static void ShowFormResetRequest()
        {
            if (formResetRequest == null || formResetRequest.IsDisposed)
            {
                formResetRequest = new FormResetRequest();
            }
            formlogin?.Hide();
            formResetRequest.Show();

        }

        public static void ShowFormOTPVerification()
        {
            if (formtotpverification == null || formtotpverification.IsDisposed)
            {
                formtotpverification = new FormOTPVerification();
            }
            formResetRequest?.Hide();
            formtotpverification.Show();

        }

        public static void ShowFormNewPassword()
        {
            if (formnewpassword == null || formnewpassword.IsDisposed)
            {
                formnewpassword = new FormNewPassword();
            }
            formtotpverification?.Hide();
            formnewpassword.Show();
            formlogin?.Hide();

        }

      

    }
}
