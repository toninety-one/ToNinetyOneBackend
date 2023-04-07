using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupDetails;

public class GroupDetailsViewModel : IMapWith<Domain.Group>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<User> Users { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Group, GroupDetailsViewModel>()
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
                disciplineVm => disciplineVm.Users,
                opt => opt.MapFrom(discipline => discipline.Users)
            );
    }
}