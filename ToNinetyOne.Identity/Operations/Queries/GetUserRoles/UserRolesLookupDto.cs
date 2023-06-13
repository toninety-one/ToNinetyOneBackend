using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Identity.Operations.Queries.GetUserRoles;

public class UserRolesLookupDto : IMapWith<IdentityDomain.User>
{
    public UserRolesLookupDto()
    {
    }

    public Guid Id { get; set; }
    public string? UserRole { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<IdentityDomain.User, UserRolesLookupDto>()
            .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(obj => obj.Id)
            ).ForMember(
                dto => dto.UserRole,
                opt => opt.MapFrom(obj => obj.Role)
            );
    }
}