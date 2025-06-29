namespace WebApi.Features.Principles.Domain;

public sealed record PrincipleDescription
{
    public string Value { get; }
    private PrincipleDescription(string value) => Value = value;
    public static PrincipleDescription Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Description is required.");
        return new PrincipleDescription(value);
    }
}