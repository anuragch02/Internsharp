using Microsoft.Data.SqlClient;
using System.Data;

namespace InternSharp.DbContext
{
    public class DapperContext
    {
        public readonly IConfiguration Configuration;
        public readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            Configuration = configuration;
            _connectionString = Configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
