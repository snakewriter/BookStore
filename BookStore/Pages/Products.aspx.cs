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
        private IRepository repository = new MemoryBookRepository();
        private int pageSize = 7;


        protected uint CurrentPage
        {
            get => uint.TryParse(Request.QueryString["page"], out uint page) ? page : 1;
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