using BookStore.Models;
using BookStore.Models.Repository;
using BookStore.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkout.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack) PlaceTheOrder();
        }

        private void PlaceTheOrder()
        {
            var newOrder = new Order();
            var formValuesProvider = new FormValueProvider(ModelBindingExecutionContext);

            if (!TryUpdateModel(newOrder, formValuesProvider)) return;

            FillOrderWithItems(newOrder);
            UpdateDataStorageForOrder(newOrder);
            UpdateCartAndView();
        }

        void FillOrderWithItems(Order newOrder)
        {
            newOrder.Items = new List<OrderItem>();
            var cart = SessionHelper.GetCart(Session);

            foreach (var item in cart.Items) newOrder.Items.Add(new OrderItem()
            {
                BookID = item.Book.ID,
                Quantity = item.Quantity
            });
        }

        void UpdateDataStorageForOrder(Order newOrder)
        {
            var repository = Factory.GetResourse<IRepository>();
            repository.Orders.Insert(newOrder);
            repository.SaveChanges();
        }

        private void UpdateCartAndView()
        {
            SessionHelper.GetCart(Session).Clear();
            checkout.Visible = false;
            checkoutMessage.Visible = true;        
        }
    }
}