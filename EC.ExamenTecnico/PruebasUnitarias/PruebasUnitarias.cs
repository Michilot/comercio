using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EC.BusinessLogic;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        public void TestChangeString()
        {
            ChangeString oChangeString = new ChangeString();
            string sResultado = "123 bcde*3";
            string sCalculo = oChangeString.build("123 abcd*3");
            Assert.AreEqual(sCalculo, sResultado);
        }

        [TestMethod]
        public void TestCompleteRange()
        {
            CompleteRange oCompleteRange = new CompleteRange();
            string sResultado = "1,2,3,4,5";
            string sCalculo = oCompleteRange.build("​2, 1, 4, 5");
            Assert.AreEqual(sCalculo, sResultado);
        }


        [TestMethod]
        public void TestMoneyParts()
        {
            MoneyParts oMoneyParts = new MoneyParts();
            string sResultado = "[[0.05,0.05]],\r\n[[0.1]]";
            string sCalculo = oMoneyParts.build(0.1);
            Assert.AreEqual(sCalculo, sResultado);
        }
    }
}
