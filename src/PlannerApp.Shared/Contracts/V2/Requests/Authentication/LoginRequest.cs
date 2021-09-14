using System.ComponentModel.DataAnnotations;

namespace PlannerApp.Shared.Contracts.V2.Requests.Authentication
{
  public class LoginRequest
  {
    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 6)]
    public string Password { get; set; }
  }
}
