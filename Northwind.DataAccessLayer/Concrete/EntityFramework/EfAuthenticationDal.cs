using Northwind.DataAccessLayer.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccessLayer.Concrete.EntityFramework
{
    public class EfAuthenticationDal : IAuthenticateDal
    {
        public bool IsValid(User user)
        {
            if (user.UserName=="emre" &&user.Password=="123456")
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
