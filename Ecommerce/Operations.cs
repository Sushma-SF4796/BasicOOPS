using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Ecommerce
{
    public static class Operations
    {
        public static List<CustomerDetails> customerList = new List<CustomerDetails>();
        public static List<ProductDetails> productList = new List<ProductDetails>();
        public static List<OrderDetails> orderList = new List<OrderDetails>();
        public static CustomerDetails loggedInCustomer;



        public static void MainMenu()
        {
            try
            {
                bool choice = true;
                do
                {
                    Console.WriteLine("************Main Menu*************");
                    Console.WriteLine("Select options\n 1.Registration\n 2.Login\n 3.Exit");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                // Console.WriteLine("Registration");
                                Registration();
                                break;
                            }
                        case 2:
                            {
                                // Console.WriteLine("Login");
                                Login();
                                break;
                            }
                        case 3:
                            {
                                choice = false;
                                break;
                            }
                    }

                } while (choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }
        public static void Registration()
        {
            try
            {
                Console.WriteLine("*******************Registration**********************");

                Console.WriteLine("Enter your name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your city");
                string city = Console.ReadLine();
                Console.WriteLine("Enter your phone number");
                long phoneNumber = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter your Mail ID");
                string mailID = Console.ReadLine();
                CustomerDetails customer = new CustomerDetails(name, city, phoneNumber, 0, mailID);
                Console.WriteLine("Your Registration ID : " + customer.CustomerID);
                customerList.Add(customer);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Login()
        {
            try
            {
                Console.WriteLine("**********************Login*********************");
                Console.WriteLine("Enter the customer ID");
                string customerID = Console.ReadLine().ToUpper();
                bool flag = true;
                foreach (CustomerDetails customer in customerList)
                {
                    if (customerID == customer.CustomerID)
                    {
                        Console.WriteLine("Login Successful");
                        loggedInCustomer = customer;
                        SubMenu();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Invalid login ID");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void SubMenu()
        {
            try
            {
                // Console.WriteLine("**********SubMenu************");
                bool choice = true;
                do
                {
                    Console.WriteLine("Select option \n 1.Purchase \n 2.Order History \n 3.Cancel \n 4.Balance Check \n 5.Recharge \n 6.Exit");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                Console.WriteLine("Purchase");
                                Purchase();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Order History");
                                OrderHistory();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Cancel");
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Balance Check");
                                BalanceCheck();
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Recharge");
                                Recharge();
                                break;
                            }
                        case 6:
                            {
                                choice = false;
                                break;
                            }
                    }





                } while (choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
       public static void CancelOrder(){
        try{
            Console.WriteLine("Cancel Order");
            bool flag=true;
            foreach (OrderDetails order in orderList)
                {
                    if (loggedInCustomer.CustomerID == order.CustomerID)
                    {
                        flag = false;
                        Console.WriteLine($"{order.OrderID} {order.ProductID} {order.TotalPrice} {order.PurchaseDate.ToString("dd/MM/yyyy", null)}");
                    }
                }
                if(flag){
                    System.Console.WriteLine("Ther is no user ID found");
                }
                //Get order ID from user
                //Check order ID present in list and check it belongs to current user and its status is ordered
                //show order cancelled succesfully
                else{
                    Console.WriteLine("Enter order id to be cancelled");
                    string orderID=Console.ReadLine().ToUpper();
                    bool orderFlag=true;
                    foreach(OrderDetails order in orderList){
                        if(loggedInCustomer.CustomerID==order.CustomerID && order.OrderStatus==OrderStatusDetails.Ordered && order.OrderID==orderID){
                            order.OrderStatus=OrderStatusDetails.Cancelled;
                            loggedInCustomer.WalletRecharge(order.TotalPrice);
                            foreach(ProductDetails product in productList){
                                if(product.ProductID==order.ProductID){
                                    product.Stock+=order.Quantity;
                                }
                                Console.WriteLine("Order CAncelled Succesfuly");
                                orderFlag=false;
                                }
                            }
                            if(orderFlag)
                            Console.WriteLine("Invalid Oder Id entered");

                        }
                    }
        }catch(Exception ex){
             Console.WriteLine(ex.StackTrace);
        }
       }
        public static void BalanceCheck()
        {
            try
            {
                Console.WriteLine($"Balance is : {loggedInCustomer.WalletBalance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void Recharge()
        {
            try
            {
                Console.WriteLine("Recharge");
                Console.WriteLine("Enter the amount to recharge");
                double amount = double.Parse(Console.ReadLine());
                if (amount > 0)
                {
                    loggedInCustomer.WalletRecharge(amount);
                }
                else
                {
                    Console.WriteLine("Invalid ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void OrderHistory()
        {
            try
            {
                Console.WriteLine("Order History");
                bool flag = true;
                foreach (OrderDetails order in orderList)
                {
                    if (loggedInCustomer.CustomerID == order.CustomerID)
                    {
                        flag = false;
                        Console.WriteLine($"{order.OrderID} {order.ProductID} {order.TotalPrice} {order.PurchaseDate.ToString("dd/MM/yyyy", null)}");
                    }
                }
                if(flag){
                    System.Console.WriteLine("invalid");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        public static void DefaultData()
        {
            try
            {

                customerList.Add(new CustomerDetails("Ravi", "Chennai", 9885858588, 50000, "ravi@mail.com"));
                customerList.Add(new CustomerDetails("Baskaran", "Chennai", 9888475757, 60000, "baskaran@mail.com"));


                productList.Add(new ProductDetails("Mobile(Samsung)", 10, 10000, 3));
                productList.Add(new ProductDetails("Tablet(Lenovo)", 5, 15000, 2));
                productList.Add(new ProductDetails("Camara(Sony)", 3, 20000, 4));
                productList.Add(new ProductDetails("iPhone", 5, 50000, 6));
                productList.Add(new ProductDetails("Laptop(Lenovo I3)", 3, 40000, 3));
                productList.Add(new ProductDetails("HeadPhone(Boat)", 5, 1000, 2));
                productList.Add(new ProductDetails("Speakers(Boat)", 4, 500, 2));


                orderList.Add(new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, OrderStatusDetails.Ordered));
                orderList.Add(new OrderDetails("CID3002", "PID2003", 40000, DateTime.Now, 2, OrderStatusDetails.Ordered));


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

            public static void Purchase()
            {
                //Show product list
                //Get product ID aand count
                //Check product ID and count is valid
                //calculate total amount and cheak the user have the amount to proceed purchase
                //reduce amount from user, reduce stock count
                //CreateComInterfaceFlags object and add to its list
                foreach (ProductDetails product in productList)
                {
                    Console.WriteLine(product.ProductID, product.ProductName, product.Stock, product.Price, product.ShippingDuration);
                }
                Console.WriteLine("Enter the Product ID");
                string productID = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter the quantity");
                int count = int.Parse(Console.ReadLine());
                bool productFlag = true;
                foreach (ProductDetails product in productList)
                {
                    if (product.ProductID == productID)
                    {
                        productFlag = false;
                        if (product.Stock >= count)
                        {
                            double totalAmount = product.Price * count;
                            if (totalAmount <= loggedInCustomer.WalletBalance)
                            {
                                OrderDetails order = new OrderDetails(loggedInCustomer.CustomerID, productID, totalAmount, DateTime.Now, count, OrderStatusDetails.Ordered);
                                orderList.Add(order);
                                Console.WriteLine($"Order placed succesfully\n Order ID {order.OrderID}");
                            }
                            else
                            {
                                Console.WriteLine("Insufficiat balance");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entered quantity not available");
                        }
                    }
                }
                if (productFlag)
                {
                    Console.WriteLine("Invalid");
                }
            }

        }
    }

