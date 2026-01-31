using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class DocumentService : IDocumentService
{
    public Task<ApiResult<DocumentDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<DocumentDto>(new DocumentDto(id, "doc", "application/pdf", 0, null, Guid.Empty, 1, DateTime.UtcNow)));

    public Task<PagedResult<DocumentDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? assetId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<DocumentDto>(Array.Empty<DocumentDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateDocumentRequest request, Stream content, string contentType, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateDocumentRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<DocumentContentDto>> GetContentAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<DocumentContentDto>(new DocumentContentDto(Stream.Null, "application/octet-stream", "doc")));

    public Task<ApiResult<DocumentDto>> GetVersionAsync(Guid id, int version, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<DocumentDto>(new DocumentDto(id, "doc", "application/pdf", 0, null, Guid.Empty, version, DateTime.UtcNow)));

    public Task<ApiListResult<DocumentVersionDto>> GetVersionsAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<DocumentVersionDto>(Array.Empty<DocumentVersionDto>()));

    public Task<ApiResult<bool>> CheckOutAsync(Guid id, Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> CheckInAsync(Guid id, Stream? content, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
