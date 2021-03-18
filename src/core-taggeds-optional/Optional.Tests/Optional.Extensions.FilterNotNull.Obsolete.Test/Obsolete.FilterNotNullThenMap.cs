﻿#nullable enable

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace PrimeFuncPack.Core.Tests
{
    partial class ObsoleteFilterNotNullOptionalExtensionsTest
    {
        [Test]
        public void FilterNotNullThenMap_ExpectIsObsolete()
        {
            const string expectedMethodName = "FilterNotNullThenMap";

            const string expectedObsoleteMessage
                = "This method is obsolete. Call FilterNotNull instead.";

            IReadOnlyCollection<MethodInfo> methods = typeof(FilterNotNullOptionalExtensions)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == expectedMethodName)
                .ToArray();

            Assert.AreEqual(2, methods.Count);

            Assert.True(
                methods.All(
                    method => method.CustomAttributes.Any(
                        attr
                        =>
                        attr.AttributeType == typeof(ObsoleteAttribute) &&
                        attr.ConstructorArguments.Count == 2 &&
                        attr.ConstructorArguments[0].Value is expectedObsoleteMessage &&
                        attr.ConstructorArguments[1].Value is true)));

            Assert.True(
                methods.All(
                    method => method.CustomAttributes.Any(
                        attr
                        =>
                        attr.AttributeType == typeof(DoesNotReturnAttribute))));
         }
    }
}
