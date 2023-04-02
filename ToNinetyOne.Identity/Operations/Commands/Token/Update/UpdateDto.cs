using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;
using ToNinetyOne.Identity.Operations.Commands.Token.Refresh;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Update;

public class UpdateDto : IMapWith<UpdateDto>
{
    public string UserName { get; set; }
    public string RefreshToken { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateDto, UpdateCommand>()
            .ForMember(
                command => command.UserName,
                opt => opt.MapFrom(dto => dto.UserName)
            ).ForMember(
                command => command.RefreshToken,
                opt => opt.MapFrom(dto => dto.RefreshToken)
            );
    }
}