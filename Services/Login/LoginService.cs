using FluentResults;
using GdpFlow.API.Models.DTOs.Login;
using GdpFlow.API.Models.Results;
using GdpFlow.API.Models.Settings;
using Microsoft.Extensions.Options;

namespace GdpFlow.API.Services.Login;

public class LoginService : ILoginService
{
	public readonly IHttpClientFactory _httpClientFactory;
	private readonly KeycloakSettings _keycloakSettings;
	public LoginService(IHttpClientFactory httpClientFactory, IOptions<KeycloakSettings> keycloakSettings)
	{
		_httpClientFactory = httpClientFactory;
		_keycloakSettings = keycloakSettings.Value;
	}

	public async Task<Result<LoginTokenResponseDTO>> LoginAsync(LoginDTO loginDTO)
	{
		var client = _httpClientFactory.CreateClient();

		var content = new FormUrlEncodedContent(
		[
			new KeyValuePair<string, string>("grant_type", "password"),
			new KeyValuePair<string, string>("client_id", _keycloakSettings.ClientId),
			new KeyValuePair<string, string>("client_secret", _keycloakSettings.ClientSecret),
			new KeyValuePair<string, string>("username", loginDTO.Email),
			new KeyValuePair<string, string>("password", loginDTO.Password),
			new KeyValuePair<string, string>("scope", _keycloakSettings.Scope),
		]);

		var loginResponse = await client.PostAsync(_keycloakSettings.Uri.Login, content);
		if (!loginResponse.IsSuccessStatusCode)
		{
			return Result.Fail<LoginTokenResponseDTO>(new CustomError("Unauthorized", StatusCodes.Status401Unauthorized));
		}

		var loginResult = await loginResponse.Content.ReadFromJsonAsync<LoginTokenResponseDTO>();
		if (loginResult == null)
		{
			return Result.Fail<LoginTokenResponseDTO>(new CustomError("Internal server error from login endpoint", StatusCodes.Status500InternalServerError));
		}

		var tokenResponse = new LoginTokenResponseDTO
		{
			AccessToken = loginResult.AccessToken,
			ExpiresIn = loginResult.ExpiresIn,
			RefreshExpiresIn = loginResult.RefreshExpiresIn,
			RefreshToken = loginResult.RefreshToken,
			TokenType = loginResult.TokenType,
			IdToken = loginResult.IdToken,
			NotBeforePolicy = loginResult.NotBeforePolicy,
			SessionState = loginResult.SessionState,
			Scope = loginResult.Scope,
		};

		return Result.Ok(tokenResponse);
	}
}
