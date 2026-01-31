using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class AdminService : IAdminService
{
    public Task<ApiResult<BulkOperationDto>> StartBulkOperationAsync(BulkOperationRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<BulkOperationDto>(new BulkOperationDto(Guid.NewGuid(), request.Type, "Running", 0, 0, DateTime.UtcNow)));

    public Task<ApiResult<BulkOperationDto>> GetBulkOperationAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<BulkOperationDto>(new BulkOperationDto(id, "Export", "Completed", 100, 100, DateTime.UtcNow)));

    public Task<PagedResult<BulkOperationDto>> GetBulkOperationsPageAsync(PagingRequest paging, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<BulkOperationDto>(Array.Empty<BulkOperationDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<bool>> CancelBulkOperationAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<SystemStatsDto>> GetSystemStatsAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<SystemStatsDto>(new SystemStatsDto(0, 0, 0, 0)));

    public Task<ApiResult<TenantStatsDto>> GetTenantStatsAsync(Guid tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<TenantStatsDto>(new TenantStatsDto(tenantId, 0, 0, 0)));

    public Task<ApiResult<bool>> ClearCacheAsync(string? keyPrefix, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> ReindexAsync(string indexName, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> RunMigrationAsync(string migrationName, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<AdminExportJobDto>> StartDataExportAsync(DataExportRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AdminExportJobDto>(new AdminExportJobDto(Guid.NewGuid(), "Running", DateTime.UtcNow, null)));

    public Task<ApiResult<AdminExportJobDto>> GetExportJobAsync(Guid jobId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AdminExportJobDto>(new AdminExportJobDto(jobId, "Completed", DateTime.UtcNow, DateTime.UtcNow)));

    public Task<ApiResult<bool>> PurgeAuditLogsAsync(Guid tenantId, DateTime before, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
