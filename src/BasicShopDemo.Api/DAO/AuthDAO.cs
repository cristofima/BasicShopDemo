using BasicShopDemo.Api.Core.DTO;
using BasicShopDemo.Api.Core.DTO.Requests;
using BasicShopDemo.Api.Core.DTO.Responses;
using BasicShopDemo.Api.Data;
using BasicShopDemo.Api.Helpers;
using BasicShopDemo.Api.Utils;
using Microsoft.AspNetCore.Identity;
using System.Linq;
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
                return new ErrorResponse($"User or password is incorrect", 400);
            }
            else
            {
                var checkPassword = await this.userManager.CheckPasswordAsync(appUser, loginUser.Password);
                if (!checkPassword)
                {
                    await this.userManager.AccessFailedAsync(appUser);

                    var user = await this.userManager.FindByNameAsync(appUser.UserName);
                    if (user.LockoutEnd > DateUtils.GetCurrentDate())
                    {
                        return new ErrorResponse($"User '{appUser.UserName}' is locked.\nTry again after {user.LockoutEnd}", 400);
                    }

                    return new ErrorResponse("User or password is incorrect", 400);
                }
                else
                {
                    var user = await this.userManager.FindByNameAsync(appUser.UserName);
                    if (user.LockoutEnd > DateUtils.GetCurrentDate())
                    {
                        return new ErrorResponse($"User '{appUser.UserName}' is locked.\nTry again after {user.LockoutEnd}", 400);
                    }

                    await this.userManager.ResetAccessFailedCountAsync(appUser);
                    await this.userManager.SetLockoutEndDateAsync(appUser, null);

                    var tokenString = this.jwtFactory.GenerateEncodedToken(appUser.UserName, appUser.Email);
                    var expireDate = this.jwtFactory.GetExpireDate(tokenString);

                    return new LoginResponse(tokenString, "Success login", 200, expireDate);
                }
            }
        }

        public async Task<BaseResponse> SaveAsync(RegisterUserRequest registerUser)
        {
            var appUser = await this.userManager.FindByEmailAsync(registerUser.Email);
            if (appUser != null)
            {
                return new ErrorResponse($"User with email '{registerUser.Email}' already exists", 409);
            }

            var password = "BasicShop2020";

            appUser = new ApplicationUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var identityResult = await this.userManager.CreateAsync(appUser, password);
            if (identityResult.Succeeded)
            {
                await this.userManager.AddToRoleAsync(appUser, registerUser.RoleCode.ToString("G"));
                return new SuccessResponse($"User with email '{registerUser.Email}' was created", 201);
            }
            else
            {
                return new ErrorResponse($"User with email '{registerUser.Email}' could not be created", 400, identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
            }
        }
    }
}
