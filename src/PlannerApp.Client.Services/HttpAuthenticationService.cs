using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using PlannerApp.Client.Services.Contracts;
using PlannerApp.Client.Services.Exceptions;
using PlannerApp.Shared.Contracts.V2;
using PlannerApp.Shared.Contracts.V2.Requests.Authentication;
using PlannerApp.Shared.Contracts.V2.Responses;

namespace PlannerApp.Client.Services
{
  public class HttpAuthenticationService : IAuthenticationService
  {
    private readonly HttpClient _httpClient;

    public HttpAuthenticationService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<ApiResponse> RegisterUserAsync(RegisterRequest request)
    {
      var response = await _httpClient.PostAsJsonAsync(ApiRoutes.Auth.Register, request);

      if (!response.IsSuccessStatusCode)
      {
        var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
        throw new ApiException(errorResponse, response.StatusCode);
      }

      var result = await response.Content.ReadFromJsonAsync<ApiResponse>();

      return result;
    }
  }
}
