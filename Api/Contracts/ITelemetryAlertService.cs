using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Telemetry alerts and thresholds.</summary>
public interface ITelemetryAlertService
{
    Task<ApiResult<TelemetryAlertDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<TelemetryAlertDto>> GetPageAsync(PagingRequest paging, Guid? assetId, Guid? tenantId, CancellationToken ct = default);
    Task<ApiListResult<TelemetryAlertDto>> GetActiveByAssetAsync(Guid assetId, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateTelemetryAlertRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateTelemetryAlertRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> EnableAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> DisableAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<TelemetryAlertEventDto>> GetEventsAsync(Guid alertId, PagingRequest paging, CancellationToken ct = default);
}

public record TelemetryAlertDto(Guid Id, Guid AssetId, string MetricKey, string Condition, double Threshold, bool IsEnabled, Guid TenantId);
public record CreateTelemetryAlertRequest(Guid AssetId, string MetricKey, string Condition, double Threshold, Guid TenantId);
public record UpdateTelemetryAlertRequest(string? Condition, double? Threshold);
public record TelemetryAlertEventDto(Guid Id, Guid AlertId, object Value, DateTime TriggeredAt, bool Acknowledged);
