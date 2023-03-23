using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ToNinetyOne.Identity.Data.Interface;
using ToNinetyOne.IdentityDomain;
using ToNinetyOne.WebApi.Models;
using ToNinetyOne.WebApi.Models.Identity;


namespace ToNinetyOne.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IToNinetyOneUserDbContext _context;
    private readonly JwtSetting _jwtSetting;
    private readonly IIdentity _identity;

    public UserController(IToNinetyOneUserDbContext context, IOptions<JwtSetting> options,
        IIdentity identity)
    {
        _context = context;
        _identity = identity;
        _jwtSetting = options.Value;
    }

    #region GenerateToken

    [NonAction]
    private TokenResponse Authenticate(string userName, IEnumerable<Claim> claims)
    {
        var tokenKey = Encoding.UTF8.GetBytes(_jwtSetting.SecurityKey);

        var tokenHandler = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenResponse = new TokenResponse(new JwtSecurityTokenHandler().WriteToken(tokenHandler),
            _identity.GenerateRefreshToken(userName));


        // var cookieOptions = new CookieOptions
        // {
        //     Expires = DateTime.Now.AddDays(15),
        //     Path = "/",
        //     // HttpOnly = true,
        //     Secure = true
        // };

        //
        // Response.Cookies.Append("AuthToken",
        //     _jwtSetting.Encrypt(_tokenGenerator.GenerateToken(userName)),
        //     cookieOptions);


        return tokenResponse;
    }
    
    [HttpPost]
    public IActionResult Authenticate([FromBody] LoginDto loginDto)
    {
        var user = _context.Users.FirstOrDefault(o =>
            o.UserName == loginDto.UserName && o.Password == loginDto.Password);

        if (user == null)
        {
            return Unauthorized();
        }

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenKey = Encoding.UTF8.GetBytes(_jwtSetting.SecurityKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new(ClaimTypes.Name, user.UserName),
                    new(ClaimTypes.Role, user.UserRole.ToString()),
                    new(ClaimTypes.NameIdentifier, user.Id.ToString())
                }
            ),
            Expires = DateTime.Now.AddMinutes(5),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
        };
        
        var finalToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

        var tokenResponse = new TokenResponse(finalToken, _identity.GenerateRefreshToken(user.UserName));

        // var cookieOptions = new CookieOptions
        // {
        //     Expires = DateTime.Now.AddDays(15),
        //     Path = "/",
        //     // HttpOnly = true,
        //     Secure = true
        // };
        //
        // var encryptedRefreshToken = _jwtSetting.Encrypt(_tokenGenerator.GenerateToken(user.Name));

        // Response.Cookies.Append("AuthToken", encryptedRefreshToken, cookieOptions);

        return Ok(tokenResponse);
    }

    [HttpPost]
    public IActionResult Refresh([FromBody] TokenResponse tokenResponse)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(tokenResponse.JwtToken);

        var userName = securityToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

        var refreshTokenObject =
            _context.RefreshTokens.FirstOrDefault(o =>
                o.UserName == userName && o.Token == tokenResponse.RefreshToken);

        if (refreshTokenObject == null)
        {
            return Unauthorized();
        }

        var result = Authenticate(userName, securityToken.Claims.ToArray());

        return Ok(result);
    }

    #endregion

    [HttpPost]
    public IActionResult Register([FromBody] RegisterDto registerDto)
    {
        return Ok(registerDto);
    }
}