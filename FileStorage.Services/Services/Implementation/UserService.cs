using AutoMapper;
using FileStorage.Entities.Models;
using FileStorage.Repository;
using FileStorage.Services.Abstract;
using FileStorage.Services.Models;

namespace FileStorage.Services.Implementation;

public class UserService : IUserService
{
    private readonly IRepository<User> usersRepository;
    private readonly IMapper mapper;
    public UserService(IRepository<User> usersRepository, IMapper mapper)
    {
        this.usersRepository = usersRepository;
        this.mapper = mapper;
    }

    public void DeleteUser(Guid id)
    {
        var userToDelete = usersRepository.GetById(id);
        if (userToDelete == null)
        {
            throw new Exception("User not found");
        }

        usersRepository.Delete(userToDelete);
    }

    public UserModel GetUser(Guid id)
    {
        var user = usersRepository.GetById(id);
        return mapper.Map<UserModel>(user);
    }

    public PageModel<UserPreviewModel> GetUsers(int limit = 20, int offset = 0)
    {
        var users = usersRepository.GetAll();
        int totalCount = users.Count();
        var chunk = users.OrderBy(x => x.Email).Skip(offset).Take(limit);

        return new PageModel<UserPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<UserPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public UserModel UpdateUser(Guid id, UpdateUserModel user)
    {
        var existingUser = usersRepository.GetById(id);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        existingUser.Name = user.Name;
        existingUser.Email= user.Email;

        existingUser = usersRepository.Save(existingUser);
        return mapper.Map<UserModel>(existingUser);
    }
}