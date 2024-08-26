using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class OrderDetails
    {
        static int s_orderID=1000;
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatusDetails OrderStatus { get; set; }

        public OrderDetails(string customerID, string productID, double totalPrice, DateTime purchaseDate, int quantity, OrderStatusDetails orderStatus){
            s_orderID++;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderStatus;
            OrderID="OID"+s_orderID;
        }



    }
}