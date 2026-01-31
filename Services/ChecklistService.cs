using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class ChecklistService : IChecklistService
{
    public Task<ApiResult<ChecklistTemplateDto>> GetTemplateByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ChecklistTemplateDto>(new ChecklistTemplateDto(id, "Template", null, Guid.Empty, Array.Empty<ChecklistItemDto>())));

    public Task<PagedResult<ChecklistTemplateDto>> GetTemplatesPageAsync(PagingRequest paging, Guid? tenantId, Guid? assetTypeId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<ChecklistTemplateDto>(Array.Empty<ChecklistTemplateDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateTemplateAsync(CreateChecklistTemplateRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateTemplateAsync(Guid id, UpdateChecklistTemplateRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteTemplateAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<ChecklistInstanceDto>> GetInstanceByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ChecklistInstanceDto>(new ChecklistInstanceDto(id, Guid.Empty, Guid.Empty, "Open", Array.Empty<ChecklistItemResultDto>(), DateTime.UtcNow)));

    public Task<IdResult> CreateInstanceAsync(CreateChecklistInstanceRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> CompleteItemAsync(Guid instanceId, Guid itemId, CompleteChecklistItemRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> CompleteInstanceAsync(Guid instanceId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<PagedResult<ChecklistInstanceDto>> GetInstancesByWorkOrderAsync(Guid workOrderId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<ChecklistInstanceDto>(Array.Empty<ChecklistInstanceDto>(), 0, paging.Page, paging.PageSize));
}
