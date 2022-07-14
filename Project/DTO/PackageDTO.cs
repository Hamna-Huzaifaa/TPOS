using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO
{
    class PackageDTO
    {
        private string _packageID;
        private string _type;
        private string _price;
        private string _place;

        public string PackageID { get => _packageID; set => _packageID = value; }
        public string Type { get => _type; set => _type = value; }
        public string Price { get => _price; set => _price = value; }
        public string Place { get => _place; set => _place = value; }
    }
}
