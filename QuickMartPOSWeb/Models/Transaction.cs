using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickMartPOSWeb.Models
{
    public class Transaction
    {
        public int Id { get; set; } // Primary Key
        public DateTime Date { get; set; }
        public List<TransactionItem> Items { get; set; } = new List<TransactionItem>();
        public decimal Subtotal => Items.Sum(item => item.Product.Price * item.Quantity);
        public decimal Tax => Subtotal * 0.08m; // Assuming 8% tax rate
        public decimal Total => Subtotal + Tax;
    }
}
