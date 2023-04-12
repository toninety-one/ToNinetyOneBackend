using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Queries.UserProfile;

public class UserProfileViewModel : IMapWith<User>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Domain.Group Group { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserProfileViewModel>()
            .ForMember(
                dto => dto.FirstName,
                opt => opt.MapFrom(obj => obj.FirstName)
            ).ForMember(
                dto => dto.LastName,
                opt => opt.MapFrom(obj => obj.LastName)
            ).ForMember(
                dto => dto.MiddleName,
                opt => opt.MapFrom(obj => obj.MiddleName)
            ).ForMember(
                dto => dto.Group,
                opt => opt.MapFrom(obj => obj.UserGroup)
            );
    }
}