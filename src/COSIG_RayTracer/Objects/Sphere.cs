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

        public override bool Intersect(Ray ray, Hit hit)
        {
            Vector4 origin4 = Transformation.TransformVector4(Transformation.InvertedTransformationMatrix, new Vector4(ray.Origin.X, ray.Origin.Y, ray.Origin.Z, 1.0f));
            Vector4 direction4 = Transformation.TransformVector4(Transformation.InvertedTransformationMatrix, new Vector4(ray.Direction_Normalized.X, ray.Direction_Normalized.Y, ray.Direction_Normalized.Z, 0.0f));
            Ray invertTransformedRay = new Ray(
                new Vector3(origin4.X / origin4.W, origin4.Y / origin4.W, origin4.Z / origin4.W),
                new Vector3(direction4.X, direction4.Y, direction4.Z)
                );

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
            float a = (float)Math.Pow(invertTransformedRay.Direction_Normalized.X, 2) +
                      (float)Math.Pow(invertTransformedRay.Direction_Normalized.Y, 2) +
                      (float)Math.Pow(invertTransformedRay.Direction_Normalized.Z, 2);

            // b
            float b = 2 * ((invertTransformedRay.Direction_Normalized.X * invertTransformedRay.Origin.X) +
                (invertTransformedRay.Direction_Normalized.Y * invertTransformedRay.Origin.Y) +
                (invertTransformedRay.Direction_Normalized.Z * invertTransformedRay.Origin.Z));

            // c
            float c = (float)Math.Pow(invertTransformedRay.Origin.X, 2) +
                      (float)Math.Pow(invertTransformedRay.Origin.Y, 2) +
                      (float)Math.Pow(invertTransformedRay.Origin.Z, 2) -
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

            Vector3 P = invertTransformedRay.Origin + (invertTransformedRay.Direction_Normalized * t);

            // normal
            Vector3 normal = Vector3.Normalize(P);
            Vector4 normal4 = Transformation.TransformVector4(Transformation.TransposedInvertedTransformationMatrix, new Vector4(normal, 0.0f));
            normal = new Vector3(normal4.X, normal4.Y, normal4.Z);
            normal = Vector3.Normalize(normal);
            Vector4 P4 = Transformation.TransformVector4(Transformation.TransformationMatrix, new Vector4(P, 1.0f));
            P = new Vector3(P4.X / P4.W, P4.Y / P4.W, P4.Z / P4.W);

            Vector3 v = P - ray.Origin;

            hit.T = v.Length();
            if (hit.T > 1.0E-6 && hit.T < hit.Tmin)
            {
                hit.Tmin = hit.T;
                hit.Found = true;
                hit.Material = Material;
                hit.Point = P;
                hit.Normal = normal;
                return true;
            }
            return false;
        }
    }
}
