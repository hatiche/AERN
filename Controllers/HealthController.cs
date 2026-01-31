using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
[Produces("application/json")]
public class HealthController(IHealthService service) : ControllerBase
{
    [HttpGet]
    public Task<ApiResult<HealthStatusDto>> GetStatus(CancellationToken ct) => service.GetStatusAsync(ct);

    [HttpGet("detail")]
    public Task<ApiResult<HealthDetailDto>> GetDetail(CancellationToken ct) => service.GetDetailAsync(ct);

    [HttpGet("database")]
    public Task<ApiResult<DatabaseHealthDto>> GetDatabase(CancellationToken ct) => service.GetDatabaseHealthAsync(ct);

    [HttpGet("storage")]
    public Task<ApiResult<StorageHealthDto>> GetStorage(CancellationToken ct) => service.GetStorageHealthAsync(ct);

    [HttpGet("memory")]
    public Task<ApiResult<MemoryInfoDto>> GetMemory(CancellationToken ct) => service.GetMemoryInfoAsync(ct);

    [HttpGet("ping")]
    public Task<ApiResult<bool>> Ping(CancellationToken ct) => service.PingAsync(ct);
}
