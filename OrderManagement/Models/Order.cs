using SQLite;

namespace OrderManagement.Models
{
    public class Order
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderAmount { get; set; }
        public int ClientId { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
