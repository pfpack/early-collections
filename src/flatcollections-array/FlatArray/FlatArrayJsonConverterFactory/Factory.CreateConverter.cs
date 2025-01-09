using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System;

partial class FlatArrayJsonConverterFactory
{
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        =>
        (JsonConverter?)Activator.CreateInstance(
            type: typeof(FlatArray<>.JsonConverter).MakeGenericType(typeToConvert.GetGenericArguments()[0]),
            bindingAttr: BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance,
            binder: null,
            args: [options],
            culture: null);
}
