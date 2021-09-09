
namespace PlannerApp.Shared.Contracts.V2
{
  public static class ApiRoutes
  {
    public const string Root = "https://plannerapp-api.azurewebsites.net";
    public const string Version = "v2";
    public const string Base = Root + "/" + Version;

    public static class Posts
    {
      public const string GetAll = Base + "/posts";
      public const string Get = Base + "/posts/{postId}";
      public const string Create = Base + "/posts";
      public const string Update = Base + "/posts/{postId}";
      public const string Delete = Base + "/posts/{postId}";
    }
  }
}
