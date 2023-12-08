using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestions
{
    public class Visite
    {
        private int id;
        private int idPatient;
        private DateTime date;
        private string medecin;
        private int numSalle;
        private int tarif;
        public Visite(int id, int idPatient, DateTime date, string medecin, int numSalle, int tarif)
        {
            this.id = id;
            this.idPatient = idPatient;
            this.date = date;
            this.medecin = medecin;
            this.numSalle = numSalle;
            this.tarif = tarif;
        }
    }
}
