using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using PlannerApp.Shared.Contracts.V2.Requests.Authentication;
using PlannerApp.Client.Services.Contracts;
using PlannerApp.Client.Services.Exceptions;

namespace PlannerApp.Components
{
  public partial class RegisterForm : ComponentBase
  {
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }

    [Inject]
    public NavigationManager Navigation { get; set; }

    private readonly RegisterRequest _model = new();
    private bool _isBusy = false;
    private string _errorMessage = string.Empty;

    private async Task RegisterUserAsync()
    {
      _isBusy = true;
      _errorMessage = string.Empty;

      try
      {
        var response = await AuthenticationService.RegisterUserAsync(_model);
        Navigation.NavigateTo("/authentication/login");
      }
      catch (ApiException apiException)
      {
        _errorMessage = apiException.ApiErrorResponse.Message;
      }
      catch (Exception exception)
      {
        _errorMessage = exception.Message;
      }
      finally
      {
        _isBusy = false;
      }
    }

    private void RedirectToLogin()
    {
      Navigation.NavigateTo("/authentication/login");
    }
  }
}
