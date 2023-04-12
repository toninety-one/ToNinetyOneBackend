using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineList;

public class DisciplineLookupDto : IMapWith<Domain.Discipline>
{
    public DisciplineLookupDto()
    {
        Title = "";
    }

    public DisciplineLookupDto(string title)
    {
        Title = title;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Discipline, DisciplineLookupDto>()
            .ForMember(
                disciplineDto => disciplineDto.Id,
                opt => opt.MapFrom(discipline => discipline.Id)
            ).ForMember(
                disciplineDto => disciplineDto.Title,
                opt => opt.MapFrom(discipline => discipline.Title)
            );
    }
}