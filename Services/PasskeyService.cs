using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class PasskeyService : IPasskeyService
{
    public Task<ApiResult<PasskeyRegistrationOptionsDto>> GetRegistrationOptionsAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<PasskeyRegistrationOptionsDto>(new PasskeyRegistrationOptionsDto("challenge", new { }, new { }, new { })));

    public Task<ApiResult<bool>> RegisterPasskeyAsync(Guid userId, RegisterPasskeyRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<PasskeyAssertionOptionsDto>> GetAssertionOptionsAsync(string email, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<PasskeyAssertionOptionsDto>(new PasskeyAssertionOptionsDto("challenge", new { })));

    public Task<ApiResult<PasskeyAssertionResultDto>> VerifyAssertionAsync(VerifyPasskeyRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<PasskeyAssertionResultDto>(new PasskeyAssertionResultDto(Guid.NewGuid(), "token")));

    public Task<ApiListResult<PasskeyDto>> GetUserPasskeysAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<PasskeyDto>(Array.Empty<PasskeyDto>()));

    public Task<ApiResult<bool>> RemovePasskeyAsync(Guid userId, Guid credentialId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> RenamePasskeyAsync(Guid userId, Guid credentialId, string name, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
