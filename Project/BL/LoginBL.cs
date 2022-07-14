using Project.DL;
using Project.DTO;
using Project.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.BL
{
    class LoginBL
    {
        private LoginDL lgDL;
        
        public LoginBL()
        {
            lgDL = new LoginDL();
           
        }
        public Form VerifyUser(LoginDTO lg)
        {
            // Here we call loginDL objects method verifyUserFromDB
            UserDTO ud = lgDL.VerifyUserFromDB(lg);
            if (ud == null)
            {
                return new WrongUserGUI();
            }
            else if (ud.Role == "admin")
            {
                return new AdminGUI(ud);
            }
            else if (ud.Role == "user")
            {
                return new UserGUI(ud);
            }
           
            else
            {
                return new WrongUserGUI();
            
            }

            return new WrongUserGUI();

        }
    }
}
