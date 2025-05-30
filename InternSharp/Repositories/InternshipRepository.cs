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
        public async Task<int> AddInternshipApplicationAsync(InternshipApplicationModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserID", model.UserID);
            parameters.Add("@InternshipID", model.InternshipID);
            parameters.Add("@StatusID", model.StatusID);
            parameters.Add("@AppliedDate", model.AppliedDate);
            parameters.Add("@ResumeID", model.ResumeID); 
            parameters.Add("@IsActive", model.IsActive);

            var query = "sp_AddInternshipApplication";
            using var connection = _context.CreateConnection();
            var applicationID = await connection.ExecuteScalarAsync<int>(
                query,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return applicationID;
        }
        public async Task<bool> HasUserAppliedAsync(int userId, int internshipId)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@UserID", userId);
            parameters.Add("@InternshipID", internshipId);

            var internship = await connection.QueryFirstOrDefaultAsync<InternshipModel>(
                "sp_GetAppliedInternships",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return internship != null;
        }
    }
}
