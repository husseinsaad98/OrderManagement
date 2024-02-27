using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using OrderManagement.Services;
using OrderManagement.Views.Account;
using OrderManagement.Views.Order;

namespace OrderManagement.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        #region Properties

        [ObservableProperty]
        string _email = string.Empty;

        [ObservableProperty]
        string _password = string.Empty;
        private readonly AccountService _accountService;
        private readonly ClientService _clientService;
        private readonly ItemService _itemService;

        #endregion
        public LoginViewModel(AccountService accountService, ClientService clientService, ItemService itemService)
        {
            _accountService = accountService;
            _clientService = clientService;
            _itemService = itemService;
        }
        [RelayCommand]
        private async Task LoadPage()
        {
            await _accountService.CreateUser();
            await _clientService.CreatClients();
            await _itemService.CreatItems();
        }
        [RelayCommand]
        private async Task SignIn()
        {
            try
            {
                var user = await _accountService.SignIn(Email, Password);

                if (user == null)
                    return;

                var token = await _accountService.GetToken();

                Preferences.Set("user", JsonConvert.SerializeObject(user));

                await App.DataStore.SaveTokenAsync(token);

                await Shell.Current.GoToAsync($"//{nameof(Login)}/{nameof(Orders)}");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
