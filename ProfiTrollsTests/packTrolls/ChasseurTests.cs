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
        public void RecevoirArmeTest()
        {
            Arme a = G_Armes.CreerUneArme(1, "epee", 35);
            Chasseur c = G_Personnage.AjouterChasseur("C1", "forgeron");
            c.RecevoirArme(a);
            List<Arme> lArmes = (List<Arme>) c.GetListeArmes();
            Assert.AreEqual(lArmes[0], a);
        }

        [TestMethod()]
        public void PresentationCourteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PresentationDetailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListeArmesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ListerMesArmesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTypePersTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ChasseurTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetForceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetTypePersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetFonctionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void c_SetForceTest()
        {
            Assert.Fail();
        }
    }
}
