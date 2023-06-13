using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUserList;

public class UserLookupDto : IMapWith<Domain.User>
{
    public UserLookupDto()
    {
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string UserGroup { get; set; }
    public string? UserRole { get; set; } = Roles.User;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.User, UserLookupDto>()
            .ForMember(
                dto => dto.Id,
                opt => opt.MapFrom(obj => obj.Id)
            ).ForMember(
                dto => dto.LastName,
                opt => opt.MapFrom(obj => obj.LastName)
            ).ForMember(
                dto => dto.FirstName,
                opt => opt.MapFrom(obj => obj.FirstName)
            ).ForMember(
                dto => dto.MiddleName,
                opt => opt.MapFrom(obj => obj.MiddleName)
            ).ForMember(
                dto => dto.UserGroup,
                opt => opt.MapFrom(obj => obj.UserGroup!.Title)
            );
    }
}