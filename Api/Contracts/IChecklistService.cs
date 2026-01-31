using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Maintenance checklists and tasks.</summary>
public interface IChecklistService
{
    Task<ApiResult<ChecklistTemplateDto>> GetTemplateByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<ChecklistTemplateDto>> GetTemplatesPageAsync(PagingRequest paging, Guid? tenantId, Guid? assetTypeId, CancellationToken ct = default);
    Task<IdResult> CreateTemplateAsync(CreateChecklistTemplateRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateTemplateAsync(Guid id, UpdateChecklistTemplateRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteTemplateAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<ChecklistInstanceDto>> GetInstanceByIdAsync(Guid id, CancellationToken ct = default);
    Task<IdResult> CreateInstanceAsync(CreateChecklistInstanceRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> CompleteItemAsync(Guid instanceId, Guid itemId, CompleteChecklistItemRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> CompleteInstanceAsync(Guid instanceId, CancellationToken ct = default);
    Task<PagedResult<ChecklistInstanceDto>> GetInstancesByWorkOrderAsync(Guid workOrderId, PagingRequest paging, CancellationToken ct = default);
}

public record ChecklistTemplateDto(Guid Id, string Name, Guid? AssetTypeId, Guid TenantId, IReadOnlyList<ChecklistItemDto> Items);
public record ChecklistItemDto(Guid Id, string Title, bool IsRequired, int Order);
public record ChecklistInstanceDto(Guid Id, Guid TemplateId, Guid WorkOrderId, string Status, IReadOnlyList<ChecklistItemResultDto> Items, DateTime CreatedAt);
public record ChecklistItemResultDto(Guid ItemId, bool Completed, string? Notes, DateTime? CompletedAt);
public record CreateChecklistTemplateRequest(string Name, Guid? AssetTypeId, Guid TenantId, IEnumerable<ChecklistItemDto> Items);
public record UpdateChecklistTemplateRequest(string? Name, IEnumerable<ChecklistItemDto>? Items);
public record CreateChecklistInstanceRequest(Guid TemplateId, Guid WorkOrderId);
public record CompleteChecklistItemRequest(string? Notes);
