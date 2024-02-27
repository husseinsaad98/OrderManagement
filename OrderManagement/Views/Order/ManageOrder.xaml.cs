using OrderManagement.ViewModels;

namespace OrderManagement.Views.Order;

public partial class ManageOrder : ContentPage
{
    public ManageOrder(ManageOrderViewModel manageOrderViewModel)
    {
        InitializeComponent();
        BindingContext = manageOrderViewModel;
    }
}