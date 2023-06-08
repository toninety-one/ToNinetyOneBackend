using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Queries.Discipline.GetDisciplineDetails;

public class DisciplineDetailsViewModel : IMapWith<Domain.Discipline>
{
    public DisciplineDetailsViewModel()
    {
        Title = "";
    }

    public DisciplineDetailsViewModel(Guid id, string title, DateTime creationDate, DateTime editDate)
    {
        Id = id;
        Title = title;
        CreationDate = creationDate;
        EditDate = editDate;
    }

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public ICollection<Domain.Group> Groups { get; set; }
    public ICollection<Domain.LabWork> LabWorks { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Discipline, DisciplineDetailsViewModel>()
            .ForMember(
                disciplineVm => disciplineVm.Title,
                opt => opt.MapFrom(discipline => discipline.Title))
            .ForMember(
                disciplineVm => disciplineVm.Id,
                opt => opt.MapFrom(discipline => discipline.Id)
            ).ForMember(
                disciplineVm => disciplineVm.CreationDate,
                opt => opt.MapFrom(discipline => discipline.CreationDate)
            ).ForMember(
                disciplineVm => disciplineVm.EditDate,
                opt => opt.MapFrom(discipline => discipline.EditDate)
            ).ForMember(
                disciplineVm => disciplineVm.Groups,
                opt => opt.MapFrom(discipline => discipline.Groups)
            ).ForMember(
                disciplineVm => disciplineVm.UserId,
                opt => opt.MapFrom(discipline => discipline.UserId)
            ).ForMember(
                disciplineVm => disciplineVm.LabWorks,
                opt => opt.MapFrom(discipline => discipline.LabWorks)
            );
    }
}