using System.Data;
//using System.Data.SQLite;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace NoventIQ.UserMgmt.Repositories
{
    public class Daprepositories
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;


        public Daprepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");

        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using IDbConnection db = new SqliteConnection(_connectionString);
            return await db.QueryAsync<T>(sql, parameters);
        }
    }
}
