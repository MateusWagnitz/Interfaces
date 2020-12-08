using Shape_Como_Interface.Model.Entities;
using Shape_Como_Interface.Model.Enums;
using System;

namespace Shape_Como_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {

                IShape s1 = new Circle() { Radius = 2.0, Color = Color.White };
                IShape s2 = new Rectangle() { Width = 3.5, Height = 4.2, Color = Color.Black };
                Console.WriteLine(s1);
                Console.WriteLine(s2);
            }
        }
    }
}
