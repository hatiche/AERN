using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController(IPermissionService service) : ControllerBase
{
    [HttpGet]
    public Task<ApiListResult<PermissionDto>> GetAll(CancellationToken ct) => service.GetAllAsync(ct);

    [HttpGet("{id}")]
    public Task<ApiResult<PermissionDto>> GetById(string id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet("user/{userId:guid}")]
    public Task<ApiListResult<string>> GetUserPermissions(Guid userId, CancellationToken ct) => service.GetUserPermissionsAsync(userId, ct);

    [HttpGet("user/{userId:guid}/has")]
    public Task<ApiResult<bool>> HasPermission(Guid userId, [FromQuery] string permission, CancellationToken ct) => service.HasPermissionAsync(userId, permission, ct);

    [HttpPost("user/{userId:guid}/grant")]
    public Task<ApiResult<bool>> Grant(Guid userId, [FromQuery] string permission, [FromQuery] string? resourceType, [FromQuery] Guid? resourceId, CancellationToken ct) =>
        service.GrantAsync(userId, permission, resourceType, resourceId, ct);

    [HttpPost("user/{userId:guid}/revoke")]
    public Task<ApiResult<bool>> Revoke(Guid userId, [FromQuery] string permission, [FromQuery] string? resourceType, [FromQuery] Guid? resourceId, CancellationToken ct) =>
        service.RevokeAsync(userId, permission, resourceType, resourceId, ct);

    [HttpGet("resource-type/{resourceType}")]
    public Task<ApiListResult<PermissionDto>> GetByResourceType(string resourceType, CancellationToken ct) => service.GetByResourceTypeAsync(resourceType, ct);
}
