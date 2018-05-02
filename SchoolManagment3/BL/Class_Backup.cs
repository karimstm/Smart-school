using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SchoolManagment3.DAL;

namespace SchoolManagment3.BL
{
    class Class_Backup
    {
        public static void usp_backup(string path)
        {
            DataAccessLayer.Open();
            string Query = string.Format("BACKUP DATABASE SchoolManagment2017 TO DISK = '{0}'", path);
            DataAccessLayer.ExecuteNonQuery(Query, CommandType.Text);
            DataAccessLayer.Close();
        }
    }
}
