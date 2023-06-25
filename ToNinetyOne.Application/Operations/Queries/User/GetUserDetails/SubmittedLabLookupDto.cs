using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUserDetails;

public class SubmittedLabLookupDto : IMapWith<Domain.SubmittedLab>
{
    public Guid Id { get; set; }
    public Guid LabWorkId { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    public string? Mark { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.SubmittedLab, SubmittedLabLookupDto>()
            .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(obj => obj.Id)
            ).ForMember(
                dto => dto.Details,
                opt => opt.MapFrom(obj => obj.Details)
            ).ForMember(
                dto => dto.CreationDate,
                opt => opt.MapFrom(obj => obj.CreationDate)
            ).ForMember(
                dto => dto.EditDate,
                opt => opt.MapFrom(obj => obj.EditDate)
            ).ForMember(
                dto => dto.Mark,
                opt => opt.MapFrom(obj => obj.Mark)
            ).ForMember(
                dto => dto.Title,
                opt => opt.MapFrom(obj => obj.Title)
            ).ForMember(
                dto => dto.LabWorkId,
                opt => opt.MapFrom(obj => obj.SelfLabWork.Id)
            );
    }
}