using FluentResults;
using GdpFlow.API.Models.DTOs.User.Register;
using GdpFlow.API.Models.Entities;
using GdpFlow.API.Models.Results;
using GdpFlow.API.Models.Settings;
using GdpFlow.API.Repositories.UserRepository;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace GdpFlow.API.Services.UserServices.Register;

public class RegisterUserService : IRegisterUserService
{
	public readonly IHttpClientFactory _httpClientFactory;
	public readonly IUserRepository _userRepository;
	private readonly KeycloakSettings _keycloakSettings;

	public RegisterUserService(IHttpClientFactory httpClientFactory, IUserRepository userRepository, IOptions<KeycloakSettings> keycloakSettings)
	{
		_httpClientFactory = httpClientFactory;
		_userRepository = userRepository;
		_keycloakSettings = keycloakSettings.Value;
	}

	public async Task<Result> RegisterAsync(RegisterDTO registerDTO)
	{
		var existingUser = await _userRepository.GetByEmailAsync(registerDTO.Email);
		if (existingUser != null)
		{
			return Result.Fail(new CustomError("User already exists", StatusCodes.Status409Conflict));
		}

		var adminAccessToken = await GetAdminTokenAsync();
		if (adminAccessToken == null)
		{
			return Result.Fail(new CustomError("Error fetching access token from keycloak client", StatusCodes.Status500InternalServerError));
		}

		var keycloakRegistered = await RegisterUserKeycloak(adminAccessToken, registerDTO);
		if (!keycloakRegistered.IsSuccessStatusCode)
		{
			return Result.Fail(new CustomError("An error occurred while registering a user in keycloak", StatusCodes.Status500InternalServerError));
		}

		var locationHeader = keycloakRegistered.Headers.Location?.ToString();
		var userKeycloakId = locationHeader!.Split('/').Last();

		var userRegistered = await RegisterUserInDatabase(userKeycloakId, registerDTO);
		if (!userRegistered)
		{
			return Result.Fail(new CustomError("Error creating user in database", StatusCodes.Status500InternalServerError));
		}

		return Result.Ok().WithSuccess(new CustomSuccess("User registered successfully", StatusCodes.Status201Created));
	}

	private async Task<string?> GetAdminTokenAsync()
	{
		var client = _httpClientFactory.CreateClient();

		var content = new FormUrlEncodedContent(
		[
			new KeyValuePair<string, string>("grant_type", "client_credentials"),
			new KeyValuePair<string, string>("client_id", _keycloakSettings.ClientId),
			new KeyValuePair<string, string>("client_secret", _keycloakSettings.ClientSecret)
		]);

		var tokenResponse = await client.PostAsync(_keycloakSettings.Uri.Login, content);

		if (!tokenResponse.IsSuccessStatusCode)
		{
			return null;
		}

		var tokenResult = await tokenResponse.Content.ReadFromJsonAsync<AdminTokenResponseDTO>();
		return tokenResult?.AccessToken;
	}

	private async Task<HttpResponseMessage> RegisterUserKeycloak(string adminAccessToken, RegisterDTO registerDTO)
	{
		var client = _httpClientFactory.CreateClient();

		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminAccessToken);

		return await client.PostAsJsonAsync(
			_keycloakSettings.Uri.Register,
			new KeycloakDTO
			{
				Email = registerDTO.Email,
				FirstName = registerDTO.FirstName,
				LastName = registerDTO.LastName,
				Enabled = true,
				EmailVerified = true,
				Credentials = new List<CredentialDTO> {
					new() {
						Type = "password",
						Value = registerDTO.Password,
						Temporary = false
						}
					}
			});
	}

	public async Task<bool> RegisterUserInDatabase(string userKeycloakId, RegisterDTO userDTO)
	{
		var user = new User
		{
			Id = Guid.Parse(userKeycloakId),
			Email = userDTO.Email,
			FirstName = userDTO.FirstName,
			LastName = userDTO.LastName,
		};

		var userRegistered = await _userRepository.AddAsync(user);
		return userRegistered;
	}
}