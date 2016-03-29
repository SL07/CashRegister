using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class Item
    {
        private string _item_name;
        private double _item_unit_price;
        private string _unit; //Unit: pce or weight

        public Item(String item_name, double item_unit_price, String unit)
        {
            _item_name = item_name;
            _item_unit_price = Math.Round(item_unit_price, 2);
            _unit = unit;
        }

        public String name
        {
            get { return _item_name; }
        }

        public double unit_price
        {
            get { return _item_unit_price;}
            set { _item_unit_price = Math.Round(value, 2); }
        }

        public String unit
        {
            get { return _unit; }
        }
    }
}
