using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Repository
{
    public class DataCollection<T> : IEnumerable<T>
    {
        List<T> dataItems = new List<T>();


        public DataCollection() { }

        public DataCollection(IEnumerable<T> items)
        {
            dataItems.AddRange(items);
        }


        public IEnumerator<T> GetEnumerator()
        {
            return dataItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dataItems.GetEnumerator();
        }

        public void Insert(T item)
        {
            dataItems.Add(item);
        }
    }
}