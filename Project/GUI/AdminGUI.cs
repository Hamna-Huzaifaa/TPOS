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

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_hadd_Click(object sender, EventArgs e)
        {
            if (!(txt_hid.Text == "" || txt_hname.Text == "" || cmb_hplace.Text == "" || cmb_hprice.Text == "" || cmb_htype.Text == "" ))
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

        private void dgv_hotel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        }

        private void btn_badd_Click(object sender, EventArgs e)
        {
            if (!(txt_bid.Text == "" || txt_capacity.Text == "" || dtp_bus.Text == "" ))
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
            if (!(txt_mid.Text == "" || cmb_mtype.Text == "" || txt_mdesc.Text == "" || txt_mprice.Text == "" ))
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
            if (!(txt_pid.Text == "" || cmb_ptype.Text == "" || txt_pprice.Text == "" || cmb_pplace.Text == "" ))
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
            if (!(txt_tid.Text == "" || txt_name.Text == "" || txt_desc.Text == "" || cmb_bus.Text == "" || cmb_pkg.Text == "" ))
            {
                tdto.TourID = txt_tid.Text;
                tdto.Name = txt_name.Text;
                tdto.Description = txt_desc.Text;
                tdto.BusID = cmb_bus.Text;
                tdto.PkgID = cmb_pkg.Text;
                

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



        private void dgv_tours_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
