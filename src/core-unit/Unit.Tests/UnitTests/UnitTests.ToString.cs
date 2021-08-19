#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitTests
    {
        [Test]
        public void ToString_ExpectUnitValueString()
        {
            var source = default(Unit);
            var actual = source.ToString();

            const string expected = "The Unit value: ()";
            Assert.AreEqual(expected, actual);
        }
    }
}
