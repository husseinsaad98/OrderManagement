using SQLite;

namespace OrderManagement.Models
{
    public class OrderItem
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
