using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageBlobsController(IStorageBlobService service) : ControllerBase
{
    [HttpPost("{container}/{blobName}")]
    [Consumes("application/octet-stream", "multipart/form-data")]
    public async Task<ApiResult<BlobUploadResultDto>> Upload(string container, string blobName, [FromQuery] string contentType, IFormFile? file, CancellationToken ct)
    {
        var stream = file?.OpenReadStream() ?? Stream.Null;
        var ctHeader = file?.ContentType ?? contentType ?? "application/octet-stream";
        return await service.UploadAsync(container, blobName, stream, ctHeader, ct);
    }

    [HttpGet("{container}/{blobName}")]
    public Task<ApiResult<Stream>> Download(string container, string blobName, CancellationToken ct) => service.DownloadAsync(container, blobName, ct);

    [HttpDelete("{container}/{blobName}")]
    public Task<ApiResult<bool>> Delete(string container, string blobName, CancellationToken ct) => service.DeleteAsync(container, blobName, ct);

    [HttpGet("{container}/{blobName}/metadata")]
    public Task<ApiResult<BlobMetadataDto>> GetMetadata(string container, string blobName, CancellationToken ct) => service.GetMetadataAsync(container, blobName, ct);

    [HttpPost("{container}/{blobName}/image-with-thumbnail")]
    [Consumes("multipart/form-data")]
    public async Task<ApiResult<BlobUploadResultDto>> UploadImageWithThumbnail(string container, string blobName, IFormFile file, [FromQuery] int thumbWidth = 200, [FromQuery] int thumbHeight = 200, CancellationToken ct = default)
    {
        await using var stream = file.OpenReadStream();
        return await service.UploadImageWithThumbnailAsync(container, blobName, stream, file.ContentType, thumbWidth, thumbHeight, ct);
    }

    [HttpGet("{container}/{blobName}/thumbnail")]
    public Task<ApiResult<Stream>> GetThumbnail(string container, string blobName, [FromQuery] int width = 200, [FromQuery] int height = 200, CancellationToken ct = default) =>
        service.GetThumbnailAsync(container, blobName, width, height, ct);

    [HttpGet("{container}")]
    public Task<ApiListResult<BlobItemDto>> List(string container, [FromQuery] string? prefix = null, [FromQuery] int maxResults = 100, CancellationToken ct = default) =>
        service.ListAsync(container, prefix, maxResults, ct);

    [HttpHead("{container}/{blobName}")]
    public Task<ApiResult<bool>> Exists(string container, string blobName, CancellationToken ct) => service.ExistsAsync(container, blobName, ct);
}
