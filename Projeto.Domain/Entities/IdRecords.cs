namespace Projeto.Domain;
public abstract record IdRecord(Guid Guid);

public static class GuidExtensions
{
    public static T ToType<T>(this Guid guid) where T : IdRecord?
        => (Activator.CreateInstance(typeof(T), guid) as T)!;

    public static T? ToNullType<T>(this Guid? guid) where T : IdRecord
        => guid.HasValue ? Activator.CreateInstance(typeof(T), guid.Value) as T : null;
}

public static class IdHelper
{
    public static T FromString<T>(string id) where T : IdRecord
    {
        if (Guid.TryParse(id, out var guid)) return guid.ToType<T>();
        else throw new AppDomainException($"string '{nameof(id)}' não é um uuid");
    }
}