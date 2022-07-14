using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO
{
    class HotelDTO
    {
        private string _hotelID;
        private string _name;
        private string _place;
        private string _price;
        private string _type;

        public string HotelID { get => _hotelID; set => _hotelID = value; }
        public string Name { get => _name; set => _name = value; }
        public string Place { get => _place; set => _place = value; }
        public string Price { get => _price; set => _price = value; }
        public string Type { get => _type; set => _type = value; }
    }
}
