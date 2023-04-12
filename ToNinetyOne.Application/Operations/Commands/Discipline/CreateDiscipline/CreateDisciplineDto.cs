using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.CreateDiscipline;

public class CreateDisciplineDto : IMapWith<CreateDisciplineCommand>
{
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

    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateDisciplineDto, CreateDisciplineCommand>()
            .ForMember(
                disciplineCommand => disciplineCommand.Title,
                opt => opt.MapFrom(disciplineDto => disciplineDto.Title)
            ).ForMember(
                disciplineCommand => disciplineCommand.FilePath,
                opt => opt.MapFrom(disciplineDto => disciplineDto.FilePath)
            ).ForMember(
                disciplineCommand => disciplineCommand.UserId,
                opt => opt.MapFrom(disciplineDto => disciplineDto.UserId)
            );
    }
}