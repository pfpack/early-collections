using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System.Collections.Generic;

internal sealed partial class FlatArrayJsonConverter<T> : JsonConverter<FlatArray<T>>
{
    private readonly JsonConverter<T> itemConverter;

    public FlatArrayJsonConverter(JsonSerializerOptions options)
    {
        Debug.Assert(options is not null);

        itemConverter = (JsonConverter<T>)options.GetConverter(InnerItemType.Value);
    }
}
