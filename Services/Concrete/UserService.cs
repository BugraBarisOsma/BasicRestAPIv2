using BasicRestAPI.Models;
using BasicRestAPI.Services.Abstract;

namespace BasicRestAPI.Services;

public class UserService : IUserService
{
    public readonly List<User> Users = new List<User>
    {
        new User { userName = "test", password = "12345" }
    };
    public async Task<User> ValidateUser(string userName, string password)
    {
        return Users.FirstOrDefault(u => u.userName == userName && u.password == password);
    }
}