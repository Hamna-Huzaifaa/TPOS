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


        }

        private void User_load(object sender, EventArgs e)
        {
            if (dto.Login == true)
            {
                btn_loginSignup.Text = dto.Name;
                dataGridView1.DataSource = bl.Get_Tours();
            }
            else
            {
                dataGridView1.DataSource = bl.Get_Tours();
            }


            

        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            BookingDTO reqDTO = new BookingDTO();          
            reqDTO.Tourid = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            reqDTO.Userid = dto.Name;
            gui.label10.Text = reqDTO.Userid;
            gui.lbl_tid.Text = reqDTO.Tourid;
            gui.ShowDialog();
            //reqDTO.StdID = studentDTO.UserID;
            //reqDTO.ReqType = "add";


            //if (MessageBox.Show("Are you really want to add this course?", "Adding course section " + reqDTO.SecID, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        stdBL.RegisterCourseRequest(reqDTO);
            //        MessageBox.Show("Add Course request submitted Succesfullly");
            //    }
            //    catch (SqlException ex)
            //    {
            //        MessageBox.Show("Course has not been added");

            //    }
            //    dgv_ViewOffered.DataSource = stdBL.GetOfferedCourses(studentDTO.UserID);
            //    btn_Add_Course.Enabled = false;

            //}
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btn_book.Enabled = true;
        }
    }
}
