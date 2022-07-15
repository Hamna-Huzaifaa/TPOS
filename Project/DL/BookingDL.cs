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
    class BookingDL
    {
        private DBconnection db;

        public BookingDL()
        {
            db = new DBconnection();
        }

        public void CreateBookedItem(BookingDTO bd)
        {
            
                try
                {
                    db.Con.Open();
                    //string queryString = "INSERT INTO MyUser VALUES('"+ud.UserID+"','"+ud.Password+"','"+ud.Role+"','active');" ;
                    string queryString1 = "INSERT INTO booking VALUES(@tourid,@userid,@seats,@breakfast,@lunch,@dinner,@hid,@payment);";

                    SqlCommand com = new SqlCommand(queryString1, db.Con);
                    com.Parameters.AddWithValue("@tourid", bd.Tourid);
                    com.Parameters.AddWithValue("@userid", bd.Userid);
                    com.Parameters.AddWithValue("@seats", bd.Seats);
                    com.Parameters.AddWithValue("@breakfast", bd.Breakfast);
                    com.Parameters.AddWithValue("@lunch", bd.Lunch);
                    com.Parameters.AddWithValue("@dinner", bd.Dinner);
                    com.Parameters.AddWithValue("@hid", bd.Hotelid);
                    com.Parameters.AddWithValue("@payment", bd.Paymentid);
                   

                int rowAffected = com.ExecuteNonQuery();
                MessageBox.Show("Tour booked Successfully", "Tour Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public PackageDTO getPackageAmountFromDB(string id)
        {
            PackageDTO package = new PackageDTO(); 
            //int package;
            try
            {
                db.Con.Open();
                string queryString = "SELECT package.price FROM package,tour WHERE package.pid=tour.pid ";
                SqlCommand com = new SqlCommand(queryString, db.Con);

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    package.Price = reader["price"].ToString();                   
                    return package;
                }
                return null;
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
        public PackageDTO getMealAmountFromDB(string id)
        {
            PackageDTO meal = new PackageDTO();
            //int package;
            try
            {
                db.Con.Open();
                string queryString = "SELECT package.ptype FROM package,tour WHERE package.pid=tour.pid ";
                SqlCommand com = new SqlCommand(queryString, db.Con);

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    meal.Type = reader["ptype"].ToString();
                    return meal;
                }
                return null;
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
        public HotelDTO getHotelAmountFromDB(string id)
        {
            HotelDTO package = new HotelDTO();
            //int package;
            try
            {
                db.Con.Open();
                string queryString = "SELECT hotel.price FROM hotel,tour WHERE tour.hid=hotel.hid ";
                SqlCommand com = new SqlCommand(queryString, db.Con);

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    package.Price = reader["price"].ToString();
                   
                    return package;
                }
                return null;
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
        public HotelDTO getHotelPlace(string id)
        {
            HotelDTO package = new HotelDTO();
            //int package;
            try
            {
                db.Con.Open();
                string queryString = "SELECT hotel.place FROM hotel,tour WHERE tour.hid=hotel.hid ";
                SqlCommand com = new SqlCommand(queryString, db.Con);

                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                   
                    package.Place = reader["place"].ToString();
                    return package;
                }
                return null;
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
        public BookingDTO getRecieptFromDB(BookingDTO dto)
        {
            BookingDTO package = new BookingDTO();
            //int package;
            try
            {
                db.Con.Open();
                string queryString = "SELECT bookingid,tourid,userid,seats,payment FROM booking where tourid = @tourid and userid = @userid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@tourid", dto.Tourid);
                com.Parameters.AddWithValue("@userid", dto.Userid);
                SqlDataReader reader = com.ExecuteReader();
               
                while (reader.Read())
                {

                    package.Bookingid = reader["bookingid"].ToString();
                    package.Tourid = reader["tourid"].ToString();
                    package.Userid = reader["userid"].ToString();
                    package.Seats = Convert.ToInt32(reader["seats"]);
                    package.Paymentid = reader["payment"].ToString();
                    return package;
                }
                return null;
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
