using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class ExportService : IExportService
{
    public Task<ApiResult<ExportJobDto>> StartExportAsync(StartExportRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ExportJobDto>(new ExportJobDto(Guid.NewGuid(), request.Type, "Running", request.Format, request.TenantId, request.UserId, DateTime.UtcNow, null)));

    public Task<ApiResult<ExportJobDto>> GetExportJobAsync(Guid jobId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ExportJobDto>(new ExportJobDto(jobId, "Export", "Completed", "csv", Guid.Empty, null, DateTime.UtcNow, DateTime.UtcNow)));

    public Task<PagedResult<ExportJobDto>> GetExportJobsPageAsync(PagingRequest paging, Guid? tenantId, Guid? userId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<ExportJobDto>(Array.Empty<ExportJobDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<Stream>> DownloadExportAsync(Guid jobId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<Stream>(Stream.Null));

    public Task<ApiResult<bool>> CancelExportAsync(Guid jobId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteExportAsync(Guid jobId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<ExportTemplateDto>> GetTemplatesAsync(Guid tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<ExportTemplateDto>(Array.Empty<ExportTemplateDto>()));

    public Task<IdResult> CreateTemplateAsync(CreateExportTemplateRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));
}
