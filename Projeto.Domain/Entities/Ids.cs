using System.Text.Json.Serialization;

namespace Projeto.Domain;
[JsonConverter(typeof(IdRecordConverterFactory))]
public sealed record ProductId(Guid Guid) : IdRecord(Guid);

