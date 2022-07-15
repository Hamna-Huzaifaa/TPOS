using Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                MessageBox.Show("Hotel Created Successfully", "Hotel Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Bus Created Successfully", "Bus Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Meal Created Successfully", "Meal Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Package Created Successfully", "Package Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void CreateTourInDB(TourDTO ud)
        {
            try
            {
                db.Con.Open();
                //string queryString = "INSERT INTO MyUser VALUES('"+ud.UserID+"','"+ud.Password+"','"+ud.Role+"','active');" ;
                string queryString1 = "INSERT INTO tour VALUES( @id, @name ,@description ,@bid, @pid,@hid);";

                SqlCommand com = new SqlCommand(queryString1, db.Con);
                com.Parameters.AddWithValue("@id", ud.TourID);
                com.Parameters.AddWithValue("@name", ud.Name);
                com.Parameters.AddWithValue("@description", ud.Description);
                com.Parameters.AddWithValue("@bid", ud.BusID);
                com.Parameters.AddWithValue("@pid", ud.PkgID);
                com.Parameters.AddWithValue("@hid", ud.HotelID);
                //com.Parameters.AddWithValue("@mid", ud.MealID);


                int rowAffected = com.ExecuteNonQuery();
                MessageBox.Show("Tour Created Successfully", "Tour Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            public DataTable getBookingsFromDB()
            {
                DataTable dt = new DataTable();
                try
                {
                    db.Con.Open();
                    string queryString = "SELECT * FROM booking";
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
        public void EdithotelinDB(HotelDTO dto)
        {
            try
            {
                db.Con.Open();
                string queryString = @"UPDATE hotel SET  hname = @hname, place = @place, type = @type, price = @price where hid = @hid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@hid", dto.HotelID);
                com.Parameters.AddWithValue("@hname", dto.Name);
                com.Parameters.AddWithValue("@place", dto.Place);
                com.Parameters.AddWithValue("@type", dto.Type);
                com.Parameters.AddWithValue("@price", dto.Price);

                com.CommandText = queryString;
                int noOfRowsAffected = com.ExecuteNonQuery();
                MessageBox.Show("Record Edit Successfully", "Record Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Con.Close();
            }
        }

        public void EditbusinDB(BusDTO dto)
        {
            try
            {
                db.Con.Open();
                string queryString = @"UPDATE bus SET  capacity = @capacity, datetime = @datetime where bid = @bid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@bid", dto.BusID);
                com.Parameters.AddWithValue("@capacity", dto.Capacity);
                com.Parameters.AddWithValue("@datetime", dto.DateTime);

                com.CommandText = queryString;
                int noOfRowsAffected = com.ExecuteNonQuery();
                MessageBox.Show("Record Edit Successfully", "Record Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Con.Close();
            }
        }
        public void EditmealinDB(MealDTO dto)
        {
            try
            {
                db.Con.Open();
                string queryString = @"UPDATE meal SET  type = @type, description = @description, price=@price where mid = @mid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@mid", dto.MealID);
                com.Parameters.AddWithValue("@type", dto.Type);
                com.Parameters.AddWithValue("@description", dto.Description);
                com.Parameters.AddWithValue("@price", dto.Price);

                com.CommandText = queryString;
                int noOfRowsAffected = com.ExecuteNonQuery();
                MessageBox.Show("Record Edit Successfully", "Record Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Con.Close();
            }
        }
        public void EditpkginDB(PackageDTO dto)
        {
            try
            {
                db.Con.Open();
                string queryString = @"UPDATE package SET  ptype = @ptype, price=@price, place = @place where pid = @pid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@pid", dto.PackageID);
                com.Parameters.AddWithValue("@ptype", dto.Type);
                com.Parameters.AddWithValue("@price", dto.Price);
                com.Parameters.AddWithValue("@place", dto.Place);

                com.CommandText = queryString;
                int noOfRowsAffected = com.ExecuteNonQuery();
                MessageBox.Show("Record Edit Successfully", "Record Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Con.Close();
            }
        }
        public void EditTourinDB(TourDTO dto)
        {
            try
            {
                db.Con.Open();
                string queryString = @"UPDATE tour SET  name=@name, description = @description, bid=@bid, pid=@pid, hid=@hid where tid = @tid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@tid", dto.TourID);
                com.Parameters.AddWithValue("@name", dto.Name);
                com.Parameters.AddWithValue("@description", dto.Description);
                com.Parameters.AddWithValue("@bid", dto.BusID);
                com.Parameters.AddWithValue("@pid", dto.PkgID);
                com.Parameters.AddWithValue("@hid", dto.HotelID);

                com.CommandText = queryString;
                int noOfRowsAffected = com.ExecuteNonQuery();
                MessageBox.Show("Record Edit Successfully", "Record Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Con.Close();
            }
        }
        public void DelhotelinDB(HotelDTO dto)
        {
            try
            {
                db.Con.Open();
                string queryString = @"Delete FROM hotel WHERE hid = @hid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@hid", dto.HotelID);

                com.CommandText = queryString;
                int noOfRowsAffected = com.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully", "Record Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Con.Close();
            }
        }
        public void DelbusinDB(BusDTO dto)
        {
            try
            {
                db.Con.Open();
                string queryString = @"Delete FROM bus WHERE bid = @bid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@bid", dto.BusID);

                com.CommandText = queryString;
                int noOfRowsAffected = com.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully", "Record Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Con.Close();
            }
        }
        public void DelmealinDB(MealDTO dto)
        {
            try
            {
                db.Con.Open();
                string queryString = @"Delete FROM meal WHERE mid = @mid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@mid", dto.MealID);

                com.CommandText = queryString;
                int noOfRowsAffected = com.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully", "Record Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Con.Close();
            }
        }
        public void DelpkginDB(PackageDTO dto)
        {
            try
            {
                db.Con.Open();
                string queryString = @"Delete FROM package WHERE pid = @pid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@pid", dto.PackageID);

                com.CommandText = queryString;
                int noOfRowsAffected = com.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully", "Record Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.Con.Close();
            }
        }
        public void DelToursinDB(TourDTO dto)
        {
            try
            {
                db.Con.Open();
                string queryString = @"Delete FROM tour WHERE tid = @tid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                com.Parameters.AddWithValue("@tid", dto.TourID);

                com.CommandText = queryString;
                int noOfRowsAffected = com.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully", "Record Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
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
