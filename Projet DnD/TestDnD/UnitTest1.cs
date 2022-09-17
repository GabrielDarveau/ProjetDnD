using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Projet_DnD;

namespace TestDnD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            if(Projet_DnD.Perso.GetNiveau(27550) != 7)
            {
                Assert.Fail();
            }
        }
    }
}
