using System;
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
                             Console.WriteLine("{0,-4}{1,-4}{2,-10}{3,-6}{4,-6}{5,-16}{6,-8}",
                                               "id", "nom", "type", "force", "vie",
                                               "taille/fctn", "nbarmes");
                             Console.Write("========================================");
                             Console.WriteLine("==========================");
                             Console.WriteLine(Facade.AfficherPersonnageDD(idPers));
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
                         Facade.CreerUneArme(idA, nom, puissance);
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
            Console.Write("Choix ? (0..12) ");

        }
    }
}
