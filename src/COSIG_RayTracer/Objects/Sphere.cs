using COSIG_RayTracer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Sphere : Object3D
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

        Vector3[] vectors = new Vector3[3];

        public override bool Intersect(Ray ray, Hit hit)
        {
            // distancia do Ponto a Intersecao
            float t = 0;

            /** Calcular valor do Delta Δ
             * 
             * Δ = b^2 – 4 ac
             * 
             *      a = Vx^2 +Vy^2 + Vz^2 (Sempre igual a 1)
             * 
             *      b = 2 (VxPx + VyPy + VzPz)
             * 
             *      c = Px^2 +Py^2 + Pz^2 – 1 
             * 
             *      Se Δ < 0, nao ha intersecao
             *      Se Δ > 0, ha duas intersecoes
             *      Se Δ == 0, ha uma intersecao
             * 
            */
            // a
            float a = (float)Math.Pow(ray.Direction_Normalized.X, 2) +
                      (float)Math.Pow(ray.Direction_Normalized.Y, 2) +
                      (float)Math.Pow(ray.Direction_Normalized.Z, 2);

            // b
            float b = 2 * ((ray.Direction_Normalized.X * ray.Origin.X) +
                (ray.Direction_Normalized.Y * ray.Origin.Y) +
                (ray.Direction_Normalized.Z * ray.Origin.Z));

            // c
            float c = (float)Math.Pow(ray.Origin.X, 2) +
                      (float)Math.Pow(ray.Origin.Y, 2) +
                      (float)Math.Pow(ray.Origin.Z, 2) -
                      1;

            // Δ
            float delta = (float)Math.Pow(b, 2) - (4 * a * c);

            // Se Δ < 0, nao ha intersecao
            if (delta < 0)
            {
                return false;
            }
            else if (delta > 0) // Se Δ > 0, ha duas intersecoes
            {
                float tOne = ((0 - b) + (float)Math.Sqrt(delta)) / (2 * a);

                float tTwo = ((0 - b) - (float)Math.Sqrt(delta)) / (2 * a);

                t = (float)Math.Min(tOne, tTwo);

                if (t < 0)
                {
                    return false;
                }
            }
            else if (delta == 0) // Se Δ == 0, ha uma intersecao
            {
                t = ((0 - b) + (float)Math.Sqrt(delta)) / (2 * a);

                if (t < 0)
                {
                    return false;
                }
            }

            Vector3 P = ray.Origin + (ray.Direction_Normalized * t);

            hit.T = t;
            if (hit.T > 1.0E-6 && hit.T < hit.Tmin)
            {
                hit.Tmin = hit.T;
                hit.Found = true;
                hit.Material = Material;
                hit.Point = P;
                hit.Normal = Vector3.Normalize(P); // Normal already calculated 
                return true;
            }
            return false;
        }
    }
}
