using InternSharp.Models;

namespace InternSharp.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<IEnumerable<AccountTypes>> GetAccountTypesAsync();
        Task<UserModel?> GetUserByEmailAsync(string email);
    }
}
