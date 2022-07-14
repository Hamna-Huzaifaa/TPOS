using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO
{
    class BookingDTO
    {

        private string _bookingid;
        private string _tourid;
        private string _paymentid;
        private string _userid;
        private string _hotelid;
        private int seats;
        private bool lunch;
        private bool breakfast;
        private bool dinner;

        public string Tourid { get => _tourid; set => _tourid = value; }
        public string Paymentid { get => _paymentid; set => _paymentid = value; }
        public string Userid { get => _userid; set => _userid = value; }
        public string Hotelid { get => _hotelid; set => _hotelid = value; }
        public int Seats { get => seats; set => seats = value; }
        public bool Lunch { get => lunch; set => lunch = value; }
        public bool Breakfast { get => breakfast; set => breakfast = value; }
        public bool Dinner { get => dinner; set => dinner = value; }
        public string Bookingid { get => _bookingid; set => _bookingid = value; }
    }
}
