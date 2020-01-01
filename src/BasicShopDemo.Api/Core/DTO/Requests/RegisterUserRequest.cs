using System.ComponentModel.DataAnnotations;

namespace BasicShopDemo.Api.Core.DTO.Requests
{
    public class RegisterUserRequest
    {
        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 10)]
        public string Email { get; set; }

        [Required]
        [EnumDataType(typeof(RoleEnum), ErrorMessage = "Role must be Administrator (10) or Supervisor (20)")]
        public RoleEnum RoleCode { get; set; }
    }
}
