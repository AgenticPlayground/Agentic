using Agentic.WebApi.Shared.Domain;

namespace Agentic.WebApi.Features.Principles.Domain;

public sealed record PrincipleId(long Value) : StronglyTypedId<PrincipleId>(Value);