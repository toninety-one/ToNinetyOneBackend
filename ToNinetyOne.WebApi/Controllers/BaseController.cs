using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.WebApi.Controllers;

/// <inheritdoc />
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    /// <summary>
    ///     Mediator
    /// </summary>
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>() ??
                                                  throw new NullReferenceException("Service not found");

    internal Guid UserId => User.Identity is { IsAuthenticated: false }
        ? Guid.Empty
        : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");

    internal string UserRole => User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value ??
                                throw new NotFoundException(nameof(User), "role");
}