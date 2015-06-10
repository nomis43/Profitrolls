using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using packTrolls;

namespace TrollProg
{
    class Test1
    {  static void Main(string[] args)
        {
            //Test1 : Jeu de tests fourni

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
       
    }
}