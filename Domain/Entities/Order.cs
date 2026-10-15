using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductDetail { get; set; } = string.Empty;
        public Decimal Total { get; set; }
        public string Status { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}
