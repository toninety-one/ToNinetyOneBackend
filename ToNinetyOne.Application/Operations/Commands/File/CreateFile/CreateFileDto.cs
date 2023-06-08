using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.File.CreateFile;

public class CreateFileDto : IMapWith<CreateFileCommand>
{
    public void Mapping(Profile profile)
    {
        // profile.CreateMap<CreateFileDto, CreateFileCommand>()
        //     .ForMember(
        //         command => "template",
        //         opt => opt.MapFrom(dto => "template")
        //     );
    }
}
