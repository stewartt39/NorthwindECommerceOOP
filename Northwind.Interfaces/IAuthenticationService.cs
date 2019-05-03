using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interfaces
{
   public interface IAuthenticationService
    {
        bool IsValid(User user);
    }
}
