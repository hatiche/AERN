using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class SessionService : ISessionService
{
    public Task<ApiResult<SessionDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<SessionDto>(new SessionDto(id, Guid.Empty, DateTime.UtcNow, null, null, true)));

    public Task<PagedResult<SessionDto>> GetUserSessionsAsync(Guid userId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<SessionDto>(Array.Empty<SessionDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<bool>> RevokeAsync(Guid sessionId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> RevokeAllUserSessionsAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<SessionDto>> RefreshAsync(Guid sessionId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<SessionDto>(new SessionDto(sessionId, Guid.Empty, DateTime.UtcNow, DateTime.UtcNow.AddHours(1), null, true)));

    public Task<ApiResult<bool>> ValidateTokenAsync(string token, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(false));
}
