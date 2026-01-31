using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class RateLimitService : IRateLimitService
{
    public Task<ApiResult<RateLimitStatusDto>> GetStatusAsync(string? key, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<RateLimitStatusDto>(new RateLimitStatusDto(key ?? "", 100, 100, null)));

    public Task<ApiResult<bool>> CheckAsync(string key, string policy, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> ResetAsync(string key, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<RateLimitPolicyDto>> GetPoliciesAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<RateLimitPolicyDto>(Array.Empty<RateLimitPolicyDto>()));

    public Task<ApiResult<bool>> SetPolicyAsync(string name, RateLimitPolicyDto policy, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
