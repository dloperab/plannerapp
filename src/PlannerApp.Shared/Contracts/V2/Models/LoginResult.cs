using System;

namespace PlannerApp.Shared.Contracts.V2.Models
{
  public class LoginResult
  {
    public string Token { get; set; }

    public DateTime ExpiryDate { get; set; }
  }
}
