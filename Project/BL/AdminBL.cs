using Project.DL;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    class AdminBL
    {
        private AdminDL dl;

        public AdminBL()
        {
            dl = new AdminDL();
        }

        public void verifyHotel(HotelDTO dto)
        {
            dl.CreateHotelInDB(dto);
        }
        public void verifyBus(BusDTO dto)
        {
            dl.CreateBusInDB(dto);
        }

        public void verifyMeal(MealDTO dto)
        {
            dl.CreateMealInDB(dto);
        }

        public void verifyPackage(PackageDTO dto)
        {
            dl.CreatePackageInDB(dto);
        }


        public DataTable GetHotels()
        {
            return dl.getHotelsFromDB();
            
        }
        public DataTable GetMeals()
        {
            return dl.getMealsFromDB();

        }
        public DataTable GetBus()
        {
            return dl.getBusFromDB();

        }
        public DataTable GetPackages()
        {
            return dl.getPackagesFromDB();

        }
        public DataTable GetTours()
        {
            return dl.getToursFromDB();

        }
        public DataTable GetBookings()
        {
            return dl.getBookingsFromDB();

        }

        public void verifyTour(TourDTO tdto)
        {
            dl.CreateTourInDB(tdto);
        }
    }
}
