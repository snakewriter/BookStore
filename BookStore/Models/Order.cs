using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите свое имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите свой номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Введите свой почтовый индекс")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Введите свой город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Введите свою улицу")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Введите свой номер дома")]
        public string House { get; set; }

        public int Apt { get; set; }

        public bool IsDispatched { get; set; }

        public virtual List<OrderItem> Items { get; set; }
    }
}