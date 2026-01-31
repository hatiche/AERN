using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Audit logs and compliance.</summary>
public interface IAuditLogService
{
    Task<ApiResult<AuditLogDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<AuditLogDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? userId, string? entityType, DateTime? from, DateTime? to, CancellationToken ct = default);
    Task<ApiListResult<AuditLogDto>> GetByEntityAsync(string entityType, Guid entityId, int limit, CancellationToken ct = default);
    Task<ApiResult<bool>> ExportAsync(ExportAuditRequest request, Stream destination, CancellationToken ct = default);
    Task<ApiResult<AuditSummaryDto>> GetSummaryAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default);
    Task<ApiResult<bool>> ArchiveAsync(DateTime before, string destinationPath, CancellationToken ct = default);
}

public record AuditLogDto(Guid Id, string Action, string EntityType, Guid EntityId, Guid? UserId, Guid TenantId, string? Changes, DateTime TimestampUtc);
public record ExportAuditRequest(Guid? TenantId, DateTime From, DateTime To, string Format);
public record AuditSummaryDto(int TotalCount, IReadOnlyDictionary<string, int> ByAction, IReadOnlyDictionary<string, int> ByEntityType);
