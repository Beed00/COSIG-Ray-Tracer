using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Light
    {
        // Transformation (Index)
        private int transformationIndex = -1;
        public int TransformationIndex
        {
            get => transformationIndex;
            set => transformationIndex = Math.Max(0, value);
        }

        // Transformation
        public Transformation Transformation { get; set; }

        // Background Colour
        public Colour3 Intensity { get; set; }

        public void SetIntensity(double red, double green, double blue)
        {
            Intensity = new Colour3(red, green, blue);
        }

        // Constructor
        public Light()
        {
            Intensity = new Colour3();
        }
    }
}
