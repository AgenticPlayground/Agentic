using System.Collections.Concurrent;

namespace WebApi.Features.Principles.Domain;

public interface IPrincipleRepository
{
    void Add(Principle principle);
    Task<Principle?> GetOrDefault(PrincipleId id, CancellationToken cancellationToken);
    Task<Principle> Get(PrincipleId id, CancellationToken cancellationToken);
    Task<Principle[]> GetAll(CancellationToken cancellationToken);
    void Delete(PrincipleId id);
    void Update(Principle principle);
}

public class InMemoryPrincipleRepository : IPrincipleRepository
{
    private readonly ConcurrentDictionary<PrincipleId, Principle> _principles = new();

    public void Add(Principle principle)
    {
        if (!_principles.TryAdd(principle.Id, principle))
            throw new InvalidOperationException($"Principle with id {principle.Id} already exists.");
    }

    public Task<Principle?> GetOrDefault(PrincipleId id, CancellationToken cancellationToken)
    {
        _principles.TryGetValue(id, out var principle);
        return Task.FromResult(principle);
    }

    public Task<Principle> Get(PrincipleId id, CancellationToken cancellationToken)
    {
        if (_principles.TryGetValue(id, out var principle))
            return Task.FromResult(principle);
        throw new KeyNotFoundException($"Principle with id {id} not found.");
    }

    public Task<Principle[]> GetAll(CancellationToken cancellationToken)
    {
        return Task.FromResult(_principles.Values.ToArray());
    }

    public void Delete(PrincipleId id)
    {
        if (!_principles.TryRemove(id, out _))
            throw new KeyNotFoundException($"Principle with id {id} not found.");
    }

    public void Update(Principle principle)
    {
        if (!_principles.ContainsKey(principle.Id))
            throw new KeyNotFoundException($"Principle with id {principle.Id} not found.");
        _principles[principle.Id] = principle;
    }
}