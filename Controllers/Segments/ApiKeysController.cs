using AERN.Api.Contracts.Segments;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers.Segments;

[ApiController]
[Route("api/segments/api-keys")]
public class ApiKeysController(IApiKeyService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<ApiKeyDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<ApiKeyDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? clientId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, clientId, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateApiKeyRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPost("{id:guid}/revoke")]
    public Task<ApiResult<bool>> Revoke(Guid id, CancellationToken ct) => service.RevokeAsync(id, ct);

    [HttpPost("{id:guid}/rotate")]
    public Task<ApiResult<bool>> Rotate(Guid id, CancellationToken ct) => service.RotateAsync(id, ct);

    [HttpGet("lookup")]
    public Task<ApiResult<ApiKeyDto>> GetByKeyPrefix([FromQuery] string keyPrefix, CancellationToken ct) => service.GetByKeyHashAsync(keyPrefix, ct);

    [HttpGet("clients")]
    public Task<ApiListResult<ApiClientDto>> GetClients([FromQuery] Guid tenantId, CancellationToken ct) => service.GetClientsAsync(tenantId, ct);

    [HttpPost("clients")]
    public Task<IdResult> CreateClient([FromBody] CreateApiClientRequest request, CancellationToken ct) => service.CreateClientAsync(request, ct);
}
