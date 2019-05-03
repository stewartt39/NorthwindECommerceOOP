using Northwind.Entities.Concrete;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BusinessLogicLayer.Concrete
{
    public class AuthenticationManager : IAuthenticationService
    {
        public bool IsValid(User user)
        {
            if(user.UserName == "emre" && user.Password == "123456")
            {
                return true;

            }
            else
            {
                return false;
            }

        }
    }
}
