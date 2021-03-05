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
                <label for="firstName">Имя</label>
                <input id="firstName" name="firstName" runat="server" />
            </div>
            <div>
                <label for="phone">Телефон</label>
                <input id="phone" name="phone" type="tel" runat="server" />
            </div>
            <div>
                <label for="zipCode">Почтовый индекс</label>
                <input id="zipCode" name="zipCode" type="number" runat="server" />
            </div>
            <div>
                <label for="city">Город</label>
                <input id="city" name="city" runat="server" />
            </div>
            <div>
                <label for="street">Улица</label>
                <input id="street" name="street" runat="server" />
            </div>
            <div>
                <label for="house">Дом (корпус и апартамент при наличии)</label>
                <input id="house" name="house" runat="server" />
            </div>

            <p class="action-buttons">
                <button class="action-buttons checkout-button" type="submit">Отправить заказ</button>
            </p>
        </div>

        <div id="checkoutMessage" runat="server">
            <h2>Спасибо!</h2>
            Спасибо, что выбрали наш магазин! 
            В ближайшее время менеждер свяжется с Вами
        </div>
    </div>
</asp:Content>
