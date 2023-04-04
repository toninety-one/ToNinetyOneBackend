using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.Group.DeleteGroup;

public class DeleteGroupDto : IMapWith<DeleteGroupCommand>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteGroupDto, DeleteGroupCommand>()
            .ForMember(
                command => "template",
                opt => opt.MapFrom(dto => "template")
            );
    }
}
