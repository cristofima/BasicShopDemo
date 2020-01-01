using BasicShopDemo.Api.Core.DTO.Requests;
using BasicShopDemo.Api.Core.DTO.Responses;
using BasicShopDemo.Api.Data;
using BasicShopDemo.Api.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BasicShopDemo.Api.DAO
{
    public class AuthDAO
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtFactory jwtFactory;

        public AuthDAO(UserManager<ApplicationUser> userManager, JwtFactory jwtFactory)
        {
            this.userManager = userManager;
            this.jwtFactory = jwtFactory;
        }

        public async Task<BaseResponse> LoginAsync(LoginRequest loginUser)
        {
            var appUser = await this.userManager.FindByNameAsync(loginUser.UserName);
            if (appUser == null)
            {
                return new ErrorCRUDResponse($"User or password is incorrect", 400);
            }
            else
            {
                var checkPassword = await this.userManager.CheckPasswordAsync(appUser, loginUser.Password);
                if (checkPassword)
                {
                    var tokenString = this.jwtFactory.GenerateEncodedToken(appUser.UserName, appUser.Email);
                    var expireDate = this.jwtFactory.GetExpireDate(tokenString);

                    return new LoginResponse(tokenString, "Success login", 200, expireDate);
                }

                return new ErrorCRUDResponse("User or password is incorrect", 400);
            }
        }
    }
}
