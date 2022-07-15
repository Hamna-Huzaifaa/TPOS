using Project.DL;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    class BookingBL
    {
        private BookingDL dl;

        public BookingBL()
        {
            dl = new BookingDL();
        }

        public void CreateBooking(BookingDTO dto)
        {
            dl.CreateBookedItem(dto);
        }

        public PackageDTO getPackageAmount(string id)
        {
            return dl.getPackageAmountFromDB(id);

        }
        public PackageDTO getMealAmount(string id)
        {
            return dl.getMealAmountFromDB(id);

        }
        public int getHotelPlace(string id)
        {
            HotelDTO dto = new HotelDTO();
            dto = dl.getHotelPlace(id);
            if (dto.Place == "Swat")
            {
                return 2;
            }
            else if (dto.Place == "Hunza")
            {
                return 5;
            }
            else if (dto.Place == "Mushkpuri")
            {
                return 1;
            }

            else
            {
                return 1;
            }
        }
        public HotelDTO getHotelAmount(string id)
        {


            return dl.getHotelAmountFromDB(id); ;
        }

        public BookingDTO getReciept(BookingDTO dto)
        {
            return dl.getRecieptFromDB(dto);
        }
    }
}
