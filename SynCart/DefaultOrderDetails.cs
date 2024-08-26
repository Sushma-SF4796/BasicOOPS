using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class DefaultOrderDetails
    {
        public static int s_orderID=1000;
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public int TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatusDetail OrderStatus { get; set; }

        public DefaultOrderDetails(string customerID, string productID, int totalPrice, DateTime purchaseDate, int quantity,OrderStatusDetail orderstatus ){
            s_orderID++;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=orderstatus;
            OrderID="OID"+s_orderID;
        }
    }
}