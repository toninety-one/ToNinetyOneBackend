using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.User;

public class UserTransferDto : IMapWith<UserTransferCommand>
{
    public Guid RegisterId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }

    public UserTransferDto()
    {
        FirstName = "";
        LastName = "";
        MiddleName = "";
    }

    public UserTransferDto(Guid registerId)
    {
        RegisterId = registerId;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserTransferDto, UserTransferCommand>()
            .ForMember(
                command => command.RegisterId,
                opt => opt.MapFrom(dto => dto.RegisterId)
            ).ForMember(
                command => command.FirstName,
                opt => opt.MapFrom(dto => dto.FirstName)
            ).ForMember(
                command => command.LastName,
                opt => opt.MapFrom(dto => dto.LastName)
            ).ForMember(
                command => command.MiddleName,
                opt => opt.MapFrom(dto => dto.MiddleName)
            );
    }
}