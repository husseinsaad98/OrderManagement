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
    [QueryProperty("OrderId", "OrderId")]
    public partial class ManageOrderViewModel : ObservableObject
    {
        #region Fields

        private readonly ClientService _clientService;
        private readonly ItemService _itemService;
        private readonly OrderService _orderService;
        private readonly User _user = JsonConvert.DeserializeObject<User>(Preferences.Get("user", null));

        private List<OrderItem> _orderItems;

        [ObservableProperty]
        ObservableCollection<Client> _clients = new();

        [ObservableProperty]
        ObservableCollection<OrderItemView> _orderItemsView = new();

        [ObservableProperty]
        ObservableCollection<Item> _items = new();

        [ObservableProperty]
        Client _client = new();

        [ObservableProperty]
        Binding _name;

        [ObservableProperty]
        int _orderId;

        [ObservableProperty]
        DateTime _date = new();


        #endregion
        public ManageOrderViewModel(ClientService clientService, ItemService itemService, OrderService orderService)
        {
            _clientService = clientService;
            _itemService = itemService;
            _orderService = orderService;
        }
        [RelayCommand]
        private async Task LoadPage()
        {
            Clients = new ObservableCollection<Client>(await _clientService.GetClients());

            Items = new ObservableCollection<Item>(await _itemService.GetItems());

            if (OrderId > 0)
            {

                var order = await _orderService.GetOrder(OrderId);

                //populating date
                Date = order.OrderDate;

                //populating select client
                Client = Clients.FirstOrDefault(x => x.Id == order.ClientId);

                _orderItems = await _clientService.GetOrderItems(OrderId);



                foreach (var item in _orderItems)
                {
                    OrderItemsView.Add(new OrderItemView()
                    {
                        OrderItem = new Item()
                        {
                            Id = item.ItemId,
                            Name = Items.FirstOrDefault(x => x.Id == item.ItemId).Name
                        },
                        Quantity = item.Quantity
                    });
                }
            }
        }
        [RelayCommand]
        private async Task Submit()
        {

            // order ammount should be an equation quantity * price appended to all items
            decimal orderAmount = 21;
            var order = new Order()
            {
                ClientId = Client.Id,
                CreatedByUserId = _user.Id,
                OrderAmount = orderAmount,
                OrderDate = DateTime.Now,
            };

            if (OrderId > 0)
                await UpdateOrder(order);

            else await CreateOrder(order);

            await Shell.Current.GoToAsync($"//{nameof(Login)}/{nameof(Orders)}");
        }
        private async Task CreateOrder(Order order)
        {
            var newOrder = await _orderService.CreateOrder(order);

            foreach (var item in OrderItemsView)
            {
                var result = await _orderService.AddOrderItem(new OrderItem()
                {
                    ItemId = item.OrderItem.Id,
                    OrderId = newOrder.Id,
                    Quantity = item.Quantity,
                });
            }
        }
        private async Task UpdateOrder(Order order)
        {
            order.Id = OrderId;
            var newOrder = await _orderService.Update(order);

            foreach (var item in OrderItemsView)
            {
                if (_orderItems.FirstOrDefault(x => x.ItemId == item.OrderItem.Id) == null)

                    await _orderService.AddOrderItem(new OrderItem()
                    {
                        ItemId = item.OrderItem.Id,
                        OrderId = newOrder.Id,
                        Quantity = item.Quantity,
                    });

                else
                    await _orderService.UpdateOrderItem(new OrderItem()
                    {
                        ItemId = item.OrderItem.Id,
                        OrderId = newOrder.Id,
                        Quantity = item.Quantity,
                    });
            }
        }
        [RelayCommand]
        private void AddOrderItem()
        {
            OrderItemsView.Add(new OrderItemView()
            {

            });
        }


    }
}
