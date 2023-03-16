using COSIG_RayTracer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Box : Object3D
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


        // Material (Index)
        private int materialIndex = -1;
        public int MaterialIndex
        {
            get => materialIndex;
            set => materialIndex = Math.Max(0, value);
        }

        // Material
        public Material Material { get; set; }

        public override bool Intersect(Ray ray, Hit hit)
        {
            return false;
        }
    }
}
