using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.LabWorks.GetLabWorkDetails;

public class LabWorkDetailsViewModel : IMapWith<LabWork>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LabWork, LabWorkDetailsViewModel>()
            .ForMember(
                labWorkVm => labWorkVm.Title,
                opt => opt.MapFrom(labWork => labWork.Title))
            .ForMember(
                labWorkVm => labWorkVm.Details,
                opt => opt.MapFrom(labWork => labWork.Details)
            ).ForMember(
                labWorkVm => labWorkVm.FilePath,
                opt => opt.MapFrom(labWork => labWork.FilePath)
            ).ForMember(
                labWorkVm => labWorkVm.Id,
                opt => opt.MapFrom(labWork => labWork.Id)
            ).ForMember(
                labWorkVm => labWorkVm.CreationDate,
                opt => opt.MapFrom(labWork => labWork.CreationDate)
            ).ForMember(
                labWorkVm => labWorkVm.EditDate,
                opt => opt.MapFrom(labWork => labWork.EditDate)
            );
    }
}