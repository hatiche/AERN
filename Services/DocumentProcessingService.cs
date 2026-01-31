using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class DocumentProcessingService : IDocumentProcessingService
{
    public Task<ApiResult<ProcessingJobDto>> SubmitAsync(Guid documentId, ProcessingOptions options, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ProcessingJobDto>(new ProcessingJobDto(Guid.NewGuid(), documentId, "Pending", null, DateTime.UtcNow, null)));

    public Task<ApiResult<ProcessingJobDto>> GetJobAsync(Guid jobId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ProcessingJobDto>(new ProcessingJobDto(jobId, Guid.Empty, "Completed", null, DateTime.UtcNow, DateTime.UtcNow)));

    public Task<PagedResult<ProcessingJobDto>> GetJobsByDocumentAsync(Guid documentId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<ProcessingJobDto>(Array.Empty<ProcessingJobDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<bool>> CancelJobAsync(Guid jobId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<OcrResultDto>> GetOcrResultAsync(Guid documentId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<OcrResultDto>(new OcrResultDto("", Array.Empty<OcrBlockDto>())));

    public Task<ApiResult<ScanResultDto>> GetScanResultAsync(Guid documentId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ScanResultDto>(new ScanResultDto(true, null)));

    public Task<ApiResult<ThumbnailDto>> GetThumbnailAsync(Guid documentId, int width, int height, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ThumbnailDto>(new ThumbnailDto(Stream.Null, "image/png")));
}
