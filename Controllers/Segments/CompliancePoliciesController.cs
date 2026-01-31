using AERN.Api.Contracts.Segments;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers.Segments;

[ApiController]
[Route("api/segments/compliance-policies")]
public class CompliancePoliciesController(ICompliancePolicyService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<CompliancePolicyDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<CompliancePolicyDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? category = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, category, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateCompliancePolicyRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateCompliancePolicyRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpPost("{policyId:guid}/run-check")]
    public Task<ApiResult<ComplianceCheckResultDto>> RunCheck(Guid policyId, [FromQuery] Guid? assetId, CancellationToken ct) => service.RunCheckAsync(policyId, assetId, ct);
}
