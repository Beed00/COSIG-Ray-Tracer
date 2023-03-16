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

            float t1X = ((float)(0 - 0.5) - ray.Origin.X) / ray.Direction_Normalized.X;
            float t1Y = ((float)(0 - 0.5) - ray.Origin.Y) / ray.Direction_Normalized.Y;
            float t1Z = ((float)(0 - 0.5) - ray.Origin.Z) / ray.Direction_Normalized.Z;

            float t2X = ((float)0.5 - ray.Origin.X) / ray.Direction_Normalized.X;
            float t2Y = ((float)0.5 - ray.Origin.Y) / ray.Direction_Normalized.Y;
            float t2Z = ((float)0.5 - ray.Origin.Z) / ray.Direction_Normalized.Z;

            // testar se e paralelo
            if (ray.Direction_Normalized.X == 0 && (ray.Origin.X < (float)(0 - 0.5) || ray.Origin.X > (float)(0.5)))
            {

            }

            if (ray.Direction_Normalized.Y == 0 && (ray.Origin.Y < (float)(0 - 0.5) || ray.Origin.Y > (float)(0.5)))
            {

            }

            if (ray.Direction_Normalized.Z == 0 && (ray.Origin.Z < (float)(0 - 0.5) || ray.Origin.Z > (float)(0.5)))
            {

            }


            // testar se nao e paralelo

            return false;
        }
    }
}
