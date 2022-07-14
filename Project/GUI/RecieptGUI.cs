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
        public RecieptGUI()
        {
            InitializeComponent();
            bl = new BookingBL();
        }

        private void lbl_bid_Click(object sender, EventArgs e)
        {


        }

        private void RecieptGUI_Load(object sender, EventArgs e)
        {
            BookingDTO dto = new BookingDTO();
            dto = bl.getReciept();
            lbl_bid.Text = dto.Bookingid;
            lbl_tid.Text = dto.Tourid;
            lbl_uid.Text = dto.Userid;
            lbl_seats.Text = dto.Seats.ToString();
            lbl_amt.Text = dto.Paymentid;
        }
    }
}
