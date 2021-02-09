using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Repository
{
    public class MemoryBookRepository : IRepository
    {
        public static IRepository Instance
        {
            get => instance ?? new MemoryBookRepository();
        }
        public IEnumerable<Book> Books { get; private set; }

        private Random rnd = new Random();
        private static IRepository instance;


        private MemoryBookRepository()
        {            
            GenerateBooks(rnd.Next(50, 100));
            instance = this;
        }

        void GenerateBooks(int count)
        {
            var booksList = new List<Book>();
            for (int i = 0; i < count; i++) GenerateBook(booksList, i);
            Books = booksList;
        }

        void GenerateBook(List<Book> booksList, int index)
        {
            booksList.Add(new Book()
            {
                ID = index,
                Title = GenerateString(rnd.Next(10, 25)),
                Author = GenerateString(rnd.Next(5, 15)),
                Price = (float)(rnd.NextDouble() * rnd.Next(100, 10000))
            });
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
            throw new NotImplementedException();
        }
    }
}