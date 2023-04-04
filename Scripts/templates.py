operations = {
    "command": """using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.{0}.{1};

public class {0}Command : IRequest<Guid>
{
}
    
    """,
    "handler": """using MediatR;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;
        
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
"""
}
