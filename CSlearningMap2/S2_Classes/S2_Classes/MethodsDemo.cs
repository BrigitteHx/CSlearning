﻿//using System;

//namespace S2_Classes
//{
//    class Program
//        {
//            static void Main(string[] args)
//            {
                
//            }

//            static void UseOutModifier()
//            {
//                try
//                {
//                    var num = int.Parse("abc");
//                }
//                catch (Exception)
//                {
//                    Console.WriteLine("Conversion failed.");
//                }


//                int number;
//                var result = int.TryParse("abc", out number);
//                if (result)
//                    Console.WriteLine(number);
//                else
//                    Console.WriteLine("Conversion failed.");

//            }

//            static void UseParams()
//            {
//                var calculator = new Calculator();
//                Console.WriteLine(calculator.Add(1, 2));
//                Console.WriteLine(calculator.Add(1, 2, 3));
//                Console.WriteLine(calculator.Add(1, 2, 3, 4));
//                Console.WriteLine(calculator.Add(new int[] { 1, 2, 3, 4, 5 }));
//            }

//            static void UsePoints()
//            {
//                try
//                {
//                    var point = new Point(10, 20);
//                    point.Move(null);
//                    Console.WriteLine("Point is at ({0}, {1})", point.X, point.Y);

//                    point.Move(100, 200);
//                    Console.WriteLine("Point is at ({0}, {1})", point.X, point.Y);
//                }
//                catch (Exception)
//                {
//                    Console.WriteLine("An unexpected error occured.");
//                }
//            }

//            public class Point
//            {
//                public int X;
//                public int Y;

//                public Point(int x, int y)
//                {
//                    this.X = x;
//                    this.Y = y;
//                }

//                public void Move(int x, int y)
//                {
//                    this.X = x;
//                    this.Y = y;
//                }

//                public void Move(Point newLocation)
//                {
//                    if (newLocation == null)
//                        throw new ArgumentNullException("newLocation");

//                    Move(newLocation.X, newLocation.Y);
//                }
//            }

//            public class Calculator
//            {
//                public int Add(params int[] numbers)
//                {
//                    var sum = 0;
//                    foreach (var number in numbers)
//                    {
//                        sum += number;
//                    }

//                    return sum;
//                }
//            }
//    }


//}

