using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class ConfigurationService : IConfigurationService
{
    public Task<ApiResult<ConfigDto>> GetByKeyAsync(string key, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ConfigDto>(new ConfigDto(key, "", tenantId)));

    public Task<ApiListResult<ConfigDto>> GetAllAsync(Guid? tenantId, string? prefix, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<ConfigDto>(Array.Empty<ConfigDto>()));

    public Task<ApiResult<bool>> SetAsync(SetConfigRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(string key, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> GetFeatureFlagAsync(string name, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(false));

    public Task<ApiResult<bool>> SetFeatureFlagAsync(string name, bool enabled, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<FeatureFlagDto>> GetFeatureFlagsAsync(Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<FeatureFlagDto>(Array.Empty<FeatureFlagDto>()));
}
