using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Infrastructure
{
  public class Constants
  {
    protected Constants() { }

    public const string LocalStorageTokenKey = "token_access";
    public const string LocalStorageTokenExpiryDate = "token_expiry_date";
  }
}
