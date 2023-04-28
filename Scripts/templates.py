operations = {
    "command": """using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.{0}.{1};

public class {1}Command : IRequest<Guid>
{
    public Guid UserId { get; set; }
}
    
    """,
    "handler": """using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
        
namespace ToNinetyOne.Application.Operations.Commands.{0}.{1};
        
public class  {1}CommandHandler : IRequestHandler<{1}Command, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;
        
    public {1}CommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public async Task<Guid> Handle({1}Command request, CancellationToken cancellationToken)
    {
    
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);
        
        throw new NotImplementedException();
    }
}
"""
    ,
    "validator": """using FluentValidation;

namespace ToNinetyOne.Application.Operations.Commands.{0}.{1};

public class {1}CommandValidator : AbstractValidator<{1}Command>
{
    public {1}CommandValidator()
    {
        RuleFor(command => command.UserId).NotEqual(Guid.Empty);
    }
}
    
""",
    "dto": """using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.{0}.{1};

public class {1}Dto : IMapWith<{1}Command>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<{1}Dto, {1}Command>()
            .ForMember(
                command => "template",
                opt => opt.MapFrom(dto => "template")
            );
    }
}
""",
    "query": """using MediatR;

namespace ToNinetyOne.Application.Operations.Queries.{0}.{1};

public class {1}Query : IRequest<{1}ViewModel>
{
}
    """,
    "queryhandler": """using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;

namespace ToNinetyOne.Application.Operations.Queries.{0}.{1};

public class {1}QueryHandler : IRequestHandler<{1}Query, {0}ListViewModel>
{
    private readonly IToNinetyOneDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetLabWorkListQueryHandler(IToNinetyOneDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<{0}ListViewModel> Handle({1}Query request, CancellationToken cancellationToken)
    {
        var query = new {0}Query();
        
        return new {0}ListViewModel(query);
    }
}
""",
    "viewmodel": """namespace ToNinetyOne.Application.Operations.Queries.{0}.{1};

public class {0}ListViewModel
{
    public IList<{0}LookupDto> {0}s { get; set; }

    public {0}ListViewModel()
    {
        {0}s = new List<{0}LookupDto>();
    }

    public {0}ListViewModel(IList<{0}LookupDto> lookup)
    {
        {0}s = lookup;
    }
}
    """,
}
