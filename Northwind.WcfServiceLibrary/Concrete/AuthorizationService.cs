using Northwind.BusinessLogicLayer.Concrete;
using Northwind.DataAccessLayer.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.WcfServiceLibrary.Concrete
{
    public class AuthorizationService : IAuthenticationService
    {
        //Dataya erişmemiz gerekiyor business katmanı manager sınıfı olduğundan ve dataya eriştiğinden manager katmanını newleriz
        AuthenticationManager _authenticationManager = new AuthenticationManager(new EfAuthenticationDal());
        public bool IsValid(User user)
        {
            if (_authenticationManager.IsValid(user))
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
