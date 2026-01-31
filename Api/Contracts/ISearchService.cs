using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Global and entity search.</summary>
public interface ISearchService
{
    Task<ApiResult<SearchResultDto>> SearchAsync(SearchRequest request, CancellationToken ct = default);
    Task<ApiResult<SearchResultDto>> SearchAssetsAsync(string query, Guid? tenantId, PagingRequest paging, CancellationToken ct = default);
    Task<ApiResult<SearchResultDto>> SearchDocumentsAsync(string query, Guid? tenantId, PagingRequest paging, CancellationToken ct = default);
    Task<ApiResult<SearchResultDto>> SearchUsersAsync(string query, Guid? tenantId, PagingRequest paging, CancellationToken ct = default);
    Task<ApiResult<bool>> IndexEntityAsync(string entityType, Guid entityId, object payload, CancellationToken ct = default);
    Task<ApiResult<bool>> RemoveFromIndexAsync(string entityType, Guid entityId, CancellationToken ct = default);
    Task<ApiResult<bool>> ReindexAsync(string? entityType, Guid? tenantId, CancellationToken ct = default);
    Task<ApiListResult<string>> GetSuggestionsAsync(string prefix, string? entityType, int limit, CancellationToken ct = default);
}

public record SearchRequest(string Query, string? EntityType, Guid? TenantId, PagingRequest Paging, string? SortBy);
public record SearchResultDto(IReadOnlyList<SearchHitDto> Hits, int TotalCount, string? TookMs);
public record SearchHitDto(string EntityType, Guid EntityId, string Title, string? Snippet, double Score, IReadOnlyDictionary<string, object?>? Fields);
