using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SchoolManagment3.DAL;

namespace SchoolManagment3.BL
{
    class Class_SchoolYear
    {
        public static int PS_addSchoolYear(string SchoolYear)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("PS_addSchoolYear", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@SchoolYear", SqlDbType.NVarChar, SchoolYear));
            DataAccessLayer.Close();
            return count;
        }

        public static int PS_UpdateSchoolYear(int id, string SchoolYear)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("PS_UpdateSchoolYear", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@SchoolYear", SqlDbType.NVarChar, SchoolYear),
                DataAccessLayer.CreateParameter("@idyear", SqlDbType.BigInt, id));
            DataAccessLayer.Close();
            return count;
        }
        public static int PS_DeleteSchoolYear(int id)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("PS_DeleteSchoolYear", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idyear", SqlDbType.BigInt, id));
            DataAccessLayer.Close();
            return count;

        }

        public static DataTable PS_SelectSchoolYear()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("PS_SelectSchoolYear", CommandType.StoredProcedure);
            return dt;
        }


    }
}
