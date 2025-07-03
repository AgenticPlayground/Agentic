using WebApi.Shared.Domain;

namespace WebApi.Features.Principles.Domain
{
    public class Principle
    {
        public PrincipleId Id { get; }
        public PrincipleName Name { get; }
        public PrincipleDescription Description { get; }
        public UserId UserId { get; }

        public Principle(PrincipleId id, PrincipleName name, PrincipleDescription description, UserId userId)
            : this(id, name, description, userId) { }

        private Principle(PrincipleId id, PrincipleName name, PrincipleDescription description, UserId userId)
        {
            Id = id;
            Name = name;
            Description = description;
            UserId = userId;
        }

        public static Principle Create(PrincipleName name, PrincipleDescription description, UserId userId)
            => new(PrincipleId.NewId(), name, description, userId);
    }
}
