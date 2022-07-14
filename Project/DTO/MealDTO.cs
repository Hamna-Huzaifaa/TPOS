using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO
{
    class MealDTO
    {
        private string _mealID;
        private string _type;
        private string _description;
        private string _price;

        public string MealID { get => _mealID; set => _mealID = value; }
        public string Type { get => _type; set => _type = value; }
        public string Description { get => _description; set => _description = value; }
        public string Price { get => _price; set => _price = value; }
    }
}
