using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using packTrolls;

namespace TrollProg
{
    class Test2
    {
        static void Main(string[] args)
        { //Test2  : Jeu de tests plus poussé : création et distribution d'armes (y compris à un troll), combats
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
    }
}
