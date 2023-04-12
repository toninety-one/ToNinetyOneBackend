using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ToNinetyOne.Application.Operations.Commands.User;
using ToNinetyOne.Identity.Operations.Commands.Registration;
using ToNinetyOne.Identity.Operations.Commands.Token;
using ToNinetyOne.Identity.Operations.Commands.Token.Authenticate;
using ToNinetyOne.Identity.Operations.Commands.Token.Refresh;
using ToNinetyOne.Identity.Operations.Commands.Token.Update;
using ToNinetyOne.IdentityDomain;

namespace ToNinetyOne.WebApi.Controllers;

/// <inheritdoc />
[AllowAnonymous]
[ApiController]
public class UserController : BaseController
{
    private readonly JwtSetting _jwtSetting;
    private readonly IMapper _mapper;

    /// <inheritdoc />
    public UserController(IMapper mapper, IOptions<JwtSetting> options)
    {
        _mapper = mapper;
        _jwtSetting = options.Value;
    }

    [NonAction]
    private async Task<Token> Authenticate(string userName, IEnumerable<Claim> claims)
    {
        var tokenResponse = new Token();

        var tokenKey = Encoding.UTF8.GetBytes(_jwtSetting.SecurityKey);

        var tokenHandler = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256)
        );

        tokenResponse.JwtToken = new JwtSecurityTokenHandler().WriteToken(tokenHandler);

        var refreshTokenCommand = _mapper.Map<RefreshCommand>(new RefreshDto { UserName = userName });

        tokenResponse.RefreshToken = await Mediator.Send(refreshTokenCommand);

        return tokenResponse;
    }

    /// <summary>
    ///     Identity and authenticate. Returns jwt and refresh tokens
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /api/User/authenticate
    ///     {
    ///     "login": "string",
    ///     "password": "string"
    ///     }
    /// </remarks>
    /// <param name="authenticateDto">AuthenticateDto object</param>
    /// <returns>Returns jwt and refresh tokens</returns>
    /// <response code="200">Success token refreshed</response>
    /// <response code="401">If user not auth</response>
    [Route("[action]")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateDto authenticateDto)
    {
        var tokenResponse = new Token();

        var command = _mapper.Map<AuthenticateCommand>(authenticateDto);

        var authenticateResult = await Mediator.Send(command);

        if (authenticateResult == null) return Unauthorized();

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new(ClaimTypes.Name, authenticateResult.UserName),
                    new(ClaimTypes.Role, authenticateResult.Role),
                    new(ClaimTypes.NameIdentifier, authenticateResult.Id.ToString())
                }
            ),
            Expires = DateTime.Now.AddMinutes(5),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecurityKey)),
                    SecurityAlgorithms.HmacSha256)
        };

        tokenResponse.JwtToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

        var refreshTokenCommand =
            _mapper.Map<RefreshCommand>(new RefreshDto { UserName = authenticateResult.UserName });

        tokenResponse.RefreshToken = await Mediator.Send(refreshTokenCommand);

        return Ok(tokenResponse);
    }

    /// <summary>
    ///     Refresh auth token
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /api/User/refresh
    ///     {
    ///     "jwtToken": "string",
    ///     "refreshToken": "string"
    ///     }
    /// </remarks>
    /// <param name="token">Token object</param>
    /// <returns>Returns jwt and refresh tokens</returns>
    /// <response code="200">Success token refreshed</response>
    /// <response code="401">If user not auth</response>
    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Refresh([FromBody] Token token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token.JwtToken);

        var username = securityToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

        if (username == null) return Unauthorized();

        var updateTokenCommand =
            _mapper.Map<UpdateCommand>(new UpdateDto { UserName = username, RefreshToken = token.RefreshToken });

        var refreshToken = await Mediator.Send(updateTokenCommand);

        if (string.IsNullOrEmpty(refreshToken)) return Unauthorized();

        var result = await Authenticate(username, securityToken.Claims.ToArray());

        return Ok(result);
    }

    /// <summary>
    ///     Creates the account
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /api/User/register
    ///     {
    ///     "userName": "string",
    ///     "firstName": "string",
    ///     "lastName": "string",
    ///     "password" : "string"
    ///     }
    /// </remarks>
    /// <param name="registrationDto">RegistrationDto object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201">Success register</response>
    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Guid>> Register([FromBody] RegistrationDto registrationDto)
    {
        var command = _mapper.Map<RegistrationCommand>(registrationDto);

        var registerId = await Mediator.Send(command);

        var transferCommand = _mapper.Map<UserTransferCommand>(new UserTransferDto(registerId)
        {
            FirstName = registrationDto.FirstName,
            LastName = registrationDto.LastName,
            MiddleName = registrationDto.MiddleName
        });

        var userId = await Mediator.Send(transferCommand);

        return Ok(userId);
    }
}