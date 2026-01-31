using AERN.Api.Contracts.Segments;
using AERN.Api.Models;

namespace AERN.Services.Segments;

public sealed class ApiKeyService : IApiKeyService
{
    public Task<ApiResult<ApiKeyDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ApiKeyDto>(new ApiKeyDto(id, Guid.Empty, "aern_****", DateTime.UtcNow, null, true)));

    public Task<PagedResult<ApiKeyDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? clientId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<ApiKeyDto>(Array.Empty<ApiKeyDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateApiKeyRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> RevokeAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> RotateAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<ApiKeyDto>> GetByKeyHashAsync(string keyPrefix, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ApiKeyDto>(new ApiKeyDto(Guid.NewGuid(), Guid.Empty, keyPrefix, DateTime.UtcNow, null, true)));

    public Task<ApiListResult<ApiClientDto>> GetClientsAsync(Guid tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<ApiClientDto>(Array.Empty<ApiClientDto>()));

    public Task<IdResult> CreateClientAsync(CreateApiClientRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));
}
