using AutoMapper;
using ToNinetyOne.Application.Common.Mappings;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.LabWorks.GetLabWorkList;

public class LabWorkLookupDto : IMapWith<LabWork>
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LabWork, LabWorkLookupDto>()
            .ForMember(
                labWorkDto => labWorkDto.Id,
                opt => opt.MapFrom(labWork => labWork.Id)
            ).ForMember(
                labWorkDto => labWorkDto.Title,
                opt => opt.MapFrom(labWork => labWork.Title)
            );
    }
}