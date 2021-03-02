using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Cart
    {
        List<CartItem> booksOrdered = new List<CartItem>();


        public IEnumerable<CartItem> Items
        {
            get => booksOrdered;
        }

        public float Total
        {
            get => booksOrdered.Sum(item => item.Book.Price * item.Quantity);
        }


        public void AddItem(Book book, int quantity)
        {
            var cartItem = booksOrdered
                .Where(item => item.Book.ID == book.ID)
                .FirstOrDefault();

            if (cartItem == null)
                booksOrdered.Add(new CartItem()
                {
                    Book = book,
                    Quantity = quantity
                });
            else cartItem.Quantity += quantity;
        }

        public void RemoveItem(Book book)
        {
            booksOrdered.RemoveAll(item => item.Book.ID == book.ID);
        }

        public void Clear()
        {
            booksOrdered.Clear();
        }
    }
}