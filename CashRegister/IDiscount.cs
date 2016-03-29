using System.Collections.Generic;

namespace CashRegister
{
    //Outline other type of Discount in this interface
    public interface IDiscount
    {
        string item_name { get; }
        int min_quantity { get; }
        int discount_amount { get; }

        double calculateBulkDiscount(List<CartItem> purchased_item);
    }
}