﻿using System.Web.Mvc;

namespace MVCUI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Default", action = "Index", id = UrlParameter.Optional } // Buraya eklediğimiz controller = "Default",  kodu admin areasında her hangi bir sayfa belirtilmezse varsayılan olarak default controller ve index action u çalıştırılmasını sağlar. 
            );
        }
    }
}