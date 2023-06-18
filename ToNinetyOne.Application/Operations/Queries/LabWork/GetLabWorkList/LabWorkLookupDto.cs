using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkList;

public class LabWorkLookupDto : IMapWith<Domain.LabWork>
{
    public LabWorkLookupDto()
    {
        Title = "";
    }

    public LabWorkLookupDto(string title)
    {
        Title = title;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string DisciplineTitle { get; set; }
    public string? Mark { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.LabWork, LabWorkLookupDto>()
            .ForMember(
                labWorkDto => labWorkDto.Id,
                opt => opt.MapFrom(labWork => labWork.Id)
            ).ForMember(
                labWorkDto => labWorkDto.Title,
                opt => opt.MapFrom(labWork => labWork.Title)
            ).ForMember(
                labWorkDto => labWorkDto.DisciplineTitle,
                opt => opt.MapFrom(labWork => labWork.SelfDiscipline.Title)
            );
    }
}