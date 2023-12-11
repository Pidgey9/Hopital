using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestions
{
    public class Patient
    {
        private int id;
        private string nom;
        private string prenom;
        private string adresse;
        private string telephone;

        public Patient(/*int id,*/ string nom, string prenom, string adresse, string telephone)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.telephone = telephone;
        }
    }
}
