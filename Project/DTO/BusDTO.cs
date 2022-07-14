using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO
{
    class BusDTO
    {
        private string _busID;
        private string _capacity;
        private DateTime _dateTime;

        public string BusID { get => _busID; set => _busID = value; }
        public string Capacity { get => _capacity; set => _capacity = value; }
        public DateTime DateTime { get => _dateTime; set => _dateTime = value; }
    }
}
