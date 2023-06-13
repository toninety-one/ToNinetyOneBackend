namespace ToNinetyOne.Identity.Operations.Queries.GetUserRoles;

public class UserRolesViewModel
{
    public UserRolesViewModel()
    {
        Roles = new List<UserRolesLookupDto>();
    }

    public UserRolesViewModel(IList<UserRolesLookupDto> roles)
    {
        Roles = roles;
    }

    public IList<UserRolesLookupDto> Roles { get; set; }
}