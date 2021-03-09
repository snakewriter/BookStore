using BookStore.Models;
using BookStore.Models.Repository;
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

        public IEnumerable<CartItem> GetCartItems()
        {
            return SessionHelper.GetCart(Session).Items;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) RemoveItem();
        }

        private void RemoveItem()
        {
            var repository = Factory.GetResourse<IRepository>();
            if (!int.TryParse(Request.Form["remove"], out int bookID)) return;

            var bookToRemove = repository.Books
                .Where(book => book.ID == bookID)
                .FirstOrDefault();

            if (bookToRemove == null) return;
            SessionHelper.GetCart(Session).RemoveItem(bookToRemove);
        }
    }
}