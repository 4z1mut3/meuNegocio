using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository.Sql
{
    public class UserSql
    {


        public string Insert   // property
        {
            get { return @"INSERT INTO est_00.`user`(Name, Password)
                                        VALUES(@Name, @Password)"; }

        }
        public string getById   // property
        {
            get { return @" SELECT * FROM User where IdUsuario =  @id "; }

        }
    }
}



