﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using packTrolls;

namespace ProfiTrolls
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Facade.InitialiserJeuVide();
            bool fin = false;
            while ( ! fin )
            {
                
                // affichage du menu
                Menu();
                // saisie choix
                int choix = LireEntier();
				int idP,idA;
                switch (choix)
                {
                    case 0:                
                            Facade.CreerJeuDEssai();
                            break;

                    case 1: //Lister ts les personnages (desc courte)
							Console.WriteLine("{0,-4}{1,-4}{2,-10}{3,-6}{4,-6}{5,-16}{6,-8}",
                                              "id", "nom", "type", "force", "vie",
                                              "taille/fctn", "nbarmes");
                            Console.Write("========================================");
                            Console.WriteLine("==========================");
                            foreach (string p in Facade.AfficherTsPersonnagesDC())
                            {
                                Console.WriteLine(p);
                            }
                            break;
                  
                     case 2: 
                             Console.Write("id du personnage ? ");
                             int idPers = LireEntier();
                             try
                             {
                                 Console.WriteLine("{0,-4}{1,-4}{2,-10}{3,-6}{4,-6}{5,-16}{6,-8}",
                                                   "id", "nom", "type", "force", "vie",
                                                   "taille/fctn", "nbarmes");
                                 Console.Write("========================================");
                                 Console.WriteLine("==========================");
                                 Console.WriteLine(Facade.AfficherPersonnageDD(idPers));
                             }
                             catch (ArgumentOutOfRangeException a)
                             {
                                 Console.WriteLine(a.Message);
                                 throw;
                             }
                             break;
                           
                     case 3: // Lister ts les personnages (desc détaillée)
                             Console.WriteLine("{0,-4}{1,-4}{2,-10}{3,-6}{4,-6}{5,-16}{6,-8}",
                                               "id", "nom", "type", "force", "vie",
                                               "taille/fctn", "nbarmes");
                             Console.Write("========================================");
                             Console.WriteLine("==========================");
                             foreach (string p in Facade.AfficherTsPersonnagesDD())
                             {
                                 Console.WriteLine(p);
                             }
                             break;		
                    
                    
                     case 4: // Créer un Troll
                             Console.Write("Nom du troll ? ");
                             string nomt = Console.ReadLine();
                             Console.Write("Taille ? ");
                             int taille = LireEntier(); 
                             Console.Write("Force ? ");
                             int force =  LireEntier();
                             Troll t=Facade.AjouterTroll(nomt, taille, force); 
                             Console.WriteLine("Creation du troll:\n {0}", t.PresentationCourte());
                             break;

                     case 5:   // Créer un Chasseur
                             Console.Write("Nom du chasseur? ");
                             string nomc = Console.ReadLine();
                             Console.Write("Fonction ? ");
                             string fonction = Console.ReadLine();
                             Chasseur c = Facade.AjouterChasseur(nomc, fonction);
                             Console.WriteLine("Creation du chasseur:\n {0}", c.PresentationCourte());
                             break;
					
                     case 6: //Créer une arme 
                         Console.Write("Identifiant de l'arme ? ");
                         idA = LireEntier(); 
                         Console.Write("Nom de l'arme ? ");
                         string nom = Console.ReadLine();
                         Console.Write("Puissance ? ");
                         int puissance =  LireEntier();
                         try
                         {
                             Facade.CreerUneArme(idA, nom, puissance);
                         }
                         catch (ArgumentOutOfRangeException a)
                         {
                             Console.WriteLine(a.Message);
                         }
                         break;
							
                    case 7: //Lister les armes disponibles 
                         Console.WriteLine("Liste des armes disponibles :");
                         
                         foreach (string a in Facade.AfficherArmesDisponibles()  )
                         { Console.WriteLine(a); Console.WriteLine("-------------------------------"); }
                         break;

                    case 8 : //Donner une arme à un personnage 
                         Console.Write("Identifiant de l'arme ? ");
                         idA = LireEntier();
                         Console.Write("Identifiant du personnage ? ");
                         idP = LireEntier();
                         Facade.DonnerUneArme(idA, idP);
                         break;

                    case 9: // frapper (agresseur,victime)
                         Console.Write("Identifiant de l'agresseur ? ");
                         int idAgresseur =  LireEntier();
                         Console.Write("Identifiant de la victime ? ");
                         int idVictime =  LireEntier();
                         Facade.Frapper(idAgresseur, idVictime);
                         break;

                    case 10: //suppression d'un personnage
                         Console.Write("Identifiant du personnage ? ");
                         idP = LireEntier();
                         Facade.SupprimerPers(idP);
                         break;
                   
                    case 11: fin = true;
                            break;
                    default: Console.WriteLine("Erreur choix !");
                            break;   
                
                    case 12: // Créer un mage
                         Console.Write("Nom du mage? ");
                         string nomm = Console.ReadLine();
                         Mage m = Facade.AjouterMage(nomm);
                         Console.WriteLine("Creation du mage:\n {0}", m.PresentationCourte());
                         break;

                    case 13:
                         Test1();
                         break;

                    case 14:
                         Test2();
                         break;

                    case 15:
                         Test3();
                         break;
                  
                }

            }
        } // end Main
        static int LireEntier()
        {
            int i = 0;
            string s;
            bool saisieEntier = false;
            while (!saisieEntier)
            {
                s = Console.ReadLine();
                saisieEntier = int.TryParse(s, out i);
                if (!saisieEntier)
                {
                    Console.WriteLine("Entrez une nouvelle valeur (numerique !)");
                }
            }
            return i;
        }
        static void Menu()
        {
            Console.WriteLine("0.  Lancer le jeu d'essai");
            Console.WriteLine("1.  Lister tous les personnages (description courte)");
            Console.WriteLine("2.  Description detaillee d'un personnage (idP)");
            Console.WriteLine("3.  Lister tous les personnages (description detaillee)");
            Console.WriteLine("4.  Ajouter un troll");
            Console.WriteLine("5.  Ajouter un chasseur");
            Console.WriteLine("6.  Creer une arme");
            Console.WriteLine("7.  Lister les armes disponibles");
            Console.WriteLine("8.  Donner une arme a un personnage");
            Console.WriteLine("9.  Frapper");
            Console.WriteLine("10. Supprimer un personnage");
            Console.WriteLine("11. Quitter le jeu");
            Console.WriteLine("12. Ajouter un mage");
            Console.WriteLine("13. Test1");
            Console.WriteLine("14. Test2");
            Console.WriteLine("15. Test3");
            Console.Write("Choix ? (0..12) ");
        }

        static void Test1()
        {
            Facade.InitialiserJeuVide();
            Facade.CreerJeuDEssai();
            Console.WriteLine("=================================");
            foreach (string p in Facade.AfficherTsPersonnagesDC()) { Console.WriteLine(p); }
            Facade.Frapper(4, 1);
            Facade.Frapper(6, 3);
            Facade.Frapper(3, 6);
            Console.WriteLine("=================================");
            foreach (string p in Facade.AfficherTsPersonnagesDC()) { Console.WriteLine(p); }
            Console.WriteLine("=================================");
            Console.WriteLine(Facade.AfficherPersonnageDD(6));
        }

        static void Test2()
        {
            Console.WriteLine("============Test2  : Jeu de tests plus poussé : création et distribution d'armes (y compris à un troll), combats =====================");
            Facade.InitialiserJeuVide();
            Facade.CreerJeuDEssai();
            Facade.AjouterTroll("T4", 314, 99); //idP=7
            Facade.AjouterChasseur("C4", "guetteur");//idP=8
            Console.WriteLine("============Ajout T4 et C4 =====================");
            foreach (string p in Facade.AfficherTsPersonnagesDC()) { Console.WriteLine(p); }

            //nouvelle arme et distribution des armes
            Facade.CreerUneArme(4, "laser", 50);
            Facade.DonnerUneArme(3, 4);
            Facade.DonnerUneArme(1, 8);
            Facade.DonnerUneArme(4, 8);
            Facade.DonnerUneArme(4, 8);// 2 fois la meme arme, il ne la prend pas.
            Facade.DonnerUneArme(4, 4);

            Console.WriteLine("====== nb armes et force augmentés pour C1 et C4 =======");
            foreach (string p in Facade.AfficherTsPersonnagesDC()) { Console.WriteLine(p); }
            Console.WriteLine("---------------------------------");
            Console.WriteLine(Facade.AfficherPersonnageDD(4));
            Console.WriteLine(Facade.AfficherPersonnageDD(8));
            Console.WriteLine(Facade.AfficherPersonnageDD(1));
            Console.WriteLine("------------C4 n'a pas 2 fois laser ? --------------");
            Facade.DonnerUneArme(4, 1);
            Console.WriteLine(Facade.AfficherPersonnageDD(1));
            Console.WriteLine("============= T1 n'a pas plus de force ? =============");
            //combats

            Facade.Frapper(4, 7);
            Facade.Frapper(7, 4);
            Facade.Frapper(8, 4);

            Facade.Frapper(1, 8);
            Facade.Frapper(2, 8);
            Facade.Frapper(6, 8);
            Facade.Frapper(6, 8);//2 fois la meme frappe => une seule fois l'ennemi ?

            Console.WriteLine("=================================");
            foreach (string p in Facade.AfficherTsPersonnagesDC()) { Console.WriteLine(p); }
            Console.WriteLine("---------------------------------");
            Console.WriteLine(Facade.AfficherPersonnageDD(4));
            Console.WriteLine(Facade.AfficherPersonnageDD(7));
            Console.WriteLine(Facade.AfficherPersonnageDD(8));
            Console.WriteLine("======= une seule fois l'ennemi C3 ? ==========");
        }

        static void Test3()
        {
            Console.WriteLine("===========Test3  : Jeu de tests avec suppression et ajout de personnages ======================");
            Facade.InitialiserJeuVide();
            Facade.CreerJeuDEssai();
            Console.WriteLine("===========suppression de T1 et C3 ; ajout de T4 et C4 ======================");
            Facade.SupprimerPers(1);
            Facade.SupprimerPers(6);
            Facade.AjouterTroll("T4", 314, 99); //idP=7
            Facade.AjouterChasseur("C4", "guetteur");//idP=8
            Console.WriteLine("=================================");
            foreach (string p in Facade.AfficherTsPersonnagesDC()) { Console.WriteLine(p); }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("========= armes et combats ======================");
            Facade.DonnerUneArme(1, 5);
            Facade.DonnerUneArme(3, 8);
            Facade.DonnerUneArme(3, 8);//il l'a déjà !
            Facade.Frapper(5, 7);
            Facade.Frapper(5, 8);
            Facade.Frapper(5, 3);
            Facade.Frapper(2, 7);
            Facade.Frapper(2, 8);
            Facade.Frapper(7, 2);

            foreach (string p in Facade.AfficherTsPersonnagesDD()) { Console.WriteLine(p); }
            Console.WriteLine("=========suppression de C2==========");
            Facade.SupprimerPers(5); //suppression de C2
            foreach (string p in Facade.AfficherTsPersonnagesDD()) { Console.WriteLine(p); }
            Console.WriteLine("========= C2 supprimé aussi des ennemis ? ==========");
            Console.WriteLine("========T2 puis C4 frappés à mort ============");
            Facade.Frapper(7, 2);
            Facade.Frapper(8, 2);
            Facade.Frapper(4, 8);
            Facade.Frapper(3, 8);
            foreach (string p in Facade.AfficherTsPersonnagesDD()) { Console.WriteLine(p); }
            Console.WriteLine("=================================");
            Console.WriteLine("======= Qq essais sur les morts========");

            Facade.DonnerUneArme(3, 8); // donner une arme à un mort
            Facade.Frapper(7, 2); // frapper un mort
            Facade.Frapper(2, 7); // demander à un mort de frapper !
            foreach (string p in Facade.AfficherTsPersonnagesDD()) { Console.WriteLine(p); }
        }
    }
}
