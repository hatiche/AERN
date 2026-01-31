using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Injection firewall: scan uploads (e.g. ClamSharp) for malicious content.</summary>
public interface IInjectionScanService
{
    Task<ApiResult<InjectionScanResultDto>> ScanStreamAsync(Stream content, string contentType, CancellationToken ct = default);
    Task<ApiResult<InjectionScanResultDto>> ScanFileAsync(string path, CancellationToken ct = default);
    Task<ApiResult<bool>> IsHealthyAsync(CancellationToken ct = default);
}

public record InjectionScanResultDto(bool IsClean, string? ThreatType, string? Message);
