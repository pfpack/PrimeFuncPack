﻿#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Data;
using PrimeFuncPack.UnitTest.Moq;
using System;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class InvokeToUnitActionExtensionsTests
    {
        [Test]
        public void InvokeThenToUnit_01_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType> action = null!;
            var arg = GenerateStructType();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = action.InvokeThenToUnit(arg));

            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void InvokeThenToUnit_01_ExpectCallActionOnce(
            in bool isArgNull)
        {
            var mockAction = MockActionFactory.CreateMockAction<RefType?>();
            var action = new Action<RefType?>(mockAction.Object.Invoke);

            var arg = isArgNull ? null : GenerateRefType();
            var actual = action.InvokeThenToUnit(arg);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg), Times.Once);
        }
    }
}
