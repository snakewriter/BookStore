using BookStore.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Pages.Helpers
{
    public static class Factory
    {
        public static T GetResourse<T>()
        {
            if (typeof(T) == typeof(IRepository))
                return (T)TestBookRepository.Instance;
            throw new NotImplementedException("Добавьте тип данных");
        }
    }
}