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
    class Class_Classes
    {
        public static DataTable PS_GetClassesData()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("PS_GetClassesData", CommandType.StoredProcedure);
            return dt;
        }

        public static int Ps_InsertClasses(string label, int idFiliere, int idYear)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("Ps_InsertClasses", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idYear", SqlDbType.BigInt, idYear),
                DataAccessLayer.CreateParameter("@Label", SqlDbType.NVarChar, label),
                DataAccessLayer.CreateParameter("@idFiliere", SqlDbType.BigInt, idFiliere));
            DataAccessLayer.Close();
            return count;
        }

        public static int Ps_UpdateClasses(int idClasse, string label, int idFiliere, int idYear)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("Ps_UpdateClasses", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idClass", SqlDbType.BigInt, idClasse),
                DataAccessLayer.CreateParameter("@Label", SqlDbType.NVarChar, label),
                DataAccessLayer.CreateParameter("@idFiliere", SqlDbType.BigInt, idFiliere),
                DataAccessLayer.CreateParameter("@idYear", SqlDbType.BigInt, idYear));
            DataAccessLayer.Close();
            return count;
        }

        public static int Ps_DeleteClasses(int idClass)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("Ps_DeleteClasses", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idClass", SqlDbType.BigInt, idClass));
            DataAccessLayer.Close();
            return count;
        }

        public static DataTable PS_GetClassesDataByYear(int id)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("PS_GetClassesDataByYear", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("idyear", SqlDbType.BigInt, id));
            return dt;
        }

        public static DataTable Ps_GetYears()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetYears", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable Ps_GetFiliers()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetFiliers", CommandType.StoredProcedure);
            return dt;
        }
    }
}
