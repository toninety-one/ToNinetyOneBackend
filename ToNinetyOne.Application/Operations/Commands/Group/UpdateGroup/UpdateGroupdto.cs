using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.Group.UpdateGroup;

public class UpdateGroupDto : IMapWith<UpdateGroupCommand>
{
    public string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateGroupDto, UpdateGroupCommand>()
            .ForMember(
                command => command.Title,
                opt => opt.MapFrom(dto => dto.Title)
            );
    }
}