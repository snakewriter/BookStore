<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="BookStore.Pages.Products"
    MasterPageFile="~/Pages/Store.Master" %>
<%@ Import Namespace="System.Web.Routing"  %>


<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <asp:Repeater ItemType="BookStore.Models.Book" 
            SelectMethod="GetBooks" runat="server">
            <ItemTemplate>
                <div class="item">
                    <h3><%# Item.Title %></h3>
                    <%# Item.Author %>
                    <h4><%# Item.Price.ToString("C") %></h4>

                    <button name="buy" type="submit" value="<%# Item.ID %>">
                        Купить
                    </button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="pager">
        <%
            for (int i = 1; i <= MaxPage; i++)
            {
                var path = RouteTable.Routes.GetVirtualPath(
                    null, null, new RouteValueDictionary()
                    { { "page", i } }).VirtualPath;

                var aClass = i == CurrentPage ? "class='selected' " : string.Empty;
                Response.Write(
                    $"<a href='{path}' {aClass} >{i}");
            }
        %>
    </div>
</asp:Content>
