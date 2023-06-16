using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Commands.User.UpdateUser;
using ToNinetyOne.Application.Operations.Queries.User.GetUserList;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Identity.Operations.Commands.UpdateIdentityUser;
using ToNinetyOne.Identity.Operations.Queries.GetIdentityUserDetails;
using ToNinetyOne.Identity.Operations.Queries.GetIdentityUserRoles;

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
    public async Task<ActionResult<Application.Operations.Queries.User.GetUserDetails.UserDetailsViewModel>>
        Get([FromQuery] Guid? id)
    {
        var query =
            new Application.Operations.Queries.User.GetUserDetails.GetUserDetailsQuery(UserId, UserId, UserRole);

        if (id != null)
        {
            query.UserId = id;
        }

        var viewModel = await Mediator.Send(query);

        var identity =
            await Mediator.Send(
                new GetIdentityUserDetailsQuery(id ?? UserId, UserId, UserRole));

        viewModel.UserRole = identity.UserRole;
        viewModel.UserName = identity.UserName;

        return Ok(viewModel);
    }

    /// <summary>
    ///     return all users
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /api/userProfile
    /// </remarks>
    /// <returns>returns UserProfileViewModel</returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If user not auth</responce>
    [Authorize(Roles = Roles.Administrator)]
    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UsersListViewModel>> GetAll()
    {
        var query = new GetUsersListQuery(UserId, UserRole);

        var viewModel = await Mediator.Send(query);
        var idList = viewModel.Users.Select(u => u.Id).ToList();
        var roles = await Mediator.Send(new GetIdentityUserRolesQuery(idList));

        foreach (var user in viewModel.Users)
        {
            user.UserRole = roles.Roles.FirstOrDefault(r => r.Id == user.Id)?.UserRole;
        }

        return Ok(viewModel);
    }

    #endregion

    #region Put

    /// <summary>
    ///     Updates the user
    /// </summary>
    /// <remarks>
    ///     Sample request:
    /// </remarks>
    /// <param name="updateUserDto">UpdateUserDto object</param>
    /// <returns>none</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [Authorize(Roles = Roles.Administrator)]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Update([FromBody] UpdateUserDto updateUserDto)
    {
        var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    ///     Updates the user
    /// </summary>
    /// <remarks>
    ///     Sample request:
    /// </remarks>
    /// <param name="updateIdentityUserDto">UpdateUserDto object</param>
    /// <returns>none</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}, {Roles.User}")]
    [HttpPut("i")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Update([FromBody] UpdateIdentityUserDto updateIdentityUserDto)
    {
        var command = _mapper.Map<UpdateIdentityUserCommand>(updateIdentityUserDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }

    #endregion
}