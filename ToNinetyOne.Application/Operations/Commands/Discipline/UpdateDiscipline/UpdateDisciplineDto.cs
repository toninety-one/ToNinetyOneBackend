using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.UpdateDiscipline;

public class UpdateDisciplineDto : IMapWith<UpdateDisciplineCommand>
{
    public UpdateDisciplineDto()
    {
        Title = "";
    }

    public UpdateDisciplineDto(string title)
    {
        Title = title;
    }

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateDisciplineDto, UpdateDisciplineCommand>()
            .ForMember(
                disciplineCommand => disciplineCommand.Title,
                opt => opt.MapFrom(disciplineDto => disciplineDto.Title)
            ).ForMember(
                disciplineCommand => disciplineCommand.UserId,
                opt => opt.MapFrom(disciplineDto => disciplineDto.UserId)
            ).ForMember(
                disciplineCommand => disciplineCommand.Id,
                opt => opt.MapFrom(disciplineDto => disciplineDto.Id)
            );
    }
}