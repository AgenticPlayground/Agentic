using MediatR;
using WebApi.Features.Principles.Domain;
using WebApi.Shared.Domain;

namespace WebApi.Features.Principles.UseCases;

public static class CreatePrinciple
{
    public record Request(PrincipleName Name, PrincipleDescription Description, UserId UserId) 
        : IRequest<PrincipleId>;

    public class Handler(IPrincipleRepository repository) 
        : IRequestHandler<Request, PrincipleId>
    {
        public Task<PrincipleId> Handle(Request request, CancellationToken cancellationToken)
        {
            var principle = Principle.Create(
                request.Name,
                request.Description,
                request.UserId);

            repository.Add(principle);
            return Task.FromResult(principle.Id);
        }
    }
}