using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Admin and bulk operations.</summary>
public interface IAdminService
{
    Task<ApiResult<BulkOperationDto>> StartBulkOperationAsync(BulkOperationRequest request, CancellationToken ct = default);
    Task<ApiResult<BulkOperationDto>> GetBulkOperationAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<BulkOperationDto>> GetBulkOperationsPageAsync(PagingRequest paging, Guid? tenantId, CancellationToken ct = default);
    Task<ApiResult<bool>> CancelBulkOperationAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<SystemStatsDto>> GetSystemStatsAsync(CancellationToken ct = default);
    Task<ApiResult<TenantStatsDto>> GetTenantStatsAsync(Guid tenantId, CancellationToken ct = default);
    Task<ApiResult<bool>> ClearCacheAsync(string? keyPrefix, CancellationToken ct = default);
    Task<ApiResult<bool>> ReindexAsync(string indexName, CancellationToken ct = default);
    Task<ApiResult<bool>> RunMigrationAsync(string migrationName, CancellationToken ct = default);
    Task<ApiResult<AdminExportJobDto>> StartDataExportAsync(DataExportRequest request, CancellationToken ct = default);
    Task<ApiResult<AdminExportJobDto>> GetExportJobAsync(Guid jobId, CancellationToken ct = default);
    Task<ApiResult<bool>> PurgeAuditLogsAsync(Guid tenantId, DateTime before, CancellationToken ct = default);
}

public record BulkOperationDto(Guid Id, string Type, string Status, int Total, int Processed, DateTime StartedAt);
public record BulkOperationRequest(string Type, IReadOnlyDictionary<string, object?> Parameters);
public record SystemStatsDto(int TenantCount, int UserCount, int AssetCount, long StorageBytes);
public record TenantStatsDto(Guid TenantId, int UserCount, int AssetCount, long StorageBytes);
public record AdminExportJobDto(Guid Id, string Status, DateTime StartedAt, DateTime? CompletedAt);
public record DataExportRequest(Guid TenantId, string Format, DateTime? From, DateTime? To);
