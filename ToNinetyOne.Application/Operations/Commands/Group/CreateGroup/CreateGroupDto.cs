using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.Group.CreateGroup;

public class CreateGroupDto : IMapWith<CreateGroupCommand>
{
    public CreateGroupDto()
    {
        Title = "";
    }

    public CreateGroupDto(string title)
    {
        Title = title;
    }

    public string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateGroupDto, CreateGroupCommand>()
            .ForMember(
                command => command.Title,
                opt => opt.MapFrom(dto => dto.Title)
            );
    }
}