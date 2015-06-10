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
            "Facade.init :puissance nulle ne lance pas l'exception ArgumentOutOfRangeException")]
        public void CreerUneArmeTest8()
        {
            new Arme(1, "a", 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identifiant du personnage vide ne lance pas l'exception ArgumentOutOfRangeException")]
        public void DonnerUneArmeTest1()
        {
           Facade.DonnerUneArme(0, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identifiant du personnage négatif ne lance pas l'exception ArgumentOutOfRangeException")]
        public void DonnerUneArmeTest2()
        {
            Facade.DonnerUneArme(-1, 1);
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
        public void FrapperTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identifiant du personnage négatif ne lance pas l'exception ArgumentOutOfRangeException")]
        public void SupprimerPersTest1()
        {
            Facade.SupprimerPers(-1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identifiant du personnage nul ne lance pas l'exception ArgumentOutOfRangeException")]
        public void SupprimerPersTest2()
        {
            Facade.SupprimerPers(0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Facade.init : Identifiant du personnage inexistant ne lance pas l'exception ArgumentOutOfRangeException")]
        public void SupprimerPersTest3()
        {
            Facade.SupprimerPers(1);
        }

        public void SupprimerPersTest4()
        {
            Personnage C1 = G_Personnage.AjouterChasseur("C1", "Barde");
            Personnage C2 = G_Personnage.AjouterChasseur("C2", "Clown");

            Facade.SupprimerPers(1);
            List<Personnage> lp = (List<Personnage>) G_Personnage.ListerTsPersonnages();
            CollectionAssert.DoesNotContain(lp, C1);
            CollectionAssert.Contains(lp, C2);
            Facade.SupprimerPers(2);
            if (!lp.Any())
            {
                Assert.Fail();
            }
        }

        public void SupprmierPersTest6()
        {
            Personnage C1 = G_Personnage.AjouterChasseur("C1", "Barde");
            Personnage C2 = G_Personnage.AjouterChasseur("C2", "Clown");

            C1.Frapper(C2);

            G_Personnage.SupprimerPers(1);
            List<Personnage> listeEnnemis = (List<Personnage>)C2.GetListeEnnemis();
            CollectionAssert.DoesNotContain(listeEnnemis, C1);
        }

        public void SupprmierPersTest5()
        {
            G_Personnage.AjouterChasseur("C1", "Barde");
            Facade.SupprimerPers(1);
            List<Personnage> lp = (List<Personnage>) G_Personnage.ListerTsPersonnages();
            if (!lp.Any())
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ListerTsPersonnagesTest()
        {
            G_Personnage.Reset();
            Personnage C1 = G_Personnage.AjouterChasseur("C1", "F1");
            Personnage C2 = G_Personnage.AjouterChasseur("C2", "F2");

            List<Personnage> lp = (List<Personnage>) G_Personnage.ListerTsPersonnages();

            if (lp.Count != 2)
            {
                Assert.Fail();
            }
            CollectionAssert.Contains(lp, C1);
            CollectionAssert.Contains(lp, C2);
        }

        public void ListerTsPersonnagesTest2() {
            if (G_Personnage.ListerTsPersonnages().Count() != 0)
            {
                Assert.Fail();
            }
        }

        public void ListerTsPersonnagesTest3()
        {
            Personnage C1 = G_Personnage.AjouterChasseur("C1", "F1");
            List<Personnage> lp = (List<Personnage>) G_Personnage.ListerTsPersonnages();
            if (lp.Count != 1)
            {
                Assert.Fail();
            }
            CollectionAssert.Contains(lp, C1);
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
