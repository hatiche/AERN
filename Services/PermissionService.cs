using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class PermissionService : IPermissionService
{
    public Task<ApiListResult<PermissionDto>> GetAllAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<PermissionDto>(Array.Empty<PermissionDto>()));

    public Task<ApiResult<PermissionDto>> GetByIdAsync(string id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<PermissionDto>(new PermissionDto(id, id, null, null)));

    public Task<ApiListResult<string>> GetUserPermissionsAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<string>(Array.Empty<string>()));

    public Task<ApiResult<bool>> HasPermissionAsync(Guid userId, string permission, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(false));

    public Task<ApiResult<bool>> GrantAsync(Guid userId, string permission, string? resourceType, Guid? resourceId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> RevokeAsync(Guid userId, string permission, string? resourceType, Guid? resourceId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<PermissionDto>> GetByResourceTypeAsync(string resourceType, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<PermissionDto>(Array.Empty<PermissionDto>()));
}
