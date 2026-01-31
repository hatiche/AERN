using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class IntegrationService : IIntegrationService
{
    public Task<ApiResult<IntegrationDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<IntegrationDto>(new IntegrationDto(id, "Integration", "webhook", true, Guid.Empty, DateTime.UtcNow)));

    public Task<PagedResult<IntegrationDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? type, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<IntegrationDto>(Array.Empty<IntegrationDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateIntegrationRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateIntegrationRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> EnableAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DisableAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<IntegrationTestResultDto>> TestAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<IntegrationTestResultDto>(new IntegrationTestResultDto(true, null, 200)));

    public Task<PagedResult<IntegrationDeliveryDto>> GetWebhookDeliveriesAsync(Guid webhookId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<IntegrationDeliveryDto>(Array.Empty<IntegrationDeliveryDto>(), 0, paging.Page, paging.PageSize));
}
