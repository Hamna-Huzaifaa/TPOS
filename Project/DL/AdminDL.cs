using Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DL
{
    class AdminDL
    {
        private DBconnection db;

        public AdminDL()
        {
            db = new DBconnection();
        }

        public void CreateHotelInDB(HotelDTO ud)
        {
            try
            {
                db.Con.Open();
                //string queryString = "INSERT INTO MyUser VALUES('"+ud.UserID+"','"+ud.Password+"','"+ud.Role+"','active');" ;
                string queryString1 = "INSERT INTO hotel VALUES( @id, @name, @place, @type,@price);";

                SqlCommand com = new SqlCommand(queryString1, db.Con);
                com.Parameters.AddWithValue("@id", ud.HotelID);
                com.Parameters.AddWithValue("@name", ud.Name);
                com.Parameters.AddWithValue("@place", ud.Place);
                com.Parameters.AddWithValue("@type", ud.Type);
                com.Parameters.AddWithValue("@price", ud.Price);



                int rowAffected = com.ExecuteNonQuery();
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

        

        public void CreateBusInDB(BusDTO ud)
        {
            try
            {
                db.Con.Open();
                //string queryString = "INSERT INTO MyUser VALUES('"+ud.UserID+"','"+ud.Password+"','"+ud.Role+"','active');" ;
                string queryString1 = "INSERT INTO bus VALUES( @id, @capacity, @datetime);";

                SqlCommand com = new SqlCommand(queryString1, db.Con);
                com.Parameters.AddWithValue("@id", ud.BusID);
                com.Parameters.AddWithValue("@capacity", ud.Capacity);
                com.Parameters.AddWithValue("@datetime", ud.DateTime);
                



                int rowAffected = com.ExecuteNonQuery();
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

        public void CreateMealInDB(MealDTO ud)
        {
            try
            {
                db.Con.Open();
                //string queryString = "INSERT INTO MyUser VALUES('"+ud.UserID+"','"+ud.Password+"','"+ud.Role+"','active');" ;
                string queryString1 = "INSERT INTO meal VALUES( @id, @type, @description,@price);";

                SqlCommand com = new SqlCommand(queryString1, db.Con);
                com.Parameters.AddWithValue("@id", ud.MealID);
                com.Parameters.AddWithValue("@type", ud.Type);             
                com.Parameters.AddWithValue("@description", ud.Description);
                com.Parameters.AddWithValue("@price", ud.Price);



                int rowAffected = com.ExecuteNonQuery();
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

        public void CreatePackageInDB(PackageDTO ud)
        {
            try
            {
                db.Con.Open();
                //string queryString = "INSERT INTO MyUser VALUES('"+ud.UserID+"','"+ud.Password+"','"+ud.Role+"','active');" ;
                string queryString1 = "INSERT INTO package VALUES( @id, @type,@price,@place);";

                SqlCommand com = new SqlCommand(queryString1, db.Con);
                com.Parameters.AddWithValue("@id", ud.PackageID);
                com.Parameters.AddWithValue("@type", ud.Type);
                com.Parameters.AddWithValue("@price", ud.Price);
                com.Parameters.AddWithValue("@place", ud.Place);
                

                int rowAffected = com.ExecuteNonQuery();
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
        public void CreateTourInDB(TourDTO ud)
        {
            try
            {
                db.Con.Open();
                //string queryString = "INSERT INTO MyUser VALUES('"+ud.UserID+"','"+ud.Password+"','"+ud.Role+"','active');" ;
                string queryString1 = "INSERT INTO tour VALUES( @id, @name ,@description ,@bid, @pid);";

                SqlCommand com = new SqlCommand(queryString1, db.Con);
                com.Parameters.AddWithValue("@id", ud.TourID);
                com.Parameters.AddWithValue("@name", ud.Name);
                com.Parameters.AddWithValue("@description", ud.Description);
                com.Parameters.AddWithValue("@bid", ud.BusID);
                com.Parameters.AddWithValue("@pid", ud.PkgID);


                int rowAffected = com.ExecuteNonQuery();
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
        public DataTable getHotelsFromDB()
        {
            DataTable dt = new DataTable();
            try
            {
                db.Con.Open();
                string queryString = "SELECT * FROM hotel ";
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
        public DataTable getMealsFromDB()
        {
            DataTable dt = new DataTable();
            try
            {
                db.Con.Open();
                string queryString = "SELECT * FROM meal ";
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

        public DataTable getBusFromDB()
        {
            DataTable dt = new DataTable();
            try
            {
                db.Con.Open();
                string queryString = "SELECT * FROM bus ";
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

        public DataTable getPackagesFromDB()
        {
            DataTable dt = new DataTable();
            try
            {
                db.Con.Open();
                string queryString = "SELECT * FROM package ";
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
        public DataTable getToursFromDB()
        {
            DataTable dt = new DataTable();
            try
            {
                db.Con.Open();
                string queryString = "SELECT * FROM tour";
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
