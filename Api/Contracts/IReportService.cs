using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Reporting and analytics (read side / views).</summary>
public interface IReportService
{
    Task<ApiResult<ReportDefinitionDto>> GetReportByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<ReportDefinitionDto>> GetReportsPageAsync(PagingRequest paging, Guid? tenantId, CancellationToken ct = default);
    Task<ApiResult<ReportResultDto>> RunReportAsync(Guid reportId, ReportParameters parameters, CancellationToken ct = default);
    Task<ApiResult<Stream>> ExportReportAsync(Guid reportId, ReportParameters parameters, string format, CancellationToken ct = default);
    Task<IdResult> CreateReportAsync(CreateReportRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateReportAsync(Guid id, UpdateReportRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteReportAsync(Guid id, CancellationToken ct = default);
    Task<ApiListResult<ReportDefinitionDto>> GetFavoritesAsync(Guid userId, CancellationToken ct = default);
    Task<ApiResult<bool>> ScheduleReportAsync(Guid reportId, ScheduleReportRequest schedule, CancellationToken ct = default);
    Task<PagedResult<ReportRunHistoryDto>> GetRunHistoryAsync(Guid reportId, PagingRequest paging, CancellationToken ct = default);
}

public record ReportDefinitionDto(Guid Id, string Name, string? Description, string QueryOrStoredProc, Guid TenantId);
public record ReportResultDto(IReadOnlyList<ReportColumnDto> Columns, IReadOnlyList<object[]> Rows);
public record ReportColumnDto(string Name, string Type);
public record ReportParameters(IReadOnlyDictionary<string, object?> Values);
public record CreateReportRequest(string Name, string? Description, string QueryOrStoredProc, Guid TenantId);
public record UpdateReportRequest(string? Name, string? Description, string? QueryOrStoredProc);
public record ScheduleReportRequest(string CronExpression, string[] Recipients, string Format);
public record ReportRunHistoryDto(Guid Id, DateTime RunAt, Guid RunBy, string Status);
