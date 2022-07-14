using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DL
{
    class DBconnection
    {
        private SqlConnection con;
        public DBconnection()
        {

            string Path = Environment.CurrentDirectory;
            string[] appPath = Path.Split(new string[] { "bin" }, StringSplitOptions.None);
            AppDomain.CurrentDomain.SetData("DataDirectory", appPath[0]);
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + appPath[0] + @"TPOS.mdf;Integrated Security=True";




            //string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=C:\USERS\HAMNA\SOURCE\REPOS\PROJECT\PROJECT\TPOS.MDF;Integrated Security=True";
            con = new SqlConnection(conString);
        }

        public SqlConnection Con { get => con; }
    }
}
