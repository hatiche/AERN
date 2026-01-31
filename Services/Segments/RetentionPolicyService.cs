using AERN.Api.Contracts.Segments;
using AERN.Api.Models;

namespace AERN.Services.Segments;

public sealed class RetentionPolicyService : IRetentionPolicyService
{
    public Task<ApiResult<RetentionPolicyDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<RetentionPolicyDto>(new RetentionPolicyDto(id, "Audit", "AuditLog", 365, null, Guid.Empty, true)));

    public Task<PagedResult<RetentionPolicyDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? entityType, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<RetentionPolicyDto>(Array.Empty<RetentionPolicyDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateRetentionPolicyRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateRetentionPolicyRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<ArchiveJobDto>> StartArchiveJobAsync(Guid policyId, DateTime? asOfDate, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ArchiveJobDto>(new ArchiveJobDto(Guid.NewGuid(), policyId, "Running", 0, DateTime.UtcNow, null)));

    public Task<ApiResult<ArchiveJobDto>> GetArchiveJobAsync(Guid jobId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ArchiveJobDto>(new ArchiveJobDto(jobId, Guid.Empty, "Completed", 100, DateTime.UtcNow, DateTime.UtcNow)));

    public Task<PagedResult<ArchiveJobDto>> GetArchiveJobsAsync(Guid policyId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<ArchiveJobDto>(Array.Empty<ArchiveJobDto>(), 0, paging.Page, paging.PageSize));
}
