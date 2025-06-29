using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace WebApi.Shared.Domain;

[DebuggerDisplay("{Value}")]
public abstract record StronglyTypedId<T>(long Value) : SingleValueObject<T, long>(Value)
    where T : StronglyTypedId<T>
{
    public static T NewId()
    {
        var id = IdGenerator.NewId();
        return FromLong(id);
    }

    public static bool TryParse(string? value, [NotNullWhen(true)] out T? result)
    {
        if (value is null)
        {
            result = null;
            return false;
        }

        if (!long.TryParse(value, out var parsedValue))
        {
            result = null;
            return false;
        }

        result = FromLong(parsedValue);
        return true;
    }

    public static T Parse(long value) => FromLong(value);
    public static T Parse(string value) => Parse(long.Parse(value));

    private static T FromLong(long newValue)
    {
        return (T)Activator.CreateInstance(
            typeof(T),
            BindingFlags.Instance | BindingFlags.Public,
            null,
            [newValue],
            null
        )!;
    }
}