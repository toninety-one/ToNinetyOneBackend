using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.File.DeleteFile;

public class DeleteFileDto : IMapWith<DeleteFileCommand>
{
    public Guid Id { get; set; }
    public Guid SelfId { get; set; }
    public string Type { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteFileDto, DeleteFileCommand>()
            .ForMember(
                command => command.SelfId,
                opt => opt.MapFrom(dto => dto.SelfId)
            ).ForMember(
                command => command.Type,
                opt => opt.MapFrom(dto => dto.Type)
            ).ForMember(
                command => command.Id,
                opt => opt.MapFrom(dto => dto.Id)
            );
    }
}