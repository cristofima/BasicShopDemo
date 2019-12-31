using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BasicShopDemo.Api.Data
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        [Key]
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
