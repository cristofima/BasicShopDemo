using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicShopDemo.Api.Data
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        [Key]
        [Column(Order = 1)]
        public override string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public override string RoleId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}

