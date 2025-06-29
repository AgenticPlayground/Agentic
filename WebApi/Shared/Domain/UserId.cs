namespace WebApi.Shared.Domain;

public sealed record UserId(long Value) : StronglyTypedId<UserId>(Value);
