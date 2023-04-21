using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.UpdateSubmittedLab;

public class UpdateSubmittedLabDto : IMapWith<UpdateSubmittedLabCommand>
{
    public Guid Id { get; set; }
    public Guid SelfLabId { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateSubmittedLabDto, UpdateSubmittedLabCommand>()
            .ForMember(
                command => command.Details,
                opt => opt.MapFrom(dto => dto.Details)
            ).ForMember(
                command => command.Id,
                opt => opt.MapFrom(dto => dto.Id)
            ).ForMember(
                command => command.Title,
                opt => opt.MapFrom(dto => dto.Title)
            ).ForMember(
                command => command.FilePath,
                opt => opt.MapFrom(dto => dto.FilePath)
            ).ForMember(
                command => command.SelfLabId,
                opt => opt.MapFrom(dto => dto.SelfLabId)
            );
    }
}