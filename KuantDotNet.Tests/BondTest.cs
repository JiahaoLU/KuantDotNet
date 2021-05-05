using Microsoft.VisualStudio.TestTools.UnitTesting;
using KuantDotNet.Instruments;
using System.Collections.Generic;
using System;
using KuantDotNet.Instruments.Interpolation;
using KuantDotNet.KuantDateTime;
using KuantDotNet.Instruments.Rate;
using KuantDotNet.Instruments.SeriesValue;

namespace KuantDotNet.Tests
{
    [TestClass]
    public class BondTest
    {
        [TestMethod]
        public void BondPriceTest()
        {
            var rate = new SeriesValue<double>(
                new List<KDateTime>{
                    new KDateTime(1990, 7, 1),
                    new KDateTime(1991, 1, 1),
                    new KDateTime(1991, 7, 1),
                    new KDateTime(1992, 1, 1)},
                new List<double>{
                    0.05, 0.058, 0.064, 0.068
                });
            var crate = new CustomRate("Libor", rate, Frequency.Continuous);
            var asof = new KDateTime(1990, 1, 1);

            var bond = new FixedRateBond(100, 2, Frequency.Semiannual,
                    new ConstantValue<double>(0.03), crate, asof);

            Assert.AreEqual(bond.SpotPriceAsUnderlying(asof), 98.39, 0.01);
             Assert.AreEqual(bond.ParYield(asof), 0.0687, 0.0001);

        }
    }
}