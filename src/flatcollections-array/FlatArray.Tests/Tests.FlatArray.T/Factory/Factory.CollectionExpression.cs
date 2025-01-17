﻿using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FlatArrayTest
{
    [Fact]
    public static void ConstructFromCollectionExpression_SourceIsEmpty_ExpectDefault()
    {
        FlatArray<string?> actual = [];
        actual.VerifyInnerState_Default();
    }

    [Fact]
    public static void ConstructFromCollectionExpression_SourceIsNotEmpty_ExpectInnerStateIsSourceCollection()
    {
        FlatArray<string?> actual = [ SomeString, null, EmptyString, WhiteSpaceString, AnotherString ];
        string?[] expectedItems = [ SomeString, null, EmptyString, WhiteSpaceString, AnotherString ];

        actual.VerifyInnerState(expectedItems, expectedItems.Length);
    }
}
