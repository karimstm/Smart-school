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
    class Class_Filiere
    {
        public static DataTable PS_SelectNivau()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("PS_SelectNivau", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable PS_SelectFiliere()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("PS_SelectFiliere", CommandType.StoredProcedure);
            return dt;
        }
        public static int PS_InsertFiliere(string label, int idNivau)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("PS_InsertFiliere", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@label", SqlDbType.NVarChar, label),
                DataAccessLayer.CreateParameter("@idNiveau", SqlDbType.BigInt, idNivau));
            DataAccessLayer.Close();
            return count;
        }

        public static int PS_UpdateFiliere(int id, string label, int idNivau)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("PS_UpdateFiliere", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.BigInt, id),
                DataAccessLayer.CreateParameter("@label", SqlDbType.NVarChar, label),
                DataAccessLayer.CreateParameter("@idNiveau", SqlDbType.BigInt, idNivau));
            DataAccessLayer.Close();
            return count;
        }

        public static int PS_RemoveFiliere(int id)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("PS_RemoveFiliere", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.BigInt, id));
            DataAccessLayer.Close();
            return count;
        }
    }
}
