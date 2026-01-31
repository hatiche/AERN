using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class InjectionScanService : IInjectionScanService
{
    public Task<ApiResult<InjectionScanResultDto>> ScanStreamAsync(Stream content, string contentType, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<InjectionScanResultDto>(new InjectionScanResultDto(true, null, null)));

    public Task<ApiResult<InjectionScanResultDto>> ScanFileAsync(string path, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<InjectionScanResultDto>(new InjectionScanResultDto(true, null, null)));

    public Task<ApiResult<bool>> IsHealthyAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
