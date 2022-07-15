using Project.BL;
using Project.DL;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AdminGUI : Form
    {
        private UserDTO adminDTO;
        private HotelDTO dto;
        private BusDTO bdto;
        private MealDTO mdto;
        private PackageDTO pdto;
        private TourDTO tdto;
        private DBconnection db;

        private AdminBL bl;
        private bool viewHotel = false;
        private bool viewMeal = false;
        private bool viewBus = false;
        private bool viewPkg = false;
        private bool viewTour = false;
        private bool viewBooking = false;

        public AdminGUI(UserDTO admin)
        {
            InitializeComponent();
            adminDTO = admin;
            dto = new HotelDTO();
            bl = new AdminBL();
            bdto = new BusDTO();
            mdto = new MealDTO();
            pdto = new PackageDTO();
            tdto = new TourDTO();
            db = new DBconnection();
        }

        public AdminGUI()
        {
            InitializeComponent();
            dto = new HotelDTO();
            bl = new AdminBL();
            bdto = new BusDTO();
            mdto = new MealDTO();
            pdto = new PackageDTO();
            tdto = new TourDTO();
            db = new DBconnection();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            try
            {
                db.Con.Open();
                string queryString = "SELECT hid FROM hotel";
                SqlCommand comm = new SqlCommand(queryString, db.Con);
                SqlDataReader reader1;
                reader1 = comm.ExecuteReader();
                while (reader1.Read())
                {
                    cmb_hotel.Items.Add(reader1[0].ToString());
                }

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_hadd_Click(object sender, EventArgs e)
        {
            if (!(txt_hid.Text == "" || txt_hname.Text == "" || cmb_hplace.Text == "" || cmb_hprice.Text == "" || cmb_htype.Text == ""))
            {
                dto.HotelID = txt_hid.Text;
                dto.Name = txt_hname.Text;
                dto.Place = cmb_hplace.Text;
                dto.Type = cmb_htype.Text;
                dto.Price = cmb_hprice.Text;
                bl.verifyHotel(dto);
                MessageBox.Show("New Hotel has been added successfully!!!", "hotel Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_hotel.DataSource = bl.GetHotels();
            viewHotel = true;
            dgv_meal.DataSource = bl.GetMeals();
            viewMeal = true;
            dgv_bus.DataSource = bl.GetBus();
            viewBus = true;
            dgv_pkg.DataSource = bl.GetPackages();
            viewPkg = true;
            dgv_tours.DataSource = bl.GetTours();
            viewTour = true;
            dgv_bookings.DataSource = bl.GetBookings();
            viewBooking = true;
        }

        private void btn_badd_Click(object sender, EventArgs e)
        {
            if (!(txt_bid.Text == "" || txt_capacity.Text == "" || dtp_bus.Text == ""))
            {
                dtp_bus.CustomFormat = "dddd, dd MMMM yyyy HH: mm:ss";
                dtp_bus.Format = DateTimePickerFormat.Custom;
                bdto.BusID = txt_bid.Text;
                bdto.Capacity = txt_capacity.Text;
                bdto.DateTime = Convert.ToDateTime(dtp_bus.Text);

                bl.verifyBus(bdto);
                MessageBox.Show("New Bus has been added successfully!!!", "Bus Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(txt_mid.Text == "" || cmb_mtype.Text == "" || txt_mdesc.Text == "" || txt_mprice.Text == ""))
            {
                mdto.MealID = txt_mid.Text;
                mdto.Type = cmb_mtype.Text;
                mdto.Description = txt_mdesc.Text;
                mdto.Price = txt_mprice.Text;

                bl.verifyMeal(mdto);
                MessageBox.Show("New Meal has been added successfully!!!", "Meal Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btn_padd_Click(object sender, EventArgs e)
        {
            if (!(txt_pid.Text == "" || cmb_ptype.Text == "" || txt_pprice.Text == "" || cmb_pplace.Text == ""))
            {
                pdto.PackageID = txt_pid.Text;
                pdto.Type = cmb_ptype.Text;
                pdto.Price = txt_pprice.Text;
                pdto.Place = cmb_pplace.Text;

                bl.verifyPackage(pdto);
                MessageBox.Show("New Package has been added successfully!!!", "Package Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btn_post_Click(object sender, EventArgs e)
        {
            if (!(txt_tid.Text == "" || txt_name.Text == "" || txt_desc.Text == "" || cmb_bus.Text == "" || cmb_pkg.Text == "" || cmb_hotel.Text == "" ))
            {
                tdto.TourID = txt_tid.Text;
                tdto.Name = txt_name.Text;
                tdto.Description = txt_desc.Text;
                tdto.BusID = cmb_bus.Text;
                tdto.PkgID = cmb_pkg.Text;
                tdto.HotelID = cmb_hotel.Text;
                

                bl.verifyTour(tdto);
                MessageBox.Show("New Tour has been added successfully!!!", "Tour Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void cmb_bus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdminGUI_Load(object sender, EventArgs e)
        {
            
            try
            {
                db.Con.Open();
                string queryString = "SELECT bid FROM bus ";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                SqlDataReader reader;
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    cmb_bus.Items.Add(reader[0].ToString());
                }

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

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
           
        }



      

        private void cmb_hotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmb_meal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    db.Con.Open();
            //    string queryString = "SELECT mid FROM meal ";
            //    SqlCommand comm = new SqlCommand(queryString, db.Con);
            //    SqlDataReader reader1;
            //    reader1 = comm.ExecuteReader();
            //    while (reader1.Read())
            //    {
            //        cmb_meal.Items.Add(reader1[0].ToString());
            //    }

            //}
            //catch (SqlException ex)
            //{
            //    throw ex;
            //}

            //finally
            //{
            //    db.Con.Close();
            //}
        }

        private void btn_hdel_Click(object sender, EventArgs e)
        {
            HotelDTO dto = new HotelDTO();
            dto.HotelID = txt_hid.Text;
            bl.Delhotel(dto);
            int rowindex = dgv_hotel.CurrentCell.RowIndex;
            dgv_hotel.Rows.RemoveAt(rowindex);
            txt_hid.Text = "";
            txt_hname.Text = "";
            cmb_htype.Text = "";
            cmb_hplace.Text = "";
            cmb_hprice.Text = "";
        }

        private void dgv_hotel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow;
            selectedRow = e.RowIndex;
            DataGridViewRow row = dgv_hotel.Rows[selectedRow];

            // display datagridview selected row data into textboxes
            txt_hid.Text = row.Cells[0].Value.ToString();
            txt_hname.Text = row.Cells[1].Value.ToString();
            cmb_htype.Text = row.Cells[2].Value.ToString();
            cmb_hplace.Text = row.Cells[3].Value.ToString();
            cmb_hprice.Text = row.Cells[4].Value.ToString();
        }
        private void btn_hedit_Click(object sender, EventArgs e)
        {
            HotelDTO dto = new HotelDTO();
            dto.HotelID = txt_hid.Text;
            dto.Name = txt_hname.Text;
            dto.Place = cmb_hplace.Text;
            dto.Type = cmb_htype.Text;
            dto.Price = cmb_hprice.Text;


            bl.Edithotel(dto);
        }

        private void dgv_bus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow;
            selectedRow = e.RowIndex;
            DataGridViewRow row = dgv_bus.Rows[selectedRow];

            // display datagridview selected row data into textboxes
            txt_bid.Text = row.Cells[0].Value.ToString();
            txt_capacity.Text = row.Cells[1].Value.ToString();
            dtp_bus.Text = row.Cells[2].Value.ToString();
        }
        private void btn_bedit_Click(object sender, EventArgs e)
        {
            BusDTO dto = new BusDTO();
            dto.BusID = txt_bid.Text;
            dto.Capacity = txt_capacity.Text;
            dto.DateTime = Convert.ToDateTime(dtp_bus.Text);


            bl.EditBus(dto);
        }

        private void dgv_meal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow;
            selectedRow = e.RowIndex;
            DataGridViewRow row = dgv_meal.Rows[selectedRow];

            // display datagridview selected row data into textboxes
            txt_mid.Text = row.Cells[0].Value.ToString();
            cmb_mtype.Text = row.Cells[1].Value.ToString();
            txt_mdesc.Text = row.Cells[2].Value.ToString();
            txt_mprice.Text = row.Cells[3].Value.ToString();

        }
        private void btn_medit_Click(object sender, EventArgs e)
        {
            MealDTO dto = new MealDTO();
            dto.MealID = txt_mid.Text;
            dto.Type = cmb_mtype.Text;
            dto.Description = txt_mdesc.Text;
            dto.Price = txt_mprice.Text;


            bl.EditMeal(dto);
        }

        private void dgv_pkg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow;
            selectedRow = e.RowIndex;
            DataGridViewRow row = dgv_pkg.Rows[selectedRow];

            // display datagridview selected row data into textboxes
            txt_pid.Text = row.Cells[0].Value.ToString();
            cmb_ptype.Text = row.Cells[1].Value.ToString();
            txt_pprice.Text = row.Cells[2].Value.ToString();
            cmb_pplace.Text = row.Cells[3].Value.ToString();
        }

        private void btn_pedit_Click(object sender, EventArgs e)
        {
            PackageDTO dto = new PackageDTO();
            dto.PackageID = txt_pid.Text;
            dto.Type = cmb_ptype.Text;
            dto.Price = txt_pprice.Text;
            dto.Place = cmb_pplace.Text;


            bl.EditPkg(dto);

        }
        private void dgv_tours_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow;
            selectedRow = e.RowIndex;
            DataGridViewRow row = dgv_tours.Rows[selectedRow];

            // display datagridview selected row data into textboxes
            txt_tid.Text = row.Cells[1].Value.ToString();
            txt_name.Text = row.Cells[2].Value.ToString();
            txt_desc.Text = row.Cells[3].Value.ToString();
            cmb_bus.Text = row.Cells[4].Value.ToString();
            cmb_pkg.Text = row.Cells[5].Value.ToString();
            cmb_hotel.Text = row.Cells[6].Value.ToString();
        }

        private void btn_tedit_Click_1(object sender, EventArgs e)
        {
            TourDTO dto = new TourDTO();
            dto.TourID = txt_tid.Text;
            dto.Name = txt_name.Text;
            dto.Description = txt_desc.Text;
            dto.BusID = cmb_bus.Text;
            dto.PkgID = cmb_pkg.Text;
            dto.HotelID = cmb_hotel.Text;


            bl.EditTour(dto);
        }

        private void btn_bdel_Click(object sender, EventArgs e)
        {
            BusDTO dto = new BusDTO();
            dto.BusID = txt_bid.Text;
            bl.Delbus(dto);
            int rowindex = dgv_bus.CurrentCell.RowIndex;
            dgv_bus.Rows.RemoveAt(rowindex);
            txt_bid.Text = "";
            txt_capacity.Text = "";
            dtp_bus.Text = "";
        }

        private void btn_mdel_Click(object sender, EventArgs e)
        {
            MealDTO dto = new MealDTO();
            dto.MealID = txt_mid.Text;
            bl.Delmeal(dto);
            int rowindex = dgv_meal.CurrentCell.RowIndex;
            dgv_meal.Rows.RemoveAt(rowindex);
            txt_mid.Text = "";
            cmb_mtype.Text = "";
            txt_mdesc.Text = "";
            cmb_hprice.Text = "";

        }
        private void btn_pdel_Click(object sender, EventArgs e)
        {
            PackageDTO dto = new PackageDTO();
            dto.PackageID = txt_pid.Text;
            bl.Delpkg(dto);
            int rowindex = dgv_pkg.CurrentCell.RowIndex;
            dgv_pkg.Rows.RemoveAt(rowindex);
            txt_pid.Text = "";
            cmb_ptype.Text = "";
            cmb_pplace.Text = "";
            txt_pprice.Text = "";
        }
        private void btn_tdel_Click_1(object sender, EventArgs e)
        {
            TourDTO dto = new TourDTO();
            dto.TourID = dgv_tours.CurrentRow.Cells[1].Value.ToString();
            bl.Deltour(dto);
            int rowindex = dgv_tours.CurrentCell.RowIndex;
            dgv_tours.Rows.RemoveAt(rowindex);
            //txt_pid.Text = "";
            //cmb_ptype.Text = "";
            //cmb_pplace.Text = "";
            //txt_pprice.Text = "";
        }

        private void AdminGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure you want to exit!!!", "Form is closing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)

                {
                    e.Cancel = true;
                }
                
                    

            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cmb_pkg_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            try
            {
                db.Con.Open();
                string queryString = "SELECT pid FROM package ";
                SqlCommand comm = new SqlCommand(queryString, db.Con);
                SqlDataReader reader1;
                reader1 = comm.ExecuteReader();
                while (reader1.Read())
                {
                    cmb_pkg.Items.Add(reader1[0].ToString());
                }

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

