using Agentic.WebApi.Features.Principles.Domain;
using Agentic.WebApi.Features.Principles.UseCases;
using Agentic.WebApi.Shared.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agentic.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PrinciplesController(IMediator mediator) : ControllerBase
    {
        // DTOs
        public record CreatePrincipleRequest(string Name, string Description, long UserId);

        [HttpPost]
        public async Task<long> Create([FromBody] CreatePrincipleRequest request)
        {
            // Sample UserId
            var currentUserId = UserId.Parse(1);
            var response = await mediator.Send(new CreatePrinciple.Request(
                PrincipleName.Create(request.Name),
                PrincipleDescription.Create(request.Description),
                currentUserId));

            return response.Value;
        }
    }
}