<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="BookStore.Pages.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Книжный магазин</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
    </form>
</body>
</html>
