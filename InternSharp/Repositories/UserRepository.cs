using InternSharp.Models;
using System.Data;
using Dapper;
using InternSharp.DbContext;
namespace InternSharp.Repositories

{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<UserModel> CreateUserAsync(UserModel user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@PasswordHash", user.PasswordHash);

            var query = "sp_RegisterUser";

            using var connection = _context.CreateConnection();
            var newUserId = await connection.ExecuteScalarAsync<int>(query, parameters, commandType: CommandType.StoredProcedure);

            user.Id = newUserId;
            return user;
        }
        public async Task<UserModel?> GetUserByEmailAsync(string email)
        {
            var query = "sp_GetUserByEmail"; 

            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);

            using var connection = _context.CreateConnection();
            var user = await connection.QuerySingleOrDefaultAsync<UserModel>(query, parameters, commandType: CommandType.StoredProcedure);

            return user;
        }
        public async Task<IEnumerable<AccountTypes>> GetAccountTypesAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "SELECT Id, AccountType FROM AccountsMaster"; // Assuming AccountType table
            return await connection.QueryAsync<AccountTypes>(query);
        }

    }
}
