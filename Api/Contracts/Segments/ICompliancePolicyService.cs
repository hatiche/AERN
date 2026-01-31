using AERN.Api.Models;

namespace AERN.Api.Contracts.Segments;

/// <summary>Segment: Compliance &amp; Governance – policies and regulatory checks.</summary>
public interface ICompliancePolicyService
{
    Task<ApiResult<CompliancePolicyDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<CompliancePolicyDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? category, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateCompliancePolicyRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateCompliancePolicyRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<ComplianceCheckResultDto>> RunCheckAsync(Guid policyId, Guid? assetId, CancellationToken ct = default);
}

public record CompliancePolicyDto(Guid Id, string Name, string Category, bool IsActive, Guid TenantId, DateTime CreatedAt);
public record CreateCompliancePolicyRequest(string Name, string Category, string? RuleJson, Guid TenantId);
public record UpdateCompliancePolicyRequest(string? Name, string? Category, string? RuleJson, bool? IsActive);
public record ComplianceCheckResultDto(bool Passed, IReadOnlyList<string> Findings, DateTime CheckedAt);
