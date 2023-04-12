using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Commands.LabWork.CreateLabWork;
using ToNinetyOne.Application.Operations.Commands.LabWork.DeleteLabWork;
using ToNinetyOne.Application.Operations.Commands.LabWork.UpdateLabWork;
using ToNinetyOne.Application.Operations.Commands.SubmittedLab.CreateSubmittedLab;
using ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;
using ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkList;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.WebApi.Controllers;

/// <inheritdoc />
[Authorize(Roles = Roles.Teacher)]
[ApiController]
public class LabWorksController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="mapper">configured mapper</param>
    public LabWorksController(IMapper mapper)
    {
        _mapper = mapper;
    }

    #region Get

    /// <summary>
    ///     return the list of all lab works
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /api/labwork
    /// </remarks>
    /// <param name="disciplineId">discipline id (guid</param>
    /// <returns>returns GroupListViewModel</returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If user not auth</responce>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LabWorkListViewModel>> Get([FromQuery] Guid? disciplineId)
    {
        var query = new GetLabWorkListQuery(UserId, disciplineId);

        var viewModel = await Mediator.Send(query);

        return Ok(viewModel);
    }

    /// <summary>
    ///     Gets the lab work by id
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /api/group/D34D349E-43B8-429E-BCA4-793C932FD580
    /// </remarks>
    /// <param name="id">Group id (guid)</param>
    /// <returns>Returns GroupDetailsViewModel</returns>
    /// <response code="200">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LabWorkDetailsViewModel>> Get(Guid id)
    {
        var query = new GetLabWorkDetailsQuery(UserId, id);

        var viewModel = await Mediator.Send(query);

        return Ok(viewModel);
    }

    #endregion

    #region Post

    /// <summary>
    ///     Creates the lab work
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /api/labWork
    ///     {
    ///     "title": "string",
    ///     "details": "string",
    ///     "filePath": "string",
    ///     }
    /// </remarks>
    /// <param name="createLabWorkDto">CreateLabWorkDto object</param>
    /// <returns>Returns lab work id (guid)</returns>
    /// <response code="201">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateLabWorkDto createLabWorkDto)
    {
        var command = _mapper.Map<CreateLabWorkCommand>(createLabWorkDto);
        command.UserId = UserId;
        var labWorkId = await Mediator.Send(command);
        return Ok(labWorkId);
    }

    /// <summary>
    ///     submit lab work
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /api/labWork/{id}
    ///     {
    ///     "title": "string",
    ///     "details": "string",
    ///     "filePath": "string",
    ///     }
    /// </remarks>
    /// <param name="createSubmittedLabDto">CreateSubmittedLabDto object</param>
    /// <param name="id"></param>
    /// <returns>Returns submitted lab work id (guid)</returns>
    /// <response code="201">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpPost("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create(Guid id, [FromBody] CreateSubmittedLabDto createSubmittedLabDto)
    {
        var command = _mapper.Map<CreateSubmittedLabCommand>(createSubmittedLabDto);
        command.UserId = UserId;
        command.LabWorkId = id;
        var labWorkId = await Mediator.Send(command);
        return Ok(labWorkId);
    }

    #endregion
    
    #region Put

    /// <summary>
    ///     Updates the lab work
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     PUT /api/labwork
    ///     {
    ///     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///     "title": "string",
    ///     "details": "string",
    ///     "filePath": "string",
    ///     }
    /// </remarks>
    /// <param name="updateLabWorkDto">UpdateLabWorkDto object</param>
    /// <returns>none</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Update([FromBody] UpdateLabWorkDto updateLabWorkDto)
    {
        var command = _mapper.Map<UpdateLabWorkCommand>(updateLabWorkDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }

    #endregion

    #region Delete

    /// <summary>
    ///     Deletes the lab work by id
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     DELETE /api/labwork/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    /// </remarks>
    /// <param name="id">lab work id</param>
    /// <returns>none</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteLabWorkCommand(id, UserId);
        await Mediator.Send(command);
        return NoContent();
    }

    #endregion
}