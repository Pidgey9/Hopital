﻿using Dao;
using Gestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program

    {
        static void Main(string[] args)
        {
            TestAuthentification();

        }
        static void TestAuthentification()
        {

            Hopital hopital = Hopital.Instance;
            DaoAuthentification daoA = new DaoAuthentification();

            Console.WriteLine("---------------------Menu Principale-----------------------");
            Console.Write("Entrez votre login : ");
            string login = Console.ReadLine();


            Console.Write("Entrez votre mot de passe : ");
            string password = Console.ReadLine();

            Authentification authentifie = new Authentification(login, password);
            Authentification a = daoA.SelectByLogin(login);



            if (authentifie.Login == a.Login && authentifie.Password == a.Password)
            {
                Console.WriteLine("authentification reussi.");
                authentifie.Nom = a.Nom;
                authentifie.Metier = a.Metier;
                switch (authentifie.Metier)
                {


                    case 0:
                        afficherMenuSecretaire(hopital);
                        break;

                    case 1:
                        afficherMenuMedecin1(hopital);
                        break;
                    case 2:
                        afficherMenuMedecin2(hopital);
                        break;
                    default:
                        Console.WriteLine("Métier inconnu");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Échec de l'authentification. Accès refusé.");
                TestAuthentification();

            }



        }
        static void afficherMenuSecretaire(Hopital hopital)
        {
            DaoPatients daoP = new DaoPatients();
            DaoVisites daoV = new DaoVisites();


            int choixSec;
            do
            {
                Console.WriteLine("---------------------Menu Secrétaire-----------------------");

                Console.WriteLine("1. Rajouter un patient à la file d'attente");
                Console.WriteLine("2. Afficher l'état de la liste d'attente");
                Console.WriteLine("3. Afficher le prochain patient de la liste d'attente");
                Console.WriteLine("4. Afficher les visites d'un patient");
                Console.WriteLine("5. Mettre a jour la fiche patient avec un nouveau téléphone / adresse");
                Console.WriteLine("6. Quitter l'interface secrétaire et revenir au menu principal");

                Console.Write("Entrez votre choix : ");
                choixSec = Convert.ToInt32(Console.ReadLine());
                switch (choixSec)
                {
                    case 1:
                        // Logique pour ajouter un patient à la file d'attente
                        
                        Console.WriteLine("Entrez l'id du patient :");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Patients patient = daoP.SelectById(id);
                        if (patient != null)
                        {
                            hopital.Add(patient);

                            new TimeFile().File(patient);

                            Console.WriteLine("Le patient avec l'ID " + id + " est ajoute a la file d'attente");

                        }
                        else
                        {
                            Console.WriteLine("Aucun patient trouvé avec l'ID " + id + ".");
                            Console.Write("Entrer son nom : ");
                            string nom = Console.ReadLine();
                            Console.Write("Entrer son prénom : ");
                            string prenom = Console.ReadLine();
                            Console.Write("Entrer son âge : ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Entrer son adresse : ");
                            string adresse = Console.ReadLine();
                            Console.Write("Entrer son numéro de téléphone : ");
                            string tel = Console.ReadLine();
                            Patients p = new Patients(id, nom, prenom, age, adresse, tel);
                            daoP.Insert(p);
                            Console.WriteLine("Le patient " + id + " vient d'être insérer dans la base de donnée.");
                            hopital.Add(p);

                            new TimeFile().File(p);

                            Console.WriteLine("le patient avec l'ID " + id + " est ajoute a la file d'attente");

                        }
                        break;

                    case 2:
                        // Logique pour  Afficher l'état de la liste d'attentee
                        Console.WriteLine("l'etat de la liste d'attente " + " \n" + hopital.CheckQueue());
                        break;

                    case 3:
                        // Logique pour Afficher le prochain patient de la liste d'attente"
                        Console.WriteLine("le prochain patient est : ");
                        Patients pat = hopital.Next();
                        Console.WriteLine(pat.Id + "\t" + pat.Nom + "\t" + pat.Prenom + "\t" + pat.Age + "\t" + pat.Adresse + "\t" + pat.Telephone);
                        // il faut traiter la partie ou la file d attente est vide
                        break;

                    case 4:
                        // Logique pour Afficher les visites d'un patient
                        Console.Write("Entrez l'id du patient : ");
                        int idPatient = Convert.ToInt32(Console.ReadLine());
                        Visites v = daoV.SelectByIdPatient(idPatient);
                        if (v != null)
                            Console.WriteLine(v.Id + "\t" + v.IdPatient + "\t" + v.Date + "\t" + v.Medecin + "\t" + v.NumSalle + "\t" + v.Tarif);
                        else
                            Console.WriteLine("visite  de " + idPatient + "  introuvable");

                        break;
                    case 5:
                        // Logique pour Mettre a jour la fiche patient avec un nouveau téléphone / adresse

                        Console.Write("entrez l'id du patient : ");
                        int id2 = Convert.ToInt32(Console.ReadLine());


                        Patients patient2 = daoP.SelectById(id2);
                        Console.Write("entrez la nouvelle adresse du patient : ");
                        patient2.Adresse = Console.ReadLine();
                        Console.Write("entrez le nouveau telephone : ");
                        patient2.Telephone = Console.ReadLine();
                        daoP.Update(patient2);

                        break;
                    case 6:
                        // Logique pour Quitter l'interface secrétaire et revenir au menu principal
                        Console.WriteLine("Retour au menu principal.");
                        TestAuthentification();
                        break;
                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir à nouveau.");
                        afficherMenuSecretaire(hopital);
                        break;
                }


            } while (choixSec != 6);




        }

        static void afficherMenuMedecin1(Hopital hopital)
        {
            Salle salle1 = new Salle(1, "Dr Jacob", 50);
            int choixSec;
            do
            {
                Console.WriteLine("---------------------Menu Médecin Salle 1-----------------------");

                Console.WriteLine("1. Rendre la salle dispo");
                Console.WriteLine("2. afficher la file d attente");
                Console.WriteLine("3. sauvegarder les visites");
                Console.WriteLine("4. afficher la liste des visites");

                Console.WriteLine("5. Quitter l'interface medecin et revenir au menu principal");

                Console.Write("Entrez votre choix : ");
                choixSec = Convert.ToInt32(Console.ReadLine());
                switch (choixSec)
                {

                    case 1:
                        // Logique pour Rendre la salle dispo
                        try
                        {
                            if (salle1.IsDispo)
                            {


                                Patients p = hopital.Next();
                                Visites v1 = new Visites(p.Id, DateTime.Now, p.Nom, salle1.Num, salle1.Tarif);
                                salle1.Add(v1);

                                Console.WriteLine("la salle est dispo");
                            }
                            else
                            {
                                Console.WriteLine("la salle est occupee");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Pas de patients en attente.");
                        }


                        break;

                    case 2:
                        // Logique pour  afficher la file d attente
                        Console.WriteLine("l'etat de la liste d'attente : " + " \n" + hopital.CheckQueue());


                        break;

                    case 3:// Logique pour sauvegarder les visites
                        salle1.Clear();
                        Console.WriteLine("la liste des visites est sauvegardee  ");

                        break;
                    case 4:
                        // Logique pour afficher la liste des visites"
                        Console.WriteLine(salle1.CheckList());

                        break;

                    case 5:
                        // Logique pour Quitter l'interface medecin et revenir au menu principal"
                        Console.WriteLine("Retour au menu principal.");
                        TestAuthentification();

                        break;

                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir à nouveau.");
                        break;
                }


            } while (choixSec != 6);




        }
        static void afficherMenuMedecin2(Hopital hopital)
        {
            Salle salle2 = new Salle(2, "Dr Zukzuk", 150);
            int choixSec;
            do
            {
                Console.WriteLine("---------------------Menu Médecin Salle 2-----------------------");

                Console.WriteLine("1. Rendre la salle dispo");
                Console.WriteLine("2. afficher la file d attente");
                Console.WriteLine("3. sauvegarder les visites");
                Console.WriteLine("4. afficher la liste des visites");

                Console.WriteLine("5. Quitter l'interface medecin et revenir au menu principal");

                Console.Write("Entrez votre choix : ");
                choixSec = Convert.ToInt32(Console.ReadLine());
                switch (choixSec)
                {

                    case 1:
                        // Logique pour Rendre la salle dispo
                        try
                        {
                            if (salle2.IsDispo)
                            {


                                Patients p = hopital.Next();
                                Visites v1 = new Visites(p.Id, DateTime.Now, p.Nom, salle2.Num, salle2.Tarif);
                                salle2.Add(v1);

                                Console.WriteLine("la salle est dispo");
                            }
                            else
                            {
                                Console.WriteLine("la salle est occupee");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Pas de patients en attente.");
                        }


                        break;

                    case 2:
                        // Logique pour  afficher la file d attente
                        Console.WriteLine("l'etat de la liste d'attente : " + " \n" + hopital.CheckQueue());


                        break;

                    case 3:// Logique pour sauvegarder les visites
                        salle2.Clear();
                        Console.WriteLine("la liste des visites est sauvegardee  ");

                        break;
                    case 4:
                        // Logique pour afficher la liste des visites"
                        Console.WriteLine(salle2.CheckList());

                        break;

                    case 5:
                        // Logique pour Quitter l'interface medecin et revenir au menu principal"
                        Console.WriteLine("Retour au menu principal.");
                        TestAuthentification();

                        break;

                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir à nouveau.");
                        break;
                }


            } while (choixSec != 6);

        }





    }
}
