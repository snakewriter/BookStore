using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.Pages.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        public string OrdersUrl
        {
            get => GetUrl("admin-orders");
        }

        public string ProductsUrl
        {
            get => GetUrl("admin-products");
        }




        private string GetUrl(string routeName)
        {
            return RouteTable.Routes.GetVirtualPath(null, routeName, null).VirtualPath;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}