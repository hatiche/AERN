using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Document upload, storage, and versioning.</summary>
public interface IDocumentService
{
    Task<ApiResult<DocumentDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<DocumentDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? assetId, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateDocumentRequest request, Stream content, string contentType, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateDocumentRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<DocumentContentDto>> GetContentAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<DocumentDto>> GetVersionAsync(Guid id, int version, CancellationToken ct = default);
    Task<ApiListResult<DocumentVersionDto>> GetVersionsAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> CheckOutAsync(Guid id, Guid userId, CancellationToken ct = default);
    Task<ApiResult<bool>> CheckInAsync(Guid id, Stream? content, CancellationToken ct = default);
}

public record DocumentDto(Guid Id, string Name, string ContentType, long SizeBytes, Guid? AssetId, Guid TenantId, int Version, DateTime CreatedAt);
public record DocumentContentDto(Stream Stream, string ContentType, string FileName);
public record DocumentVersionDto(int Version, DateTime CreatedAt, Guid CreatedBy);
public record CreateDocumentRequest(string Name, Guid? AssetId, Guid TenantId);
public record UpdateDocumentRequest(string? Name);
