using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.Disciplines.CreateDiscipline;

public class CreateDisciplineDto : IMapWith<CreateDisciplineCommand>
{
    [Required] public string Title { get; set; }
    public string FilePath { get; set; }

    public CreateDisciplineDto()
    {
        Title = "";
        FilePath = "";
    }

    public CreateDisciplineDto(string title, string filePath)
    {
        Title = title;
        FilePath = filePath;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateDisciplineDto, CreateDisciplineCommand>()
            .ForMember(
                disciplineCommand => disciplineCommand.Title,
                opt => opt.MapFrom(disciplineDto => disciplineDto.Title)
            ).ForMember(
                disciplineCommand => disciplineCommand.FilePath,
                opt => opt.MapFrom(disciplineDto => disciplineDto.FilePath)
            );
    }
}