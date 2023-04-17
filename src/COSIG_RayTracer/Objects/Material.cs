using System;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Material
    {
        public int Index { get; set; }

        // Colour
        public Colour3 Colour { get; set; }

        public Colour3 SpecularColour { get; set; }
        public Colour3 RefractionColour { get; set; }

        public void SetColour(double red, double green, double blue)
        {
            Colour = new Colour3(red, green, blue);
        }

        // Coefficients
        private double ambient = 0;
        private double diffuse = 0;
        private double specular = 0;
        private double refraction = 0;
        private double refractive_index = 0;

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

        public void CalculateSpecularColour()
        {
            SpecularColour = Colour * Specular;
        }

        public void CalculateRefractionColour()
        {
            RefractionColour = Colour * Refraction;
        }
    }
}
