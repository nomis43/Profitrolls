using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using packTrolls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace packTrolls.Tests
{
    [TestClass()]
    public class TrollTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Troll.init : Identificateur négatif ne lance pas l'exception ArgumentOutOfRangeException")]
        public void TrollTest1()
        {
            new Troll(-1, "T1", 100, 10);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Troll.init : Nom null ne lance pas l'exception ArgumentOutOfRangeException")]
        public void TrollTest2()
        {
            new Troll(1, null, 100, 10);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Troll.init : Nom vide ne lance pas l'exception ArgumentOutOfRangeException")]
        public void TrollTest3()
        {
            new Troll(1, "", 100, 10);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Troll.init : Taille négative ne lance pas l'exception ArgumentOutOfRangeException")]
        public void TrollTest4()
        {
            new Troll(1, "T1", -100, 10);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Troll.init : Force négative ne lance pas l'exception ArgumentOutOfRangeException")]
        public void TrollTest5()
        {
            new Troll(1, "T1", 100, -10);
        }

        [TestMethod()]
        public void GetIdpTest()
        {
            Troll t1 = new Troll(1, "T1", 100, 10);
            Assert.AreEqual(1, t1.GetId(), "Troll.GetIdp : idp mal initialisée");
        }

        [TestMethod()]
        public void GetNomTest()
        {
            Troll t1 = new Troll(1, "T1", 100, 10);
            Assert.AreEqual("T1", t1.GetNom(), "Troll.GetNom : nom mal initialisée");
        }

        [TestMethod()]
        public void GetVieTest()
        {
            Troll t1 = new Troll(1, "T1", 100, 10);
            Assert.AreEqual(Troll.C_GetVieNaiss(), t1.GetVie(), "Troll.GetVie : vie mal initialisée");
        }

        [TestMethod()]
        public void GetForceTest()
        {
            Troll t1 = new Troll(1, "T1", 100, force: 10);
            Assert.AreEqual(10, t1.GetForce(), "Troll.GetForce : Force mal initialisée");
        }

        /*
        [TestMethod()]
        public void GetTypePersTest()
        {
            Troll t1 = new Troll(1, "T1", 100, 10);
            Assert.AreEqual(Troll.C_GetType(), t1.GetTypePers(), "Troll.GetTypePers : TypePers mal initialisé");
        }
         */

        [TestMethod()]
        public void GetTailleTest()
        {
            Troll t1 = new Troll(1, "T1", taille: 100, force: 10);
            Assert.AreEqual(100, t1.GetTaille(), "Troll.GetTaille : taille mal initialisée");
        }

        [TestMethod()]
        public void RecevoirArmeTest()
        {
            Troll t1 = new Troll(1, "T1", 100, force: 10);
            t1.RecevoirArme(new Arme(1, "test unitaire", 100));
            Assert.AreEqual(10, t1.GetForce(), "Troll.RecevoirArme : Force non modifiée");
        }

        [TestMethod()]
        //        [Ignore]
        public void PresentationCourteTest()
        {
            Assert.Inconclusive("Ce test est délicat à réaliser car le format exact n'a pas été fixé");
        }

        [TestMethod()]
        public void PresentationDetailTest()
        {
            Troll t1 = new Troll(1, "T1", taille: 100, force: 10);
            StringAssert.StartsWith(t1.PresentationDetail(), t1.PresentationCourte(),
                "Troll.PresentationDetail : ne commence pas présentation courte");
        }

        [TestMethod()]
        public void MesEnnemisTest()
        {
            Troll t1 = new Troll(1, "T1", taille: 100, force: 10);
            Assert.AreEqual(0, t1.GetListeEnnemis().Count(),
                "Troll.MesEnnemis : MesEnnemis n'est pas vide initialement");
        }
    }
}
