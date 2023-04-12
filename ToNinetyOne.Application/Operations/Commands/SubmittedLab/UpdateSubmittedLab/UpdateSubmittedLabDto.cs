using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.UpdateSubmittedLab;

public class UpdateSubmittedLabDto : IMapWith<UpdateSubmittedLabCommand>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateSubmittedLabDto, UpdateSubmittedLabCommand>()
            .ForMember(
                command => "template",
                opt => opt.MapFrom(dto => "template")
            );
    }
}
