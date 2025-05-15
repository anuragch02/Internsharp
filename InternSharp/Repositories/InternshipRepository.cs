using Dapper;
using InternSharp.DbContext;
using InternSharp.Models;

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
    }
}
