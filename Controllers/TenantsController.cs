using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TenantsController(ITenantService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<TenantDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<TenantDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), ct);

    [HttpGet("all")]
    public Task<ApiListResult<TenantDto>> GetAll(CancellationToken ct) => service.GetAllAsync(ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateTenantRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateTenantRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpGet("{tenantId:guid}/settings")]
    public Task<ApiResult<TenantSettingsDto>> GetSettings(Guid tenantId, CancellationToken ct) => service.GetSettingsAsync(tenantId, ct);

    [HttpPut("{tenantId:guid}/settings")]
    public Task<ApiResult<bool>> UpdateSettings(Guid tenantId, [FromBody] TenantSettingsDto settings, CancellationToken ct) => service.UpdateSettingsAsync(tenantId, settings, ct);

    [HttpGet("{tenantId:guid}/quota")]
    public Task<ApiResult<TenantQuotaDto>> GetQuota(Guid tenantId, CancellationToken ct) => service.GetQuotaAsync(tenantId, ct);

    [HttpPut("{tenantId:guid}/quota")]
    public Task<ApiResult<bool>> SetQuota(Guid tenantId, [FromBody] TenantQuotaDto quota, CancellationToken ct) => service.SetQuotaAsync(tenantId, quota, ct);
}
