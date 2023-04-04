using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Identity.Operations.Commands.Registration;

public class RegistrationDto : IMapWith<RegistrationDto>
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegistrationDto, RegistrationCommand>()
            .ForMember(
                command => command.UserName,
                opt => opt.MapFrom(dto => dto.UserName)
            ).ForMember(
                command => command.Password,
                opt => opt.MapFrom(dto => dto.Password)
            );
    }
}