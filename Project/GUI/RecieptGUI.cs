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
    public partial class RecieptGUI : Form
    {
        private BookingBL bl;
       // private BookingGUI gui;
        public RecieptGUI()
        {
            InitializeComponent();
            bl = new BookingBL();
            //gui = new BookingGUI();
        }

        private void lbl_bid_Click(object sender, EventArgs e)
        {


        }

        private void RecieptGUI_Load(object sender, EventArgs e)
        {
            
        }

        private void RecieptGUI_FormClosing(object sender, FormClosingEventArgs e)
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
