using Microsoft.Extensions.DependencyInjection;

using PlannerApp.Client.Services.Contracts;

namespace PlannerApp.Client.Services.Infrastructure
{
  public static class DIContainerExtensions
  {
    public static IServiceCollection AddClientServices(this IServiceCollection services)
    {
      return services.AddScoped<IAuthenticationService, HttpAuthenticationService>();
    }
  }
}
