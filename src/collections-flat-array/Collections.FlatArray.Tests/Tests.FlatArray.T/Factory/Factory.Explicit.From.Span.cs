using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void FromReadOnlySpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = default(ReadOnlySpan<RecordType>);
        var actual = FlatArray<RecordType>.From(source);

        actual.VerifyDefaultState();
    }

    [Theory]
    [InlineData(SomeString)]
    [InlineData("First", "Second", "Third")]
    public void FromReadOnlySpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems(
        params string?[] sourceItems)
    {
        var source = new ReadOnlySpan<string?>(sourceItems);
        var actual = FlatArray<string?>.From(source);

        actual.VerifyInnerState(sourceItems.Length, sourceItems);
    }

    [Fact]
    public void FromSpan_SourceIsEmpty_ExpectInnerStateIsDefault()
    {
        var source = default(Span<StructType?>);
        var actual = FlatArray<StructType?>.From(source);

        actual.VerifyDefaultState();
    }

    [Fact]
    public void FromSpan_SourceIsNotEmpty_ExpectInnerStateAreSourceItems()
    {
        Span<int> source = stackalloc int[] { 5, 11, -17, 27, -81 };
        var actual = FlatArray<int>.From(source);

        const int expectedLength = 5;
        var expectedItems = new[] { 5, 11, -17, 27, -81 };

        actual.VerifyInnerState(expectedLength, expectedItems);
    }

    [Fact]
    public void FromSpan_ThanModifySource_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[]
        {
            PlusFifteenIdRefType, ZeroIdRefType
        };

        var source = sourceItems.AsSpan();
        var actual = FlatArray<RefType>.From(source);

        source[0] = MinusFifteenIdRefType;

        var expectedItems = new[]
        {
            PlusFifteenIdRefType, ZeroIdRefType
        };

        actual.VerifyInnerState(expectedItems.Length, expectedItems);
    }
}