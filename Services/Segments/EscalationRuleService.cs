using AERN.Api.Contracts.Segments;
using AERN.Api.Models;

namespace AERN.Services.Segments;

public sealed class EscalationRuleService : IEscalationRuleService
{
    public Task<ApiResult<EscalationRuleDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<EscalationRuleDto>(new EscalationRuleDto(id, "Rule", "Alert", 1, null, Guid.Empty, true)));

    public Task<PagedResult<EscalationRuleDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? triggerType, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<EscalationRuleDto>(Array.Empty<EscalationRuleDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateEscalationRuleRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateEscalationRuleRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> EvaluateAndEscalateAsync(Guid alertId, string triggerType, object? context, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<EscalationHistoryDto>> GetHistoryAsync(Guid ruleId, int limit, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<EscalationHistoryDto>(Array.Empty<EscalationHistoryDto>()));
}
