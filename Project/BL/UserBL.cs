using Project.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    class UserBL
    {
        private UserDL dl;

        public UserBL()
        {
            dl = new UserDL();
        }

        public DataTable Get_Tours()
        {
            return dl.getToursFromDB();
        }

    }
}
