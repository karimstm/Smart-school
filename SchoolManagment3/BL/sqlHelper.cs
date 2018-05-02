using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagment3.BL
{
    public class sqlHelper
    {
        SqlConnection cn;
        public sqlHelper(string connectionString)
        {
            cn = new SqlConnection(connectionString);
        }
        public bool IsConnection
        {
            get
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                return true;
            }
        }
    }
}
