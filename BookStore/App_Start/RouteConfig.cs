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
            routes.MapPageRoute(null, "list/{category}/{page}",
                "~/Pages/Products.aspx");

            routes.MapPageRoute(null, "list/{page}", "~/Pages/Products.aspx");
            routes.MapPageRoute(null, string.Empty, "~/Pages/Products.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Products.aspx");

            routes.MapPageRoute("cart", "cart", "~/Pages/CartView.aspx");
            routes.MapPageRoute("checkout", "checkout", "~/Pages/Checkout.aspx");

            //routes.MapPageRoute("admin", "admin", "~/Pages/Admin.aspx");
            routes.MapPageRoute("admin-orders", "admin/orders", "~/Pages/Admin/Orders.aspx");
            routes.MapPageRoute("admin-products", "admin/products", "~/Pages/Admin/Products.aspx");
        }
    }
}