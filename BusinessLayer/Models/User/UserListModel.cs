namespace BusinessLayer.Models.User;

public class UserListModel
{
    public UserListModel(UserItemModel[] users)
    {
        Users = users;
    }

    public UserItemModel[] Users { get; set; }
}