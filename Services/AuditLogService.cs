using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class AuditLogService : IAuditLogService
{
    public Task<ApiResult<AuditLogDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AuditLogDto>(new AuditLogDto(id, "Create", "Asset", Guid.Empty, null, Guid.Empty, null, DateTime.UtcNow)));

    public Task<PagedResult<AuditLogDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? userId, string? entityType, DateTime? from, DateTime? to, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<AuditLogDto>(Array.Empty<AuditLogDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiListResult<AuditLogDto>> GetByEntityAsync(string entityType, Guid entityId, int limit, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<AuditLogDto>(Array.Empty<AuditLogDto>()));

    public Task<ApiResult<bool>> ExportAsync(ExportAuditRequest request, Stream destination, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<AuditSummaryDto>> GetSummaryAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AuditSummaryDto>(new AuditSummaryDto(0, new Dictionary<string, int>(), new Dictionary<string, int>())));

    public Task<ApiResult<bool>> ArchiveAsync(DateTime before, string destinationPath, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
