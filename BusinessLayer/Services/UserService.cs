using AutoMapper;
using BusinessLayer.Models;
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

    public void Create(UserModel model)
    {
        var user = mapper.Map<User>(model);
        userRepository.Create(user);
    }

    public UserModel[] GetAll()
    {
        var users = userRepository.GetAll()
            .Select(x => mapper.Map<UserModel>(x))
            .ToArray();

        return users;
    }

    public UserModel Get(int id)
    {
        var user = userRepository.Get(id);

        var userModel = mapper.Map<UserModel>(user);

        return userModel;
    }

    public void Update(UserModel model)
    {
        var user = userRepository.Get(model.Id);

        if (user == null)
            return;

        user.Name = model.Name;
        user.Email = model.Email;
        user.Password = model.Password;

        userRepository.Update(user);
    }

    public void Delete(int id)
    {
        userRepository.Delete(id);
    }
}