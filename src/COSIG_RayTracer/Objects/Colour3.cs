using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Colour3
    {
        // Colour
        private double red;
        private double green;
        private double blue;

        public double Red
        {
            get => red;
            set => red = Math.Max(0.0, Math.Min(value, 1.0));
        }
        public double Green
        {
            get => green;
            set => green = Math.Max(0.0, Math.Min(value, 1.0));
        }
        public double Blue
        {
            get => blue;
            set => blue = Math.Max(0.0, Math.Min(value, 1.0));
        }

        public Colour3()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
        }

        public Colour3(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public static Colour3 operator +(Colour3 c1, Colour3 c2)
        {
            return new Colour3(c1.Red + c2.Red, c1.Green + c2.Green, c1.Blue + c2.Blue);
        }

        public static Colour3 operator *(Colour3 c1, Colour3 c2)
        {
            return new Colour3(c1.Red * c2.Red, c1.Green * c2.Green, c1.Blue * c2.Blue);
        }

        public static Colour3 operator *(Colour3 c1, double d)
        {
            return new Colour3(c1.Red * d, c1.Green * d, c1.Blue * d);
        }

        public static Colour3 operator /(Colour3 c1, int i)
        {
            return new Colour3(c1.Red / i, c1.Green / i, c1.Blue / i);
        }
    }
}
