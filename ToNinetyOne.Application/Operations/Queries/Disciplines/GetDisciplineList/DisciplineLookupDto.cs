using AutoMapper;
using ToNinetyOne.Application.Common.Mappings;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineList;

public class DisciplineLookupDto : IMapWith<Discipline>
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Discipline, DisciplineLookupDto>()
            .ForMember(
                disciplineDto => disciplineDto.Id,
                opt => opt.MapFrom(discipline => discipline.Id)
            ).ForMember(
                disciplineDto => disciplineDto.Title,
                opt => opt.MapFrom(discipline => discipline.Title)
            );
    }
}