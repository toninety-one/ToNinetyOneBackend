using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Queries.SubmittedLab.GetSubmittedLabDetails;

public class SubmittedLabDetailsViewModel : IMapWith<Domain.SubmittedLab>
{
    public SubmittedLabDetailsViewModel()
    {
        Id = Guid.NewGuid();
        Title = "";
        Details = "";
        CreationDate = DateTime.Now;
        EditDate = CreationDate;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    public string? Mark { get; set; }
    [Required] public Domain.User SelfUser { get; set; }
    [Required] public Domain.LabWork SelfLabWork { get; set; }
    public ICollection<Domain.File> Files { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.SubmittedLab, SubmittedLabDetailsViewModel>()
            .ForMember(
                viewModel => viewModel.Title,
                opt => opt.MapFrom(obj => obj.Title)
            ).ForMember(
                viewModel => viewModel.Id,
                opt => opt.MapFrom(obj => obj.Id)
            ).ForMember(
                viewModel => viewModel.Details,
                opt => opt.MapFrom(obj => obj.Details)
            ).ForMember(
                viewModel => viewModel.CreationDate,
                opt => opt.MapFrom(obj => obj.CreationDate)
            ).ForMember(
                viewModel => viewModel.EditDate,
                opt => opt.MapFrom(obj => obj.EditDate)
            ).ForMember(
                viewModel => viewModel.SelfUser,
                opt => opt.MapFrom(obj => obj.SelfUser)
            ).ForMember(
                viewModel => viewModel.SelfLabWork,
                opt => opt.MapFrom(obj => obj.SelfLabWork)
            );
    }
}