using AERN.Api.Models;

namespace AERN.Api.Contracts.Segments;

/// <summary>Segment: Data Retention &amp; Archive – retention policies and archive jobs.</summary>
public interface IRetentionPolicyService
{
    Task<ApiResult<RetentionPolicyDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<RetentionPolicyDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? entityType, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateRetentionPolicyRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateRetentionPolicyRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<ArchiveJobDto>> StartArchiveJobAsync(Guid policyId, DateTime? asOfDate, CancellationToken ct = default);
    Task<ApiResult<ArchiveJobDto>> GetArchiveJobAsync(Guid jobId, CancellationToken ct = default);
    Task<PagedResult<ArchiveJobDto>> GetArchiveJobsAsync(Guid policyId, PagingRequest paging, CancellationToken ct = default);
}

public record RetentionPolicyDto(Guid Id, string Name, string EntityType, int RetainDays, string? ArchiveTarget, Guid TenantId, bool IsActive);
public record CreateRetentionPolicyRequest(string Name, string EntityType, int RetainDays, string? ArchiveTarget, Guid TenantId);
public record UpdateRetentionPolicyRequest(string? Name, int? RetainDays, string? ArchiveTarget, bool? IsActive);
public record ArchiveJobDto(Guid Id, Guid PolicyId, string Status, int ProcessedCount, DateTime StartedAt, DateTime? CompletedAt);
