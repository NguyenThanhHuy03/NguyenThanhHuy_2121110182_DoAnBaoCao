using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO_AN.DAL.LoginDAL;

namespace DO_AN.BAL
{
    internal class dangnhap
    {
        public class BusinessLogicLayer
        {
            public static bool ValidateLoginCredentials(string username, string password)
            {
                // Perform any additional business logic here
                // Call Data Access Layer to validate credentials
                return DataAccessLayer.ValidateLoginCredentials(username, password);
            }
        }
    }
}
