using Project.BL;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class LoginSignupGUI : Form
    {
        private LoginDTO lgDTO;
        private LoginBL lgBL;
        private SignupBL signupBL;
        private UserDTO signupDTO;
        private UserGUI gui;
        //public bool login = false;
        
        public LoginSignupGUI()
        {
            InitializeComponent();
            lgDTO = new LoginDTO();
            signupDTO = new UserDTO();
            lgBL = new LoginBL();
            signupBL = new SignupBL();
            gui = new UserGUI();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(txt_Susername.Text == "" || txt_Spassword.Text == "" || txt_Semail.Text == ""))
            {
                signupDTO.Name = txt_Susername.Text;
                signupDTO.Password = txt_Spassword.Text;
                signupDTO.Email = txt_Semail.Text;
                signupBL.VerifyUser(signupDTO);
                //MessageBox.Show("Your Account has been created successfully!!!", "Account Creation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(txt_Username.Text == "" || txt_Password.Text == ""))
            {
                lgDTO.Username = txt_Username.Text;
                lgDTO.Password = txt_Password.Text;

                lgBL.VerifyUser(lgDTO).Show();
                //gui.Show(this);
                this.Hide();
                //this.Visible = false;

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
