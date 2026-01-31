using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Roles and permissions.</summary>
public interface IRoleService
{
    Task<ApiResult<RoleDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<RoleDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, CancellationToken ct = default);
    Task<ApiListResult<RoleDto>> GetAllByTenantAsync(Guid tenantId, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateRoleRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateRoleRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiListResult<string>> GetPermissionsAsync(Guid roleId, CancellationToken ct = default);
    Task<ApiResult<bool>> SetPermissionsAsync(Guid roleId, IEnumerable<string> permissions, CancellationToken ct = default);
}

public record RoleDto(Guid Id, string Name, string? Description, Guid TenantId);
public record CreateRoleRequest(string Name, string? Description, Guid TenantId);
public record UpdateRoleRequest(string? Name, string? Description);
