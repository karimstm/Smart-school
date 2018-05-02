using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagment3.DAL;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagment3.BL
{
    class Class_login
    {
        public static DataTable usp_login(string username, string password)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_login", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@username", SqlDbType.NVarChar, username),
                DataAccessLayer.CreateParameter("@pswd", SqlDbType.NVarChar, password));
            return dt;
        }
    }
}
