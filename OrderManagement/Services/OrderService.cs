using OrderManagement.Models;

namespace OrderManagement.Services
{
    public class OrderService : DbService
    {

        public async Task<Order> CreateOrder(Order order)
        {
            await _connection.InsertAsync(order);

            return order;
        }
        public async Task<Order> Update(Order order)
        {
            await _connection.UpdateAsync(order);

            return order;
        }
        public async Task<bool> Delete(Order order)
        {
            var result = await _connection.DeleteAsync(order);

            return result > 0;
        }
        public async Task<Order> GetOrder(int orderId)
        {
            return (await _connection.Table<Order>()
                                          .Where(x => x.Id == orderId)
                                          .FirstOrDefaultAsync());
        }
        public async Task<List<Order>> GetOrders(int orderId)
        {
            return (await _connection.Table<Order>()
                                          .Where(x => x.Id == orderId)
                                          .ToListAsync());
        }
        public async Task<List<Order>> GetMyCreatedOrders(int userId)
        {
            return (await _connection.Table<Order>()
                                          .Where(x => x.CreatedByUserId == userId)
                                          .ToListAsync());
        }
        public async Task<OrderItem> AddOrderItem(OrderItem orderItem)
        {
            await _connection.InsertAsync(orderItem);

            return orderItem;
        }
        public async Task<OrderItem> UpdateOrderItem(OrderItem orderItem)
        {
            await _connection.UpdateAsync(orderItem);

            return orderItem;
        }
    }
}
