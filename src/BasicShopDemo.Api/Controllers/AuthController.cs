using BasicShopDemo.Api.Core.DTO.Requests;
using BasicShopDemo.Api.Core.DTO.Responses;
using BasicShopDemo.Api.DAO;
using BasicShopDemo.Api.Data;
using BasicShopDemo.Api.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.Controllers
{
    /// <summary>
    /// Services to login and register users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly AuthDAO authDAO;

        public AuthController(UserManager<ApplicationUser> userManager, JwtFactory jwtFactory)
        {
            authDAO = new AuthDAO(userManager, jwtFactory);
        }

        /// <summary>
        /// Login to a user
        /// </summary>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(200, Type = typeof(LoginResponse))]
        [ProducesResponseType(400, Type = typeof(ErrorCRUDResponse))]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authDAO.LoginAsync(loginRequest);

            return StatusCode(result.status, result);
        }
    }
}