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
    public class RateTest
    {
        [TestMethod]
        public void LinearInterpolationDoubleTest()
        {
            var interpolator = new LinearInterpol<double>();
            var list = new List<double>{0, 1, 2};
            var labels = new List<KDateTime>{
                new KDateTime(1990, 1, 1),
                new KDateTime(1990, 1, 3),
                new KDateTime(1990, 1, 5)
            };
            var index = new KDateTime(1990, 1, 2);
            var res = interpolator.Interpolate(list, labels, index);
            System.Console.WriteLine($"res1 = {res}");
            Assert.AreEqual(res, 0.5, 0.001);


            // Assert.AreEqual(interpolator.Interpolate(list, -0.8), -0.8);
            // Assert.AreEqual(interpolator.Interpolate(list, 5), 5);
            // Assert.AreEqual(interpolator.Interpolate(list, 1), 1);
        }

        [TestMethod]
        public void LinearInterpolationIntTest()
        {
            var interpolator = new LinearInterpol<int>();
            var list = new List<int>{0, 1, 2};
            var labels = new List<KDateTime>{
                new KDateTime(1990, 1, 1),
                new KDateTime(1990, 1, 3),
                new KDateTime(1990, 1, 5)
            };
            var index = new KDateTime(1990, 1, 2);
            var res = interpolator.Interpolate(list, labels, index);
            System.Console.WriteLine($"res2 = {res}");
            Assert.IsTrue(res == 0);
            // Assert.AreEqual(interpolator.Interpolate(list, -0.8), -1);
            // Assert.AreEqual(interpolator.Interpolate(list, 5.1), 5);
            // Assert.AreEqual(interpolator.Interpolate(list, 1), 1);
        }

        [TestMethod]
        public void ConstantRateTest()
        {
            var rate = new ConstantValue<double>(new List<KDateTime>{
                new KDateTime(1990, 1, 1),
                new KDateTime(1991, 1, 1),
                new KDateTime(1992, 1, 1)
            }, 0.1);
            var crate = new ConstantRate("Libor", rate, Frequency.Semiannual);
            var asof = new KDateTime(1990, 1, 1);
            Assert.AreEqual(
                crate.DiscountValue(3, asof, new KDateTime(1992, 1, 1)),
                3 * Math.Pow(1 + 0.1 / 2, -4),
                0.001);
        }

        [TestMethod]
        public void CustomRateTest()
        {
            var rate = new SeriesValue<double>(
                new List<KDateTime>{
                    new KDateTime(1990, 1, 1),
                    new KDateTime(1991, 1, 1),
                    new KDateTime(1992, 1, 1)},
                new List<double>{
                    0.1, 0.2, 0.3
                });
            var crate = new CustomRate("Libor", rate, Frequency.Semiannual);
            var asof = new KDateTime(1989, 1, 1);
            Assert.AreEqual(
                crate.DiscountValue(3, asof, new KDateTime(1990, 1, 1)),
                3 * Math.Pow(1 + 0.1 / 2, -2),
                0.001);
            Assert.AreEqual(
                crate.DiscountValue(3, asof, new KDateTime(1991, 1, 1)),
                3 * Math.Pow(1 + 0.2 / 2, -4),
                0.001);
            Assert.AreEqual(
                crate.DiscountValue(3, asof, new KDateTime(1992, 1, 1)),
                3 * Math.Pow(1 + 0.3 / 2, -6),
                0.001);

        }
    }
}