<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartSummary.ascx.cs" 
    Inherits="BookStore.Controls.CartSummary" %>

<div id="cartSummary">
    <span class="caption">
        <b>В корзине:</b>
        <span id="cartSummaryQuantity" runat="server"></span> товаров,
        <span id="cartSummaryTotal" runat="server"></span>
    </span>
    <a id="cartSummaryLink" runat="server">Корзина</a>
</div>