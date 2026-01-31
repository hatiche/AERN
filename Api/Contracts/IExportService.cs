using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Data export and bulk download.</summary>
public interface IExportService
{
    Task<ApiResult<ExportJobDto>> StartExportAsync(StartExportRequest request, CancellationToken ct = default);
    Task<ApiResult<ExportJobDto>> GetExportJobAsync(Guid jobId, CancellationToken ct = default);
    Task<PagedResult<ExportJobDto>> GetExportJobsPageAsync(PagingRequest paging, Guid? tenantId, Guid? userId, CancellationToken ct = default);
    Task<ApiResult<Stream>> DownloadExportAsync(Guid jobId, CancellationToken ct = default);
    Task<ApiResult<bool>> CancelExportAsync(Guid jobId, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteExportAsync(Guid jobId, CancellationToken ct = default);
    Task<ApiListResult<ExportTemplateDto>> GetTemplatesAsync(Guid tenantId, CancellationToken ct = default);
    Task<IdResult> CreateTemplateAsync(CreateExportTemplateRequest request, CancellationToken ct = default);
}

public record ExportJobDto(Guid Id, string Type, string Status, string Format, Guid TenantId, Guid? UserId, DateTime StartedAt, DateTime? CompletedAt);
public record StartExportRequest(string Type, string Format, Guid TenantId, Guid? UserId, ExportFilters? Filters);
public record ExportFilters(DateTime? From, DateTime? To, Guid? AssetId, string? EntityType);
public record ExportTemplateDto(Guid Id, string Name, string Type, string Format, string? ConfigJson, Guid TenantId);
public record CreateExportTemplateRequest(string Name, string Type, string Format, string? ConfigJson, Guid TenantId);
