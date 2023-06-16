using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Identity.Operations.Queries.GetUserDetails;

public class UserDetailsViewModel : IMapWith<Domain.User>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<IdentityDomain.User, UserDetailsViewModel>()
            .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(obj => obj.Id)
            ).ForMember(
                dto => dto.UserName,
                opt => opt.MapFrom(obj => obj.UserName)
            ).ForMember(
                dto => dto.UserRole,
                opt => opt.MapFrom(obj => obj.Role)
            );
    }
}