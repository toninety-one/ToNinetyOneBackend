using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Identity.Operations.Queries.GetIdentityUserRoles;

public class IdentityUserRolesLookupDto : IMapWith<IdentityDomain.User>
{
    public IdentityUserRolesLookupDto()
    {
    }

    public Guid Id { get; set; }
    public string? UserRole { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<IdentityDomain.User, IdentityUserRolesLookupDto>()
            .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(obj => obj.Id)
            ).ForMember(
                dto => dto.UserRole,
                opt => opt.MapFrom(obj => obj.Role)
            );
    }
}