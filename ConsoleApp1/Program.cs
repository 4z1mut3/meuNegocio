// See https://aka.ms/new-console-template for more information
using Dapper;
using Models;
using MySqlConnector;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;


User usr = new User();
using (IDbConnection dbConnection = new MySqlConnection("Server=localhost;Database=est_00;Uid=root;Pwd=;"))
{
    dbConnection.Open();
    usr = (User)dbConnection.QueryFirst<User>("SELECT * FROM User where IdUsuario =  @id", new { id = 1 });
}

//return usr;



    Console.Write(usr.IdUsuario.ToString() + usr.Name);

