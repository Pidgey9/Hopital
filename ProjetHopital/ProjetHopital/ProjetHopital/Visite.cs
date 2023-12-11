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
        public Visite()
        {

        }

        public int Id
        {
            get
            {
                return id;
            }
        }
        public int IdPatient
        {
            get
            {
                return idPatient;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
        }
        public string Medecin
        {
            get
            {
                return medecin;
            }
        }
        public int NumSalle
        {
            get
            {
                return numSalle;
            }
        }
        public int Tarif
        {
            get
            {
                return tarif;
            }
        }


    }
}
