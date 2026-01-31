using AERN.Api.Contracts.Segments;
using AERN.Api.Models;

namespace AERN.Services.Segments;

public sealed class CompliancePolicyService : ICompliancePolicyService
{
    public Task<ApiResult<CompliancePolicyDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<CompliancePolicyDto>(new CompliancePolicyDto(id, "Policy", "Safety", true, Guid.Empty, DateTime.UtcNow)));

    public Task<PagedResult<CompliancePolicyDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? category, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<CompliancePolicyDto>(Array.Empty<CompliancePolicyDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateCompliancePolicyRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateCompliancePolicyRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<ComplianceCheckResultDto>> RunCheckAsync(Guid policyId, Guid? assetId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ComplianceCheckResultDto>(new ComplianceCheckResultDto(true, Array.Empty<string>(), DateTime.UtcNow)));
}
