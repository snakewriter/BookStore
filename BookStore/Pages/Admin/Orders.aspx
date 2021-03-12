<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" 
    CodeBehind="Orders.aspx.cs" Inherits="BookStore.Pages.Admin.Orders" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="outer-container">
        <table id="orders-table">
            <tr>
                <th>Имя заказчика</th>
                <th>Город</th>
                <th>Заказов</th>
                <th>Сумма</th>
                <th></th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" SelectMethod="GetOrders"
                ItemType="BookStore.Models.Order">
                <ItemTemplate>
                    <tr>
                        <td><%# Item.Name %></td>
                        <td><%# Item.City %></td>
                        <td><%# Item.Items.Sum(item => item.Quantity) %></td>
                        <td><%# Total(Item.Items).ToString("C") %></td>
                        <td>
                            <asp:PlaceHolder ID="PlaceHolder1" Visible="<%# !Item.IsDispatched %>"
                                runat="server">
                                <button type="submit" name="dispatch" value="<%# Item.ID %>">
                                    Пометить отправленным
                                </button>
                            </asp:PlaceHolder>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div id="orders-check">
        <asp:CheckBox ID="showDispatched" runat="server" Checked="false" AutoPostBack="true" />
        Показать отправленные заказы?
    </div>
</asp:Content>
