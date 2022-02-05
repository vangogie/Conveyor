using Conveyor.Business.Services.Interfaces;
using Conveyor.DataAccess.Entities;
using Conveyor.ViewModels.ViewModels;
using Conveyor.Web.AuthOpt;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Conveyor.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("validate")]
        [Authorize]
        public bool GetValid() { return true; }

        [HttpPost("login")]
        //[ValidateAntiForgeryToken]
        public async Task<string> Login(UserModel model)
        {
            var identity = await _usersService.IsValidUser(model);
            if (identity == null)
            {
                return null; // BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new { token = $"Bearer {encodedJwt}" };
            /*new
        {
            access_token = encodedJwt,
            username = identity.Name
        };*/

            return JsonConvert.SerializeObject(response);
        }
    }
}
