using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InjectionScanController(IInjectionScanService service) : ControllerBase
{
    [HttpPost("scan/stream")]
    [Consumes("application/octet-stream", "multipart/form-data")]
    public async Task<ApiResult<InjectionScanResultDto>> ScanStream(IFormFile? file, [FromQuery] string contentType = "application/octet-stream", CancellationToken ct = default)
    {
        var stream = file?.OpenReadStream() ?? Stream.Null;
        var ctHeader = file?.ContentType ?? contentType;
        return await service.ScanStreamAsync(stream, ctHeader, ct);
    }

    [HttpPost("scan/file")]
    public Task<ApiResult<InjectionScanResultDto>> ScanFile([FromQuery] string path, CancellationToken ct) => service.ScanFileAsync(path, ct);

    [HttpGet("health")]
    public Task<ApiResult<bool>> IsHealthy(CancellationToken ct) => service.IsHealthyAsync(ct);
}
