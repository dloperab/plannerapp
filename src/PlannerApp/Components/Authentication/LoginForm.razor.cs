using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using Blazored.LocalStorage;

using PlannerApp.Shared.Contracts.V2.Requests.Authentication;
using PlannerApp.Shared.Contracts.V2;
using PlannerApp.Shared.Contracts.V2.Responses;
using PlannerApp.Shared.Contracts.V2.Models;
using PlannerApp.Shared.Infrastructure;

namespace PlannerApp.Components
{
  public partial class LoginForm : ComponentBase
  {
    [Inject]
    public HttpClient HttpClient { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; }

    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    public ILocalStorageService Storage { get; set; }

    private LoginRequest _model = new();
    private bool _isBusy = false;
    private string _errorMessage = string.Empty;

    private async Task LoginUserAsync()
    {
      _isBusy = true;
      _errorMessage = string.Empty;

      var response = await HttpClient.PostAsJsonAsync(ApiRoutes.Auth.Login, _model);
      if (response.IsSuccessStatusCode)
      {
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<LoginResult>>();

        // Store it in local storage
        await Storage.SetItemAsStringAsync(Constants.LocalStorageTokenKey, result.Value.Token);
        await Storage.SetItemAsync<DateTime>(Constants.LocalStorageTokenExpiryDate, result.Value.ExpiryDate);

        await AuthenticationStateProvider.GetAuthenticationStateAsync();

        Navigation.NavigateTo("/");
      }
      else
      {
        var errorResult = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
        _errorMessage = errorResult.Message;
      }

      _isBusy = false;
    }
  }
}
