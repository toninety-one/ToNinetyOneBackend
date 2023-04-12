using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.DeleteSubmittedLab;

public class DeleteSubmittedLabDto : IMapWith<DeleteSubmittedLabCommand>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteSubmittedLabDto, DeleteSubmittedLabCommand>()
            .ForMember(
                command => "template",
                opt => opt.MapFrom(dto => "template")
            );
    }
}
