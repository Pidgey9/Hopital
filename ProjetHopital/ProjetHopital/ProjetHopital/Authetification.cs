using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestions
{
    class Authentification
    {
        private string login;
        private string password;
        private string nom;
        private int metier;
        public Authentification(string login, string password, string nom, int metier)
        {
            this.login = login;
            this.password = password;
            this.nom = nom;
            this.metier = metier;
        }
    }
}
