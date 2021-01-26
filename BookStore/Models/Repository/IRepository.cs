using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Repository
{
    public interface IRepository
    {
        IEnumerable<Book> Books { get; }
        void SaveChanges();
    }
}
