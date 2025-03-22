using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPresencesProfesseursISI
{
    internal class Users
    {
        public Users() { }
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //propriété calculé
        public string FullName => $"{Prenom} {Nom}";
       
       
    }



}
