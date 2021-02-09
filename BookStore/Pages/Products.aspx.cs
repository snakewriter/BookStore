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
        private IRepository repository = MemoryBookRepository.Instance;
        private int pageSize = 5;


        protected uint CurrentPage
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
                return (uint)Math.Ceiling((decimal)repository.Books.Count() / pageSize);
            }
        }

        protected IEnumerable<Book> GetBooks()
        {
            return repository.Books
                .OrderBy(book => book.ID)
                .Skip(((int)CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}