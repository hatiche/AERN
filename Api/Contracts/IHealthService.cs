using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Health checks and diagnostics.</summary>
public interface IHealthService
{
    Task<ApiResult<HealthStatusDto>> GetStatusAsync(CancellationToken ct = default);
    Task<ApiResult<HealthDetailDto>> GetDetailAsync(CancellationToken ct = default);
    Task<ApiResult<DatabaseHealthDto>> GetDatabaseHealthAsync(CancellationToken ct = default);
    Task<ApiResult<StorageHealthDto>> GetStorageHealthAsync(CancellationToken ct = default);
    Task<ApiResult<MemoryInfoDto>> GetMemoryInfoAsync(CancellationToken ct = default);
    Task<ApiResult<bool>> PingAsync(CancellationToken ct = default);
}

public record HealthStatusDto(string Status, DateTime TimestampUtc);
public record HealthDetailDto(string Status, IReadOnlyList<ComponentHealthDto> Components);
public record ComponentHealthDto(string Name, string Status, string? Message, TimeSpan? Duration);
public record DatabaseHealthDto(bool IsHealthy, TimeSpan? LatencyMs);
public record StorageHealthDto(bool IsHealthy, long? AvailableBytes);
public record MemoryInfoDto(long WorkingSetBytes, long GcHeapBytes);
