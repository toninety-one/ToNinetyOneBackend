using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToNinetyOne.Application.Operations.Queries.UserProfile;

namespace ToNinetyOne.WebApi.Controllers;

/// <inheritdoc />
[Authorize]
[ApiController]
public class SubmittedLabController : BaseController
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mapper">configured mapper</param>
    public SubmittedLabController(IMapper mapper)
    {
        _mapper = mapper;
    }

    #region Get

    /// <summary>
    /// return user profile info
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /api/labwork
    /// </remarks>
    /// <returns>returns GroupListViewModel</returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If user not auth</responce>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Get()
    {
        return Ok(new List<string>());
    }

    /// <summary>
    /// return user profile info
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /api/labwork
    /// </remarks>
    /// <returns>returns GroupListViewModel</returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If user not auth</responce>
    [HttpGet("{disciplineId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Get(Guid disciplineId)
    {
        return Ok(disciplineId);
    }

    /// <summary>
    /// return user profile info
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /api/labwork
    /// </remarks>
    /// <returns>returns GroupListViewModel</returns>
    /// <responce code="200">Success</responce>
    /// <responce code="401">If user not auth</responce>
    [HttpGet("{disciplineId:guid}/{labId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> Get(Guid disciplineId, Guid labId)
    {
        return Ok(disciplineId.ToString() + labId.ToString());
    }

    #endregion
}