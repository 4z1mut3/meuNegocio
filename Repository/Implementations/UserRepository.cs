using Dapper;
using Microsoft.Extensions.Configuration;
using Models;
using MySqlConnector;
using Repository.Contracts;
using Repository;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Repository.Sql;

namespace Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        //private const string getById = "SELECT * FROM User where IdUsuario =  @id";
        //private const string insert = @"INSERT INTO est_00.`user`(Name, Password)
        //                                VALUES(@Name, @Password);";

        private readonly UserSql _userSql = new UserSql();
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        public User GetUser()
        {
            var usr = new User();
            using (IDbConnection dbConnection = new MySqlConnection("Server=localhost;Database=est_00;Uid=root;Pwd=;"))
            {
                dbConnection.Open();
                usr = dbConnection.QueryFirst<User>(_userSql.getById, new { id = 1 });
                dbConnection.Close();
            }

            return usr;
        }

        public bool CreateUser(User usuario) 
        {
            int isSuccess = 0;
            using (IDbConnection dbConnection = new MySqlConnection("Server=localhost;Database=est_00;Uid=root;Pwd=;"))
            {
                dbConnection.Open();
                isSuccess = dbConnection.Execute(_userSql.Insert, new { Name = usuario.Name, Password=usuario.Password }) ;
                dbConnection.Close();
            }

            if (isSuccess > 0)
            {
                
                return true;                
            }
            else {
                return false;
            }
        }
    }
}
