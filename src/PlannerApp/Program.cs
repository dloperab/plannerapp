using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlannerApp.Client.Services.Infrastructure;
using PlannerApp.Extensions;

namespace PlannerApp
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.ConfigureHttpClientBuilder();
      builder.ConfigureExternalLibs();
      builder.ConfigureAuthorization();
      builder.Services.AddClientServices();

      await builder.Build().RunAsync();
    }
  }
}
