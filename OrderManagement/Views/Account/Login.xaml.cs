using OrderManagement.ViewModels;

namespace OrderManagement.Views.Account;

public partial class Login : ContentPage
{
	public Login(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext = loginViewModel;
	}
}