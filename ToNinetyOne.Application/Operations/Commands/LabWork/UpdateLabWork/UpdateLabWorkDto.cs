using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.UpdateLabWork;

public class UpdateLabWorkDto : IMapWith<UpdateLabWorkCommand>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateLabWorkDto, UpdateLabWorkCommand>()
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
                command => command.Id,
                opt => opt.MapFrom(dto => dto.Id)
            );
    }
}