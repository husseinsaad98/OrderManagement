using OrderManagement.Models;

namespace OrderManagement.Services
{
    public class ClientService : DbService
    {
        public async Task CreatClients()
        {
            var accounts = await _connection.Table<Client>()
                                        .ToListAsync();

            if (accounts.Count == 0)
            {
                await _connection.InsertAsync(new Client()
                {
                    Name = "Mounir",
                });
                await _connection.InsertAsync(new Client()
                {
                    Name = "Jamil",
                });
                await _connection.InsertAsync(new Client()
                {
                    Name = "Mona",
                });
                await _connection.InsertAsync(new Client()
                {
                    Name = "Jad",
                });
            }

        }
        public async Task<List<Client>> GetClients()
        {
            return (await _connection.Table<Client>()
                                          .ToListAsync());
        }
        public async Task<List<OrderItem>> GetOrderItems(int orderId)
        {
            return (await _connection.Table<OrderItem>()
                                     .Where(x=>x.OrderId == orderId)
                                     .ToListAsync());
        }
    }
}
