using BookStore.Models;
using BookStore.Models.Repository;
using BookStore.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.Pages.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        IRepository repository = Factory.GetResourse<IRepository>();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Order> GetOrders()
        {
            return repository.Orders;
        }

        public float Total(IEnumerable<OrderItem> orderItems)
        {
            var orderDetails = repository.Books
                .Join(orderItems, book => book.ID, item => item.BookID, (book, item) => new
                {
                    book.Price,
                    item.Quantity
                });
            return orderDetails.Sum(book => book.Price * book.Quantity);
        }
    }
}