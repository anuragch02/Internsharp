using Dapper;
using InternSharp.DbContext;
using InternSharp.Models;
using System.Data;
using System.Text.Json;

namespace InternSharp.Repositories
{
    public class InternshipRepository : IInternshipRepository
    {
        private readonly DapperContext _context;

        public InternshipRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<InternshipModel>> GetAllInternshipsAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "sp_GetAllInternships";
            var internships = await connection.QueryAsync<InternshipModel>(query);
            return internships;
        }
        public async Task<InternshipModel> GetInternshipByIdAsync(int id)
        {
            using var connection = _context.CreateConnection();
            var query = "sp_GetInternshipById";

            var parameters = new { ID = id };

            var internship = await connection.QueryFirstOrDefaultAsync<InternshipModel>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure);
            return internship;
        }
    }
}
