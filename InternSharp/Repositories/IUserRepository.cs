using InternSharp.Models;

namespace InternSharp.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<UserModel?> GetUserByEmailAsync(string email);
    }
}
