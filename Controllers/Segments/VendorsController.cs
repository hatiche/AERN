using AERN.Api.Contracts.Segments;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers.Segments;

[ApiController]
[Route("api/segments/vendors")]
public class VendorsController(IVendorService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<VendorDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<VendorDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? status = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, status, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateVendorRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateVendorRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpGet("{vendorId:guid}/contracts")]
    public Task<ApiListResult<VendorContractDto>> GetContracts(Guid vendorId, CancellationToken ct) => service.GetContractsAsync(vendorId, ct);

    [HttpPost("{vendorId:guid}/contracts")]
    public Task<IdResult> AddContract(Guid vendorId, [FromBody] CreateVendorContractRequest request, CancellationToken ct) => service.AddContractAsync(vendorId, request, ct);
}
