using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeFac;
using System;
using System.Numerics;
using System.Security.Cryptography;
namespace PrimeFac
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PollardRhoTest1()
        {
            int n = 101 * 103;
            Assert.AreEqual(101, PrimeFac.PollardRho(n));
        }
        [TestMethod]
        public void PollardRhoTest2()
        {
            BigInteger n = new BigInteger(204791) * 0x10001;
            Assert.AreEqual(0x10001, PrimeFac.PollardRho(n));
        }
        //This may not end in a day don't try it
        //[TestMethod]
        public void PollardRhoTest3()
        {
            using (RSA rsa = RSA.Create(512))
            {
                var key = rsa.ExportParameters(true);
                BigInteger n = new BigInteger(key.Modulus);
                Assert.AreEqual(new BigInteger(key.P), PrimeFac.PollardRho(n));
            }
        }
    }
}
