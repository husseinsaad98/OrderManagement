using OrderManagement.ViewModels;

namespace OrderManagement.Views.Order;

public partial class Orders : ContentPage
{
    public Orders(OrdersViewModel ordersViewModel)
    {
        InitializeComponent();
        BindingContext = ordersViewModel;
    }
}