using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Commands.Group.CreateGroup;
using ToNinetyOne.Application.Operations.Commands.Group.DeleteGroup;
using ToNinetyOne.Application.Operations.Commands.Group.SetUserGroup;
using ToNinetyOne.Application.Operations.Commands.Group.UpdateGroup;
using ToNinetyOne.Application.Operations.Queries.Group.GetGroupDetails;
using ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;
using ToNinetyOne.IdentityDomain.Static;

namespace ToNinetyOne.WebApi.Controllers;

/// <inheritdoc />
[Authorize(Roles = Roles.Administrator)]
[ApiController]
public class GroupController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper">configured mapper</param>
    public GroupController(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// return the list of all groups
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /api/group
    /// </remarks>
    /// <returns>returns GroupListViewModel</returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If user not auth</responce>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GroupListViewModel>> GetAll()
    {
        var query = new GetGroupListQuery(UserId);

        var viewModel = await Mediator.Send(query);

        return Ok(viewModel);
    }

    /// <summary>
    /// Gets the group with users by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /api/group/D34D349E-43B8-429E-BCA4-793C932FD580
    /// </remarks>
    /// <param name="id">Group id (guid)</param>
    /// <returns>Returns GroupDetailsViewModel</returns>
    /// <response code="200">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GroupDetailsViewModel>> Get(Guid id)
    {
        var query = new GetGroupDetailsQuery(UserId, id);

        var viewModel = await Mediator.Send(query);

        return Ok(viewModel);
    }

    /// <summary>
    /// Creates the group
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /api/group
    /// {
    ///     "title": "string"
    /// }
    /// </remarks>
    /// <param name="createGroupDto">CreateGroupDto object</param>
    /// <returns>Returns group id (guid)</returns>
    /// <response code="201">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateGroupDto createGroupDto)
    {
        var command = _mapper.Map<CreateGroupCommand>(createGroupDto);
        command.UserId = UserId;
        var groupId = await Mediator.Send(command);
        return Ok(groupId);
    }

    /// <summary>
    /// Updates user group
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /api/group/setUserGroup
    /// {
    ///     "userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///     "groupId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    /// }
    /// </remarks>
    /// <param name="setUserGroupDto">SetUserGroupDto object</param>
    /// <returns>Returns group id (guid)</returns>
    /// <response code="201">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> SetUserGroup(SetUserGroupDto setUserGroupDto)
    {
        var command = _mapper.Map<SetUserGroupCommand>(setUserGroupDto);

        var userId = await Mediator.Send(command);

        return Ok(userId);
    }

    /// <summary>
    /// Updates the group
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PUT /api/group
    /// {
    ///     "groupId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///     "title": "string"
    /// }
    /// </remarks>
    /// <param name="updateGroupDto">UserUpdateDto</param>
    /// <returns>none</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Update([FromBody] UpdateGroupDto updateGroupDto)
    {
        var command = _mapper.Map<UpdateGroupCommand>(updateGroupDto);
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Deletes the group by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /api/group/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    /// </remarks>
    /// <param name="id">group id</param>
    /// <returns>none</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteGroupCommand() { Id = id };
        await Mediator.Send(command);
        return NoContent();
    }
}