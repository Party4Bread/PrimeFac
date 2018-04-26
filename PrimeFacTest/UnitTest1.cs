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
        public BigInteger p1 = 101, p2 = 103,
            p3 = 0x10001, p4 = 204791,
            p5 = 32416188583, p6 = 32416189919,
            n1, n2, n3;
        [TestInitialize]
        public void Init()
        {
            n1 = p1 * p2;
            n2 = p3 * p4;
            n3 = p5 * p5;
        }
        [TestMethod]
        public void PollardRhoTest1()
        {
            Assert.AreEqual(p1, PrimeFac.PollardRho(n1));
        }
        [TestMethod]
        public void PollardRhoTest2()
        {
            Assert.AreEqual(p3, PrimeFac.PollardRho(n2));
        }
        [TestMethod]
        public void PollardRhoTest3()
        {
            Assert.AreEqual(p5, PrimeFac.PollardRho(n3));
        }
        [TestMethod]
        public void PollardRhoLimitTest1()
        {
            PrimeFac.PollardRho(n2, out BigInteger a);
            Assert.AreEqual(p3, a);
        }
        [TestMethod]
        public void PollardRhoLimitTimeoutTest()
        {
            Assert.AreEqual(false, PrimeFac.PollardRho(n3, out BigInteger a, 1));
        }
        [TestMethod]
        public void FermatTest1()
        {
            Assert.AreEqual(p1, PrimeFac.Fermat(n1));
        }
        [TestMethod]
        public void FermatTest2()
        {
            Assert.AreEqual(p3, PrimeFac.Fermat(n2));
        }
        //This test will consume super large amount of time
        //[TestMethod]
        public void FermatTest3()
        {
            Assert.AreEqual(p5, PrimeFac.Fermat(n3));
        }
        [TestMethod]
        public void FermatLimitTest1()
        {
            PrimeFac.Fermat(n2, out BigInteger k, 100000);
            Assert.AreEqual(p3, k);
        }
        [TestMethod]
        public void FermatLimitTimeoutTest()
        {
            Assert.AreEqual(false, PrimeFac.Fermat(n3, out BigInteger a, 1));
        }
        [TestMethod]
        public void BrentTest1()
        {
            Assert.AreEqual(p1, PrimeFac.PollardRho_brent(n1));
        }
        [TestMethod]
        public void BrentTest2()
        {
            Assert.AreEqual(p3, PrimeFac.PollardRho_brent(n2));
        }
        [TestMethod]
        public void BrentTest3()
        {
            Assert.AreEqual(p5, PrimeFac.PollardRho_brent(n3));
        }

        [TestMethod]
        public void isqrtspeedTest1()
        {
            Assert.AreEqual(Util.isqrt(n3), Util.isqrt(n3));
        }
    }
}
