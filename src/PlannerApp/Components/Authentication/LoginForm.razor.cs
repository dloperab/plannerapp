using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using PlannerApp.Shared.Contracts.V2.Requests.Authentication;

namespace PlannerApp.Components
{
  public partial class LoginForm : ComponentBase
  {
    [Inject]
    public HttpClient HttpClient { get; set; }

    private LoginRequest _model = new();

    private async Task LoginAsync()
    {
      throw new NotImplementedException(); 
    }
  }
}
