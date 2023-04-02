using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Refresh;

public class RefreshDto : IMapWith<RefreshDto>
{
    public string UserName { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<RefreshDto, RefreshCommand>()
            .ForMember(
                command => command.UserName,
                opt => opt.MapFrom(dto => dto.UserName)
            );
    }
}