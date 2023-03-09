using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Material
    {
        // Colour
        public Colour3 Colour { get; set; }

        public void SetColour(double red, double green, double blue)
        {
            Colour = new Colour3(red, green, blue);
        }

        // Coefficients
        private double ambient;
        private double diffuse;
        private double specular;
        private double refraction;
        private double refractive_index;

        public double Ambient
        {
            get => ambient;
            set => ambient = Math.Max(0.0, Math.Min(value, 1.0));
        }
        public double Diffuse
        {
            get => diffuse;
            set => diffuse = Math.Max(0.0, Math.Min(value, 1.0));
        }
        public double Specular
        {
            get => specular;
            set => specular = Math.Max(0.0, Math.Min(value, 1.0));
        }
        public double Refraction
        {
            get => refraction;
            set => refraction = Math.Max(0.0, Math.Min(value, 1.0));
        }
        public double Refractive_index
        {
            get => refractive_index;
            set => refractive_index = Math.Max(1.0, value);
        }

        public void SetCoefficients(double ambient, double diffuse, double specular, double refraction, double refractive_index)
        {
            Ambient = ambient;
            Diffuse = diffuse;
            Specular = specular;
            Refraction = refraction;
            Refractive_index = refractive_index;
        }

        // Constructor
        public Material()
        {
            Colour = new Colour3();
        }
    }
}
