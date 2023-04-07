using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.Disciplines.UpdateDiscipline;

public class UpdateDisciplineDto : IMapWith<UpdateDisciplineCommand>
{
    public string Title { get; set; }
    public string FilePath { get; set; }

    public UpdateDisciplineDto()
    {
        Title = "";
        FilePath = "";
    }

    public UpdateDisciplineDto(string title, string filePath)
    {
        Title = title;
        FilePath = filePath;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateDisciplineDto, UpdateDisciplineCommand>()
            .ForMember(
                disciplineCommand => disciplineCommand.Title,
                opt => opt.MapFrom(disciplineDto => disciplineDto.Title)
            ).ForMember(
                disciplineCommand => disciplineCommand.FilePath,
                opt => opt.MapFrom(disciplineDto => disciplineDto.FilePath)
            );
    }
}