using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using OrderManagement.Models;
using OrderManagement.Services;
using OrderManagement.Views.Account;
using OrderManagement.Views.Order;
using System.Collections.ObjectModel;

namespace OrderManagement.ViewModels
{
    public partial class OrdersViewModel : ObservableObject
    {
        private readonly OrderService _orderService;
        #region Fields
        [ObservableProperty]
        ObservableCollection<Order> _orders = new();
        #endregion
        public OrdersViewModel(OrderService orderService)
        {
            _orderService = orderService;
        }
        [RelayCommand]
        private async Task LoadPage()
        {
            var user = JsonConvert.DeserializeObject<User>(Preferences.Get("user", null));
            Orders = new ObservableCollection<Order>(await _orderService.GetMyCreatedOrders(user.Id));
        }
        [RelayCommand]
        private async Task CreateOrderNavigate()
        {
            await Shell.Current.GoToAsync($"//{nameof(Login)}/{nameof(Orders)}/{nameof(ManageOrder)}");
        }
        [RelayCommand]
        private async Task UpdateOrderNavigate(int id)
        {
            await Shell.Current.GoToAsync($"//{nameof(Login)}/{nameof(Orders)}/{nameof(ManageOrder)}?OrderId={id}");
        }
        [RelayCommand]
        private async Task DeleteOrder(int id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            await _orderService.Delete(order);
            await LoadPage();
        }

    }
}
