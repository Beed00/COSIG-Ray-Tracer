using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Vector3SelFMade
    {
        // Vector
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }        

        public Vector3SelFMade()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3SelFMade(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
