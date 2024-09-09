using MediatR;
using Microsoft.AspNetCore.Mvc;
using poc.Application.Roles.Commands;
using poc.Application.Roles.Queries;
using poc.Contracts.Requests;
using poc.Domain.Enums;
using poc.webapi.Authorization;

namespace poc.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class RoleController(ISender sender) : ControllerBase
{
    [HttpGet]
    [Authorize(Permissions.ManageRoles | Permissions.ViewRoles | Permissions.ViewAccessControl)]
    public async Task<IActionResult> GetRoles(CancellationToken cancellationToken = default)
    {
        var query = new GetRolesQuery();
        var result = await sender.Send(query, cancellationToken);
        
        return Ok(result.Value);
    }
    
    [HttpPost]
    [Authorize(Permissions.ManageRoles)]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request, CancellationToken cancellationToken = default)
    {
        var command = new CreateRoleCommand(request.Name, request.Permissions);
        var result = await sender.Send(command, cancellationToken);

        return Ok(result.Value);
    }
}