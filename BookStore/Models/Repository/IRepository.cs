using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Repository
{
    public interface IRepository
    {
        DataCollection<Book> Books { get; }

        DataCollection<Order> Orders { get; }

        void SaveChanges();
    }
}
