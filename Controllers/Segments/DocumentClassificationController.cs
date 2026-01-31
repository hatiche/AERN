using AERN.Api.Contracts.Segments;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers.Segments;

[ApiController]
[Route("api/segments/document-classification")]
public class DocumentClassificationController(IDocumentClassificationService service) : ControllerBase
{
    [HttpPost("documents/{documentId:guid}/classify")]
    public Task<ApiResult<ClassificationResultDto>> Classify(Guid documentId, CancellationToken ct) => service.ClassifyAsync(documentId, ct);

    [HttpGet("documents/{documentId:guid}/classification")]
    public Task<ApiResult<ClassificationResultDto>> GetClassification(Guid documentId, CancellationToken ct) => service.GetClassificationAsync(documentId, ct);

    [HttpPost("train")]
    public Task<IdResult> Train([FromQuery] string categoryName, [FromQuery] Guid tenantId, [FromBody] IEnumerable<Guid> documentIds, CancellationToken ct) =>
        service.TrainCategoryAsync(categoryName, documentIds, tenantId, ct);

    [HttpGet("categories")]
    public Task<ApiListResult<string>> GetCategories([FromQuery] Guid tenantId, CancellationToken ct) => service.GetCategoriesAsync(tenantId, ct);

    [HttpGet("documents/{documentId:guid}/metadata")]
    public Task<ApiResult<ExtractedMetadataDto>> ExtractMetadata(Guid documentId, CancellationToken ct) => service.ExtractMetadataAsync(documentId, ct);
}
