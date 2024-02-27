using OrderManagement.Models;
using SQLite;

namespace OrderManagement.Services
{
    public class DbService
    {
        private const string _dbName = "OrderManagment_db.db3";
        protected readonly SQLiteAsyncConnection _connection;
        public DbService()
        {

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, _dbName));
            _connection.CreateTableAsync<User>();
            _connection.CreateTableAsync<Order>();
            _connection.CreateTableAsync<OrderItem>();
            _connection.CreateTableAsync<Client>();
            _connection.CreateTableAsync<Item>();
        }
    }
}
