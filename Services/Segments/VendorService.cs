using AERN.Api.Contracts.Segments;
using AERN.Api.Models;

namespace AERN.Services.Segments;

public sealed class VendorService : IVendorService
{
    public Task<ApiResult<VendorDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<VendorDto>(new VendorDto(id, "Vendor", "V001", "Active", Guid.Empty, null, DateTime.UtcNow)));

    public Task<PagedResult<VendorDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? status, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<VendorDto>(Array.Empty<VendorDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateVendorRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateVendorRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<VendorContractDto>> GetContractsAsync(Guid vendorId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<VendorContractDto>(Array.Empty<VendorContractDto>()));

    public Task<IdResult> AddContractAsync(Guid vendorId, CreateVendorContractRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));
}
