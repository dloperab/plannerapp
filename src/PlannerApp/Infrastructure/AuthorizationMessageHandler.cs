using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

using Blazored.LocalStorage;

using PlannerApp.Shared.Infrastructure;

namespace PlannerApp.Infrastructure
{
  public class AuthorizationMessageHandler : DelegatingHandler
  {
    private readonly ILocalStorageService _localStorageService;

    public AuthorizationMessageHandler(ILocalStorageService localStorageService)
    {
      _localStorageService = localStorageService;
    }

    protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      if (await _localStorageService.ContainKeyAsync(Constants.LocalStorageTokenKey))
      {
        var token = await _localStorageService.GetItemAsStringAsync(Constants.LocalStorageTokenKey);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
      }

      return await SendAsync(request, cancellationToken);
    }
  }
}
