using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.Group.SetUserGroup;

public class SetUserGroupDto : IMapWith<SetUserGroupCommand>
{
    public Guid UserId { get; set; }
    public Guid GroupId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SetUserGroupDto, SetUserGroupCommand>()
            .ForMember(
                command => command.GroupId,
                opt => opt.MapFrom(dto => dto.GroupId)
            ).ForMember(
                command => command.UserId,
                opt => opt.MapFrom(dto => dto.UserId)
            );
    }
}
