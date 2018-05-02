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
    class Class_Discount
    {
        public static DataTable usp_tblDiscountSelect()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblDiscountSelect", CommandType.StoredProcedure);
            return dt;
        }

        public static int usp_tblDiscountInsert(decimal discount, string reason, string NumInscription)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblDiscountInsert", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Discount", SqlDbType.Decimal, discount),
                DataAccessLayer.CreateParameter("@Reason", SqlDbType.NVarChar, reason),
                DataAccessLayer.CreateParameter("@NumInscription", SqlDbType.VarChar, NumInscription));
            DataAccessLayer.Close();
            return count;
        }

        public static int usp_tblDiscountUpdate(int id, decimal discount, string reason, string NumInscription)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblDiscountUpdate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Discount", SqlDbType.Decimal, discount),
                DataAccessLayer.CreateParameter("@idDiscount", SqlDbType.BigInt, id),
                DataAccessLayer.CreateParameter("@Reason", SqlDbType.NVarChar, reason),
                DataAccessLayer.CreateParameter("@NumInscription", SqlDbType.VarChar, NumInscription));
            DataAccessLayer.Close();
            return count;
        }

        public static int usp_tblDiscountDelete(int id)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblDiscountDelete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idDiscount", SqlDbType.BigInt, id));
            DataAccessLayer.Close();
            return count;
        }
    }
}
