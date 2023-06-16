using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUserDetails;

public class UserDetailsViewModel : IMapWith<Domain.User>
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string UserRole { get; set; }
    public Domain.Group UserGroup { get; set; }
    public IEnumerable<Domain.SubmittedLab> LastSubmittedLabs { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.User, UserDetailsViewModel>()
            .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(obj => obj.Id)
            ).ForMember(
                dto => dto.FirstName,
                opt => opt.MapFrom(obj => obj.FirstName)
            ).ForMember(
                dto => dto.LastName,
                opt => opt.MapFrom(obj => obj.LastName)
            ).ForMember(
                dto => dto.MiddleName,
                opt => opt.MapFrom(obj => obj.MiddleName)
            ).ForMember(
                dto => dto.UserGroup,
                opt => opt.MapFrom(obj => obj.UserGroup)
            );
    }
}