using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;

using MudBlazor.Services;
using Blazored.LocalStorage;

using PlannerApp.Infrastructure;
using PlannerApp.Shared.Contracts.V2;

namespace PlannerApp.Extensions
{
  public static class BuilderExtensions
  {
    public static void ConfigureHttpClientBuilder(this WebAssemblyHostBuilder builder)
    {
      builder.Services.AddHttpClient("PlannerApp.Api", client =>
      {
        client.BaseAddress = new Uri(ApiRoutes.Root);
      }).AddHttpMessageHandler<AuthorizationMessageHandler>(); ;

      builder.Services.AddTransient<AuthorizationMessageHandler>();
      builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("PlannerApp.Api"));
    }

    public static void ConfigureAuthorization(this WebAssemblyHostBuilder builder)
    {
      builder.Services.AddAuthorizationCore();
      builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
    }

    public static void ConfigureMudBlazor(this WebAssemblyHostBuilder builder)
    {
      builder.Services.AddMudServices();
    }

    public static void ConfigureExternalLibs(this WebAssemblyHostBuilder builder)
    {
      builder.Services.AddBlazoredLocalStorage();
    }
  }
}
