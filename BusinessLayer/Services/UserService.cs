using AutoMapper;
using BusinessLayer.Models.Auth;
using BusinessLayer.Models.User;
using DataLayer.Entities.Users;
using DataLayer.Repositories;

namespace BusinessLayer.Services;

public class UserService
{
    private readonly UserRepository userRepository;
    private readonly IMapper mapper;

    public UserService(IMapper mapper, UserRepository userRepository)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public void Create(UserForm itemModel)
    {
        var user = mapper.Map<User>(itemModel);
        userRepository.Create(user);
    }

    public UserItemModel[] GetAll()
    {
        var users = userRepository.GetAll()
            .Select(x => mapper.Map<UserItemModel>(x))
            .OrderBy(x => x.Id)
            .ToArray();

        return users;
    }

    public UserItemModel Get(int id)
    {
        var user = userRepository.Get(id);

        var userModel = mapper.Map<UserItemModel>(user);

        return userModel;
    }

    public UserForm GetForUpdate(int id)
    {
        var user = userRepository.Get(id);

        var userForm = mapper.Map<UserForm>(user);

        return userForm;
    }

    public void Update(UserForm form)
    {
        var user = userRepository.Get(form.Id!.Value);

        if (user == null)
            return;

        user.Name = form.Name;
        user.Email = form.Email;
        user.Password = form.Password;

        userRepository.Update(user);
    }

    public void Delete(int id)
    {
        userRepository.Delete(id);
    }

    public void Create(RegisterForm form)
    {
        var user = mapper.Map<User>(form);
        userRepository.Create(user);
    }
}