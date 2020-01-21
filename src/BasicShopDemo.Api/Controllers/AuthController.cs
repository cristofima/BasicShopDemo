using BasicShopDemo.Api.Core.DTO.Requests;
using BasicShopDemo.Api.Core.DTO.Responses;
using BasicShopDemo.Api.Core.Interfaces;
using BasicShopDemo.Api.DAO;
using BasicShopDemo.Api.Data;
using BasicShopDemo.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
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

        public AuthController(UserManager<ApplicationUser> userManager, JwtFactory jwtFactory, IEmailSender emailSender)
        {
            authDAO = new AuthDAO(userManager, jwtFactory, emailSender);
        }

        /// <summary>
        /// Login to a user
        /// </summary>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(200, Type = typeof(LoginResponse))]
        [ProducesResponseType(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authDAO.LoginAsync(loginRequest);

            return StatusCode(result.status, result);
        }

        /// <summary>
        /// Register a user
        /// </summary>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(201, Type = typeof(SuccessResponse))]
        [ProducesResponseType(400, Type = typeof(ErrorResponse))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(409, Type = typeof(ErrorResponse))]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Administrator")]
        public async Task<IActionResult> Register([FromBody]RegisterUserRequest registerUserRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await authDAO.SaveAsync(registerUserRequest);

            return StatusCode(result.status, result);
        }
    }
}