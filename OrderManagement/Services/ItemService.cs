using OrderManagement.Models;

namespace OrderManagement.Services
{
    public class ItemService:DbService
    {
        public async Task CreatItems()
        {
            var items = await _connection.Table<Item>()
                                        .ToListAsync();

            if (items.Count == 0)
            {
                await _connection.InsertAsync(new Item()
                {
                    Name = "Tv",
                });
                await _connection.InsertAsync(new Item()
                {
                    Name = "Phone",
                });
                await _connection.InsertAsync(new Item()
                {
                    Name = "Camera",
                });
                await _connection.InsertAsync(new Item()
                {
                    Name = "Power Bank",
                });
            }

        }
        public async Task<List<Item>> GetItems()
        {
            return (await _connection.Table<Item>()
                                          .ToListAsync());
        }
     
    }
}
