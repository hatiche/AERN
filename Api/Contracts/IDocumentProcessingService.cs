using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Document processing: OCR, virus scan, thumbnails.</summary>
public interface IDocumentProcessingService
{
    Task<ApiResult<ProcessingJobDto>> SubmitAsync(Guid documentId, ProcessingOptions options, CancellationToken ct = default);
    Task<ApiResult<ProcessingJobDto>> GetJobAsync(Guid jobId, CancellationToken ct = default);
    Task<PagedResult<ProcessingJobDto>> GetJobsByDocumentAsync(Guid documentId, PagingRequest paging, CancellationToken ct = default);
    Task<ApiResult<bool>> CancelJobAsync(Guid jobId, CancellationToken ct = default);
    Task<ApiResult<OcrResultDto>> GetOcrResultAsync(Guid documentId, CancellationToken ct = default);
    Task<ApiResult<ScanResultDto>> GetScanResultAsync(Guid documentId, CancellationToken ct = default);
    Task<ApiResult<ThumbnailDto>> GetThumbnailAsync(Guid documentId, int width, int height, CancellationToken ct = default);
}

public record ProcessingJobDto(Guid Id, Guid DocumentId, string Status, string? Error, DateTime CreatedAt, DateTime? CompletedAt);
public record ProcessingOptions(bool RunOcr, bool RunVirusScan, bool GenerateThumbnail);
public record OcrResultDto(string Text, IReadOnlyList<OcrBlockDto> Blocks);
public record OcrBlockDto(string Text, double X, double Y, double Width, double Height);
public record ScanResultDto(bool IsClean, string? ThreatType);
public record ThumbnailDto(Stream Content, string ContentType);
