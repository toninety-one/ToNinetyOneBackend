using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Identity.Operations.Commands.UpdateUser;

public class UpdateUserDto : IMapWith<UpdateUserCommand>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
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