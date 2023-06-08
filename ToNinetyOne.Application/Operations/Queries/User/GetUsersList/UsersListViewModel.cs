using ToNinetyOne.Application.Operations.Queries.LabWork.GetLabWorkList;

namespace ToNinetyOne.Application.Operations.Queries.User.GetUsersList;

public class UsersListViewModel
{
    public UsersListViewModel()
    {
        Users = new List<Domain.User>();
    }

    public UsersListViewModel(IList<Domain.User> users)
    {
        Users = users;
    }

    public IList<Domain.User> Users { get; set; }
}