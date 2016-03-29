using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegister;
using System.Collections.Generic;

namespace CashRegisterTest
{
    [TestClass]
    public class CashRegisterUnitTest
    {
        [TestMethod]
        public void addItemTest_addOneTime()
        {
            //Test for basic add Item
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            cashRegister.addItemToStore(item);
            Assert.IsTrue(cashRegister.store_item.Count == 1);
            Assert.IsTrue(cashRegister.store_item.Exists(findMug));
            Assert.IsFalse(cashRegister.store_item.Exists(findCandy));
            //Add item with same name
            cashRegister.addItemToStore(item);
            Assert.IsTrue(cashRegister.store_item.Count == 1);
        }

        [TestMethod]
        public void addItemTest_addItemWithRepeatedName()
        {
            //Test for basicc add Item
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            Item item2 = new Item("mug", 2, "pce");
            cashRegister.addItemToStore(item);
            cashRegister.addItemToStore(item2);
            Assert.IsTrue(cashRegister.store_item.Count == 1);
            Assert.IsTrue(cashRegister.store_item.Exists(findMug));
        }

        [TestMethod]
        public void removeItemTest_removeItemWithDifferentName()
        {
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            cashRegister.addItemToStore(item);
            Assert.IsTrue(cashRegister.store_item.Exists(findMug));
            Assert.IsTrue(cashRegister.store_item.Count == 1);
            cashRegister.removeItemToStore("candy");
            Assert.IsTrue(cashRegister.store_item.Count == 1);
        }

        [TestMethod]
        public void removeItemTest_removeItemWithSameName()
        {
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            cashRegister.addItemToStore(item);
            Assert.IsTrue(cashRegister.store_item.Exists(findMug));
            Assert.IsTrue(cashRegister.store_item.Count == 1);
            cashRegister.removeItemToStore("mug");
            Assert.IsTrue(cashRegister.store_item.Count == 0);
        }

        [TestMethod]
        public void editItemTest_editItemInStore()
        {
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            cashRegister.addItemToStore(item);
            Assert.IsTrue(cashRegister.store_item.Exists(findMug));
            Assert.IsTrue(cashRegister.store_item.Count == 1);
            cashRegister.editItem("mug", 2.444);
            Assert.IsTrue(cashRegister.store_item.Exists(findMugEdit));
            Assert.IsTrue(cashRegister.store_item.Count == 1);
        }

        [TestMethod]
        public void editItemTest_editItemNotInStore()
        {
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            cashRegister.addItemToStore(item);
            Assert.IsTrue(cashRegister.store_item.Exists(findMug));
            Assert.IsTrue(cashRegister.store_item.Count == 1);
            cashRegister.editItem("pasta", 2.444);
            Assert.IsTrue(cashRegister.store_item.Exists(findMug));
            Assert.IsTrue(cashRegister.store_item.Count == 1);
        }

        [TestMethod]
        public void addCouponTest_addOneWithCash()
        {
            Register cashRegister = new Register();
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
            Assert.IsFalse(cashRegister.coupons_list.Exists(findCoupon2));
        }

