namespace Agentic.WebApi.Features.Principles.Domain;

public sealed record PrincipleName
{
    public string Value { get; }
    private PrincipleName(string value) => Value = value;
    public static PrincipleName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name is required.");
        if (value.Length > 200) throw new ArgumentException("Name cannot exceed 200 characters.");
        return new PrincipleName(value);
    }
}