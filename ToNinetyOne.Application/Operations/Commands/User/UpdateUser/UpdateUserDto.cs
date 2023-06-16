using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using ToNinetyOne.Config.Common.Mappings;

namespace ToNinetyOne.Application.Operations.Commands.User.UpdateUser;

public class UpdateUserDto : IMapWith<UpdateUserCommand>
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    [AllowNull] public Guid? GroupId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
            .ForMember(
                command => command.UserId,
                opt => opt.MapFrom(dto => dto.UserId)
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
                command => command.GroupId,
                opt => opt.MapFrom(dto => dto.GroupId)
            );
    }
}