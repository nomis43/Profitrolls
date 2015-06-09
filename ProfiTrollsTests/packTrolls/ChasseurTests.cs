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
    public class ChasseurTests
    {
        [TestMethod()]
        public void RecevoirArmeTest1()
        {
            Arme a = G_Armes.CreerUneArme(1, "epee", 35);
            Chasseur c = G_Personnage.AjouterChasseur("C1", "forgeron");
            c.RecevoirArme(a);
            List<Arme> lArmes = (List<Arme>) c.GetListeArmes();
            CollectionAssert.Contains(lArmes, a);
        }

        [TestMethod]
        public void RecevoirArmeTest2()
        {
            Arme a = G_Armes.CreerUneArme(1, "epee", 35);
            Chasseur c = G_Personnage.AjouterChasseur("C1", "forgeron");
            c.RecevoirArme(a);
            c.RecevoirArme(a);
            List<Arme> lArmes = (List<Arme>) c.GetListeArmes();
            CollectionAssert.AllItemsAreUnique(lArmes);
        }

        [TestMethod()]
        [Ignore]
        public void PresentationCourteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PresentationDetailTest()
        {
            Chasseur c1 = new Chasseur(1, "C1", "forgeron");
            StringAssert.StartsWith(c1.PresentationDetail(), c1.PresentationCourte(),
                "Chasseur.PresentationDetail : ne commence pas présentation courte");
        }

        [TestMethod()]
        public void GetListeArmesTest()
        {
            Chasseur c = G_Personnage.AjouterChasseur("C1", "forgeron");
            List<Arme> lArmes = (List<Arme>) c.GetListeArmes();
            Assert.IsNotNull(lArmes);
        }

        [TestMethod()]
        [Ignore]
        public void ListerMesArmesTest()
        {  
            Assert.Inconclusive();
        }

        [TestMethod()]
        public void GetTypePersTest()
        {
            Chasseur c1 = new Chasseur(1, "C1", "facteur");
            Assert.AreEqual(c1.GetTypePers(), "Chasseur");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Chasseur.init : Identificateur négatif ne lance pas l'exception ArgumentOutOfRangeException")]
        public void ChasseurTest1()
        {
            new Chasseur(-1, "C1", "facteur");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Chasseur.init : Nom null ne lance pas l'exception ArgumentOutOfRangeException")]
        public void ChasseurTest2()
        {
            new Chasseur(1, null, "facteur");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Chasseur.init : Nom vide ne lance pas l'exception ArgumentOutOfRangeException")]
        public void ChasseurTest3()
        {
            new Chasseur(1, "", "facteur");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Chasseur.init : Fonction null ne lance pas l'exception ArgumentOutOfRangeException")]
        public void ChasseurTest4()
        {
            new Chasseur(1, "C1", null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Chasseur.init : Fonction vide ne lance pas l'exception ArgumentOutOfRangeException")]
        public void ChasseurTest5()
        {
            new Chasseur(1, "C1", "");
        }

        [TestMethod()]
        public void GetForceTest()
        {
            Chasseur c1 = new Chasseur(1, "C1", "facteur");
            Assert.AreEqual(20, c1.GetForce());
        }

        [TestMethod()]
        public void SetTypePersTest()
        {
            Chasseur c1 = new Chasseur(1, "C1", "facteur");
            c1.SetTypePers("Seigneur");
            Assert.AreEqual("Seigneur", c1.GetTypePers());
        }

        [TestMethod()]
        public void GetFonctionTest()
        {
            Chasseur c1 = new Chasseur(1, "C1", "facteur");
            Assert.AreEqual("facteur", c1.GetFonction());
        }

        [TestMethod()]
        public void c_SetForceTest()
        {
            Chasseur c1 = new Chasseur(1, "C1", "facteur");
            Chasseur.c_SetForce(54);
            Assert.AreEqual(54, c1.GetForce());
        }
    }
}
