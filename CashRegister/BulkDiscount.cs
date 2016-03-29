using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    //Eg. Buy 2 get 1 free, Buy 1 get 1 free
    public class BulkDiscount : IDiscount
    {

        private int _min_quantity;
        private String _item_name;
        private int _discount_amount;

        public BulkDiscount(String item_name, int min_quantity, int discount_amount)
        {
            _min_quantity = min_quantity;
            _item_name = item_name;
            _discount_amount = discount_amount;
        }
        /*
         Required:
             Calculate the total discount amount from the pruchased_item
         */
        public double calculateBulkDiscount(List<CartItem> purchased_item)
        {
            double discount_subTotal = 0;

            for(int i = 0; i < purchased_item.Count; i++)
            {
                if (purchased_item[i].item.name == _item_name && purchased_item[i].amount > min_quantity)
                {
                    discount_subTotal = purchased_item[i].item.unit_price * discount_amount;
                }
            }
            return discount_subTotal;
        }

        public String item_name
        {
            get { return _item_name; }
        }

        public int min_quantity
        {
            get { return _min_quantity; }
        }

        public int discount_amount
        {
            get { return _discount_amount; }
        }
    }
}
