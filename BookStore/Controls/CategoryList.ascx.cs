using BookStore.Models;
using BookStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookStore.Controls
{
    public partial class CategoryList : System.Web.UI.UserControl
    {
        private IRepository repository = Factory.GetResourse<IRepository>();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected IEnumerable<string> GetCategories()
        {
            var result = repository.Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(b => b);
            return result;
        }

        protected string CreateHomeLinkHtml()
        {
            var path = RouteTable.Routes.GetVirtualPath(null, null).VirtualPath;
            return $"<a href='{path}'> Главная</a>";
        }

        protected string CreateLinkHtml(string category)
        {
            var selectedCat = (string)Page.RouteData.Values["category"] ??
                Request.QueryString["category"];

            var path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary()
                {
                    { "category", category },
                    { "page", "1" }
                }).VirtualPath;

            var selectedClass = selectedCat == category ? "selected" : string.Empty;
            return $"<a href='{path}' class='{selectedClass}'> {category}</a>";
        }
    }
}