namespace ToNinetyOne.Identity.Operations.Queries.GetIdentityUserRoles;

public class IdentityUserRolesViewModel
{
    public IdentityUserRolesViewModel()
    {
        Roles = new List<IdentityUserRolesLookupDto>();
    }

    public IdentityUserRolesViewModel(IList<IdentityUserRolesLookupDto> roles)
    {
        Roles = roles;
    }

    public IList<IdentityUserRolesLookupDto> Roles { get; set; }
}