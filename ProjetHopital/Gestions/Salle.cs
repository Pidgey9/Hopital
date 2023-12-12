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
        private List<Visites> listeVisites = new List<Visites>();
        private Hopital h = Hopital.Instance;
        private int visitesMax = 5;
        private int num;
        private string medecin;
        private int tarif;
        private bool isDispo = true;
        public Salle()
        {

        }
        public void Add(Visites v)
        {
            for (int i = 0; i < listeVisites.Count + 1; i++)
            {
                if (listeVisites[i] == null)
                {
                    listeVisites[i] = v;
                    break;
                }
            }
            if (listeVisites.Count >= visitesMax)
            {
                listeVisites.Clear();
            }
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
        public bool IsDispo
        {
            get
            {
                return isDispo;
            }
        }
    }
}
