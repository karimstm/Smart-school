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
    class Class_OtherFees
    {
        public static DataTable usp_tblOtherFeesSelect()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblOtherFeesSelect", CommandType.StoredProcedure);
            return dt;
        }

        public static int usp_tblOtherFeesInsert(string Name, decimal price)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblOtherFeesInsert", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Name", SqlDbType.NVarChar, Name),
                DataAccessLayer.CreateParameter("@Price", SqlDbType.NVarChar, price));
            DataAccessLayer.Close();
            return count;
        }

        public static int usp_tblOtherFeesUpdate(int id,string Name, decimal price)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblOtherFeesUpdate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Name", SqlDbType.NVarChar, Name),
                DataAccessLayer.CreateParameter("@Price", SqlDbType.NVarChar, price),
                DataAccessLayer.CreateParameter("@idOtherfees", SqlDbType.BigInt, id));
            DataAccessLayer.Close();
            return count;
        }
        public static int usp_tblOtherFeesDelete(int id)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblOtherFeesDelete", CommandType.StoredProcedure,
                 DataAccessLayer.CreateParameter("@idOtherfees", SqlDbType.BigInt, id));
            DataAccessLayer.Close();
            return count;
        }

    }
}
