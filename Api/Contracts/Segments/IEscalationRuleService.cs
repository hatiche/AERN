using AERN.Api.Models;

namespace AERN.Api.Contracts.Segments;

/// <summary>Segment: Alerts &amp; Escalation – escalation rules and routing.</summary>
public interface IEscalationRuleService
{
    Task<ApiResult<EscalationRuleDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<EscalationRuleDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? triggerType, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateEscalationRuleRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateEscalationRuleRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> EvaluateAndEscalateAsync(Guid alertId, string triggerType, object? context, CancellationToken ct = default);
    Task<ApiListResult<EscalationHistoryDto>> GetHistoryAsync(Guid ruleId, int limit, CancellationToken ct = default);
}

public record EscalationRuleDto(Guid Id, string Name, string TriggerType, int Level, string? TargetRoleOrUser, Guid TenantId, bool IsActive);
public record CreateEscalationRuleRequest(string Name, string TriggerType, int Level, string? TargetRoleOrUser, Guid TenantId);
public record UpdateEscalationRuleRequest(string? Name, int? Level, string? TargetRoleOrUser, bool? IsActive);
public record EscalationHistoryDto(Guid Id, Guid RuleId, Guid AlertId, DateTime EscalatedAt, string Status);
