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
    class Class_Fees
    {
        public static DataTable usp_tblFeetypeSelect()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblFeetypeSelect", CommandType.StoredProcedure);
            return dt;
        }

        public static Decimal usp_getMyDiscoutn(string num)
        {
            DataAccessLayer.Open();
            decimal Discout = Convert.ToDecimal(DataAccessLayer.ExecuteScalar("usp_getMyDiscoutn", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@NumInscription", SqlDbType.VarChar, num)));
            DataAccessLayer.Close();
            return Discout;
        }

        public static int usp_tblFeesInsert(string year, Decimal GrandTotal, decimal TotalPaid, decimal totalDue, DateTime date, DataTable paimentDetail, string note)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblFeesInsert", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@schoolYear", SqlDbType.NVarChar, year),
                DataAccessLayer.CreateParameter("@GrandTotal", SqlDbType.Decimal, GrandTotal),
                DataAccessLayer.CreateParameter("@TotalPaid", SqlDbType.Decimal, TotalPaid),
                DataAccessLayer.CreateParameter("@DuePaid", SqlDbType.Decimal, totalDue),
                DataAccessLayer.CreateParameter("@FeesDate", SqlDbType.DateTime, date),
                DataAccessLayer.CreateParameter("@tblDetailPaimentTable", SqlDbType.Structured, paimentDetail),
                DataAccessLayer.CreateParameter("@Note", SqlDbType.NVarChar, note));
            DataAccessLayer.Close();
            return count;
        }

        public static int usp_getLastFees()
        {
            DataAccessLayer.Open();
            int count = Convert.ToInt32(DataAccessLayer.ExecuteScalar("usp_getLastFees", CommandType.StoredProcedure));
            DataAccessLayer.Close();
            return count;
        }

        public static DataSet usp_getRecu(int id)
        {
            SchoolDs ds = new SchoolDs();
            SqlDataAdapter da = new SqlDataAdapter("usp_getRecu", DataAccessLayer.con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parm = new SqlParameter("@idfees", SqlDbType.BigInt) { Value = id };
            da.SelectCommand.Parameters.Add(parm);
            da.Fill(ds.Tables["Facture"]);
            return ds;
        }

        public static DataTable usp_SelectFees()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_SelectFees", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable usp_SelectFeesById(int id)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_SelectFeesById", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idFees", SqlDbType.BigInt, id));
            return dt;
        }

        public static int usp_tblFeesUpdate(int idFees, Decimal GrandTotal, decimal TotalPaid, decimal totalDue, string note)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblFeesUpdate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idFees", SqlDbType.BigInt, idFees),
                DataAccessLayer.CreateParameter("@GrandTotal", SqlDbType.Decimal, GrandTotal),
                DataAccessLayer.CreateParameter("@TotalPaid", SqlDbType.Decimal, TotalPaid),
                DataAccessLayer.CreateParameter("@DuePaid", SqlDbType.Decimal, totalDue),
                DataAccessLayer.CreateParameter("@Note", SqlDbType.NVarChar, note));
            DataAccessLayer.Close();
            return count;
        }

        public static int usp_tblFeesDelete(int idFees)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblFeesDelete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idFees", SqlDbType.BigInt, idFees));
            DataAccessLayer.Close();
            return count;
        }

        public static DataSet usp_PrintAllFees(string schoolYear)
        {
            SchoolDs ds = new SchoolDs();
            SqlDataAdapter da = new SqlDataAdapter("usp_PrintAllFees", DataAccessLayer.con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter parm = new SqlParameter("@SchoolYear", SqlDbType.NVarChar) { Value = schoolYear };
            da.SelectCommand.Parameters.Add(parm);
            da.Fill(ds.Tables["Facture"]);
            return ds;
        }

        public static DataTable usp_SelectFeesByName(string Name)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_SelectFeesByName", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Name", SqlDbType.NVarChar, Name));
            return dt;
        }

        public static DataTable usp_SelectFeesByClass(int idClass)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_SelectFeesByClass", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idClass", SqlDbType.BigInt, idClass));
            return dt;
        }
        public static DataTable usp_GetNombreOfFees(string Year, int Filiere)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_GetNombreOfFees", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@SchoolYear", SqlDbType.NVarChar, Year),
                DataAccessLayer.CreateParameter("@filiere", SqlDbType.BigInt, Filiere));
            return dt;
        }

        public static DataTable usp_GetFeesByDate(DateTime date)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_GetFeesByDate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Date", SqlDbType.Date, date));
            return dt;
        }

        public static DataTable usp_getMu(string Year, string Num)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_getMu", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@NumInscription", SqlDbType.NVarChar, Num),
                DataAccessLayer.CreateParameter("@year", SqlDbType.NVarChar, Year));
            return dt;
        }

        public static DataTable usp_getLateThismonth(int idclass, int idmonth)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_getLateThismonth", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@classID", SqlDbType.BigInt, idclass),
                DataAccessLayer.CreateParameter("@idMonth", SqlDbType.BigInt, idmonth));
            return dt;
        }

        public static DataTable usp_getLateThismonthNoClasses(int idYear, int idmonth)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_getLateThismonthNoClasses", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idYear", SqlDbType.BigInt, idYear),
                DataAccessLayer.CreateParameter("@idMonth", SqlDbType.BigInt, idmonth));
            return dt;
        }

        public static DataTable usp_getmylatDue(string Num)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_getmylatDue", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@NumInscription", SqlDbType.VarChar, Num));
            return dt;
        }
    }

}
