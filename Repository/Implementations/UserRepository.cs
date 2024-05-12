using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using MySqlConnector;
using Repository.Contracts;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private const string Sql = "SELECT * FROM User where IdUsuario =  @id";
        

        public UserRepository()
        {        

        }

       // string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        //public IDbConnection Connection => new MySqlConnection(_connectionString);

        public User GetUser()
        {
            var usr = new User();
            using (IDbConnection dbConnection = new MySqlConnection("Server=localhost;Database=est_00;Uid=root;Pwd=;"))
            {
                dbConnection.Open();
                usr = dbConnection.QueryFirst<User>(Sql, new { id = 1 });
            }

            return usr;
        }
    }
}
