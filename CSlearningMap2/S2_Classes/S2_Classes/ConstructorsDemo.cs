//using System.Collections.Generic;
//using System;
//using static global::S2_Classes.Customer;

//namespace S2_Classes
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var customer = new Customer();

//            customer.Id = 1;
//            customer.Name = "John";

//            var order = new Order();
//            customer.Orders.Add(order);

//            Console.WriteLine(customer.Id);
//            Console.WriteLine(customer.Name);

//        }
//    }
//}
//public class Customer
//{
//    public int Id; 
//    public string Name;
//    public List<Order> Orders;

//    public Customer()
//    {
//        Orders = new List<Order>();
//    }
//    public Customer(int id) 
//        : this()
//    {
//        this.Id = id;

//    }

//    public Customer(int id, string name)
//        : this(id)
//    {
//        this.Id = id;
//        this.Name = name;
//    }

//    public class Order
//    {

//    }
//}