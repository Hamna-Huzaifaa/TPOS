using Project.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.DL
{
    class SignupDL
    {
        private DBconnection db;
        
        public SignupDL()
        {
            db = new DBconnection();
        }

        public void CreateAccountInDB(UserDTO ud)
        {
            try
            {
                db.Con.Open();
                //string queryString = "INSERT INTO MyUser VALUES('"+ud.UserID+"','"+ud.Password+"','"+ud.Role+"','active');" ;
                string queryString1 = "INSERT INTO MyUser VALUES( @Name, @Password, @Email, 'user' );";

                SqlCommand com = new SqlCommand(queryString1, db.Con);
                com.Parameters.AddWithValue("@Name", ud.Name);
                com.Parameters.AddWithValue("@Password", ud.Password);               
                com.Parameters.AddWithValue("@Email", ud.Email);
                
                

                int rowAffected = com.ExecuteNonQuery();
                MessageBox.Show("Account Created Successfully", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Con.Close();
            }
        }
    }
}
