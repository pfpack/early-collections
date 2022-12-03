using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayFlatListTest
{
    [Fact]
    public void GetEnumeratorGeneric_SourceIsEmpty_ExpectTypeIsInnerEnumeratorEmpty()
    {
        var source = TestHelper.CreateEmptyFlatList<RecordType>();

        var actual = source.GetEnumerator().GetType().Name;
        const string expected = "InnerEnumeratorEmpty";

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, EmptyString)]
    [InlineData(2, SomeString, AnotherString, TabString, EmptyString)]
    public void GetEnumeratorGeneric_SourceIsNotEmpty_ExpectInnerEnumeratorCorrectState(
        int length, params string?[] items)
    {
        var source = items.InitializeFlatList(length);
        var actual = source.GetEnumerator();

        actual.VerifyInnerFlatListEnumeratorState(items, length, -1);
    }
}