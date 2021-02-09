using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace BookStore.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(null, string.Empty, "~/Pages/Products.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Products.aspx");
        }
    }
}