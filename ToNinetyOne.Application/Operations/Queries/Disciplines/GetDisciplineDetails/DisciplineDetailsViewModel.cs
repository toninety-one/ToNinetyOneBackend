using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.Disciplines.GetDisciplineDetails;

public class DisciplineDetailsViewModel : IMapWith<Discipline>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }

    public DisciplineDetailsViewModel()
    {
        Title = "";
        FilePath = "";
    }

    public DisciplineDetailsViewModel(Guid id, string title, string filePath, DateTime creationDate, DateTime editDate)
    {
        Id = id;
        Title = title;
        FilePath = filePath;
        CreationDate = creationDate;
        EditDate = editDate;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Discipline, DisciplineDetailsViewModel>()
            .ForMember(
                disciplineVm => disciplineVm.Title,
                opt => opt.MapFrom(discipline => discipline.Title))
            .ForMember(
                disciplineVm => disciplineVm.FilePath,
                opt => opt.MapFrom(discipline => discipline.FilePath)
            ).ForMember(
                disciplineVm => disciplineVm.Id,
                opt => opt.MapFrom(discipline => discipline.Id)
            ).ForMember(
                disciplineVm => disciplineVm.CreationDate,
                opt => opt.MapFrom(discipline => discipline.CreationDate)
            ).ForMember(
                disciplineVm => disciplineVm.EditDate,
                opt => opt.MapFrom(discipline => discipline.EditDate)
            );
    }
}