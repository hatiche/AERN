using AERN.Api.Contracts.Segments;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers.Segments;

[ApiController]
[Route("api/segments/escalation")]
public class EscalationRulesController(IEscalationRuleService service) : ControllerBase
{
    [HttpGet("rules/{id:guid}")]
    public Task<ApiResult<EscalationRuleDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet("rules")]
    public Task<PagedResult<EscalationRuleDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? triggerType = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, triggerType, ct);

    [HttpPost("rules")]
    public Task<IdResult> Create([FromBody] CreateEscalationRuleRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("rules/{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateEscalationRuleRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("rules/{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpPost("evaluate")]
    public Task<ApiResult<bool>> Evaluate([FromQuery] Guid alertId, [FromQuery] string triggerType, [FromBody] object? context, CancellationToken ct) =>
        service.EvaluateAndEscalateAsync(alertId, triggerType, context, ct);

    [HttpGet("rules/{ruleId:guid}/history")]
    public Task<ApiListResult<EscalationHistoryDto>> GetHistory(Guid ruleId, [FromQuery] int limit = 50, CancellationToken ct = default) =>
        service.GetHistoryAsync(ruleId, limit, ct);
}