        [TestMethod]
        public void addCouponTest_addOneWithPercent()
        {
            Register cashRegister = new Register();
            Coupon coupon = new Coupon("coupon3", 15, 0.15, "percent");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon3));
            Assert.IsFalse(cashRegister.coupons_list.Exists(findCoupon2));
        }

        [TestMethod]
        public void addCouponTest_addOneWithLessValueCash()
        {
            Register cashRegister = new Register();
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
            Assert.IsFalse(cashRegister.coupons_list.Exists(findCoupon2));
            //Insert Coupon with less value
            Coupon coupon2 = new Coupon("coupon2", 6, 1, "cash");
            cashRegister.addCoupon(coupon2);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
        }

        [TestMethod]
        public void addCouponTest_addOneWithLessValuePercet()
        {
            Register cashRegister = new Register();
            Coupon coupon = new Coupon("coupon3", 15, 0.15, "percent");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon3));
            Assert.IsFalse(cashRegister.coupons_list.Exists(findCoupon2));

            Coupon coupon2 = new Coupon("coupon4", 16, 0.12, "percent");
            cashRegister.addCoupon(coupon2);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon3));
        }

        [TestMethod]
        public void addCouponTest_addOneWithSameName()
        {
            Register cashRegister = new Register();
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
            Assert.IsFalse(cashRegister.coupons_list.Exists(findCoupon2));

            Coupon coupon2 = new Coupon("coupon1", 10, 0.12, "percent");
            cashRegister.addCoupon(coupon2);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
        }

        [TestMethod]
        public void removeCouponTest_removeCouponWithDifferentName()
        {
            Register cashRegister = new Register();
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
            cashRegister.removeCoupon("coupon2");
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
        }

        [TestMethod]
        public void removeCouponTest_removeCouponWithSameName()
        {
            Register cashRegister = new Register();
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
            cashRegister.removeCoupon("coupon1");
            Assert.IsTrue(cashRegister.coupons_list.Count == 0);
        }

        [TestMethod]
        public void addBulkDiscountTest_addOne()
        {
            Register cashRegister = new Register();
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            Assert.IsTrue(cashRegister.discount_item.Exists(findMugBulkDiscount));
            Assert.IsFalse(cashRegister.discount_item.Exists(findPastaBulkDiscount));
        }

        [TestMethod]
        public void addBulkDiscountTest_addOneWithSameName()
        {
            Register cashRegister = new Register();
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            Assert.IsTrue(cashRegister.discount_item.Exists(findMugBulkDiscount));
            Assert.IsFalse(cashRegister.discount_item.Exists(findPastaBulkDiscount));
            BulkDiscount newBulkDiscount2 = new BulkDiscount("mug", 2, 1);
            cashRegister.addBulkDiscount(newBulkDiscount2);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
        }

        [TestMethod]
        public void addBulkDiscountTest_addOneWithDifferentName()
        {
            Register cashRegister = new Register();
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            Assert.IsTrue(cashRegister.discount_item.Exists(findMugBulkDiscount));
            Assert.IsFalse(cashRegister.discount_item.Exists(findPastaBulkDiscount));
            BulkDiscount newBulkDiscount2 = new BulkDiscount("pasta", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount2);
            Assert.IsTrue(cashRegister.discount_item.Count == 2);
            Assert.IsTrue(cashRegister.discount_item.Exists(findMugBulkDiscount));
            Assert.IsTrue(cashRegister.discount_item.Exists(findPastaBulkDiscount));
        }

        [TestMethod]
        public void removeBulkDiscountTest_withSameName()
        {
            Register cashRegister = new Register();
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            Assert.IsTrue(cashRegister.discount_item.Exists(findMugBulkDiscount));
            cashRegister.removeBulkDiscount("mug");
            Assert.IsTrue(cashRegister.discount_item.Count == 0);
        }

        [TestMethod]
        public void removeBulkDiscountTest_withDiffernetName()
        {
            Register cashRegister = new Register();
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            Assert.IsTrue(cashRegister.discount_item.Exists(findMugBulkDiscount));
            cashRegister.removeBulkDiscount("pasta");
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
        }

        [TestMethod]
        public void addCartItemTest_addOneItem()
        {
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            CartItem cart_item = new CartItem(item, 2);
            cashRegister.addCartItem(cart_item);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            Assert.IsTrue(cashRegister.cart_item.Exists(findMugPurchase));
            Assert.IsFalse(cashRegister.cart_item.Exists(findCandyPurchase));
        }

        [TestMethod]
        public void addCartItemTest_addOneItemWithSameName()
        {
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            CartItem cart_item = new CartItem(item, 2);
            cashRegister.addCartItem(cart_item);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            Assert.IsTrue(cashRegister.cart_item.Exists(findMugPurchase));
            Assert.IsFalse(cashRegister.cart_item.Exists(findCandyPurchase));
            cashRegister.addCartItem(cart_item);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            Assert.IsTrue(cashRegister.cart_item.Exists(findMugPurchase2));
        }

        [TestMethod]
        public void addCartItemTest_addOneWithDifferentName()
        {
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            CartItem cart_item = new CartItem(item, 2);
            cashRegister.addCartItem(cart_item);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            Assert.IsTrue(cashRegister.cart_item.Exists(findMugPurchase));
            Assert.IsFalse(cashRegister.cart_item.Exists(findCandyPurchase));
            Item item2 = new Item("pasta", 2, "pce");
            CartItem cart_item2 = new CartItem(item2, 1);
            cashRegister.addCartItem(cart_item2);
            Assert.IsTrue(cashRegister.cart_item.Count == 2);
            Assert.IsTrue(cashRegister.cart_item.Exists(findPastaPurchase));
        }

        [TestMethod]
        public void removeCartItemTest_removeOneWithoutRemoveFromList()
        {
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            CartItem cart_item = new CartItem(item, 2);
            cashRegister.addCartItem(cart_item);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            Assert.IsTrue(cashRegister.cart_item.Exists(findMugPurchase));
            Assert.IsFalse(cashRegister.cart_item.Exists(findCandyPurchase));
            cashRegister.removeCartItem("mug", 1);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            Assert.IsTrue(cashRegister.cart_item.Exists(findMugPurchase3));
        }

        [TestMethod]
        public void removeCartItemTest_removeItemRemoveFromList()
        {
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            CartItem cart_item = new CartItem(item, 2);
            cashRegister.addCartItem(cart_item);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            Assert.IsTrue(cashRegister.cart_item.Exists(findMugPurchase));
            Assert.IsFalse(cashRegister.cart_item.Exists(findCandyPurchase));
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            cashRegister.removeCartItem("mug", 2);
            Assert.IsTrue(cashRegister.cart_item.Count == 0);
        }

        [TestMethod]
        public void removeCartItemTest_removeItemWithDiffernetName()
        {
            Register cashRegister = new Register();
            Item item = new Item("mug", 5, "pce");
            CartItem cart_item = new CartItem(item, 2);
            cashRegister.addCartItem(cart_item);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            Assert.IsTrue(cashRegister.cart_item.Exists(findMugPurchase));
            Assert.IsFalse(cashRegister.cart_item.Exists(findCandyPurchase));
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            cashRegister.removeCartItem("pasta", 2);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            Assert.IsTrue(cashRegister.cart_item.Exists(findMugPurchase));
        }

        [TestMethod]
        public void calculateBulkDiscountTest_itemMatchedBulk()
        {
            Register cashRegister = new Register();
            //Add Item
            Item item = new Item("mug", 5, "pce");
            cashRegister.addItemToStore(item);
            Assert.IsTrue(cashRegister.store_item.Count == 1);
            Assert.IsTrue(cashRegister.store_item.Exists(findMug));
            Assert.IsFalse(cashRegister.store_item.Exists(findCandy));
            //Add bulkDiscount
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            Assert.IsTrue(cashRegister.discount_item.Exists(findMugBulkDiscount));
            Assert.IsFalse(cashRegister.discount_item.Exists(findPastaBulkDiscount));
            //Add Purchase Item
            CartItem cart_item = new CartItem(item, 2);
            cashRegister.addCartItem(cart_item);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            //calculateBulkDiscount
            Assert.AreEqual(5, newBulkDiscount.calculateBulkDiscount(cashRegister.cart_item));
        }

        [TestMethod]
        public void calculateBulkDiscountTest_noItemMatch()
        {
            Register cashRegister = new Register();
            //Add Item
            Item item = new Item("pasta", 2, "pce");
            cashRegister.addItemToStore(item);
            Assert.IsTrue(cashRegister.store_item.Count == 1);
            Assert.IsTrue(cashRegister.store_item.Exists(findPasta));
            Assert.IsFalse(cashRegister.store_item.Exists(findCandy));
            //Add bulkDiscount
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            Assert.IsTrue(cashRegister.discount_item.Exists(findMugBulkDiscount));
            Assert.IsFalse(cashRegister.discount_item.Exists(findPastaBulkDiscount));
            //Add Purchase Item
            CartItem cart_item = new CartItem(item, 1);
            cashRegister.addCartItem(cart_item);
            Assert.IsTrue(cashRegister.cart_item.Count == 1);
            //calculateBulkDiscount
            Assert.AreEqual(0, newBulkDiscount.calculateBulkDiscount(cashRegister.cart_item));
        }

        [TestMethod]
        public void checkOutTest_noDiscountAndCoupon()
        {
            Register cashRegister = new Register();
            //Add Item
            Item item1 = new Item("candy", 1.23, "weight");
            Item item2 = new Item("mug", 5, "pce");
            Item item3 = new Item("pasta", 2, "pce");
            cashRegister.addItemToStore(item1);            
            cashRegister.addItemToStore(item2);       
            cashRegister.addItemToStore(item3);
            Assert.IsTrue(cashRegister.store_item.Count == 3);
            //Add CartItem
            CartItem cart_item1 = new CartItem(item1, 0.5);
            CartItem cart_item2 = new CartItem(item2, 2);
            CartItem cart_item3 = new CartItem(item3, 1);
            cashRegister.addCartItem(cart_item1);
            cashRegister.addCartItem(cart_item2);
            cashRegister.addCartItem(cart_item3);
            Assert.IsTrue(cashRegister.cart_item.Count == 3);
            //Calculate subTotal when no discount and coupon
            Assert.AreEqual(12.62, cashRegister.checkOut(cashRegister.cart_item));
        }

        [TestMethod]
        public void checkOutTest_bulkDiscount()
        {
            Register cashRegister = new Register();
            //Add Item
            Item item1 = new Item("candy", 1.23, "weight");
            Item item2 = new Item("mug", 5, "pce");
            Item item3 = new Item("pasta", 2, "pce");
            cashRegister.addItemToStore(item1);
            cashRegister.addItemToStore(item2);
            cashRegister.addItemToStore(item3);
            Assert.IsTrue(cashRegister.store_item.Count == 3);
            //Add CartItem
            CartItem cart_item1 = new CartItem(item1, 0.5);
            CartItem cart_item2 = new CartItem(item2, 2);
            CartItem cart_item3 = new CartItem(item3, 1);
            cashRegister.addCartItem(cart_item1);
            cashRegister.addCartItem(cart_item2);
            cashRegister.addCartItem(cart_item3);
            Assert.IsTrue(cashRegister.cart_item.Count == 3);
            //Add BulkDiscount
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            //Calculate subTotal after bulkDicount
            Assert.AreEqual(7.62, cashRegister.checkOut(cashRegister.cart_item));
        }

        [TestMethod]
        public void checkOutTest_coupon()
        {
            Register cashRegister = new Register();
            //Add Item
            Item item1 = new Item("candy", 1.23, "weight");
            Item item2 = new Item("mug", 5, "pce");
            Item item3 = new Item("pasta", 2, "pce");
            cashRegister.addItemToStore(item1);
            cashRegister.addItemToStore(item2);
            cashRegister.addItemToStore(item3);
            Assert.IsTrue(cashRegister.store_item.Count == 3);
            //Add CartItem
            CartItem cart_item1 = new CartItem(item1, 0.5);
            CartItem cart_item2 = new CartItem(item2, 2);
            CartItem cart_item3 = new CartItem(item3, 1);
            cashRegister.addCartItem(cart_item1);
            cashRegister.addCartItem(cart_item2);
            cashRegister.addCartItem(cart_item3);
            Assert.IsTrue(cashRegister.cart_item.Count == 3);          
            //Add Coupon
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
            //Calculate subTotal after coupon1
            Assert.AreEqual(11.62, cashRegister.checkOut(cashRegister.cart_item));          
        }

        [TestMethod]
        public void checkOutTest_multipleCoupon()
        {
            Register cashRegister = new Register();
            //Add Item
            Item item1 = new Item("candy", 1.23, "weight");
            Item item2 = new Item("mug", 5, "pce");
            Item item3 = new Item("pasta", 2, "pce");
            cashRegister.addItemToStore(item1);
            cashRegister.addItemToStore(item2);
            cashRegister.addItemToStore(item3);
            Assert.IsTrue(cashRegister.store_item.Count == 3);
            //Add CartItem
            CartItem cart_item1 = new CartItem(item1, 0.5);
            CartItem cart_item2 = new CartItem(item2, 2);
            CartItem cart_item3 = new CartItem(item3, 1);
            cashRegister.addCartItem(cart_item1);
            cashRegister.addCartItem(cart_item2);
            cashRegister.addCartItem(cart_item3);
            Assert.IsTrue(cashRegister.cart_item.Count == 3);
            //Add Coupon
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
            Coupon coupon2 = new Coupon("coupon2", 5, 0.15, "percent");
            cashRegister.addCoupon(coupon2);
            Assert.IsTrue(cashRegister.coupons_list.Count == 2);
            Coupon coupon3 = new Coupon("coupon3", 5, 0.5, "percent");
            cashRegister.addCoupon(coupon3);
            Assert.IsTrue(cashRegister.coupons_list.Count == 3);
            //Calculate subTotal
            Assert.AreEqual(6.31, cashRegister.checkOut(cashRegister.cart_item));
        }

        [TestMethod]
        public void checkOutTest_oneCouponWithOneBulkDicount()
        {
            Register cashRegister = new Register();
            //Add Item
            Item item1 = new Item("candy", 1.23, "weight");
            Item item2 = new Item("mug", 5, "pce");
            Item item3 = new Item("pasta", 2, "pce");
            cashRegister.addItemToStore(item1);
            cashRegister.addItemToStore(item2);
            cashRegister.addItemToStore(item3);
            Assert.IsTrue(cashRegister.store_item.Count == 3);
            //Add CartItem
            CartItem cart_item1 = new CartItem(item1, 0.5);
            CartItem cart_item2 = new CartItem(item2, 2);
            CartItem cart_item3 = new CartItem(item3, 1);
            cashRegister.addCartItem(cart_item1);
            cashRegister.addCartItem(cart_item2);
            cashRegister.addCartItem(cart_item3);
            Assert.IsTrue(cashRegister.cart_item.Count == 3);
            //Add BulkDiscount
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            //Add Coupon
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
            //Calculate subTotal after coupon1
            Assert.AreEqual(6.62, cashRegister.checkOut(cashRegister.cart_item));
        }
        [TestMethod]
        public void checkOutTest_multipleCouponAndBulkDiscount()
        {
            Register cashRegister = new Register();
            //Add Item
            Item item1 = new Item("candy", 1.23, "weight");
            Item item2 = new Item("mug", 5, "pce");
            Item item3 = new Item("pasta", 2, "pce");
            cashRegister.addItemToStore(item1);
            cashRegister.addItemToStore(item2);
            cashRegister.addItemToStore(item3);
            Assert.IsTrue(cashRegister.store_item.Count == 3);
            //Add CartItem
            CartItem cart_item1 = new CartItem(item1, 0.5);
            CartItem cart_item2 = new CartItem(item2, 2);
            CartItem cart_item3 = new CartItem(item3, 1);
            cashRegister.addCartItem(cart_item1);
            cashRegister.addCartItem(cart_item2);
            cashRegister.addCartItem(cart_item3);
            Assert.IsTrue(cashRegister.cart_item.Count == 3);;
            //Add BulkDiscount
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            //Add Coupon
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Assert.IsTrue(cashRegister.coupons_list.Exists(findCoupon1));
            Coupon coupon2 = new Coupon("coupon2", 5, 0.15, "percent");
            cashRegister.addCoupon(coupon2);
            Assert.IsTrue(cashRegister.coupons_list.Count == 2);
            Coupon coupon3 = new Coupon("coupon3", 5, 0.5, "percent");
            cashRegister.addCoupon(coupon3);
            Assert.IsTrue(cashRegister.coupons_list.Count == 3);
            //Calculate subTotal
            Assert.AreEqual(3.81, cashRegister.checkOut(cashRegister.cart_item));
        }

        [TestMethod]
        public void ResetSystemTest()
        {
            Register cashRegister = new Register();
            //Add Item
            Item item1 = new Item("candy", 1.23, "weight");
            Item item2 = new Item("mug", 5, "pce");
            Item item3 = new Item("pasta", 2, "pce");
            cashRegister.addItemToStore(item1);
            cashRegister.addItemToStore(item2);
            cashRegister.addItemToStore(item3);
            Assert.IsTrue(cashRegister.store_item.Count == 3);
            //Add CartItem
            CartItem cart_item1 = new CartItem(item1, 0.5);
            CartItem cart_item2 = new CartItem(item2, 2);
            CartItem cart_item3 = new CartItem(item3, 1);
            cashRegister.addCartItem(cart_item1);
            cashRegister.addCartItem(cart_item2);
            cashRegister.addCartItem(cart_item3);
            Assert.IsTrue(cashRegister.cart_item.Count == 3);
            //Add BulkDiscount
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            //Add Coupon
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Coupon coupon2 = new Coupon("coupon2", 5, 0.15, "percent");
            cashRegister.addCoupon(coupon2);
            Assert.IsTrue(cashRegister.coupons_list.Count == 2);
            Coupon coupon3 = new Coupon("coupon3", 5, 0.5, "percent");
            cashRegister.addCoupon(coupon3);
            Assert.IsTrue(cashRegister.coupons_list.Count == 3);
            //Calculate subTotal
            cashRegister.resetSystem();
            Assert.IsTrue(cashRegister.store_item.Count == 0);
            Assert.IsTrue(cashRegister.cart_item.Count == 0);
            Assert.IsTrue(cashRegister.coupons_list.Count == 0);
            Assert.IsTrue(cashRegister.discount_item.Count == 0);
            Assert.AreEqual(0, cashRegister.checkOut(cashRegister.cart_item));
        }

        [TestMethod]
        public void ResetCartTest()
        {
            Register cashRegister = new Register();
            //Add Item
            Item item1 = new Item("candy", 1.23, "weight");
            Item item2 = new Item("mug", 5, "pce");
            Item item3 = new Item("pasta", 2, "pce");
            cashRegister.addItemToStore(item1);
            cashRegister.addItemToStore(item2);
            cashRegister.addItemToStore(item3);
            Assert.IsTrue(cashRegister.store_item.Count == 3);
            //Add CartItem
            CartItem cart_item1 = new CartItem(item1, 0.5);
            CartItem cart_item2 = new CartItem(item2, 2);
            CartItem cart_item3 = new CartItem(item3, 1);
            cashRegister.addCartItem(cart_item1);
            cashRegister.addCartItem(cart_item2);
            cashRegister.addCartItem(cart_item3);
            Assert.IsTrue(cashRegister.cart_item.Count == 3);
            //Add BulkDiscount
            BulkDiscount newBulkDiscount = new BulkDiscount("mug", 1, 1);
            cashRegister.addBulkDiscount(newBulkDiscount);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            //Add Coupon
            Coupon coupon = new Coupon("coupon1", 5, 1, "cash");
            cashRegister.addCoupon(coupon);
            Assert.IsTrue(cashRegister.coupons_list.Count == 1);
            Coupon coupon2 = new Coupon("coupon2", 5, 0.15, "percent");
            cashRegister.addCoupon(coupon2);
            Assert.IsTrue(cashRegister.coupons_list.Count == 2);
            Coupon coupon3 = new Coupon("coupon3", 5, 0.5, "percent");
            cashRegister.addCoupon(coupon3);
            Assert.IsTrue(cashRegister.coupons_list.Count == 3);
            //Calculate subTotal
            cashRegister.resetCart();
            Assert.IsTrue(cashRegister.cart_item.Count == 0);
            Assert.IsTrue(cashRegister.coupons_list.Count == 3);
            Assert.IsTrue(cashRegister.discount_item.Count == 1);
            Assert.IsTrue(cashRegister.store_item.Count == 3);
            Assert.AreEqual(0, cashRegister.checkOut(cashRegister.cart_item));
        }

        private Boolean findMug(Item item)
        {
            if (item.name == "mug" && item.unit_price == 5 && item.unit == "pce")
                return true;
            else
                return false;
        }

        private Boolean findPasta(Item item)
        {
            if (item.name == "pasta" && item.unit_price == 2 && item.unit == "pce")
                return true;
            else
                return false;
        }

        private Boolean findCandy(Item item)
        {
            if (item.name == "candy" && item.unit_price == 1.23 && item.unit == "weight")
                return true;
            else
                return false;
        }

        private Boolean findMugEdit(Item item)
        {
            if (item.name == "mug" && item.unit_price == 2.44 && item.unit == "pce")
                return true;
            else
                return false;
        }

        private Boolean findCoupon1(Coupon coupon)
        {
            if (coupon.name == "coupon1" && coupon.min_subTotal == 5 && coupon.discountAmount == 1 && coupon.unit == "cash")
                return true;
            else
                return false;
        }

        private Boolean findCoupon2(Coupon coupon)
        {
            if (coupon.name == "coupon2" && coupon.min_subTotal == 10 && coupon.discountAmount == 2 && coupon.unit == "cash")
                return true;
            else
                return false;
        }

        private Boolean findCoupon3(Coupon coupon)
        {
            if (coupon.name == "coupon3" && coupon.min_subTotal == 15 && coupon.discountAmount == 0.15 && coupon.unit == "percent")
                return true;
            else
                return false;
        }

        private Boolean findMugBulkDiscount(IDiscount bulkDiscount)
        {
            if (bulkDiscount.item_name == "mug" && bulkDiscount.min_quantity == 1 && bulkDiscount.discount_amount == 1)
                return true;
            else
                return false;
        }

        private Boolean findPastaBulkDiscount(IDiscount bulkDiscount)
        {
            if (bulkDiscount.item_name == "pasta" && bulkDiscount.min_quantity == 1 && bulkDiscount.discount_amount == 1)
                return true;
            else
                return false;
        }

        private bool findMugPurchase(CartItem cart_item)
        {
            if (cart_item.item.name == "mug" && cart_item.item.unit_price == 5 && cart_item.item.unit == "pce" && cart_item.amount == 2)
                return true;
            else
                return false;
        }

        private bool findMugPurchase2(CartItem cart_item)
        {
            if (cart_item.item.name == "mug" && cart_item.item.unit_price == 5 && cart_item.item.unit == "pce" && cart_item.amount == 4)
                return true;
            else
                return false;
        }

        private bool findMugPurchase3(CartItem cart_item)
        {
            if (cart_item.item.name == "mug" && cart_item.item.unit_price == 5 && cart_item.item.unit == "pce" && cart_item.amount == 1)
                return true;
            else
                return false;
        }

        private bool findPastaPurchase(CartItem cart_item)
        {
            if (cart_item.item.name == "pasta" && cart_item.item.unit_price == 2 && cart_item.item.unit == "pce" && cart_item.amount == 1)
                return true;
            else
                return false;
        }

        private bool findCandyPurchase(CartItem cart_item)
        {
            if (cart_item.item.name == "candy" && cart_item.item.unit_price == 1.23 && cart_item.item.unit == "weight" && cart_item.amount == 0.5)
                return true;
            else
                return false;
        }
    }
}
