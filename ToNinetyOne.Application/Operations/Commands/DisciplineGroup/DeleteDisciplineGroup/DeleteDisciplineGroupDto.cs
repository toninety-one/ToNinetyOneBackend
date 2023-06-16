using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.DisciplineGroup.AddDisciplineGroup;

public class DeleteDisciplineGroupDto : IMapWith<DeleteDisciplineGroupCommand>
{
    public Guid GroupId { get; set; }
    public Guid DisciplineId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteDisciplineGroupDto, DeleteDisciplineGroupCommand>()
            .ForMember(
                command => command.GroupId,
                opt => opt.MapFrom(dto => dto.GroupId)
            ).ForMember(
                command => command.DisciplineId,
                opt => opt.MapFrom(dto => dto.DisciplineId)
            );
    }
}