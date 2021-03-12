using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BookStore.Models.Repository
{
    public class TestBookRepository : IRepository
    {
        public static IRepository Instance
        {
            get => instance ?? new TestBookRepository();
        }

        public DataCollection<Book> Books
        {
            get;
            private set;
        }

        public DataCollection<Order> Orders
        {
            get;
            private set;
        }      


        private Random rnd = new Random();
        private static IRepository instance;
        private string[] categories = new string[]
        {
            "Роман", "Детектив", "Приключения", "Политика"
        };


        private TestBookRepository()
        {            
            GenerateBooks(rnd.Next(50, 100));
            GenerateOrders(rnd.Next(5, 10));
            instance = this;
        }

        void GenerateBooks(int count)
        {
            var booksList = new List<Book>();
            for (int i = 0; i < count; i++)
            {
                GenerateItem(booksList, i);
                booksList[i].Category = categories[rnd.Next(0, categories.Length)];
            }
            Books = new DataCollection<Book>(booksList);
        }

        void GenerateOrders(int count)
        {
            var ordersList = new List<Order>();

            int orderID = 1;
            for (int i = 0; i < count; i++)
            {
                GenerateItem(ordersList, i);
                ordersList[i].Items = new List<OrderItem>();

                for (int j = 0; j < rnd.Next(1, 4); j++)   
                {
                    ordersList[i].Items.Add(new OrderItem()
                    {
                        ID = orderID,
                        BookID = rnd.Next(1, Books.Count()),
                        Quantity = rnd.Next(1, 5)
                    });
                    orderID++;
                }
            }
            Orders = new DataCollection<Order>(ordersList);
        }

        void GenerateItem<T>(List<T> itemsList, int index)
        {
            var newItem = Activator.CreateInstance<T>();

            foreach (var propInfo in typeof(T).GetProperties())
                if (propInfo.PropertyType == typeof(string))
                    SetProperty(propInfo, newItem, GenerateString(rnd.Next(15, 30)));

                else if (propInfo.Name == "ID")
                    SetProperty(propInfo, newItem, index);

                else if (propInfo.PropertyType == typeof(int))
                    SetProperty(propInfo, newItem, rnd.Next(10, 10000));

                else if (propInfo.PropertyType == typeof(float))
                    SetProperty(propInfo, newItem, (float)rnd.NextDouble() * 1000);

            itemsList.Add(newItem);

        }

        void SetProperty<T>(PropertyInfo propertyInfo, T item, object value)
        {
            propertyInfo.SetValue(item, value);
        }


        string GenerateString(int count)
        {
            const string chars = "QWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
            var wordLetters = new char[count];
            for (int i = 0; i < count; i++)
                wordLetters[i] = SelectRandomChar(chars);
            return new string(wordLetters);
        }

        char SelectRandomChar(string source)
        {
            var letter = source[rnd.Next(0, source.Length)]; // Берем букву из строки
            if (rnd.Next(0, 2) != 0) letter = char.ToLower(letter); // Случайно приводим к нижнему регистру
            return letter;
        }

        public void SaveChanges()
        {   
        }
    }
}