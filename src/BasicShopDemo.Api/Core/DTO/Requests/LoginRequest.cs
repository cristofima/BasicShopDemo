using System.ComponentModel.DataAnnotations;

namespace BasicShopDemo.Api.Core.DTO.Requests
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
