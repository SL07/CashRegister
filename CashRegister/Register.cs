using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class Register
    {
        public List<Item> store_item = new List<Item>();
        public List<CartItem> cart_item = new List<CartItem>();
        public List<Coupon> coupons_list = new List<Coupon>();
        public List<IDiscount> discount_item = new List<IDiscount>();

        public Register()
        {
        }

        /*
        Required:
            Add an Item to store_item
        Additional: 
            Check if the Item with same name already existed in store_item
                If Item with same name already existed, do not add to store_item
                Else add to store_item
        */
        public List<Item> addItemToStore(Item item)
        {
            Boolean nameCheck = false;

            for (int i = 0; i < store_item.Count; i++)
            {
                if (store_item[i].name == item.name)
                    nameCheck = true;
            }

            if(nameCheck == false)
                store_item.Add(item);

            return store_item;
        }

        /*
        Required:
            Remove all item with the given name from store_item
        */
        public List<Item> removeItemToStore(String item_name)
        {
            for (int i = 0; i < store_item.Count; i++){
                if (item_name == store_item[i].name)
                    store_item.RemoveAt(i);
            }

            return store_item;
        }

        /*
        Required:
            Change the price for a given Item in store_item 
                If item exist, modifty Item unit_price
                Else no action
        */
        public List<Item> editItem(String item_name, double unit_price)
        {
            for(int i = 0; i < store_item.Count; i++)
            {
                if(item_name == store_item[i].name)
                {
                    store_item[i].unit_price = unit_price;
                }
            }

            return store_item;
        }

        /*
        Required:
            Add coupon to coupon_list
        Additional: 
            Check if the Coupon with same name already existed in coupon_list
                If Coupon with same name already existed, do not add to coupon_list
                Else add to coupon_item
            Check if the new Coupon value are higher than existed Coupon in coupon_list
                If new Coupon value are higher, add to coupon_list
                Else do not add to coupon_list
        */
        public List<Coupon> addCoupon(Coupon coupon)
        {
            Boolean nameCheck = false;
            Boolean valueCheck = false;
            for (int i = 0; i < coupons_list.Count; i++)
            {
                if (coupon.name == coupons_list[i].name)
                    nameCheck = true;

                //Check value for for discount with same unit 
                if ((coupon.unit == "cash" && coupons_list[i].unit == "cash") || (coupon.unit == "percent" && coupons_list[i].unit == "percent"))
                {
                    if ((coupon.min_subTotal > coupons_list[i].min_subTotal) && (coupon.discountAmount <= coupons_list[i].discountAmount))
                        valueCheck = true;
                }
            }

            if(nameCheck == false && valueCheck == false)
                coupons_list.Add(coupon);

            return coupons_list;
        }

        /*
        Required:
            Remove all Coupon with the given name from coupon_list
        */
        public List<Coupon> removeCoupon(String coupon_name)
        {
            for (int i = 0; i < coupons_list.Count; i++)
            {
                if (coupon_name == coupons_list[i].name)
                    coupons_list.RemoveAt(i);
            }

            return coupons_list;
        }

        /*
        Required:
            Add BulkDiscount to discount_list
        Additional: 
            Check if the Item with already have a BulkDiscount in discount_list
                If Item with same name already existed, do not add to discount_list
                Else add to discount_list
        */
        public List<IDiscount> addBulkDiscount(BulkDiscount bulkDiscount)
        {
            Boolean nameCheck = false;
            for (int i = 0; i < discount_item.Count; i++)
            {
                if (bulkDiscount.item_name == discount_item[i].item_name)
                    nameCheck = true;
            }

            if(nameCheck == false)
                discount_item.Add(bulkDiscount);

            return discount_item;
        }

        /*
        Required:
            Remove all Discount with the given name from discount_list
        */
        public List<IDiscount> removeBulkDiscount(String bulkDiscount_name)
        {
            for (int i = 0; i < discount_item.Count; i++)
            {
                if (bulkDiscount_name == discount_item[i].item_name)
                    discount_item.RemoveAt(i);
            }

            return discount_item;
        }

        /*
        Required:
            Add CartItem to cart_item
        Additional: 
            Check if the Item in CartItem already existed in the cart_item
                If Item already existed, add CartItem amount
                Else add CartItem to cart_item
        */
        public List<CartItem> addCartItem(CartItem cartItem)
        {
            Boolean nameCheck = false;
            for (int i = 0; i < cart_item.Count; i++)
            {
                if(cartItem.item.name == cart_item[i].item.name)
                {
                    cart_item[i].amount += cartItem.amount;
                    nameCheck = true;
                }
            }

            if (nameCheck == false)
                cart_item.Add(cartItem);

            return cart_item;
        }

        /*
         Required:
             Remove CartItem from cart_item with the CartItem name and amount
             If given amount > cart_item amount, remove from cart_item
             Else modify cart_item amount
         */
        public List<CartItem> removeCartItem(String cartItem_name, double remove_amount)
        {
            for(int i = 0; i < cart_item.Count; i++)
            {
                if (cartItem_name == cart_item[i].item.name)
                {                
                    if(cart_item[i].amount > remove_amount)
                    {
                        cart_item[i].amount -= remove_amount;
                    }else
                        cart_item.RemoveAt(i);
                }
            }
            return cart_item;
        }

        /*
         Required:
             Calculate the subTotal of all CartItem in cart_list
             Apply BulkDiscount if matched to CartItem name and amount
             Apply Coupon discount and find the best value coupon for user
         */
        public double checkOut(List<CartItem> checkOutList)
        {
            double subTotal = 0;
            double max_discount = 0;

            for (int i = 0; i < checkOutList.Count; i++)
            {
                subTotal += (checkOutList[i].item.unit_price * checkOutList[i].amount);
            }

            for (int j = 0; j < discount_item.Count; j++)
            {
                subTotal -= discount_item[j].calculateBulkDiscount(cart_item);
            }

            //Check which coupon has best value to client
            for (int k = 0; k < coupons_list.Count; k++)
            {
                if (coupons_list[k].min_subTotal <= subTotal)
                {
                    if(coupons_list[k].unit == "percent")
                    {
                        if (max_discount < (subTotal * coupons_list[k].discountAmount))
                            max_discount = subTotal * coupons_list[k].discountAmount;
                    }else if(coupons_list[k].unit == "cash")
                    {
                        if (max_discount < coupons_list[k].discountAmount)
                        {
                            max_discount = coupons_list[k].discountAmount;
                        }
                    }
                }
            }
            
            return Math.Round(subTotal - max_discount, 2);
        }

        /*
        Required:
            Reset the whole system.
        */
        public void resetSystem()
        {
            store_item.Clear();
            cart_item.Clear();
            coupons_list.Clear();
            discount_item.Clear();
        }

        /*
        Required:
            Reset the whole system.
        */
        public void resetCart()
        {
            cart_item.Clear();
        }
    }
}
