using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConfigurationController(IConfigurationService service) : ControllerBase
{
    [HttpGet("{key}")]
    public Task<ApiResult<ConfigDto>> GetByKey(string key, [FromQuery] Guid? tenantId, CancellationToken ct) => service.GetByKeyAsync(key, tenantId, ct);

    [HttpGet]
    public Task<ApiListResult<ConfigDto>> GetAll([FromQuery] Guid? tenantId, [FromQuery] string? prefix, CancellationToken ct) => service.GetAllAsync(tenantId, prefix, ct);

    [HttpPut]
    public Task<ApiResult<bool>> Set([FromBody] SetConfigRequest request, CancellationToken ct) => service.SetAsync(request, ct);

    [HttpDelete("{key}")]
    public Task<ApiResult<bool>> Delete(string key, [FromQuery] Guid? tenantId, CancellationToken ct) => service.DeleteAsync(key, tenantId, ct);

    [HttpGet("feature-flags/{name}")]
    public Task<ApiResult<bool>> GetFeatureFlag(string name, [FromQuery] Guid? tenantId, CancellationToken ct) => service.GetFeatureFlagAsync(name, tenantId, ct);

    [HttpPut("feature-flags/{name}")]
    public Task<ApiResult<bool>> SetFeatureFlag(string name, [FromQuery] bool enabled, [FromQuery] Guid? tenantId, CancellationToken ct) =>
        service.SetFeatureFlagAsync(name, enabled, tenantId, ct);

    [HttpGet("feature-flags")]
    public Task<ApiListResult<FeatureFlagDto>> GetFeatureFlags([FromQuery] Guid? tenantId, CancellationToken ct) => service.GetFeatureFlagsAsync(tenantId, ct);
}
