
namespace PlannerApp.Shared.Contracts.V2
{
  public static class ApiRoutes
  {
    public const string Root = "https://plannerapp-api.azurewebsites.net";
    public const string Version = "v2";
    public const string Base = "/api/" + Version;

    public static class Auth
    {
      public const string Login = Base + "/auth/login";
    }
  }
}
