using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.Group.GetGroupList;

public class GroupLookupDto : IMapWith<Domain.Group>
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Group, GroupLookupDto>()
            .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(obj => obj.Id)
            );
    }
}