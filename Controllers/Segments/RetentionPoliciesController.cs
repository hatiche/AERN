using AERN.Api.Contracts.Segments;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers.Segments;

[ApiController]
[Route("api/segments/retention")]
public class RetentionPoliciesController(IRetentionPolicyService service) : ControllerBase
{
    [HttpGet("policies/{id:guid}")]
    public Task<ApiResult<RetentionPolicyDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet("policies")]
    public Task<PagedResult<RetentionPolicyDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? entityType = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, entityType, ct);

    [HttpPost("policies")]
    public Task<IdResult> Create([FromBody] CreateRetentionPolicyRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("policies/{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateRetentionPolicyRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("policies/{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpPost("policies/{policyId:guid}/archive")]
    public Task<ApiResult<ArchiveJobDto>> StartArchive(Guid policyId, [FromQuery] DateTime? asOfDate, CancellationToken ct) =>
        service.StartArchiveJobAsync(policyId, asOfDate, ct);

    [HttpGet("jobs/{jobId:guid}")]
    public Task<ApiResult<ArchiveJobDto>> GetJob(Guid jobId, CancellationToken ct) => service.GetArchiveJobAsync(jobId, ct);

    [HttpGet("policies/{policyId:guid}/jobs")]
    public Task<PagedResult<ArchiveJobDto>> GetJobs(Guid policyId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default) =>
        service.GetArchiveJobsAsync(policyId, new PagingRequest(page, pageSize), ct);
}
