using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RateLimitController(IRateLimitService service) : ControllerBase
{
    [HttpGet("status")]
    public Task<ApiResult<RateLimitStatusDto>> GetStatus([FromQuery] string? key, CancellationToken ct) => service.GetStatusAsync(key, ct);

    [HttpPost("check")]
    public Task<ApiResult<bool>> Check([FromQuery] string key, [FromQuery] string policy, CancellationToken ct) => service.CheckAsync(key, policy, ct);

    [HttpPost("reset")]
    public Task<ApiResult<bool>> Reset([FromQuery] string key, CancellationToken ct) => service.ResetAsync(key, ct);

    [HttpGet("policies")]
    public Task<ApiListResult<RateLimitPolicyDto>> GetPolicies(CancellationToken ct) => service.GetPoliciesAsync(ct);

    [HttpPut("policies/{name}")]
    public Task<ApiResult<bool>> SetPolicy(string name, [FromBody] RateLimitPolicyDto policy, CancellationToken ct) => service.SetPolicyAsync(name, policy, ct);
}
