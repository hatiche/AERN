using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class HealthService : IHealthService
{
    public Task<ApiResult<HealthStatusDto>> GetStatusAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<HealthStatusDto>(new HealthStatusDto("Healthy", DateTime.UtcNow)));

    public Task<ApiResult<HealthDetailDto>> GetDetailAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<HealthDetailDto>(new HealthDetailDto("Healthy", Array.Empty<ComponentHealthDto>())));

    public Task<ApiResult<DatabaseHealthDto>> GetDatabaseHealthAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<DatabaseHealthDto>(new DatabaseHealthDto(true, TimeSpan.FromMilliseconds(1))));

    public Task<ApiResult<StorageHealthDto>> GetStorageHealthAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<StorageHealthDto>(new StorageHealthDto(true, null)));

    public Task<ApiResult<MemoryInfoDto>> GetMemoryInfoAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<MemoryInfoDto>(new MemoryInfoDto(0, 0)));

    public Task<ApiResult<bool>> PingAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
