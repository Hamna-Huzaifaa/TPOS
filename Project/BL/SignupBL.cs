using Project.DL;
using Project.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    class SignupBL
    {
        private SignupDL dl;
       

        public SignupBL()
        {
            dl = new SignupDL();
            
        }

        public void VerifyUser(UserDTO dto)
        {
            dl.CreateAccountInDB(dto);
            

        }

    }
}
