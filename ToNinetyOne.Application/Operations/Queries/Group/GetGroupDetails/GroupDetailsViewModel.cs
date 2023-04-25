using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupDetails;

public class GroupDetailsViewModel : IMapWith<Domain.Group>
{
    public GroupDetailsViewModel()
    {
        Title = "";
    }

    public GroupDetailsViewModel(Guid id, string title, ICollection<Domain.User> users, DateTime creationDate,
        DateTime editDate)
    {
        Id = id;
        Title = title;
        Users = users;
        CreationDate = creationDate;
        EditDate = editDate;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public ICollection<Domain.User> Users { get; set; }
    public ICollection<Domain.Discipline> Disciplines { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Group, GroupDetailsViewModel>()
            .ForMember(
                viewModel => viewModel.Id,
                opt => opt.MapFrom(obj => obj.Id)
            ).ForMember(
                viewModel => viewModel.Title,
                opt => opt.MapFrom(obj => obj.Title)
            ).ForMember(
                viewModel => viewModel.Users,
                opt => opt.MapFrom(obj => obj.Users)
            ).ForMember(
                viewModel => viewModel.Disciplines,
                opt => opt.MapFrom(obj => obj.Disciplines)
            ).ForMember(
                viewModel => viewModel.CreationDate,
                opt => opt.MapFrom(obj => obj.CreationDate)
            ).ForMember(
                viewModel => viewModel.EditDate,
                opt => opt.MapFrom(obj => obj.EditDate)
            );
    }
}