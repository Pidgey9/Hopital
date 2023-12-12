using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestions;
using Dao;

namespace TestBDD
{
    class Program
    {
        static void Main(string[] args)
        {
            TestL();
        }
        static void TestL()
        {
            Salle salle = new Salle();
            Console.WriteLine(salle.listeVisites.Count);
            Console.WriteLine(salle.listeVisites.Capacity);
            salle.listeVisites.Add(new Visites(1, DateTime.Now, "a", 1, 1));
            Console.WriteLine(salle.listeVisites.Count);
            Console.WriteLine(salle.listeVisites.Capacity);
            Console.WriteLine(salle.listeVisites[0]);

        }
        static void TestQ()
        {
            Hopital h = Hopital.Instance;
            Patients p1 = new Patients(1, "a", "b", 5, "c", "d");
            Patients p2 = new Patients(2, "a", "b", 5, "c", "d");

            h.Add(p1);
            h.Add(p2);
            Console.WriteLine(h.CheckQueue());
        }
        static void TestDeleteA()
        {
            DaoAuthentification daoP = new DaoAuthentification();
            daoP.Delete("a");

        }

        static void TestUpdateA()
        {
            DaoAuthentification daoP = new DaoAuthentification();
            Authentification a = new Authentification("a", "x", "y", 69);
            daoP.Update(a);

        }

        static void TestSelectAllA()
        {
            DaoAuthentification daoP = new DaoAuthentification();
            List<Authentification> liste = daoP.SelectAll();
            foreach (Authentification a in liste)
                Console.WriteLine(a.Login + "\t" + a.Password + "\t" + a.Nom + "\t" + a.Metier);


        }

        static void TestSelectByIdA()
        {
            DaoAuthentification daoP = new DaoAuthentification();

            Authentification a = daoP.SelectByLogin("a");
            Console.WriteLine(a.Login + "\t" + a.Password + "\t" + a.Nom + "\t" + a.Metier);

        }

        static void TestInsertA()
        {
            DaoAuthentification daoV = new DaoAuthentification();
            Authentification a = new Authentification("m", "b", "c", 1);
            daoV.Insert(a);

        }

        static void TestDeleteV()
        {
            DaoVisites daoP = new DaoVisites();
            daoP.Delete(1);

        }

        static void TestUpdateV()
        {
            DaoVisites daoP = new DaoVisites();
            Visites p = new Visites(1, 8, DateTime.Now, "bbb", 50, 150);
            daoP.Update(p);

        }

        static void TestSelectAllV()
        {
            DaoVisites daoP = new DaoVisites();
            List<Visites> liste = daoP.SelectAll();
            foreach (Visites p in liste)
                Console.WriteLine(p.Id + "\t" + p.IdPatient + "\t" + p.Date + "\t" + p.Medecin + "\t" + p.Tarif);


        }

        static void TestSelectByIdV()
        {
            DaoVisites daoP = new DaoVisites();

            Visites p = daoP.SelectById(1);
            Console.WriteLine(p.Id + "\t" + p.IdPatient + "\t" + p.Date + "\t" + p.Medecin + "\t" + p.Tarif);

        }

        static void TestInsertV()
        {
            DaoVisites daoV = new DaoVisites();
            Visites v = new Visites(1, DateTime.Now, "aaa", 5, 25);
            daoV.Insert(v);

        }

        static void TestInsert()
        {
            DaoPatients daoP = new DaoPatients();
            Patients p = new Patients(1, "coco", "titi", 50, "kek", "W");
            daoP.Insert(p);

        }


        static void TestDelete()
        {
            DaoPatients daoP = new DaoPatients();
            daoP.Delete(8);

        }

        static void TestUpdate()
        {
            DaoPatients daoP = new DaoPatients();
            Patients p = new Patients(8, "coco", "titi", 50, "kek", "W");
            daoP.Update(p);

        }

        static void Test2()
        {
            Console.WriteLine("hello");
        }
        static void TestSelect()
        {
            Patients p1 = new Patients(5, "dupond", "toto", 25, "aaa", "bbb");
            Patients p2 = new Patients(8, "dupond", "toto", 25, "aaa", "bbb");

            DaoPatients daoP = new DaoPatients();
            List<Patients> liste = daoP.SelectAll();
            foreach (Patients p in liste)
                Console.WriteLine(p.Id + "\t" + p.Nom + "\t" + p.Prenom + "\t" + p.Age + "\t" + p.Adresse + "\t" + p.Telephone);
            Console.WriteLine("----------------------");
            Patients pat = daoP.SelectById(5);
            Console.WriteLine(pat.Id + "\t" + pat.Nom + "\t" + pat.Prenom + "\t" + pat.Age + "\t" + pat.Adresse + "\t" + pat.Telephone);

        }

        //static void TestFile()
        //{
        //    new TimeFile().File();
        //}
        //static void TestTime()
        //{
        //    DateTime date;
        //    date = DateTime.Now;
        //    Time t = new Time();
        //    //Console.WriteLine(DateTime.Now);
        //    t.Insert();
        //}
        //static void Test()
        //{
        //    Hopital h = Hopital.Instance;
        //Patient p1 = new Patient();
        //Patient p2 = new Patient();
        //h.Add(p1);
        //    h.Add(p2);
        //    h.Remove();
        //    Console.WriteLine(h.CheckQueue());
        //}
    }
}
