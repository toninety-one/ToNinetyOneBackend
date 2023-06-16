using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Identity.Operations.Commands.UpdateIdentityUser;

public class UpdateIdentityUserDto : IMapWith<UpdateIdentityUserCommand>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateIdentityUserDto, UpdateIdentityUserCommand>()
            .ForMember(
                command => command.Id,
                opt => opt.MapFrom(dto => dto.Id)
            ).ForMember(
                command => command.UserName,
                opt => opt.MapFrom(dto => dto.UserName)
            ).ForMember(
                command => command.UserRole,
                opt => opt.MapFrom(dto => dto.UserRole)
            );
    }
}