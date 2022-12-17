using System.Diagnostics;
using System.Text.Json;

namespace System;

partial struct FlatArray<T>
{
    partial class JsonConverter
    {
        public override void Write(Utf8JsonWriter writer, FlatArray<T> value, JsonSerializerOptions options)
        {
            Debug.Assert(writer is not null);
            Debug.Assert(options is not null);

            writer.WriteStartArray();

            for (int i = 0; i < value.length; i++)
            {
                itemConverter.Write(writer, value.items![i], options);
            }

            writer.WriteEndArray();
        }
    }
}
