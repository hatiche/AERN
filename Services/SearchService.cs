using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class SearchService : ISearchService
{
    public Task<ApiResult<SearchResultDto>> SearchAsync(SearchRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<SearchResultDto>(new SearchResultDto(Array.Empty<SearchHitDto>(), 0, null)));

    public Task<ApiResult<SearchResultDto>> SearchAssetsAsync(string query, Guid? tenantId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<SearchResultDto>(new SearchResultDto(Array.Empty<SearchHitDto>(), 0, null)));

    public Task<ApiResult<SearchResultDto>> SearchDocumentsAsync(string query, Guid? tenantId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<SearchResultDto>(new SearchResultDto(Array.Empty<SearchHitDto>(), 0, null)));

    public Task<ApiResult<SearchResultDto>> SearchUsersAsync(string query, Guid? tenantId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<SearchResultDto>(new SearchResultDto(Array.Empty<SearchHitDto>(), 0, null)));

    public Task<ApiResult<bool>> IndexEntityAsync(string entityType, Guid entityId, object payload, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> RemoveFromIndexAsync(string entityType, Guid entityId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> ReindexAsync(string? entityType, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<string>> GetSuggestionsAsync(string prefix, string? entityType, int limit, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<string>(Array.Empty<string>()));
}
