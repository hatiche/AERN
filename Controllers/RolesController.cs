using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController(IRoleService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<RoleDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<RoleDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, ct);

    [HttpGet("tenant/{tenantId:guid}")]
    public Task<ApiListResult<RoleDto>> GetAllByTenant(Guid tenantId, CancellationToken ct) => service.GetAllByTenantAsync(tenantId, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateRoleRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateRoleRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpGet("{roleId:guid}/permissions")]
    public Task<ApiListResult<string>> GetPermissions(Guid roleId, CancellationToken ct) => service.GetPermissionsAsync(roleId, ct);

    [HttpPut("{roleId:guid}/permissions")]
    public Task<ApiResult<bool>> SetPermissions(Guid roleId, [FromBody] IEnumerable<string> permissions, CancellationToken ct) => service.SetPermissionsAsync(roleId, permissions, ct);
}
