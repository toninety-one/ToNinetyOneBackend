using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Commands.Discipline.CreateDiscipline;
using ToNinetyOne.Application.Operations.Commands.Discipline.DeleteDiscipline;
using ToNinetyOne.Application.Operations.Commands.Discipline.UpdateDiscipline;
using ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineDetails;
using ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineList;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.WebApi.Controllers;

/// <inheritdoc />
[Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}, {Roles.User}")]
[ApiController]
public class DisciplineController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="mapper">configured mapper</param>
    public DisciplineController(IMapper mapper)
    {
        _mapper = mapper;
    }

    #region Get

    /// <summary>
    ///     return the list of all disciplines
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /api/discipline
    /// </remarks>
    /// <returns>returns DisciplineListViewModel</returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If user not auth</responce>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<DisciplineListViewModel>> Get()
    {
        var query = new GetDisciplineListQuery(UserId, UserRole);

        var viewModel = await Mediator.Send(query);

        return Ok(viewModel);
    }

    /// <summary>
    ///     Gets the discipline by id
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     GET /api/discipline/D34D349E-43B8-429E-BCA4-793C932FD580
    /// </remarks>
    /// <param name="id">Discipline id (guid)</param>
    /// <returns>Returns DisciplineDetailsViewModel</returns>
    /// <response code="200">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<DisciplineDetailsViewModel>> Get(Guid id)
    {
        var query = new GetDisciplineDetailsQuery(UserId, id, UserRole);
        var viewModel = await Mediator.Send(query);
        return Ok(viewModel);
    }

    #endregion

    #region Post

    /// <summary>
    ///     Creates the discipline
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     POST /api/discipline
    ///     {
    ///     title: "discipline title",
    ///     filePath: "file path"
    ///     }
    /// </remarks>
    /// <param name="createDisciplineDto">CreateDisciplineDto object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201">Success</response>
    /// <responce code="401">If user not auth</responce>
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateDisciplineDto createDisciplineDto)
    {
        var command = _mapper.Map<CreateDisciplineCommand>(createDisciplineDto);
        if (createDisciplineDto.UserId == Guid.Empty)
        {
            command.UserId = UserId;
        }

        var disciplineId = await Mediator.Send(command);
        return Ok(disciplineId);
    }

    #endregion

    #region Put

    /// <summary>
    ///     Updates the discipline
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     PUT /api/discipline
    ///     {
    ///     title: "updated discipline title",
    ///     filePath: "file path"
    ///     }
    /// </remarks>
    /// <param name="updateDisciplineDto">updateDisciplineDto object</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Update([FromBody] UpdateDisciplineDto updateDisciplineDto)
    {
        var command = _mapper.Map<UpdateDisciplineCommand>(updateDisciplineDto);
        command.UserRole = UserRole;

        if (updateDisciplineDto.UserId == Guid.Empty)
        {
            command.UserId = UserId;
        }

        await Mediator.Send(command);
        return NoContent();
    }

    #endregion

    #region Delete

    /// <summary>
    ///     Deletes the discipline by id
    /// </summary>
    /// <remarks>
    ///     Sample request:
    ///     DELETE /api/discipline/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    /// </remarks>
    /// <param name="id">Id of the discipline (guid)</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [Authorize(Roles = $"{Roles.Administrator}, {Roles.Teacher}")]
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteDisciplineCommand
        {
            Id = id,
            UserId = UserId,
            UserRole = UserRole
        };
        await Mediator.Send(command);
        return NoContent();
    }

    #endregion
}