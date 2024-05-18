using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.DTO.CreateAndReponse;
using HumanService.IHumanService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManageHuman.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration configuration;
        private readonly IMapper _mapper;
        public AuthController(IUserService userService, IConfiguration config, IMapper mapper)
        {
            _userService = userService;
            configuration = config;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (login == null)
            {
                return BadRequest("Invalid client request");
            }

            var checkLogin = _userService.CheckLogin(login.UserName, login.Password);
            if (checkLogin == null)
            {
                return NotFound("User not found");
            }

            var data = _mapper.Map<UserDTO>(checkLogin);
            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]!),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
        new Claim("UserID", checkLogin.UserID.ToString()),
        new Claim(ClaimTypes.Name, data.Name),
        new Claim(ClaimTypes.Role, data.role) 
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signingCredentials);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }



    }
}
