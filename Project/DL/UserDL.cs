using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DL
{
    class UserDL
    {
        private DBconnection db;

        public UserDL()
        {
            db = new DBconnection();
        }
        public DataTable getToursFromDB()
        {
            DataTable dt = new DataTable();
            try
            {
                db.Con.Open();
                string queryString = "SELECT tid,name,description,bid,pid FROM tour ";
                SqlCommand com = new SqlCommand(queryString, db.Con);

                SqlDataReader reader = com.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                db.Con.Close();
            }
        }

    }
}
