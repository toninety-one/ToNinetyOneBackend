using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.User.UpdateUser;

public class UpdateUserDto : IMapWith<UpdateUserCommand>
{
    public Guid UserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
            .ForMember(
                command => command.UserId,
                opt => opt.MapFrom(dto => dto.UserId)
            );
    }
}