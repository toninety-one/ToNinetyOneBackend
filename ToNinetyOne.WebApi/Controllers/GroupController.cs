using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Commands.Group.CreateGroup;
using ToNinetyOne.Application.Operations.Commands.Group.DeleteGroup;
using ToNinetyOne.Application.Operations.Commands.Group.SetUserGroup;
using ToNinetyOne.Application.Operations.Commands.Group.UpdateGroup;
using ToNinetyOne.Application.Operations.Queries.Group.GetGroupDetails;
using ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;

namespace ToNinetyOne.WebApi.Controllers;

[Authorize]
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
    /// 
    /// </summary>
    /// <returns></returns>
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
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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
    /// 
    /// </summary>
    /// <param name="createGroupDto"></param>
    /// <returns></returns>
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

    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult> SetUserGroup(SetUserGroupDto setUserGroupDto)
    {
        var command = _mapper.Map<SetUserGroupCommand>(setUserGroupDto);

        var userId = await Mediator.Send(command);
        
        return Ok(userId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="updateGroupDto"></param>
    /// <returns></returns>
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
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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