using AutoMapper;
using BusinessLayer.Models.Role;
using DataLayer.Entities.Users;
using DataLayer.Repositories;

namespace BusinessLayer.Services;

public class RoleService
{
    private readonly RoleRepository roleRepository;
    private readonly IMapper mapper;

    public RoleService(IMapper mapper, RoleRepository roleRepository)
    {
        this.roleRepository = roleRepository;
        this.mapper = mapper;
    }

    public void Create(RoleForm itemModel)
    {
        var role = mapper.Map<Role>(itemModel);
        roleRepository.Create(role);
    }

    public RoleItemModel[] GetAll()
    {
        var roles = roleRepository.GetAll()
            .Select(x => mapper.Map<RoleItemModel>(x))
            .OrderBy(x => x.Id)
            .ToArray();

        return roles;
    }

    public RoleItemModel Get(int id)
    {
        var role = roleRepository.Get(id);

        var roleModel = mapper.Map<RoleItemModel>(role);

        return roleModel;
    }

    public RoleForm GetForUpdate(int id)
    {
        var role = roleRepository.Get(id);

        var roleForm = mapper.Map<RoleForm>(role);

        return roleForm;
    }

    public void Update(RoleForm form)
    {
        var role = roleRepository.Get(form.Id!.Value);

        if (role == null)
            return;

        role.Name = form.Name;

        roleRepository.Update(role);
    }

    public void Delete(int id)
    {
        roleRepository.Delete(id);
    }
}