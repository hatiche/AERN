using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Claims-based permissions.</summary>
public interface IPermissionService
{
    Task<ApiListResult<PermissionDto>> GetAllAsync(CancellationToken ct = default);
    Task<ApiResult<PermissionDto>> GetByIdAsync(string id, CancellationToken ct = default);
    Task<ApiListResult<string>> GetUserPermissionsAsync(Guid userId, CancellationToken ct = default);
    Task<ApiResult<bool>> HasPermissionAsync(Guid userId, string permission, CancellationToken ct = default);
    Task<ApiResult<bool>> GrantAsync(Guid userId, string permission, string? resourceType, Guid? resourceId, CancellationToken ct = default);
    Task<ApiResult<bool>> RevokeAsync(Guid userId, string permission, string? resourceType, Guid? resourceId, CancellationToken ct = default);
    Task<ApiListResult<PermissionDto>> GetByResourceTypeAsync(string resourceType, CancellationToken ct = default);
}

public record PermissionDto(string Id, string Name, string? Description, string? ResourceType);
