using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentProcessingController(IDocumentProcessingService service) : ControllerBase
{
    [HttpPost("submit")]
    public Task<ApiResult<ProcessingJobDto>> Submit([FromQuery] Guid documentId, [FromBody] ProcessingOptions options, CancellationToken ct) => service.SubmitAsync(documentId, options, ct);

    [HttpGet("jobs/{jobId:guid}")]
    public Task<ApiResult<ProcessingJobDto>> GetJob(Guid jobId, CancellationToken ct) => service.GetJobAsync(jobId, ct);

    [HttpGet("documents/{documentId:guid}/jobs")]
    public Task<PagedResult<ProcessingJobDto>> GetJobsByDocument(Guid documentId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default) =>
        service.GetJobsByDocumentAsync(documentId, new PagingRequest(page, pageSize), ct);

    [HttpPost("jobs/{jobId:guid}/cancel")]
    public Task<ApiResult<bool>> CancelJob(Guid jobId, CancellationToken ct) => service.CancelJobAsync(jobId, ct);

    [HttpGet("documents/{documentId:guid}/ocr")]
    public Task<ApiResult<OcrResultDto>> GetOcrResult(Guid documentId, CancellationToken ct) => service.GetOcrResultAsync(documentId, ct);

    [HttpGet("documents/{documentId:guid}/scan")]
    public Task<ApiResult<ScanResultDto>> GetScanResult(Guid documentId, CancellationToken ct) => service.GetScanResultAsync(documentId, ct);

    [HttpGet("documents/{documentId:guid}/thumbnail")]
    public Task<ApiResult<ThumbnailDto>> GetThumbnail(Guid documentId, [FromQuery] int width = 200, [FromQuery] int height = 200, CancellationToken ct = default) =>
        service.GetThumbnailAsync(documentId, width, height, ct);
}
