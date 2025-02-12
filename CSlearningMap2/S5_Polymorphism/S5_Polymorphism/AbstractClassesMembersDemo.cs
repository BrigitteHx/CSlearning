//using System.Drawing;

//namespace S5_Polymorphism
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //            var shape = new Shape();


//            var circle = new Circle();
//            circle.Draw();

//            var rectangle = new Rectangle();
//            rectangle.Draw();
//        }
//    }

//    public class Circle : Shape
//    {
//        public override void Draw()
//        {
//            Console.WriteLine("Draw a circle");
//        }
//    }

//    public class Rectangle : Shape
//    {
//        public override void Draw()
//        {
//            Console.WriteLine("Draw a rectangle");
//        }
//    }

//    public abstract class Shape
//    {
//        public int Width { get; set; }
//        public int Height { get; set; }

//        public abstract void Draw();

//        public void Copy()
//        {
//            Console.WriteLine("Copy shape into clipboard.");
//        }

//        public void Select()
//        {
//            Console.WriteLine("Select the shape.");
//        }
//    }
//}
