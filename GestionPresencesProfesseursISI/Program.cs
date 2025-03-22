using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPresencesProfesseursISI
{
    internal static class Program
    {

        // Active la gestion avancée du DPI pour un affichage net
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(int awareness);

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (Environment.OSVersion.Version.Major >= 6)
            {
                try
                {
                    SetProcessDpiAwareness(2); // Per Monitor v2 (meilleure gestion des écrans multiples)
                }
                catch
                {
                    SetProcessDPIAware(); // Fallback pour les versions plus anciennes de Windows
                }
            }

            Application.EnableVisualStyles();
            SplashScreenForm splashScreenForm = new SplashScreenForm();
            splashScreenForm.ShowDialog();
            FormManager.formlogin = new FormLogin();
            Application.Run(FormManager.formlogin);
        }
    }
}
