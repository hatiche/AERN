using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>WebAuthn/FIDO2 passkey registration and assertion.</summary>
public interface IPasskeyService
{
    Task<ApiResult<PasskeyRegistrationOptionsDto>> GetRegistrationOptionsAsync(Guid userId, CancellationToken ct = default);
    Task<ApiResult<bool>> RegisterPasskeyAsync(Guid userId, RegisterPasskeyRequest request, CancellationToken ct = default);
    Task<ApiResult<PasskeyAssertionOptionsDto>> GetAssertionOptionsAsync(string email, CancellationToken ct = default);
    Task<ApiResult<PasskeyAssertionResultDto>> VerifyAssertionAsync(VerifyPasskeyRequest request, CancellationToken ct = default);
    Task<ApiListResult<PasskeyDto>> GetUserPasskeysAsync(Guid userId, CancellationToken ct = default);
    Task<ApiResult<bool>> RemovePasskeyAsync(Guid userId, Guid credentialId, CancellationToken ct = default);
    Task<ApiResult<bool>> RenamePasskeyAsync(Guid userId, Guid credentialId, string name, CancellationToken ct = default);
}

public record PasskeyRegistrationOptionsDto(string Challenge, object Rp, object User, object PubKeyCredParams);
public record PasskeyAssertionOptionsDto(string Challenge, object AllowCredentials);
public record PasskeyAssertionResultDto(Guid UserId, string Token);
public record RegisterPasskeyRequest(string CredentialId, string ClientDataJson, string AttestationObject);
public record VerifyPasskeyRequest(string Email, string CredentialId, string ClientDataJson, string Signature);
public record PasskeyDto(Guid Id, string Name, DateTime CreatedAt);
