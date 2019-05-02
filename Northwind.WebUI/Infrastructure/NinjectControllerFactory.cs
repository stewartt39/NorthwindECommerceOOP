using Ninject;
using Northwind.BusinessLogicLayer.Concrete;
using Northwind.DataAccessLayer.Concrete.EntityFramework;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
       private IKernel _ninjectKernel;
        public NinjectControllerFactory ()
        {
            _ninjectKernel = new StandardKernel();
            AddBllBinding();
        }
        //Eğer senden biri Product Service isterse ona Product manager ver.
        private void AddBllBinding()
        {
            _ninjectKernel.Bind<IProductService>().To<ProductManager>().WithConstructorArgument("productDal",new EfProductDal());
            _ninjectKernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryDal", new EfCategoryDal());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null :(IController) _ninjectKernel.Get(controllerType);
        }
    }
}