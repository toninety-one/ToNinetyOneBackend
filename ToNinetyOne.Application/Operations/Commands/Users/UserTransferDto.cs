using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.Users;

public class UserTransferDto : IMapWith<UserTransferCommand>
{
    public Guid RegisterId { get; set; }

    public UserTransferDto(){}
    
    public UserTransferDto(Guid registerId)
    {
        RegisterId = registerId;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserTransferDto, UserTransferCommand>()
            .ForMember(
                command => command.RegisterId,
                opt => opt.MapFrom(dto => dto.RegisterId)
            );
    }
}