using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;

namespace MovieApi.Repository.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserById(Guid id);
    Task AddUser(User user);
    Task DeleteUser(Guid id);
    bool UserExists(Guid id);
}
