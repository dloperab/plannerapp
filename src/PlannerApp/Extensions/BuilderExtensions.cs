using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using MudBlazor.Services;

namespace PlannerApp.Extensions
{
  public static class BuilderExtensions
  {
    public static void ConfigureHttpClientBuilder(this WebAssemblyHostBuilder builder)
    {
      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    }

    public static void ConfigureMudBlazor(this WebAssemblyHostBuilder builder)
    {
      builder.Services.AddMudServices();
    }
  }
}
