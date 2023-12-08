using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestions
{
    public class Salle
    {
        private List<Visite> listeVisites = new List<Visite>();
        private Hopital h = Hopital.Instance;
        private int visitesMax = 5;
        public Salle()
        {

        }
        public void Add(Visite v)
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
    }
}
