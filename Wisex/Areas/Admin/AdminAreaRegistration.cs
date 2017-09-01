using System.Web.Mvc;

namespace Wisex.Areas.Admin
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
                name: "Wisex-Default",
                url: "Admin/{controller}/{action}/{moudleId}/{menuId}/{btnId}/{id}",
                defaults:
                    new
                    {
                        controller = "Control",
                        action = "Index",
                        moudleId = UrlParameter.Optional,
                        menuId = UrlParameter.Optional,
                        btnId = UrlParameter.Optional,
                        id = UrlParameter.Optional
                    }
                );

            context.MapRoute(
                name: "Wisex-Default-Menu",
                url: "Admin/{controller}/{action}/{moudleId}/{menuId}/{btnId}",
                defaults:
                    new
                    {
                        controller = "Control",
                        action = "Index",
                        moudleId = UrlParameter.Optional,
                        menuId = UrlParameter.Optional,
                        btnId = UrlParameter.Optional
                    }
                );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}