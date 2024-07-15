using BasicRestAPI.Models;

namespace BasicRestAPI.Services.Abstract;

public interface IUserService
{
    public Task<User> ValidateUser(string userName, string password); 
}