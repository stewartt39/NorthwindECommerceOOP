using Northwind.DataAccessLayer.Abstract;
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
        private IAuthenticateDal _authenticateDal;
        public AuthenticationManager(IAuthenticateDal authenticateDal)
        {
            _authenticateDal = authenticateDal;
        }
        public bool IsValid(User user)
        {
            if (_authenticateDal.IsValid(user))
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
