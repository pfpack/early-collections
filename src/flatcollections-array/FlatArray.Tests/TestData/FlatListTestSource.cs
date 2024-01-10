using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

internal static class FlatListTestSource
{
    public static TheoryData<IList<RecordType?>, RecordType?[], int, RecordType?[]> RecordTypeCopyToInRangeTestData
        =>
        new()
        {
            // Inner array length equals to the list length
            {
                new RecordType?[]
                {
                    MinusFifteenIdNullNameRecord,
                    ZeroIdNullNameRecord
                }
                .InitializeFlatList(),
                new[]
                {
                    null,
                    PlusFifteenIdSomeStringNameRecord
                },
                0,
                new[]
                {
                    MinusFifteenIdNullNameRecord,
                    ZeroIdNullNameRecord
                }
            },
            {
                new RecordType?[]
                {
                    PlusFifteenIdLowerSomeStringNameRecord
                }
                .InitializeFlatList(),
                new[]
                {
                    MinusFifteenIdNullNameRecord,
                    PlusFifteenIdSomeStringNameRecord
                },
                0,
                new[]
                {
                    PlusFifteenIdLowerSomeStringNameRecord,
                    PlusFifteenIdSomeStringNameRecord
                }
            },
            {
                new[]
                {
                    null,
                    ZeroIdNullNameRecord,
                    MinusFifteenIdSomeStringNameRecord
                }.InitializeFlatList(),
                new[]
                {
                    PlusFifteenIdSomeStringNameRecord,
                    MinusFifteenIdNullNameRecord,
                    null,
                    new()
                },
                1,
                new[]
                {
                    PlusFifteenIdSomeStringNameRecord,
                    null,
                    ZeroIdNullNameRecord,
                    MinusFifteenIdSomeStringNameRecord
                }
            },
            {
                new RecordType?[]
                {
                    PlusFifteenIdLowerSomeStringNameRecord
                }.InitializeFlatList(),
                new[]
                {
                    ZeroIdNullNameRecord,
                    MinusFifteenIdNullNameRecord,
                    PlusFifteenIdSomeStringNameRecord,
                    PlusFifteenIdLowerSomeStringNameRecord
                },
                1,
                new[]
                {
                    ZeroIdNullNameRecord,
                    PlusFifteenIdLowerSomeStringNameRecord,
                    PlusFifteenIdSomeStringNameRecord,
                    PlusFifteenIdLowerSomeStringNameRecord
                }
            },

            // Inner array length is greater than the list length
            {
                new[]
                {
                    MinusFifteenIdNullNameRecord,
                    ZeroIdNullNameRecord,
                    null
                }
                .InitializeFlatList(2),
                new[]
                {
                    null,
                    PlusFifteenIdSomeStringNameRecord
                },
                0,
                new[]
                {
                    MinusFifteenIdNullNameRecord,
                    ZeroIdNullNameRecord
                }
            },
            {
                new[]
                {
                    PlusFifteenIdLowerSomeStringNameRecord,
                    null
                }
                .InitializeFlatList(1),
                new[]
                {
                    MinusFifteenIdNullNameRecord,
                    PlusFifteenIdSomeStringNameRecord
                },
                0,
                new[]
                {
                    PlusFifteenIdLowerSomeStringNameRecord,
                    PlusFifteenIdSomeStringNameRecord
                }
            },
            {
                new[]
                {
                    null,
                    ZeroIdNullNameRecord,
                    MinusFifteenIdSomeStringNameRecord,
                    PlusFifteenIdSomeStringNameRecord
                }.InitializeFlatList(3),
                new[]
                {
                    PlusFifteenIdSomeStringNameRecord,
                    MinusFifteenIdNullNameRecord,
                    null,
                    new()
                },
                1,
                new[]
                {
                    PlusFifteenIdSomeStringNameRecord,
                    null,
                    ZeroIdNullNameRecord,
                    MinusFifteenIdSomeStringNameRecord
                }
            },
            {
                new RecordType?[]
                {
                    PlusFifteenIdLowerSomeStringNameRecord,
                    MinusFifteenIdNullNameRecord
                }.InitializeFlatList(1),
                new[]
                {
                    ZeroIdNullNameRecord,
                    MinusFifteenIdNullNameRecord,
                    PlusFifteenIdSomeStringNameRecord,
                    PlusFifteenIdLowerSomeStringNameRecord
                },
                1,
                new[]
                {
                    ZeroIdNullNameRecord,
                    PlusFifteenIdLowerSomeStringNameRecord,
                    PlusFifteenIdSomeStringNameRecord,
                    PlusFifteenIdLowerSomeStringNameRecord
                }
            }
        };
}