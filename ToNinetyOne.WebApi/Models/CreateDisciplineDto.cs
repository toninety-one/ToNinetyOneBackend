using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ToNinetyOne.Application.Common.Mappings;
using ToNinetyOne.Application.Operations.Commands.Disciplines.CreateDiscipline;

namespace ToNinetyOne.WebApi.Models;

public class CreateDisciplineDto : IMapWith<CreateDisciplineCommand>
{
    [Required]
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
            );
    }
}