using System;
using System.Collections.Generic;
namespace SynCart;
public class Program
{
    public static void Main(string[] args)
    {
        bool stop = true;
        List<CustomerDetails> customerList = new List<CustomerDetails>();
        List<DefaultOrderDetails> defaultOrderDetailsList= new List<DefaultOrderDetails>();
        CustomerDetails detail;
        DefaultOrderDetails obj2;
        do
        {
            Console.WriteLine("1.Customer Registration");
            Console.WriteLine("2.Login");
            Console.WriteLine("3.Exit");
            Console.WriteLine("Enter the choice");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        Console.WriteLine("Enter the name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter your city");
                        string city = Console.ReadLine();
                        Console.WriteLine("Enter your mobile number");
                        long phoneNumber = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the wallet balance");
                        double balance = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter your email ID");
                        string mailID = Console.ReadLine();
                        detail = new CustomerDetails(name, city, phoneNumber, balance, mailID);
                        customerList.Add(detail);
                        Console.WriteLine(detail.CustomerID);
                        break;
                    }
                case 2:
                    {
                        DefaultProductDetails obj;

                        List<DefaultProductDetails> defaultProductList = new List<DefaultProductDetails>();
                        
                        obj= new DefaultProductDetails("Mobile(Samsung)",10,10000,3);
                        
                        defaultProductList.Add(obj);

                        obj= new DefaultProductDetails("Tablet(Lenovo)",5,15000,2);
                        defaultProductList.Add(obj);

                        obj= new DefaultProductDetails("Camera(Sony)",3,20000,4);
                        defaultProductList.Add(obj);

                        obj= new DefaultProductDetails("iPhone",5,50000,6);
                        defaultProductList.Add(obj);

                        obj= new DefaultProductDetails("Laptop(Lenovo 13)",3,40000,3);
                        defaultProductList.Add(obj);

                        obj= new DefaultProductDetails("HeadPhone(Boat)",5,1000,2);
                        defaultProductList.Add(obj);

                        obj= new DefaultProductDetails("Speakers(Boat)",4,500,2);
                        defaultProductList.Add(obj);
                        
                        bool stop1 = true;
                        bool present = true;
                        Console.WriteLine("Enter the customer ID");
                        string validate = Console.ReadLine();
                        foreach (CustomerDetails value in customerList)
                        {
                            if (value.CustomerID == validate)
                            {
                                present = false;
                                do
                                {
                                    Console.WriteLine("1.Purchase");
                                    Console.WriteLine("2.Order History");
                                    Console.WriteLine("3.CancelOrder");
                                    Console.WriteLine("4.Wallet Balancee");
                                    Console.WriteLine("5.Wallet Recharge");
                                    Console.WriteLine("6.Exit");
                                    Console.WriteLine("Enter your choice");
                                    int option1 = int.Parse(Console.ReadLine());
                                    switch (option1)
                                    {
                                        case 1:
                                            {
                                                Console.WriteLine("ProductID    ProductName     Stock   Price   ShippingDuration");
                                                foreach(DefaultProductDetails detail1 in defaultProductList){
                                                    Console.WriteLine(detail1.ProductID+"   "+detail1.ProductName+"    "+detail1.Stock+"    "+detail1.Price+"   "+detail1.ShippingDuration+"    "+detail1.);
                                                }
                                                int totalAmount=0;
                                                Console.WriteLine("Enter the ProductID");
                                                string iD=Console.ReadLine();
                                                bool present1=true;
                                                foreach(DefaultProductDetails detail1 in defaultProductList){
                                                    if(detail1.ProductID==iD){
                                                        present1 =false;
                                                        Console.WriteLine("Enter the count you wishes to purchase");
                                                        int stock1=int.Parse(Console.ReadLine());
                                                        if(stock1<detail1.Stock){
                                                            Console.WriteLine("Required count not avalilable. Current availability is detail1.Stock");
                                                            break;
                                                        }
                                                        else{
                                                            totalAmount=(stock1*detail1.Price)+50;
                                                        }
                                                        if(value.Balance>=totalAmount){
                                                            value.Balance=value.Balance-totalAmount;
                                                            detail1.Stock=detail1.Stock-stock1;
                                                            obj2=new DefaultOrderDetails(value.CustomerID, obj.ProductID,totalAmount,DateTime.Now, stock1,Enum.Parse<OrderStatusDetail>("Ordered",true));
                                                           




                                                            DateTime deliveryDate=obj2.PurchaseDate.AddDays(detail1.ShippingDuration);
                                                            Console.WriteLine("Order placed successfully. Your order will be delivered on "+deliveryDate);
 
                                                        }
                                                        else{
                                                            Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do the purchase again.");
                                                            break;
                                                        }
                                                    }
                                                }
                                                if(present1)
                                                Console.WriteLine("Invalid ProductID");
                                                break;
                                            }
                                            case 2:
                                            {
                                                foreach(DefaultOrderDetails obj1 in defaultOrderDetailsList){
                                                    if(validate==obj1.CustomerID){
                                                        Console.WriteLine("Order ID : "+obj1.OrderID);
                                                        Console.WriteLine("Customer ID : "+obj1.CustomerID);
                                                        Console.WriteLine("Product ID : "+obj1.ProductID);
                                                        Console.WriteLine("Total Price : "+obj1.TotalPrice);
                                                        Console.WriteLine("Purchase Date : "+obj1.PurchaseDate);
                                                        Console.WriteLine("Qunatity : "+obj1.Quantity);
                                                        Console.WriteLine("Order Status : "+obj1.OrderStatus);
                                                        
                                                    }
                                                }
                                                break;
                                            }
                                    }
                                } while (stop1);
                            }
                            
                        }
                        if(present)
                        Console.WriteLine("Invalid customerID");



                    }
            }
        } while (stop);
    }
}