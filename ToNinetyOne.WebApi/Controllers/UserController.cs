using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Queries.User.GetUserDetails;

namespace ToNinetyOne.WebApi.Controllers;

/// <inheritdoc />
[Authorize]
[ApiController]
public class UserController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="mapper">configured mapper</param>
    public UserController(IMapper mapper)
    {
        _mapper = mapper;
    }

    #region Get

    /// <summary>
    ///     return user profile info
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /api/userProfile
    /// </remarks>
    /// <returns>returns UserProfileViewModel</returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If user not auth</responce>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserDetailsViewModel>> Get()
    {
        var query = new GetUserDetailsQuery(UserId);

        var viewModel = await Mediator.Send(query);

        return Ok(viewModel);
    }

    #endregion
}