using System;
using NUnit.Framework;
using NexidiaCodeScreen;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace NexidiaCodeScreen.Test
{
    [TestFixture]
    public class PrimeExtensionTest
    {
        [TestCase(5, "5")]
        [TestCase(8000, "2,2,2,2,2,2,5,5,5")]
        public void CanGetPrimeFactor(int x, string expected)
        {
            Assert.That(PrimeFactorExtension.GeneratePrimes(x), Is.EqualTo(expected));
        }

        [TestCase("3", true)]
        [TestCase("00R", false)]
        public void CanReturnIsInteger(string x, bool expected)
        {
            Assert.That(PrimeFactorExtension.IsInteger(x), Is.EqualTo(expected));
        }

        [TestCase ]
        public void WillReturnAResult()
        {
            var stream = CreateMockStream();
            Assert.IsNotNull(PrimeFactorExtension.ShowPrimeFactors(stream));

        }

        private static StreamReader CreateMockStream()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("8000");
            stringBuilder.AppendLine("rr00");
            stringBuilder.AppendLine("2333");
            var streamReader = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(stringBuilder.ToString())));
            return streamReader;
        }
    }
}
