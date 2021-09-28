using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PlannerApp.Shared.Contracts.V2.Requests.Authentication;
using PlannerApp.Shared.Contracts.V2.Responses;

namespace PlannerApp.Client.Services.Contracts
{
  public interface IAuthenticationService
  {
    Task<ApiResponse> RegisterUserAsync(RegisterRequest request);
  }
}
