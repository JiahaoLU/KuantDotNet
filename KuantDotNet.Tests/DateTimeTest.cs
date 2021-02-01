using Microsoft.VisualStudio.TestTools.UnitTesting;
using KuantDotNet.KuantDateTime;
using System;

namespace KuantDotNet.Tests
{
    [TestClass]
    public class DateTimeTest
    {
        [TestMethod]
        public void DateTest()
        {
            var d1 = new DateTime(2020, 2, 1);
            var d2 = new DateTime(2020, 2, 10);
            Assert.AreEqual(TimeUtil.DaySpan(d1, d2), 9);
        }
    }
}
