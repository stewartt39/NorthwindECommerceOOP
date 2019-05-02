using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.WebUI.ModelBinders
{
    //Her yerde sessiondan sepeti okuduğumuz için cart ile bir model binding yapmak istiyoruz.cart nesnesinin geçtiği her yerde 
    //sepetteki cartı anlaması için
    public class CartModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //cart nesnesinin sessiondaki cart olduğunu tanıttık
            var cart = (Cart)controllerContext.HttpContext.Session["cart"];

            if (cart==null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session["cart"] = cart;
            }
            return cart;
        }
    }
}