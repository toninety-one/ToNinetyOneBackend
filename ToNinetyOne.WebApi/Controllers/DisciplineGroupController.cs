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
    ///     Constructor
    /// </summary>
    /// <param name="mapper">configured mapper</param>
    public DisciplineGroupController(IMapper mapper)
    {
        _mapper = mapper;
    }

    #region Post

    /// <summary>
    ///     add discipline to group
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /api/Group
    ///     {
    ///     "groupId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///     "disciplineId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    /// </remarks>
    /// <param name="addDisciplineGroupDto">AddDisciplineGroupDto object</param>
    /// <returns>Returns group id (guid)</returns>
    /// <response code="201">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] AddDisciplineGroupDto addDisciplineGroupDto)
    {
        var command = _mapper.Map<AddDisciplineGroupCommand>(addDisciplineGroupDto);
        await Mediator.Send(command);
        return NoContent();
    }

    #endregion

    #region Delete

    /// <summary>
    ///     remove discipline from group
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     DELETE /api/Group
    ///     {
    ///     "groupId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///     "disciplineId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///     }
    /// </remarks>
    /// <param name="deleteDisciplineGroupDto">DeleteDisciplineGroupDto object</param>
    /// <returns>Returns group id (guid)</returns>
    /// <response code="201">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Delete(
        [FromBody] DeleteDisciplineGroupDto deleteDisciplineGroupDto)
    {
        var command = _mapper.Map<DeleteDisciplineGroupCommand>(deleteDisciplineGroupDto);
        await Mediator.Send(command);
        return NoContent();
    }

    #endregion
}