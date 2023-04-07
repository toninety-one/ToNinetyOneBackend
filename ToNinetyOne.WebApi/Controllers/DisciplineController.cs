using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Commands.Disciplines.CreateDiscipline;
using ToNinetyOne.Application.Operations.Commands.Disciplines.DeleteDiscipline;
using ToNinetyOne.Application.Operations.Commands.Disciplines.UpdateDiscipline;
using ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineDetails;
using ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineList;

namespace ToNinetyOne.WebApi.Controllers;

/// <inheritdoc />
[Authorize]
[ApiController]
[Produces("application/json")]
public class DisciplineController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper">configured mapper</param>
    public DisciplineController(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// return the list of all disciplines
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /api/discipline
    /// </remarks>
    /// <returns>returns DisciplineListViewModel</returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If user not auth</responce>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<DisciplineListViewModel>> GetAll()
    {
        var query = new GetDisciplineListQuery(UserId);

        var viewModel = await Mediator.Send(query);

        return Ok(viewModel);
    }

    /// <summary>
    /// Gets the discipline by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /api/discipline/D34D349E-43B8-429E-BCA4-793C932FD580
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
        var query = new GetDisciplineDetailsQuery(UserId, id);

        var viewModel = await Mediator.Send(query);

        return Ok(viewModel);
    }

    /// <summary>
    /// Creates the discipline
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /api/discipline
    /// {
    ///     title: "discipline title",
    ///     filePath: "file path"
    /// }
    /// </remarks>
    /// <param name="createDisciplineDto">CreateDisciplineDto object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateDisciplineDto createDisciplineDto)
    {
        var command = _mapper.Map<CreateDisciplineCommand>(createDisciplineDto);
        command.UserId = UserId;
        var disciplineId = await Mediator.Send(command);
        return Ok(disciplineId);
    }

    /// <summary>
    /// Updates the discipline
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PUT /api/discipline
    /// {
    ///     title: "updated discipline title",
    ///     filePath: "file path"
    /// }
    /// </remarks>
    /// <param name="updateDisciplineDto">updateDisciplineDto object</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Update([FromBody] UpdateDisciplineDto updateDisciplineDto)
    {
        var command = _mapper.Map<UpdateDisciplineCommand>(updateDisciplineDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Deletes the discipline by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /api/discipline/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    /// </remarks>
    /// <param name="id">Id of the discipline (guid)</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <responce code="401">If user not auth</responce>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteDisciplineCommand { Id = id, UserId = UserId };
        await Mediator.Send(command);
        return NoContent();
    }
}