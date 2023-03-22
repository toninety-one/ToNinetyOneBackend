using AutoMapper;
using ToNinetyOne.Application.Common.Mappings;
using ToNinetyOne.Application.Operations.Commands.Disciplines.CreateDiscipline;
using ToNinetyOne.Application.Operations.Commands.Disciplines.UpdateDiscipline;

namespace ToNinetyOne.WebApi.Models;

public class UpdateDisciplineDto : IMapWith<UpdateDisciplineCommand>
{
    public string Title { get; set; }
    public string FilePath { get; set; }

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