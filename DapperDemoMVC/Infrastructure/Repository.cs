using Dapper;
using DapperDemoMVC.Models;
using System.Data.SqlClient;

namespace DapperDemoMVC.Infrastructure
{
    public class Repository:IRepository
    {
        private string _connectionString;
        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool VerifyLogin(LoginCredentialsModel loginCredentials)
        {
            using var connection = new SqlConnection(_connectionString);

            var username = loginCredentials.username;
            var password = loginCredentials.password;

            string query = "Select * from tbl_users where username = @username";
            var user = connection.QueryFirstOrDefault<UserEntity>(query, new { username });

            var isValidCredentials = false;
            if (user != null)
            {
                isValidCredentials = (user.password == password);
            }
            return isValidCredentials;
        }
    }
}
