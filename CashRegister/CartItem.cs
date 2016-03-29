using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class CartItem
    {
        private Item _item;
        private double _amount;

        public CartItem(Item item, double amount)
        {
            _item = item;

            if (item.unit == "weight")  
                _amount = Math.Round(amount, 2);
            else if (item.unit == "pce")
                _amount = Math.Round(amount);
        }

        public Item item
        {
            get { return _item; }
        }

        public double amount
        {
            get { return _amount; }

            set 
            {
                if (_item.unit == "weight")
                    _amount = Math.Round(value, 2);
                else if (_item.unit == "pce")
                    _amount = Math.Round(value);
            }
        }
    }
}
