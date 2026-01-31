using AERN.Api.Contracts.Segments;
using AERN.Api.Models;

namespace AERN.Services.Segments;

public sealed class DocumentClassificationService : IDocumentClassificationService
{
    public Task<ApiResult<ClassificationResultDto>> ClassifyAsync(Guid documentId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ClassificationResultDto>(new ClassificationResultDto(documentId, "General", 0.9, ["doc"], DateTime.UtcNow)));

    public Task<ApiResult<ClassificationResultDto>> GetClassificationAsync(Guid documentId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ClassificationResultDto>(new ClassificationResultDto(documentId, "General", 0.9, Array.Empty<string>(), DateTime.UtcNow)));

    public Task<IdResult> TrainCategoryAsync(string categoryName, IEnumerable<Guid> documentIds, Guid tenantId, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiListResult<string>> GetCategoriesAsync(Guid tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<string>(["General", "Invoice", "Manual"]));

    public Task<ApiResult<ExtractedMetadataDto>> ExtractMetadataAsync(Guid documentId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ExtractedMetadataDto>(new ExtractedMetadataDto(documentId, new Dictionary<string, object?>(), DateTime.UtcNow)));
}
