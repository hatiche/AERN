using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionsController(ISessionService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<SessionDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet("user/{userId:guid}")]
    public Task<PagedResult<SessionDto>> GetUserSessions(Guid userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default) =>
        service.GetUserSessionsAsync(userId, new PagingRequest(page, pageSize), ct);

    [HttpPost("{sessionId:guid}/revoke")]
    public Task<ApiResult<bool>> Revoke(Guid sessionId, CancellationToken ct) => service.RevokeAsync(sessionId, ct);

    [HttpPost("user/{userId:guid}/revoke-all")]
    public Task<ApiResult<bool>> RevokeAll(Guid userId, CancellationToken ct) => service.RevokeAllUserSessionsAsync(userId, ct);

    [HttpPost("{sessionId:guid}/refresh")]
    public Task<ApiResult<SessionDto>> Refresh(Guid sessionId, CancellationToken ct) => service.RefreshAsync(sessionId, ct);

    [HttpPost("validate")]
    public Task<ApiResult<bool>> ValidateToken([FromBody] string token, CancellationToken ct) => service.ValidateTokenAsync(token, ct);
}
