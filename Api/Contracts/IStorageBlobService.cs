using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Azure Blob Storage: upload, thumbnails, streaming.</summary>
public interface IStorageBlobService
{
    Task<ApiResult<BlobUploadResultDto>> UploadAsync(string container, string blobName, Stream content, string contentType, CancellationToken ct = default);
    Task<ApiResult<Stream>> DownloadAsync(string container, string blobName, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(string container, string blobName, CancellationToken ct = default);
    Task<ApiResult<BlobMetadataDto>> GetMetadataAsync(string container, string blobName, CancellationToken ct = default);
    Task<ApiResult<BlobUploadResultDto>> UploadImageWithThumbnailAsync(string container, string blobName, Stream imageStream, string contentType, int thumbWidth, int thumbHeight, CancellationToken ct = default);
    Task<ApiResult<Stream>> GetThumbnailAsync(string container, string blobName, int width, int height, CancellationToken ct = default);
    Task<ApiListResult<BlobItemDto>> ListAsync(string container, string? prefix, int maxResults, CancellationToken ct = default);
    Task<ApiResult<bool>> ExistsAsync(string container, string blobName, CancellationToken ct = default);
}

public record BlobUploadResultDto(string Container, string BlobName, string? ThumbnailBlobName, long SizeBytes, string ContentType);
public record BlobMetadataDto(string BlobName, long SizeBytes, string ContentType, DateTime? LastModified);
public record BlobItemDto(string Name, long SizeBytes, DateTime? LastModified);
