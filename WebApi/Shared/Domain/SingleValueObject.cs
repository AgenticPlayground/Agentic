using System.Diagnostics;

namespace Agentic.WebApi.Shared.Domain;

[DebuggerDisplay("{Value}")]
public abstract record SingleValueObject<T, TValue>(TValue Value)
    where T : SingleValueObject<T, TValue> where TValue : IComparable<TValue>
{

    public static implicit operator TValue(SingleValueObject<T, TValue> valueObject)
    {
        return valueObject.Value;
    }

    public sealed override string ToString()
    {
        return Value.ToString() ??
               throw new UnreachableException($"Type {typeof(TValue)} ToString returned a null value.");
    }
}