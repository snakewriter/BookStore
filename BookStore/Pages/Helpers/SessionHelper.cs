using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BookStore.Pages.Helpers
{
    public enum SessionKey
    {
        Cart, ReturnUrl
    }

    public static class SessionHelper
    {
        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[key.ToString()] = value;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            var dataValue = session[key.ToString()];
            if (dataValue != null && dataValue is T) return (T)dataValue;
            return default(T);
        }

        public static Cart GetCart(HttpSessionState session)
        {
            Cart cart = Get<Cart>(session, SessionKey.Cart);
            if (cart == null)
            {
                cart = new Cart();
                Set(session, SessionKey.Cart, cart);
            }
            return cart;
        }
    }
}