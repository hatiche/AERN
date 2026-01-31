using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class RoleService : IRoleService
{
    public Task<ApiResult<RoleDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<RoleDto>(new RoleDto(id, "Role", null, Guid.Empty)));

    public Task<PagedResult<RoleDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<RoleDto>(Array.Empty<RoleDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiListResult<RoleDto>> GetAllByTenantAsync(Guid tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<RoleDto>(Array.Empty<RoleDto>()));

    public Task<IdResult> CreateAsync(CreateRoleRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateRoleRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<string>> GetPermissionsAsync(Guid roleId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<string>(Array.Empty<string>()));

    public Task<ApiResult<bool>> SetPermissionsAsync(Guid roleId, IEnumerable<string> permissions, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
