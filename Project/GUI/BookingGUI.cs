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
    public partial class BookingGUI : Form
    {
        private DBconnection db;
        private TourDTO dto;
        private BookingBL bl;
        private BookingDTO bdto;
        private UserGUI ud;
        private RecieptGUI reciept;
        int count = 0;
        
        public BookingGUI()
        {
            InitializeComponent();
            db = new DBconnection();
            dto = new TourDTO();
            bdto = new BookingDTO();
            bl = new BookingBL();
            reciept = new RecieptGUI();
            btn_reciept.Enabled = false;
        }

        private void BookingGUI_Load(object sender, EventArgs e)
        {
            
            try
            {
                db.Con.Open();
                string queryString = "SELECT hotel.hname FROM hotel,tour WHERE tour.hid=hotel.hid";
                SqlCommand com = new SqlCommand(queryString, db.Con);
                SqlDataReader reader;
                reader = com.ExecuteReader();
                while (reader.Read())
                {

                    comboBox1.Items.Add(reader[0].ToString());
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

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

        private void btn_book_Click(object sender, EventArgs e)
        {
            bdto.Tourid = lbl_tid.Text;
            bdto.Userid = label10.Text;
            bdto.Hotelid = comboBox1.Text;
            bdto.Breakfast = checkBox1.Checked;
            bdto.Lunch = checkBox2.Checked;
            bdto.Dinner = checkBox3.Checked;
            bdto.Seats = Convert.ToInt32(numericUpDown1.Value);
            bdto.Paymentid = lbl_amt.Text;

            bl.CreateBooking(bdto);
            btn_reciept.Enabled = true;
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            
            PackageDTO dto = new PackageDTO();
            PackageDTO mdto = new PackageDTO();
            HotelDTO hdto = new HotelDTO();
            
            
            dto = bl.getPackageAmount(lbl_tid.Text); 
            mdto = bl.getMealAmount(lbl_tid.Text); 
            hdto = bl.getHotelAmount(lbl_tid.Text);
            int hdto2 = bl.getHotelPlace(lbl_tid.Text);
            



            int mealprice = 0;
           

            int packageprice = Convert.ToInt32(dto.Price);
            if (mdto.Type == "Normal")
            {
                 mealprice = 500;
            }
            else if (mdto.Type == "Premium")
            {
                 mealprice = 750;
            }
            int hotelprice = Convert.ToInt32(hdto.Price);
            
            int seat = Convert.ToInt32(numericUpDown1.Value);

            int total = (packageprice + (mealprice*count*hdto2) + (hotelprice*hdto2)) * seat;

            lbl_amt.Text =  total.ToString();
            btn_calculate.Enabled = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ch = sender as CheckBox;
            count++;

        }

        private void btn_reciept_Click(object sender, EventArgs e)
        {
            BookingDTO dto = new BookingDTO();

            dto.Tourid = lbl_tid.Text;
            dto.Userid = label10.Text;
            BookingDTO dddto = new BookingDTO();
            dddto=bl.getReciept(dto);

            reciept.lbl_bid.Text = dddto.Bookingid;
            reciept.lbl_tid.Text = dddto.Tourid;
            reciept.lbl_uid.Text = dddto.Userid;
            reciept.lbl_seats.Text = dddto.Seats.ToString();
            reciept.lbl_amt.Text = dddto.Paymentid;
            reciept.Show(this);
            this.Hide();
        }

        private void BookingGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure you want to exit!!!", "Form is closing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)

                {
                    e.Cancel = true;
                }
                else
                    this.Owner.Show();

            }
        }
    }
}
