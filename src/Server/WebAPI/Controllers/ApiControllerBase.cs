using ExampleProject.Server.WebAPI.Common.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Server.WebAPI.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private Mediator.Mediator _mediator = null!;
    protected Mediator.Mediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<Mediator.Mediator>();
}
