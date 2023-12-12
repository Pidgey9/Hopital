using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;

namespace Gestions
{
    public class Salle
    {
        private List<Visites> listeVisites = new List<Visites>(5);
        private Hopital h = Hopital.Instance;
        //private int visitesMax = 5;
        private int num;
        private string medecin;
        private int tarif;
        private bool isDispo = true;
        public Salle(int num, string medecin, int tarif)
        {
            this.num = num;
            this.medecin = medecin;
            this.tarif = tarif;
        }
        public void Add(Visites v)
        {
            if (listeVisites.Count >= listeVisites.Capacity)
            {
                listeVisites.Clear();
            }
            listeVisites.Add(v);
            h.Notif();
        }
        public void Clear()
        {
            DaoVisites daoV = new DaoVisites();
            for(int i = 0; i < listeVisites.Count; i++)
            {
                daoV.Insert(listeVisites[i]);
            }
            listeVisites.Clear();
        }
        public string CheckList()
        {
            string result = "";
            foreach (Visites v in listeVisites)
            {
                result += v.Id + "\t" + v.IdPatient + "\t" + v.Date + "\t" + v.Medecin + "\t" + v.NumSalle + "\t" + v.Tarif + "\n";
            }
            return result;

        }
        public bool IsDispo
        {
            get
            {
                return isDispo;
            }
        }
        public int Num
        {
            get
            {
                return num;
            }
        }
        public string Medecin
        {
            get
            {
                return medecin;
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
