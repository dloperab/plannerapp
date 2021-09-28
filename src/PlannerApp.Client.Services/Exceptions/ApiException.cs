using System;
using System.Net;

using PlannerApp.Shared.Contracts.V2.Responses;

namespace PlannerApp.Client.Services.Exceptions
{
  public class ApiException : Exception
  {
    public ApiErrorResponse ApiErrorResponse { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public ApiException(ApiErrorResponse errorResponse, 
      HttpStatusCode statusCode) : this(errorResponse)
    {
      ApiErrorResponse = errorResponse;
      StatusCode = statusCode;
    }

    public ApiException(ApiErrorResponse errorResponse)
    {
      ApiErrorResponse = errorResponse;
    }
  }
}
