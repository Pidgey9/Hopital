using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestions
{
    public class Hopital
    {
        private static Hopital instance = null;
        private Queue<Patients> fileAttente = new Queue<Patients>();
        private Hopital()
        {

        }
        public void Add(Patients p)
        {
            fileAttente.Enqueue(p);
        }
        public Patients Remove()
        {
            return fileAttente.Dequeue();
        }
        public Patients Next()
        {
            return fileAttente.Peek();
        }
        public string CheckQueue()
        {
            string result = "";
            foreach (Patients p in fileAttente)
            {
                result += p.Id + "\t" + p.Nom + "\t" + p.Prenom + "\t" + p.Age + "\t" + p.Adresse + "\t" + p.Telephone + "\n";
            }
            return result;
        }
        public void Notif()
        {
            Remove();
        }
        public static Hopital Instance
        {
            get
            {
                if (instance == null)
                    instance = new Hopital();
                return instance;
            }
        }
    }
}
