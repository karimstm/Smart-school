using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace SchoolManagment3.DAL
{
    class DataAccessLayer
    {
        public static string stri = ConfigurationManager.ConnectionStrings["partialConnectString"].ToString();
        //public static string con = @"Data Source = .; Initial Catalog=SchoolManagment2017; Integrated Security=True";
        public static string con = $@"{stri}; Initial Catalog=SchoolManagment2017; User Id = sa; Password = M@ut%^k/12#3456";
        public static SqlConnection cn = new SqlConnection(con);




        public static void Open()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            cn.Open();
        }
        //Close the connection
        public static void Close()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            
        }
        //return one value
        public static object ExecuteScalar(String query, CommandType type, params SqlParameter[] arr)
        {

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddRange(arr);
            cmd.CommandType = type;
            object o = cmd.ExecuteScalar();
            return o;
        }
        //Return the number of row affected
        public static int ExecuteNonQuery(string query, CommandType type, params SqlParameter[] arr)
        {

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = type;
            cmd.Parameters.AddRange(arr);
            int n = cmd.ExecuteNonQuery();
            return n;

        }
        //Return a table
        public static DataTable ExecuteTable(String query, CommandType type, params SqlParameter[] arr)
        {

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = type;
            cmd.Parameters.AddRange(arr);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        // Return the parameters

        public static SqlParameter CreateParameter(string name, SqlDbType type, object value)
        {
            SqlParameter pr = new SqlParameter();
            pr.ParameterName = name;
            pr.SqlDbType = type;
            pr.SqlValue = value;
            return pr;

        }
    }
}
