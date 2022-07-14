using Project.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DL
{
    class LoginDL
    {
        private DBconnection dbCon;
        public LoginDL()
        {
            dbCon = new DBconnection();
        }
        public UserDTO VerifyUserFromDB(LoginDTO lg)
        {
            UserDTO retDTO = new UserDTO();
            try
            {

                dbCon.Con.Open();
                SqlCommand com = new SqlCommand("select * from MyUser where username=@username AND password=@password", dbCon.Con);
                
                com.Parameters.AddWithValue("@username", lg.Username);
                com.Parameters.AddWithValue("@password", lg.Password);

                SqlDataReader reader = com.ExecuteReader();
               
                while (reader.Read())
                {
                    
                    retDTO.Name = reader["username"].ToString();
                    retDTO.Password = reader["password"].ToString();
                    retDTO.Role = reader["role"].ToString();
                    retDTO.Email = reader["email"].ToString();
                    return retDTO;
                }
            }
            catch (SqlException ex)
            {
                return null;

            }
            finally
            {
                dbCon.Con.Close();
            }
            return null;

        }
    }
}
