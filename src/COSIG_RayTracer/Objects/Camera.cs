using System;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Camera
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

        // Camera properties
        private double distance = -1;
        private double field_of_view = -1;
        public double Distance
        {
            get => distance;
            set => distance = Math.Max(0.0, value);
        }
        public double Field_of_view
        {
            get => field_of_view;
            set => field_of_view = Math.Max(0.0, value);
        }
    }
}
