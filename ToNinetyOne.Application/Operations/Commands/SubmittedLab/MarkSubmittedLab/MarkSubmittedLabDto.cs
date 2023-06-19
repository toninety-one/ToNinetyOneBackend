using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.MarkSubmittedLab;

public class MarkSubmittedLabDto : IMapWith<MarkSubmittedLabCommand>
{
    public string Mark { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<MarkSubmittedLabDto, MarkSubmittedLabCommand>()
            .ForMember(
                command => command.Mark,
                opt => opt.MapFrom(dto => dto.Mark)
            );
    }
}