namespace QuickMartPOSWeb.Models
{
    public class TransactionItem
    {
        public int Id { get; set; } // Primary Key
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
