using OrderManagement.Data;
using OrderManagement.Models;
using OrderManagement.Views.Account;
using OrderManagement.Views.Order;

namespace OrderManagement
{
    public partial class App : Application
    {
        public static DataStore DataStore { get; set; }
        public static User user { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            DataStore = new DataStore();
        }
        protected async override void OnStart()
        {
            base.OnStart();

            string token = await DataStore.GetTokenAsync();

            if (string.IsNullOrWhiteSpace(token))
                return;

            else
                await Shell.Current.GoToAsync($"//{nameof(Login)}/{nameof(Orders)}");
        }
    }
}
