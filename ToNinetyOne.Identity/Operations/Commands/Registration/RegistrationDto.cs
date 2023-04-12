using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Identity.Operations.Commands.Registration;

public class RegistrationDto : IMapWith<RegistrationDto>
{
    public RegistrationDto()
    {
    }

    public RegistrationDto(string userName, string password, string firstName, string lastName, string middleName)
    {
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Password { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegistrationDto, RegistrationCommand>()
            .ForMember(
                command => command.UserName,
                opt => opt.MapFrom(dto => dto.UserName)
            ).ForMember(
                command => command.FirstName,
                opt => opt.MapFrom(dto => dto.FirstName)
            ).ForMember(
                command => command.LastName,
                opt => opt.MapFrom(dto => dto.LastName)
            ).ForMember(
                command => command.MiddleName,
                opt => opt.MapFrom(dto => dto.MiddleName)
            ).ForMember(
                command => command.Password,
                opt => opt.MapFrom(dto => dto.Password)
            );
    }
}