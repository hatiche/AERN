using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<UserDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<UserDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, ct);

    [HttpGet("by-email/{email}")]
    public Task<ApiResult<UserDto>> GetByEmail(string email, CancellationToken ct) => service.GetByEmailAsync(email, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateUserRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateUserRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpPost("{userId:guid}/password")]
    public Task<ApiResult<bool>> SetPassword(Guid userId, [FromBody] SetPasswordRequest request, CancellationToken ct) => service.SetPasswordAsync(userId, request, ct);

    [HttpPost("{userId:guid}/lock")]
    public Task<ApiResult<bool>> Lock(Guid userId, [FromQuery] DateTime? until, CancellationToken ct) => service.LockAsync(userId, until, ct);

    [HttpPost("{userId:guid}/unlock")]
    public Task<ApiResult<bool>> Unlock(Guid userId, CancellationToken ct) => service.UnlockAsync(userId, ct);

    [HttpGet("{userId:guid}/roles")]
    public Task<ApiListResult<RoleDto>> GetRoles(Guid userId, CancellationToken ct) => service.GetRolesAsync(userId, ct);

    [HttpPut("{userId:guid}/roles")]
    public Task<ApiResult<bool>> AssignRoles(Guid userId, [FromBody] IEnumerable<Guid> roleIds, CancellationToken ct) => service.AssignRolesAsync(userId, roleIds, ct);
}
