using AutoMapper;
using ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkDetails;

public class SubmittedLabDetailsLookupDto : IMapWith<Domain.SubmittedLab>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    public string? Mark { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.SubmittedLab, SubmittedLabDetailsLookupDto>()
            .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(obj => obj.Id)
            ).ForMember(
                dto => dto.FirstName,
                opt => opt.MapFrom(obj => obj.SelfUser.FirstName)
            ).ForMember(
                dto => dto.LastName,
                opt => opt.MapFrom(obj => obj.SelfUser.LastName)
            ).ForMember(
                dto => dto.MiddleName,
                opt => opt.MapFrom(obj => obj.SelfUser.MiddleName)
            ).ForMember(
                dto => dto.Details,
                opt => opt.MapFrom(obj => obj.Details)
            ).ForMember(
                dto => dto.Title,
                opt => opt.MapFrom(obj => obj.Title)
            ).ForMember(
                dto => dto.CreationDate,
                opt => opt.MapFrom(obj => obj.CreationDate)
            ).ForMember(
                dto => dto.EditDate,
                opt => opt.MapFrom(obj => obj.EditDate)
            ).ForMember(
                dto => dto.Mark,
                opt => opt.MapFrom(obj => obj.Mark)
            );
    }
}