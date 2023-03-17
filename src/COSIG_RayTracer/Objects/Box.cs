using COSIG_RayTracer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            Vector4 origin4 = Transformation.TransformVector4(new Vector4(ray.Origin.X, ray.Origin.Y, ray.Origin.Z, 1.0f), true);
            Vector4 direction4 = Transformation.TransformVector4(new Vector4(ray.Direction_Normalized.X, ray.Direction_Normalized.Y, ray.Direction_Normalized.Z, 0.0f), true);
            Ray invertTransformedRay = new Ray(
                new Vector3(origin4.X / origin4.W, origin4.Y / origin4.W, origin4.Z / origin4.W),
                new Vector3(direction4.X, direction4.Y, direction4.Z)
                );

            float t1, t2, taux;
            float tnear = float.MinValue;
            float tfar = float.MaxValue;
            // X
            // testar se e paralelo
            if (invertTransformedRay.Direction_Normalized.X == 0)
            {
                if (invertTransformedRay.Origin.X < (float)(0 - 0.5) || invertTransformedRay.Origin.X > (float)(0.5)) return false;
            }
            // if it is not paralel
            else
            {
                t1 = ((float)-0.5 - invertTransformedRay.Origin.X) / invertTransformedRay.Direction_Normalized.X;
                t2 = ((float)0.5 - invertTransformedRay.Origin.X) / invertTransformedRay.Direction_Normalized.X;

                if (t1 > t2)
                {
                    taux = t1;
                    t1 = t2;
                    t2 = taux;
                }

                if (t1 > tnear) tnear = t1;
                if (t2 < tfar) tfar = t2;

                // checking tnear > tfar not needed for first axis
                if (tfar < 0) return false;
            }





            // Y
            // Test if it is paralel
            if (invertTransformedRay.Direction_Normalized.Y == 0)
            {
                if ((invertTransformedRay.Origin.Y < (float)(0 - 0.5) || invertTransformedRay.Origin.Y > (float)(0.5))) return false;
            }
            // if it is not paralel
            else
            {
                t1 = ((float)-0.5 - invertTransformedRay.Origin.Y) / invertTransformedRay.Direction_Normalized.Y;
                t2 = ((float)0.5 - invertTransformedRay.Origin.Y) / invertTransformedRay.Direction_Normalized.Y;

                if (t1 > t2)
                {
                    taux = t1;
                    t1 = t2;
                    t2 = taux;
                }

                if (t1 > tnear) tnear = t1;
                if (t2 < tfar) tfar = t2;

                if (tnear > tfar) return false;
                if (tfar < 0) return false;
            }






            // Z
            // testar se e paralelo
            if (invertTransformedRay.Direction_Normalized.Z == 0)
            {
                if ((invertTransformedRay.Origin.Z < (float)(0 - 0.5) || invertTransformedRay.Origin.Z > (float)(0.5))) return false;
            }
            else
            {
                t1 = ((float)-0.5 - invertTransformedRay.Origin.Z) / invertTransformedRay.Direction_Normalized.Z;
                t2 = ((float)0.5 - invertTransformedRay.Origin.Z) / invertTransformedRay.Direction_Normalized.Z;

                if (t1 > t2)
                {
                    taux = t1;
                    t1 = t2;
                    t2 = taux;
                }

                if (t1 > tnear) tnear = t1;
                if (t2 < tfar) tfar = t2;

                if (tnear > tfar) return false;
                if (tfar < 0) return false;
            }

            //Get P of tnear

            Vector3 P = invertTransformedRay.Origin + (invertTransformedRay.Direction_Normalized * tnear);

            Vector4 P4 = Transformation.TransformVector4(new Vector4(P, 1.0f), false);
            P = new Vector3(P4.X / P4.W, P4.Y / P4.W, P4.Z / P4.W);

            Vector3 v = P - ray.Origin;

            hit.T = v.Length();
            if (hit.T > 1.0E-6 && hit.T < hit.Tmin)
            {
                hit.Tmin = hit.T;
                hit.Found = true;
                hit.Material = Material;
                hit.Point = P;
                hit.Normal = Vector3.Normalize(P);
                return true;
            }
            return false;


            // testar se nao e paralelo

            return false;
        }
    }
}
