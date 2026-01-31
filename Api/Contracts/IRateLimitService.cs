using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Rate limiting and quotas (security firewall).</summary>
public interface IRateLimitService
{
    Task<ApiResult<RateLimitStatusDto>> GetStatusAsync(string? key, CancellationToken ct = default);
    Task<ApiResult<bool>> CheckAsync(string key, string policy, CancellationToken ct = default);
    Task<ApiResult<bool>> ResetAsync(string key, CancellationToken ct = default);
    Task<ApiListResult<RateLimitPolicyDto>> GetPoliciesAsync(CancellationToken ct = default);
    Task<ApiResult<bool>> SetPolicyAsync(string name, RateLimitPolicyDto policy, CancellationToken ct = default);
}

public record RateLimitStatusDto(string Key, int Remaining, int Limit, DateTime? ResetAt);
public record RateLimitPolicyDto(string Name, int PermitLimit, TimeSpan Window, string? PartitionKey);
