using MediatR;
using Microsoft.AspNetCore.Mvc;
using poc.Application.User.Queries;
using poc.Domain.Enums;
using poc.webapi.Authorization;

namespace poc.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UserController(ISender sender) : ControllerBase
{
    [HttpGet]
    [Authorize(Permissions.ViewUsers | Permissions.ManageUsers)]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken = default)
    {
        var query = new GetUsersQuery();
        var result = await sender.Send(query, cancellationToken);
        
        return Ok(result.Value);
    }
}