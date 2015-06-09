using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using packTrolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace packTrolls.Tests
{
    [TestClass()]
    public class FacadeTests
    {
      

        

        [TestMethod()]
        public void AjouterTrollTest()
        {
            Troll t = Facade.AjouterTroll("T", 120, 12);

            Assert.AreEqual("T",t.GetNom());
            Assert.AreEqual(120, t.GetTaille());
            Assert.AreEqual(12, t.GetForce());
        }

        [TestMethod()]
        public void AjouterChasseurTest()
        {
            Chasseur t = Facade.AjouterChasseur("C","chef");

            Assert.AreEqual("C", t.GetNom());
            Assert.AreEqual("chef", t.GetFonction());
        }

       

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init :identifiant négatif ne lance pas l'exception ArgumentOutOfRangeException")]
        public void CreerUneArmeTest1()
        {
             new Arme(-1, "a", 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init :identifiant nul ne lance pas l'exception ArgumentOutOfRangeException")]
        public void CreerUneArmeTest2()
        {
            new Arme(0, "a", 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init :identifiant déjà existant ne lance pas l'exception ArgumentOutOfRangeException")]
        public void CreerUneArmeTest3()
        {
            G_Armes.CreerUneArme(1, "a", 12);
            G_Armes.CreerUneArme(1, "b", 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Nom null ne lance pas l'exception ArgumentOutOfRangeException")]
        public void CreerUneArmeTest4()
        {
            new Arme(1, null,12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Nom vide ne lance pas l'exception ArgumentOutOfRangeException")]
        public void CreerUneArmeTest5()
        {
            new Arme(1, "", 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init :nom déjà existant ne lance pas l'exception ArgumentOutOfRangeException")]
        public void CreerUneArmeTest6()
        {
            G_Armes.CreerUneArme(1, "a", 12);
            G_Armes.CreerUneArme(1, "a", 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init :puissance négative ne lance pas l'exception ArgumentOutOfRangeException")]
        public void CreerUneArmeTest7()
        {
            new Arme(1, "a", -12);
        }

       

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identifiant du personnage vide ne lance pas l'exception ArgumentOutOfRangeException")]
        public void DonnerUneArmeTest1()
        {
           Facade.DonnerUneArme(1, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identifiant du personnage négatif ne lance pas l'exception ArgumentOutOfRangeException")]
        public void DonnerUneArmeTest2()
        {
            Facade.DonnerUneArme(1, -1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identifiant de l'arme nul ne lance pas l'exception ArgumentOutOfRangeException")]
        public void DonnerUneArmeTest3()
        {
            Facade.DonnerUneArme(1, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identifiant de l'arme négatif ne lance pas l'exception ArgumentOutOfRangeException")]
        public void DonnerUneArmeTest4()
        {
            Facade.DonnerUneArme(1, -1);
        }

        [TestMethod()]
        public void DonnerUneArmeTest5()
        {
            Arme a = new Arme(1, "epee", 12);
            Troll t = new Troll(1,"highwaypa",100,10);
            Facade.DonnerUneArme(1, 1);
            Assert.AreEqual(10, t.GetForce());
        }

        [TestMethod()]
        public void DonnerUneArmeTest6()
        {
            Arme a =Facade.CreerUneArme(1, "epee", 12);
            Chasseur c =Facade.AjouterChasseur( "thierry", "forgeron");
            Facade.DonnerUneArme(1, c.GetId());
            Assert.AreEqual(10+a.GetPuissance(), c.GetForce());
            List<Arme> listeArmes = (List<Arme>)Facade.GetArmes(c.GetId());
            CollectionAssert.Contains(listeArmes, a);
        }

        [TestMethod()]
        public void DonnerUneArmeTest7()
        {
            Arme a1 = new Arme(1, "epee", 12);
            Arme a2 = new Arme(2, "epee", 12);
            Chasseur c = new Chasseur(1, "thierry", "forgeron");
            Facade.DonnerUneArme(1, 1);
            Facade.DonnerUneArme(2, 1);
            Assert.AreEqual(10 + a1.GetPuissance()+a2.GetPuissance(), c.GetForce());
            List<Arme> listeArmes = (List<Arme>)Facade.GetArmes(c.GetId());
            CollectionAssert.Contains(listeArmes, a1);
            CollectionAssert.Contains(listeArmes, a2);
        }

        [TestMethod()]
        public void DonnerUneArmeTest8()
        {
            Arme a = new Arme(1, "epee", 12);
            Chasseur c = new Chasseur(1, "thierry", "forgeron");
            Facade.DonnerUneArme(1, 1);
            Facade.DonnerUneArme(1, 1);
            Assert.AreEqual(10 + a.GetPuissance(), c.GetForce());
            List<Arme> listeArmes = (List<Arme>)Facade.GetArmes(c.GetId());
            CollectionAssert.AllItemsAreUnique(listeArmes);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identiiant de l'agresseur négatif ne lance pas l'exception ArgumentOutOfRangeException")]
        public void FrapperTest1()
        {
            Facade.Frapper(-1, 1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identiiant de la vitime négatif ne lance pas l'exception ArgumentOutOfRangeException")]
        public void FrapperTest2()
        {
            Facade.Frapper(1, -1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identiiant de l'agresseur nul ne lance pas l'exception ArgumentOutOfRangeException")]
        public void FrapperTest3()
        {
            Facade.Frapper(0, 1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identiiant de la victime nul ne lance pas l'exception ArgumentOutOfRangeException")]
        public void FrapperTest4()
        {
            Facade.Frapper(1, 0);
        }

        [TestMethod()]
         public void FrapperTest5()
        {
            Troll t = new Troll(1, "profy", 100, 10);
            Chasseur c = new Chasseur(2, "Rysta Fuquatou", "sage");
            Facade.Frapper(1, 2);
            Assert.AreEqual(Chasseur.C_GetVieNaiss() - t.GetForce(), c.GetVie());
            Assert.AreEqual(10, t.GetVie());
        }
        [TestMethod()]
        public void SupprimerPersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AfficherArmesDisponiblesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AfficherPersonnageDCTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AfficherPersonnageDDTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AfficherTsPersonnagesDCTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AfficherTsPersonnagesDDTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ListerTsPersonnagesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPersonnageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ListerTtesArmesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArmeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetArmesTest()
        {
            Assert.Fail();
        }
    }
}
