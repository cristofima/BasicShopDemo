using Microsoft.AspNetCore.Identity;

namespace BasicShopDemo.Api.Data
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
