namespace AERN.Api.Models;

/// <summary>Standard API response wrapper for single result.</summary>
public record ApiResult<T>(T Data, bool Success = true, string? Message = null);

/// <summary>Standard API response for paged results.</summary>
public record PagedResult<T>(IReadOnlyList<T> Items, int TotalCount, int Page, int PageSize);

/// <summary>Standard API response for list (non-paged).</summary>
public record ApiListResult<T>(IReadOnlyList<T> Items, bool Success = true, string? Message = null);

/// <summary>Id response for create operations.</summary>
public record IdResult(Guid Id, bool Success = true, string? Message = null);
