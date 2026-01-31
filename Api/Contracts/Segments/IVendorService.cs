using AERN.Api.Models;

namespace AERN.Api.Contracts.Segments;

/// <summary>Segment: Vendor &amp; Supplier – vendor management and contracts.</summary>
public interface IVendorService
{
    Task<ApiResult<VendorDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<VendorDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? status, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateVendorRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateVendorRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiListResult<VendorContractDto>> GetContractsAsync(Guid vendorId, CancellationToken ct = default);
    Task<IdResult> AddContractAsync(Guid vendorId, CreateVendorContractRequest request, CancellationToken ct = default);
}

public record VendorDto(Guid Id, string Name, string? Code, string Status, Guid TenantId, string? ContactEmail, DateTime CreatedAt);
public record CreateVendorRequest(string Name, string? Code, Guid TenantId, string? ContactEmail);
public record UpdateVendorRequest(string? Name, string? Code, string? Status, string? ContactEmail);
public record VendorContractDto(Guid Id, Guid VendorId, string Reference, DateTime StartDate, DateTime? EndDate, string Status);
public record CreateVendorContractRequest(string Reference, DateTime StartDate, DateTime? EndDate);
