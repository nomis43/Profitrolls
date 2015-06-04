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
    public class ArmeTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Arme.init : Identificateur négatif ne lance pas l'exception ArgumentOutOfRangeException")]
        public void ArmeTest1()
        {
            new Arme(-1, "A1", 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Arme.init : Nom null ne lance pas l'exception ArgumentOutOfRangeException")]
        public void ArmeTest2()
        {
            new Arme(1, null,12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Arme.init : Nom vide ne lance pas l'exception ArgumentOutOfRangeException")]
        public void ArmeTest3()
        {
            new Arme(1, "", 12);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Arme.init : Puissance négative ne lance pas l'exception ArgumentOutOfRangeException")]
        public void ArmeTest4()
        {
            new Arme(1, "A1", -12);
        }

        [TestMethod()]
        public void GetNomTest()
        {
            Arme a1 = new Arme(1, "A1", 12);
            Assert.AreEqual("A1",a1.GetNom());
        }

        [TestMethod()]
        public void GetPuissanceTest()
        {
            Arme a1 = new Arme(1, "A1", 12);
            Assert.AreEqual(12, a1.GetPuissance());
        }

        [TestMethod()]
        public void GetIdTest()
        {
            Arme a1 = new Arme(1, "A1", 12);
            Assert.AreEqual(1,a1.GetId());
        }
    }
}
