<%@ Page Language="C#" MasterPageFile="~/Pages/Store.Master" AutoEventWireup="true" 
    CodeBehind="Checkout.aspx.cs" Inherits="BookStore.Pages.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div id="checkout" class="checkout" runat="server">
            <h2>Оформить заказ</h2>
            
            Введите свои данные для доставки заказа

            <div id="errors" data-valmsg-summary="true">
                <ul>
                    <li style="display: none"></li>
                </ul>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </div>

            <h3>Укажите адрес</h3>

            <div>
                <label for="name">Имя *</label>
                <SX:ViewInput PropertyName="Name" runat="server" />
            </div>
            <div>
                <label for="phone">Телефон *</label>
                <SX:ViewInput PropertyName="Phone" runat="server" />
            </div>
            <div>
                <label for="zipCode">Почтовый индекс *</label>
                <SX:ViewInput PropertyName="ZipCode" runat="server" />
            </div>
            <div>
                <label for="city">Город *</label>
                <SX:ViewInput PropertyName="City" runat="server" />
            </div>
            <div>
                <label for="street">Улица *</label>
                <SX:ViewInput PropertyName="Street" runat="server" />
            </div>
            <div>
                <label for="house">Дом *</label>
                <SX:ViewInput PropertyName="House" runat="server" />
            </div>
            <div>
                <label for="apt">Апартамент</label>
                <input id="apt" name="apt" runat="server" />
            </div>

            <p class="action-buttons">
                <button class="action-buttons checkout-button" type="submit">
                    Отправить заказ
                </button>
            </p>
        </div>

        <div id="checkoutMessage" runat="server">
            <h2>Спасибо!</h2>
            Спасибо, что выбрали наш магазин! 
            В ближайшее время менеждер свяжется с Вами
        </div>
    </div>
</asp:Content>
