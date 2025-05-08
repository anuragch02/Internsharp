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
            user.Id = Guid.NewGuid();
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            var parameters = new DynamicParameters();
            parameters.Add("@Id", user.Id);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@PasswordHash", user.PasswordHash);

            var query = " "; //  stored procedure

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

            return user;
        }
        public async Task<UserModel?> GetUserByEmailAsync(string email)
        {
            var query = " "; // Replace with your stored procedure name

            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);

            using var connection = _context.CreateConnection();
            var user = await connection.QuerySingleOrDefaultAsync<UserModel>(query, parameters, commandType: CommandType.StoredProcedure);

            return user;
        }

    }
}
