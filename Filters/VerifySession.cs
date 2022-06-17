using Intersel_Practica.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intersel_Practica.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                var user = System.Web.HttpContext.Current.Session["User"];
                if (user!=null)
                {
                        System.Web.HttpContext.Current.Session.Timeout=10;
                }
                if (user==null)
                {
                    if (filterContext.Controller is LoginController==false)
                    {
                        filterContext.HttpContext.Response.Redirect("../Login/Index");
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}