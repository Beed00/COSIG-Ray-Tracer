using System;
using System.Collections.Generic;

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

        public List<Colour3> MaterialAmbientLights { get; set; } = new List<Colour3>();

        public List<Colour3> MaterialDiffuseLights { get; set; } = new List<Colour3>();

        // Constructor
        public Light()
        {
            Intensity = new Colour3();
        }

        public void createMaterialLightsArray(List<Material> materials)
        {
            foreach (Material material in materials)
            {
                MaterialAmbientLights.Add(Intensity * material.Colour * material.Ambient);
                MaterialDiffuseLights.Add(Intensity * material.Colour * material.Diffuse);
            }
        }
    }
}
