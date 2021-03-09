using BookStore.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.Controls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cart = SessionHelper.GetCart(Session);
            csQuantity.InnerText = cart.Items.Sum(item => item.Quantity).ToString();
            csTotal.InnerText = cart.Total.ToString("C");
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath;

        }
    }
}