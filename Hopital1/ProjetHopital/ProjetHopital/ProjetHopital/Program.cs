using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestions;

namespace ProjetHopital
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSelectAllA();


        }
        static void TestDeleteA()
        {
            DaoAuthentification daoP = new DaoAuthentification();
            daoP.Delete("a");

        }

        static void TestUpdateA()
        {
            DaoAuthentification daoP = new DaoAuthentification();
            Authentification a = new Authentification("a", "x" , "y", 69);
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
            Authentification a = new Authentification("z", "b", "c", 2);
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
            Visites p = new Visites(1, 8, "aaa", "bbb", 50, 150);
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
            Visites v = new Visites(1, DateTime.Now.ToString(), "aaa", 5, 25);
            daoV.Insert(v);

        }

        static void TestInsert()
        {
            DaoPatients daoP = new DaoPatients();
            Patients p = new Patients(11, "coco", "titi", 50, "kek", "W");
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



    }

    
}
