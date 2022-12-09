using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayStaticTest
{
    [Fact]
    public void Empty_ExpectInnerStateIsDefault()
    {
        var actual = FlatArray.Empty<RecordType>();
        actual.VerifyInnerState(default, default);
    }
}