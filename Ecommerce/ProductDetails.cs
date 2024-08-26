using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class ProductDetails
    {
        static int s_productID=2000;
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int ShippingDuration { get; set; }

        public ProductDetails(string productName, int stock, double price, int shippingDuration){
            ProductName=productName;
            Stock=stock;
            Price=price;
            ShippingDuration=shippingDuration;
            s_productID++;
            ProductID="PID"+s_productID;
        }



    }
}