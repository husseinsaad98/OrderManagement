namespace OrderManagement.Data
{
    public class DataStore
    {
        private const string _tokenKey = "UserToken";
        public async Task<string> GetTokenAsync()
        {
            return await SecureStorage.Default.GetAsync(_tokenKey);
        }

        public async Task SaveTokenAsync(string token)
        {
            await SecureStorage.Default.SetAsync(_tokenKey, token);
        }

        public void RemoveToken()
        {
            SecureStorage.Default.Remove(_tokenKey);
        }

    }
}
