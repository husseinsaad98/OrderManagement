using OrderManagement.Models;

namespace OrderManagement.Services
{
    public class AccountService : DbService
    {
        public async Task<User> SignIn(string userName, string password)
        {
            // Check if user exists in DB
            var user = await _connection.Table<User>()
                                        .Where(u => u.Username == userName && u.Password == password)
                                        .FirstOrDefaultAsync();

            // Return true if the user is found otherwise return false
            return user;
        }
        public async Task CreateUser()
        {
            var user = await _connection.Table<User>()
                                      .Where(u => u.Username == "user@user.com").FirstOrDefaultAsync();

            if (user == null)
                await _connection.InsertAsync(new User()
                {
                    Username = "user@user.com",
                    Password = "P@ssw0rd",
                });
        }

        public async Task<string> GetToken()
        {
            await Task.CompletedTask;
            return "randomToken";
        }
    }
}
