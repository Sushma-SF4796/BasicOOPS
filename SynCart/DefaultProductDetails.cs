using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
   
    public class DefaultProductDetails
    {
         private static int s_pruductID=2000;
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public int ShippingDuration { get; set; }

        public DefaultProductDetails(string name,int stock,int price,int shippingDuration){
            s_pruductID++;
            ProductName=name;
            Stock=stock;
            Price=price;
            ShippingDuration=shippingDuration;
            ProductID="PID"+s_pruductID;

        }
    }
}