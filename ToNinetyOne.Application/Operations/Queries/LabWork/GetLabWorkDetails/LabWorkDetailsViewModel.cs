using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;
using ToNinetyOne.Domain;
using File = ToNinetyOne.Domain.File;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;

public class LabWorkDetailsViewModel : IMapWith<Domain.LabWork>
{
    public LabWorkDetailsViewModel()
    {
        Title = "";
        Details = "";
    }

    public LabWorkDetailsViewModel(Guid id, string title, string details, DateTime creationDate,
        DateTime editDate)
    {
        Id = id;
        Title = title;
        Details = details;
        CreationDate = creationDate;
        EditDate = editDate;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string? Mark { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    public IEnumerable<SubmittedLabDetailsLookupDto> SubmittedLabs { get; set; }
    public ICollection<File> Files { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.LabWork, LabWorkDetailsViewModel>()
            .ForMember(
                labWorkVm => labWorkVm.Title,
                opt => opt.MapFrom(labWork => labWork.Title))
            .ForMember(
                labWorkVm => labWorkVm.Details,
                opt => opt.MapFrom(labWork => labWork.Details)
            ).ForMember(
                labWorkVm => labWorkVm.Id,
                opt => opt.MapFrom(labWork => labWork.Id)
            ).ForMember(
                labWorkVm => labWorkVm.CreationDate,
                opt => opt.MapFrom(labWork => labWork.CreationDate)
            ).ForMember(
                labWorkVm => labWorkVm.EditDate,
                opt => opt.MapFrom(labWork => labWork.EditDate)
            ).ForMember(
                labWorkVm => labWorkVm.EditDate,
                opt => opt.MapFrom(labWork => labWork.EditDate)
            );
    }
}