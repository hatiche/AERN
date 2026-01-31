using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryStockController(IInventoryStockService service) : ControllerBase
{
    [HttpGet("part/{partId:guid}/location/{locationId}")]
    public Task<ApiResult<StockLevelDto>> GetByPartAndLocation(Guid partId, string locationId, CancellationToken ct) => service.GetByPartAndLocationAsync(partId, locationId, ct);

    [HttpGet("{id:guid}")]
    public Task<ApiResult<StockLevelDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<StockLevelDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? partId = null, [FromQuery] string? locationId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, partId, locationId, ct);

    [HttpPost("adjust")]
    public Task<ApiResult<bool>> Adjust([FromBody] AdjustStockRequest request, CancellationToken ct) => service.AdjustAsync(request, ct);

    [HttpPost("reserve")]
    public Task<ApiResult<bool>> Reserve([FromBody] ReserveStockRequest request, CancellationToken ct) => service.ReserveAsync(request, ct);

    [HttpPost("reservations/{reservationId:guid}/release")]
    public Task<ApiResult<bool>> ReleaseReservation(Guid reservationId, CancellationToken ct) => service.ReleaseReservationAsync(reservationId, ct);

    [HttpGet("part/{partId:guid}/location/{locationId}/movements")]
    public Task<PagedResult<StockMovementDto>> GetMovements(Guid partId, string locationId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default) =>
        service.GetMovementsAsync(partId, locationId, new PagingRequest(page, pageSize), ct);

    [HttpGet("part/{partId:guid}")]
    public Task<ApiListResult<StockLevelDto>> GetByPart(Guid partId, CancellationToken ct) => service.GetByPartAsync(partId, ct);
}
