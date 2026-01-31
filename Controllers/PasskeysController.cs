using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PasskeysController(IPasskeyService service) : ControllerBase
{
    [HttpGet("registration-options/{userId:guid}")]
    public Task<ApiResult<PasskeyRegistrationOptionsDto>> GetRegistrationOptions(Guid userId, CancellationToken ct) => service.GetRegistrationOptionsAsync(userId, ct);

    [HttpPost("register/{userId:guid}")]
    public Task<ApiResult<bool>> Register(Guid userId, [FromBody] RegisterPasskeyRequest request, CancellationToken ct) => service.RegisterPasskeyAsync(userId, request, ct);

    [HttpGet("assertion-options")]
    public Task<ApiResult<PasskeyAssertionOptionsDto>> GetAssertionOptions([FromQuery] string email, CancellationToken ct) => service.GetAssertionOptionsAsync(email, ct);

    [HttpPost("verify")]
    public Task<ApiResult<PasskeyAssertionResultDto>> Verify([FromBody] VerifyPasskeyRequest request, CancellationToken ct) => service.VerifyAssertionAsync(request, ct);

    [HttpGet("user/{userId:guid}")]
    public Task<ApiListResult<PasskeyDto>> GetUserPasskeys(Guid userId, CancellationToken ct) => service.GetUserPasskeysAsync(userId, ct);

    [HttpDelete("user/{userId:guid}/credential/{credentialId:guid}")]
    public Task<ApiResult<bool>> Remove(Guid userId, Guid credentialId, CancellationToken ct) => service.RemovePasskeyAsync(userId, credentialId, ct);

    [HttpPatch("user/{userId:guid}/credential/{credentialId:guid}/rename")]
    public Task<ApiResult<bool>> Rename(Guid userId, Guid credentialId, [FromBody] string name, CancellationToken ct) => service.RenamePasskeyAsync(userId, credentialId, name, ct);
}
