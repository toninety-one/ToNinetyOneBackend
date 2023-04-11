using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Commands.DisciplineGroup.AddDisciplineGroup;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.WebApi.Controllers;

/// <inheritdoc />
[Authorize(Roles = Roles.Administrator)]
[ApiController]
public class DisciplineGroupController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper">configured mapper</param>
    public DisciplineGroupController(IMapper mapper)
    {
        _mapper = mapper;
    }

    #region Post

    /// <summary>
    /// add discipline to group
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /api/Group/AddDisciplineGroup
    /// {
    ///     "groupId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///     "disciplineId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    /// }
    /// </remarks>
    /// <param name="addDisciplineGroupDto">AddDisciplineGroupDto object</param>
    /// <returns>Returns group id (guid)</returns>
    /// <response code="201">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpPost]
    [Route("[action]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> AddDisciplineGroup([FromBody] AddDisciplineGroupDto addDisciplineGroupDto)
    {
        var command = _mapper.Map<AddDisciplineGroupCommand>(addDisciplineGroupDto);
        var groupId = await Mediator.Send(command);
        return Ok(groupId);
    }

    #endregion
}