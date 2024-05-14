namespace BusinessLayer.Models.Role;

public class RoleListModel
{
    public RoleListModel(RoleItemModel[] roles)
    {
        Roles = roles;
    }

    public RoleItemModel[] Roles { get; set; }
}