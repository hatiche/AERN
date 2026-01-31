using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>System and tenant configuration.</summary>
public interface IConfigurationService
{
    Task<ApiResult<ConfigDto>> GetByKeyAsync(string key, Guid? tenantId, CancellationToken ct = default);
    Task<ApiListResult<ConfigDto>> GetAllAsync(Guid? tenantId, string? prefix, CancellationToken ct = default);
    Task<ApiResult<bool>> SetAsync(SetConfigRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(string key, Guid? tenantId, CancellationToken ct = default);
    Task<ApiResult<bool>> GetFeatureFlagAsync(string name, Guid? tenantId, CancellationToken ct = default);
    Task<ApiResult<bool>> SetFeatureFlagAsync(string name, bool enabled, Guid? tenantId, CancellationToken ct = default);
    Task<ApiListResult<FeatureFlagDto>> GetFeatureFlagsAsync(Guid? tenantId, CancellationToken ct = default);
}

public record ConfigDto(string Key, string Value, Guid? TenantId);
public record SetConfigRequest(string Key, string Value, Guid? TenantId);
public record FeatureFlagDto(string Name, bool Enabled, Guid? TenantId);
