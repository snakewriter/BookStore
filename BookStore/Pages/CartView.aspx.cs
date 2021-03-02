using BookStore.Models;
using BookStore.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        public string ReturnUrl
        {
            get => SessionHelper.Get<string>(Session, SessionKey.ReturnUrl);
        }

        public float Total
        {
            get => SessionHelper.GetCart(Session).Total;
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<CartItem> GetCartItems()
        {
            return SessionHelper.GetCart(Session).Items;
        }
    }
}