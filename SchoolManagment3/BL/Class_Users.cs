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
    class Class_Users
    {
        public static DataTable GetPermission()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("GetPermission", CommandType.StoredProcedure);
            return dt;
        }

        public static DataTable usp_getNameOfUsers()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_getNameOfUsers", CommandType.StoredProcedure);
            return dt;
        }

        public static int usp_UpatePriv(DataTable dt)
        {
            DataAccessLayer.Open();
            int cout = DataAccessLayer.ExecuteNonQuery("usp_UpatePriv", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@screen", SqlDbType.Structured, dt));
            DataAccessLayer.Close();
            return cout;
        }

        public static DataTable usp_getMyprevilages(string username)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_getMyprevilages", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@username", SqlDbType.NVarChar, username));
            return dt;
        }
        public static DataTable getPriv(string username)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("getPriv", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@username", SqlDbType.NVarChar, username));
            return dt;
        }

        public static DataTable usp_searchUsr(string search)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_searchUsr", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@search", SqlDbType.NVarChar, search));
            return dt;
        }

        public static DataTable usp_tblUsersSelect()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblUsersSelect", CommandType.StoredProcedure);
            return dt;
        }
        public static int usp_tblUsersInsert(string username, string fullname, string password, string email, int permission)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblUsersInsert", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@username", SqlDbType.NVarChar, username),
                DataAccessLayer.CreateParameter("@FullName", SqlDbType.NVarChar, fullname),
                DataAccessLayer.CreateParameter("@Email", SqlDbType.NVarChar, email),
                DataAccessLayer.CreateParameter("@pswd", SqlDbType.NVarChar, password),
                DataAccessLayer.CreateParameter("@permissionid", SqlDbType.BigInt, permission));
            DataAccessLayer.Close();
            return count;
        }

        public static int usp_tblUsersUpdate(string username, string fullname, string password, string email, int permission)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblUsersUpdate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@username", SqlDbType.NVarChar, username),
                DataAccessLayer.CreateParameter("@FullName", SqlDbType.NVarChar, fullname),
                DataAccessLayer.CreateParameter("@Email", SqlDbType.NVarChar, email),
                DataAccessLayer.CreateParameter("@pswd", SqlDbType.NVarChar, password),
                DataAccessLayer.CreateParameter("@permissionid", SqlDbType.BigInt, permission));
            DataAccessLayer.Close();
            return count;
        }

        public static int usp_tblUsersDelete(string username)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblUsersDelete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@username", SqlDbType.NVarChar, username));
            DataAccessLayer.Close();
            return count;
        }
    }
}
