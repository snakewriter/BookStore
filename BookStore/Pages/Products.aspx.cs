using BookStore.Models;
using BookStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.Pages
{
    public partial class Products : System.Web.UI.Page
    {
        private IRepository repository = Factory.GetResourse<IRepository>();
        private int pageSize = 5;


        protected uint CurrentPage
        {
            get
            {
                uint page = PageFromRequest;
                return page > MaxPage ? MaxPage : page;
            }
        }

        uint PageFromRequest
        {
            get
            {
                string reqValue = (string)RouteData.Values["page"] ??
                    Request.QueryString["page"];
                return reqValue != null && uint.TryParse(reqValue, out uint page) ? page : 1;
            }
        }

        protected uint MaxPage
        {
            get
            {
                return (uint)Math.Ceiling((decimal)GetBooksByCategory().Count() / pageSize);
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            return GetBooksByCategory()
                .OrderBy(book => book.ID)
                .Skip(((int)CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        private IEnumerable<Book> GetBooksByCategory()
        {
            var books = repository.Books;
            string currentCat = (string)RouteData.Values["category"] ??
                Request.QueryString["category"];
            var result = currentCat == null ? books :
                books.Where(b => b.Category == currentCat);
            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}