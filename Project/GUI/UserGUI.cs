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
    public partial class UserGUI : Form
    {
        private UserBL bl;
        private BookingGUI gui;
        private UserDTO dto;
        

        public UserGUI()
        {
            InitializeComponent();
            bl = new UserBL();
            gui = new BookingGUI();
            

        }
        public UserGUI(UserDTO ud)
        {
            InitializeComponent();
            bl = new UserBL();
            gui = new BookingGUI();
            dto = ud;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_loginSignup_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Owner.Show();
            ////Owner.Visible = true;
            LoginSignupGUI form = new LoginSignupGUI();
            form.ShowDialog();
            this.Hide();
        }

        private void User_load(object sender, EventArgs e)
        {
            try
            {
                if (dto.Login == true)
                {
                    btn_loginSignup.Text = dto.Name;
                    dataGridView1.DataSource = bl.Get_Tours();
                }
            }
            catch(Exception ex)
            {
                dataGridView1.DataSource = bl.Get_Tours();
            }
            finally
            {
                dataGridView1.DataSource = bl.Get_Tours();
            }


            

        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            try
            {
                BookingDTO reqDTO = new BookingDTO();
                reqDTO.Tourid = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                reqDTO.Userid = dto.Name;
                gui.label10.Text = reqDTO.Userid;
                gui.lbl_tid.Text = reqDTO.Tourid;
                gui.Show(this);
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Please Login / SignUp", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
        }

        private void UserGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    if (MessageBox.Show("Are you sure you want to exit!!!", "Form is closing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)

            //    {
            //        e.Cancel = true;
            //    }
            //    else
            //        this.Owner.Show();

            //}
        }
    }
}
