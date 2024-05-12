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
        private const string getById = "SELECT * FROM User where IdUsuario =  @id";
        private const string insert = @"INSERT INTO est_00.`user`(Name, Password)
                                        VALUES(@Name, @Password);";


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
                usr = dbConnection.QueryFirst<User>(getById, new { id = 1 });
            }

            return usr;
        }

        public bool CreateUser(User usuario) 
        {
            int isSuccess = 0;
            using (IDbConnection dbConnection = new MySqlConnection("Server=localhost;Database=est_00;Uid=root;Pwd=;"))
            {
                dbConnection.Open();
                isSuccess = dbConnection.Execute(insert, new { Name = usuario.Name, Password=usuario.Password }) ;
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
