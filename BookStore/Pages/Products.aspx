<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="BookStore.Pages.Products"
    MasterPageFile="~/Pages/Store.Master" %>


<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <%
            foreach (BookStore.Models.Book book in GetBooks())
            {
                Response.Write(
                    $"<div class='item'>" +
                        $"<h3>{book.Title}</h3>{book.Author}" +
                        $"<h4>{book.Price.ToString("C")}</h4>" +
                    $"</div>");
            }
                %>
        </div>

        <div class="pager">
            <%
                for (int i = 0; i <= MaxPage; i++)
                {
                    var aClass = i == CurrentPage ? "class='selected' " : string.Empty;
                        Response.Write(
                            $"<a href='/Pages/Products.aspx?page={i}' " +
                            $"{aClass} >{i}");
                }
            %>
    </div>
</asp:Content>
