using COSIG_RayTracer.Objects;
using System;
using System.Numerics;

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
            Vector4 origin4 = Transformation.TransformVector4(Transformation.InvertedTransformationMatrix, new Vector4(ray.Origin, 1.0f));
            Vector4 direction4 = Transformation.TransformVector4(Transformation.InvertedTransformationMatrix, new Vector4(ray.Direction_Normalized, 0.0f));
            Ray invertTransformedRay = new Ray(
                new Vector3(origin4.X / origin4.W, origin4.Y / origin4.W, origin4.Z / origin4.W),
                Vector3.Normalize(new Vector3(direction4.X, direction4.Y, direction4.Z))
                );

            float t1, t2, taux;
            float tnear = float.MinValue;
            float tfar = float.MaxValue;
            // X
            // testar se e paralelo
            if (invertTransformedRay.Direction_Normalized.X == 0.0)
            {
                if (invertTransformedRay.Origin.X < -0.5f || invertTransformedRay.Origin.X > 0.5f) return false;
            }
            // if it is not paralel
            else
            {
                t1 = (-0.5f - invertTransformedRay.Origin.X) / invertTransformedRay.Direction_Normalized.X;
                t2 = (0.5f - invertTransformedRay.Origin.X) / invertTransformedRay.Direction_Normalized.X;

                if (t1 > t2)
                {
                    taux = t1;
                    t1 = t2;
                    t2 = taux;
                }

                if (t1 > tnear) tnear = t1;
                if (t2 < tfar) tfar = t2;

                // checking tnear > tfar not needed for first axis
                if (tfar < 0.0f) return false;
            }

            // Y
            // Test if it is paralel
            if (invertTransformedRay.Direction_Normalized.Y == 0.0f)
            {
                if (invertTransformedRay.Origin.Y < -0.5f || invertTransformedRay.Origin.Y > 0.5f) return false;
            }
            // if it is not paralel
            else
            {
                t1 = (-0.5f - invertTransformedRay.Origin.Y) / invertTransformedRay.Direction_Normalized.Y;
                t2 = (0.5f - invertTransformedRay.Origin.Y) / invertTransformedRay.Direction_Normalized.Y;

                if (t1 > t2)
                {
                    taux = t1;
                    t1 = t2;
                    t2 = taux;
                }

                if (t1 > tnear) tnear = t1;
                if (t2 < tfar) tfar = t2;

                if (tnear > tfar) return false;
                if (tfar < 0.0f) return false;
            }

            // Z
            // testar se e paralelo
            if (invertTransformedRay.Direction_Normalized.Z == 0.0f)
            {
                if (invertTransformedRay.Origin.Z < -0.5f || invertTransformedRay.Origin.Z > 0.5f) return false;
            }
            else
            {
                t1 = (-0.5f - invertTransformedRay.Origin.Z) / invertTransformedRay.Direction_Normalized.Z;
                t2 = (0.5f - invertTransformedRay.Origin.Z) / invertTransformedRay.Direction_Normalized.Z;

                if (t1 > t2)
                {
                    taux = t1;
                    t1 = t2;
                    t2 = taux;
                }

                if (t1 > tnear) tnear = t1;
                if (t2 < tfar) tfar = t2;

                if (tnear > tfar) return false;
                if (tfar < 0.0f) return false;
            }

            //Get P of tnear

            Vector3 P = invertTransformedRay.Origin + (invertTransformedRay.Direction_Normalized * tnear);

            float closest = P.X;
            int closestIndex = 0;

            if (Math.Abs(Math.Abs(P.Y) - 0.5f) < Math.Abs(Math.Abs(closest) - 0.5f))
            {
                closest = P.Y;
                closestIndex = 1;
            }
            if (Math.Abs(Math.Abs(P.Z) - 0.5f) < Math.Abs(Math.Abs(closest) - 0.5f))
            {
                closest = P.Z;
                closestIndex = 2;
            }

            if (closestIndex == 0)
            {
                if (closest > 0.0f)
                {
                    P = new Vector3(0.5f, P.Y, P.Z);
                }
                else
                {
                    P = new Vector3(-0.5f, P.Y, P.Z);
                }

            }
            if (closestIndex == 1)
            {
                if (closest > 0.0f)
                {
                    P = new Vector3(P.X, 0.5f, P.Z);
                }
                else
                {
                    P = new Vector3(P.X, -0.5f, P.Z);
                }

            }
            if (closestIndex == 2)
            {
                if (closest > 0.0f)
                {
                    P = new Vector3(P.X, P.Y, 0.5f);
                }
                else
                {
                    P = new Vector3(P.X, P.Y, -0.5f);
                }

            }


            // normal
            Vector3 normal =
                P.X == 0.5f || P.X == -0.5f ?
                    new Vector3(P.X, 0, 0) :
                P.Y == 0.5f || P.Y == -0.5f ?
                    new Vector3(0, P.Y, 0) :
                    // Else
                    new Vector3(0, 0, P.Z);

            normal = Vector3.Normalize(normal);

            Vector4 normal4 = Transformation.TransformVector4(Transformation.TransposedInvertedTransformationMatrix, new Vector4(normal, 0.0f));
            normal = Vector3.Normalize(new Vector3(normal4.X, normal4.Y, normal4.Z));

            Vector4 P4 = Transformation.TransformVector4(Transformation.TransformationMatrix, new Vector4(P, 1.0f));
            P = new Vector3(P4.X / P4.W, P4.Y / P4.W, P4.Z / P4.W);

            Vector3 v = P - ray.Origin;

            hit.T = v.Length();
            if (hit.T > 1.0E-6f && hit.T < hit.Tmin)
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
