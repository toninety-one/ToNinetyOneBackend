using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Queries.User.GetUserList;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Identity.Operations.Commands.UpdateUser;
using ToNinetyOne.Identity.Operations.Queries.GetUserDetails;
using ToNinetyOne.Identity.Operations.Queries.GetUserRoles;
using GetUserDetailsQuery = ToNinetyOne.Application.Operations.Queries.User.GetUserDetails.GetUserDetailsQuery;
using UserDetailsViewModel = ToNinetyOne.Application.Operations.Queries.User.GetUserDetails.UserDetailsViewModel;

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
    public async Task<ActionResult<UserDetailsViewModel>> Get([FromQuery] Guid? id)
    {
        var query = new GetUserDetailsQuery(UserId, UserId, UserRole);

        if (id != null)
        {
            query.UserId = id;
        }

        var viewModel = await Mediator.Send(query);

        var identity =
            await Mediator.Send(
                new Identity.Operations.Queries.GetUserDetails.GetUserDetailsQuery(id ?? UserId, UserId, UserRole));

        Console.WriteLine(JsonSerializer.Serialize(identity));

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
        Console.WriteLine(JsonSerializer.Serialize(viewModel));
        var idList = viewModel.Users.Select(u => u.Id).ToList();
        Console.WriteLine(JsonSerializer.Serialize(idList));

        var roles = await Mediator.Send(new GetUserRolesQuery(idList));
        Console.WriteLine(JsonSerializer.Serialize(roles));

        foreach (var user in viewModel.Users)
        {
            user.UserRole = roles.Roles.FirstOrDefault(r => r.Id == user.Id)?.UserRole;
            Console.WriteLine(JsonSerializer.Serialize(user));
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
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}, {Roles.User}")]
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

    #endregion
}