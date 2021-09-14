using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Components.Authorization;

using Blazored.LocalStorage;

using PlannerApp.Shared.Infrastructure;

namespace PlannerApp.Infrastructure
{
  public class JwtAuthenticationStateProvider : AuthenticationStateProvider
  {
    private readonly ILocalStorageService _localStorageService;

    public JwtAuthenticationStateProvider(ILocalStorageService localStorageService)
    {
      _localStorageService = localStorageService;
    }

    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      if (await _localStorageService.ContainKeyAsync(Constants.LocalStorageTokenKey))
      {
        // User is logged in
        // Get token and read claims
        var tokenString = await _localStorageService.GetItemAsStringAsync(Constants.LocalStorageTokenKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.ReadJwtToken(tokenString);
        var identity = new ClaimsIdentity(token.Claims, "Bearer");
        var user = new ClaimsPrincipal(identity);
        var authState = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(authState));

        return authState;
      }

      // Empty claims means means no identity and the user is not logged in
      return new AuthenticationState(new ClaimsPrincipal());
    }
  }
}
