using AutoMapper;
using Microsoft.AspNetCore.Http;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.CreateSubmittedLab;

public class CreateSubmittedLabDto : IMapWith<CreateSubmittedLabCommand>
{
    public string Title { get; set; }
    public string Details { get; set; }
    public IEnumerable<IFormFile> Files { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateSubmittedLabDto, CreateSubmittedLabCommand>()
            .ForMember(
                command => command.Title,
                opt => opt.MapFrom(dto => dto.Title)
            ).ForMember(
                command => command.Details,
                opt => opt.MapFrom(dto => dto.Details)
            ).ForMember(
                command => command.Files,
                opt => opt.MapFrom(dto => dto.Files)
            );
    }
}