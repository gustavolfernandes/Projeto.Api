using System.Text.Json.Serialization;
using System.Text.Json;

namespace Projeto.Domain;
public sealed class IdRecordConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert.BaseType == typeof(IdRecord);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>

        (Activator.CreateInstance(typeof(IdRecordConverterGeneric<>).MakeGenericType(typeToConvert)) as JsonConverter)!;
}

public class IdRecordConverterGeneric<TIdRecord> : JsonConverter<TIdRecord> where TIdRecord : IdRecord
{
    public override bool CanConvert(Type typeToConvert) => typeToConvert.BaseType == typeof(IdRecord);

    public override TIdRecord Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        object? id = null;
        if (reader.TryGetGuid(out var guid))
        {
            id = Activator.CreateInstance(typeToConvert, new object[] { guid });
        }

        return (id as TIdRecord)!;
    }

    public override void Write(Utf8JsonWriter writer, TIdRecord value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Guid.ToString());
    }
}