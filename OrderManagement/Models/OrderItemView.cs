using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Models
{
    public class OrderItemView : INotifyPropertyChanged
    {
        private Item _orderItem;
        public Item OrderItem
        {
            get { return _orderItem; }
            set
            {
                if (value == null)
                    return;
                if (_orderItem != value)
                {
                    _orderItem = value;
                    OnPropertyChanged(nameof(OrderItem));
                }
            }
        }
        public int Quantity { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
