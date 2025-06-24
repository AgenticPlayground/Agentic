namespace WebApi.Domain.Shared;

public sealed record UserId(long Value) : StronglyTypedId<UserId>(Value);
