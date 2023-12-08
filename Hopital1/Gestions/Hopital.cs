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
        private Queue<Patient> fileAttente = new Queue<Patient>();
        private Hopital()
        {

        }
        public void Add(Patient p)
        {
            fileAttente.Enqueue(p);
        }
        public Patient Remove()
        {
            return fileAttente.Dequeue();
        }
        public string CheckQueue()
        {
            string result = "";
            foreach(Patient p in fileAttente)
            {
                result += "x";
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
        public void TestStr()
        {
            Console.WriteLine("je teste");
        }
    }
}
