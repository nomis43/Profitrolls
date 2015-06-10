using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using packTrolls;

namespace TrollProg
{
    class Test3
    {
        static void Main(string[] args)
        {//Test3  : Jeu de tests avec suppression et ajout de personnages
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
            Facade.Frapper(7,2); // frapper un mort
            Facade.Frapper(2,7); // demander à un mort de frapper !
			foreach (string p in Facade.AfficherTsPersonnagesDD()) { Console.WriteLine(p); }

        }
    }
}
