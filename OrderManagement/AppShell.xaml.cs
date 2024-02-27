using OrderManagement.Views.Account;
using OrderManagement.Views.Order;

namespace OrderManagement
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute($"{nameof(Login)}/{nameof(Orders)}", typeof(Orders));
            Routing.RegisterRoute($"{nameof(Login)}/{nameof(Orders)}/{nameof(ManageOrder)}", typeof(ManageOrder));
        }
    }
}
