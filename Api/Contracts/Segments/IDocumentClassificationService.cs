using AERN.Api.Models;

namespace AERN.Api.Contracts.Segments;

/// <summary>Segment: Document AI / Classification – auto-classify and extract metadata.</summary>
public interface IDocumentClassificationService
{
    Task<ApiResult<ClassificationResultDto>> ClassifyAsync(Guid documentId, CancellationToken ct = default);
    Task<ApiResult<ClassificationResultDto>> GetClassificationAsync(Guid documentId, CancellationToken ct = default);
    Task<IdResult> TrainCategoryAsync(string categoryName, IEnumerable<Guid> documentIds, Guid tenantId, CancellationToken ct = default);
    Task<ApiListResult<string>> GetCategoriesAsync(Guid tenantId, CancellationToken ct = default);
    Task<ApiResult<ExtractedMetadataDto>> ExtractMetadataAsync(Guid documentId, CancellationToken ct = default);
}

public record ClassificationResultDto(Guid DocumentId, string Category, double Confidence, IReadOnlyList<string> Tags, DateTime ClassifiedAt);
public record ExtractedMetadataDto(Guid DocumentId, IReadOnlyDictionary<string, object?> Fields, DateTime ExtractedAt);
public record TrainCategoryRequest(string CategoryName, IEnumerable<Guid> DocumentIds);
