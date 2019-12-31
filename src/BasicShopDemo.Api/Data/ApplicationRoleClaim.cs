using Microsoft.AspNetCore.Identity;

namespace BasicShopDemo.Api.Data
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
