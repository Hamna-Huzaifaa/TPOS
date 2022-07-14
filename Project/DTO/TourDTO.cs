using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO
{
    class TourDTO
    {
        private string _tourID;
        private string _description;
        private string _name;
        private string _busID;
        private string _pkgID;
        private string _hotelID;
        private string _mealID;

        public string TourID { get => _tourID; set => _tourID = value; }
        public string Description { get => _description; set => _description = value; }
        public string Name { get => _name; set => _name = value; }
        public string BusID { get => _busID; set => _busID = value; }
        public string PkgID { get => _pkgID; set => _pkgID = value; }
        public string HotelID { get => _hotelID; set => _hotelID = value; }
        public string MealID { get => _mealID; set => _mealID = value; }
    }
}
