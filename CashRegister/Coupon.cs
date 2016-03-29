using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class Coupon
    {
        private string _name;
        private double _min_subTotoal;
        private double _discount_amount;
        private string _unit; // percentage or cash

        public Coupon(String name, double min_subTotal, double discount_amount, string unit)
        {
            _name = name;
            _min_subTotoal = Math.Round(min_subTotal, 2);
            _discount_amount = Math.Round(discount_amount, 2);
            _unit = unit;
        }

        public String name
        {
            get { return _name; }
        }

        public double min_subTotal
        {
            get { return _min_subTotoal; }
        }

        public double discountAmount
        {
            get { return _discount_amount; }
        }

        public String unit
        {
            get { return _unit; }
        }
    }
}
