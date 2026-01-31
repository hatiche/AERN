using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class StorageBlobService : IStorageBlobService
{
    public Task<ApiResult<BlobUploadResultDto>> UploadAsync(string container, string blobName, Stream content, string contentType, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<BlobUploadResultDto>(new BlobUploadResultDto(container, blobName, null, 0, contentType)));

    public Task<ApiResult<Stream>> DownloadAsync(string container, string blobName, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<Stream>(Stream.Null));

    public Task<ApiResult<bool>> DeleteAsync(string container, string blobName, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<BlobMetadataDto>> GetMetadataAsync(string container, string blobName, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<BlobMetadataDto>(new BlobMetadataDto(blobName, 0, "application/octet-stream", null)));

    public Task<ApiResult<BlobUploadResultDto>> UploadImageWithThumbnailAsync(string container, string blobName, Stream imageStream, string contentType, int thumbWidth, int thumbHeight, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<BlobUploadResultDto>(new BlobUploadResultDto(container, blobName, blobName + "-thumb", 0, contentType)));

    public Task<ApiResult<Stream>> GetThumbnailAsync(string container, string blobName, int width, int height, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<Stream>(Stream.Null));

    public Task<ApiListResult<BlobItemDto>> ListAsync(string container, string? prefix, int maxResults, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<BlobItemDto>(Array.Empty<BlobItemDto>()));

    public Task<ApiResult<bool>> ExistsAsync(string container, string blobName, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(false));
}
