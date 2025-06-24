using WebApi.Domain.Shared;

namespace WebApi.Domain.Principles
{
    public sealed record PrincipleId(long Value) : StronglyTypedId<PrincipleId>(Value);

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

    public class Principle
    {
        public PrincipleId Id { get; }
        public PrincipleName Name { get; }
        public PrincipleDescription Description { get; }
        public UserId UserId { get; }

        private Principle(PrincipleId id, PrincipleName name, PrincipleDescription description, UserId userId)
        {
            Id = id;
            Name = name;
            Description = description;
            UserId = userId;
        }

        public static Principle Create(PrincipleId id, PrincipleName name, PrincipleDescription description, UserId userId)
            => new(id, name, description, userId);
    }
}
