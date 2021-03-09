<%@ Page Language="C#" AutoEventWireup="true" 
    CodeBehind="CartView.aspx.cs" 
    Inherits="BookStore.Pages.CartView" 
    MasterPageFile="~/Pages/Store.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent"
     runat="server">
    <div id="content">
        <table id="cart-table">
            <thead>
                <tr>
                    <th>Количество</th>
                    <th>Книга</th>
                    <th>Цена</th>
                    <th>Сумма</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" ItemType="BookStore.Models.CartItem" 
                    SelectMethod="GetCartItems" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quantity %></td>
                            <td><%# Item.Book.Title %></td>
                            <td><%# Item.Book.Price.ToString("C") %></td>
                            <td><%# (Item.Quantity * Item.Book.Price).ToString("C") %></td>
                            <td>
                                <button type="submit" class="action-buttons" name="remove"
                                    value="<%# Item.Book.ID %>">
                                    Удалить
                                </button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">Итого:</td>
                    <td><%= Total.ToString("C") %></td>
                </tr>
            </tfoot>
        </table>
        <p class="action-buttons">
            <a href="<%= ReturnUrl %>">Продолжить покупки</a>
        </p>
    </div>
</asp:Content>

