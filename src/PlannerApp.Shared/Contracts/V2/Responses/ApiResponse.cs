
namespace PlannerApp.Shared.Contracts.V2.Responses
{
  public class ApiResponse
  {
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
  }

  public class ApiResponse<T> : ApiResponse
  {
    public T Value { get; set; }
  }
}
