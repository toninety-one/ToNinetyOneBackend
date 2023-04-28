using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Commands.LabWork.CreateLabWork;
using ToNinetyOne.Application.Operations.Commands.LabWork.DeleteLabWork;
using ToNinetyOne.Application.Operations.Commands.LabWork.UpdateLabWork;
using ToNinetyOne.Application.Operations.Commands.SubmittedLab.CreateSubmittedLab;
using ToNinetyOne.Application.Operations.Commands.SubmittedLab.DeleteSubmittedLab;
using ToNinetyOne.Application.Operations.Commands.SubmittedLab.UpdateSubmittedLab;
using ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;
using ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkList;
using ToNinetyOne.Application.Operations.Queries.SubmittedLab.GetSubmittedLabDetails;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.WebApi.Controllers;

/// <inheritdoc />
[Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}, {Roles.User}")]
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
        var query = new GetLabWorkListQuery(UserId, disciplineId, UserRole);

        var viewModel = await Mediator.Send(query);

        return Ok(viewModel);
    }

    /// <summary>
    ///     Gets the lab work details by id
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
        var query = new GetLabWorkDetailsQuery(UserId, id, UserRole);

        var viewModel = await Mediator.Send(query);

        return Ok(viewModel);
    }

    /// <summary>
    ///     Gets the submitted lab by id
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /api/group/D34D349E-43B8-429E-BCA4-793C932FD580
    /// </remarks>
    /// <param name="id">Group id (guid)</param>
    /// <param name="submittedId">Group id (guid)</param>
    /// <returns>Returns GroupDetailsViewModel</returns>
    /// <response code="200">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpGet("{id:guid}/{submittedId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<SubmittedLabDetailsViewModel>> Get(Guid id, Guid submittedId)
    {
        var query = new GetSubmittedLabDetailsQuery(UserId, id, submittedId, UserRole);

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
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromForm] CreateLabWorkDto createLabWorkDto)
    {
        var command = _mapper.Map<CreateLabWorkCommand>(createLabWorkDto);
        command.UserId = UserId;
        command.UserRole = UserRole;
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
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.User}")]
    [HttpPost("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create(Guid id, [FromBody] CreateSubmittedLabDto createSubmittedLabDto)
    {
        var command = _mapper.Map<CreateSubmittedLabCommand>(createSubmittedLabDto);
        command.UserId = UserId;
        command.LabWorkId = id;
        command.UserRole = UserRole;
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
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Update([FromBody] UpdateLabWorkDto updateLabWorkDto)
    {
        var command = _mapper.Map<UpdateLabWorkCommand>(updateLabWorkDto);
        command.UserId = UserId;
        command.UserRole = UserRole;
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    ///     Updates the submitted lab
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     PUT /api/labwork/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///     {
    ///     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///     "title": "string",
    ///     "details": "string",
    ///     "filePath": "string",
    ///     }
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="updateSubmittedLabDto">UpdateSubmittedLabDto object</param>
    /// <returns>none</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}")]
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateSubmittedLabDto updateSubmittedLabDto)
    {
        var command = _mapper.Map<UpdateSubmittedLabCommand>(updateSubmittedLabDto);
        command.Id = id;
        command.UserId = UserId;
        command.UserRole = UserRole;
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
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}")]
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteLabWorkCommand(id, UserId, UserRole);
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    ///     Deletes the lab work by id
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     DELETE /api/labwork/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    /// </remarks>
    /// <param name="id">lab work id</param>
    /// <param name="submittedLabId"></param>
    /// <returns>none</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}")]
    [HttpDelete("{id:guid}/{submittedLabId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Delete(Guid id, Guid submittedLabId)
    {
        var command = new DeleteSubmittedLabCommand(id, submittedLabId, UserId, UserRole);
        await Mediator.Send(command);
        return NoContent();
    }

    #endregion
}