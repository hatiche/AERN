using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class ReportService : IReportService
{
    public Task<ApiResult<ReportDefinitionDto>> GetReportByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ReportDefinitionDto>(new ReportDefinitionDto(id, "Report", null, "SELECT 1", Guid.Empty)));

    public Task<PagedResult<ReportDefinitionDto>> GetReportsPageAsync(PagingRequest paging, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<ReportDefinitionDto>(Array.Empty<ReportDefinitionDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<ReportResultDto>> RunReportAsync(Guid reportId, ReportParameters parameters, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ReportResultDto>(new ReportResultDto(Array.Empty<ReportColumnDto>(), Array.Empty<object[]>())));

    public Task<ApiResult<Stream>> ExportReportAsync(Guid reportId, ReportParameters parameters, string format, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<Stream>(Stream.Null));

    public Task<IdResult> CreateReportAsync(CreateReportRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateReportAsync(Guid id, UpdateReportRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteReportAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<ReportDefinitionDto>> GetFavoritesAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<ReportDefinitionDto>(Array.Empty<ReportDefinitionDto>()));

    public Task<ApiResult<bool>> ScheduleReportAsync(Guid reportId, ScheduleReportRequest schedule, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<PagedResult<ReportRunHistoryDto>> GetRunHistoryAsync(Guid reportId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<ReportRunHistoryDto>(Array.Empty<ReportRunHistoryDto>(), 0, paging.Page, paging.PageSize));
}
