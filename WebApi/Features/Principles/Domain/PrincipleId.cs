using WebApi.Shared.Domain;

namespace WebApi.Features.Principles.Domain;

public sealed record PrincipleId(long Value) : StronglyTypedId<PrincipleId>(Value);