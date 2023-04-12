using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.CreateLabWork;

public class CreateLabWorkDto : IMapWith<CreateLabWorkCommand>
{
    public Guid DisciplineId { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateLabWorkDto, CreateLabWorkCommand>()
            .ForMember(
                command => command.Title,
                opt => opt.MapFrom(dto => dto.Title)
            ).ForMember(
                command => command.Details,
                opt => opt.MapFrom(dto => dto.Details)
            ).ForMember(
                command => command.FilePath,
                opt => opt.MapFrom(dto => dto.FilePath)
            ).ForMember(
                command => command.DisciplineId,
                opt => opt.MapFrom(dto => dto.DisciplineId)
            );
    }
}