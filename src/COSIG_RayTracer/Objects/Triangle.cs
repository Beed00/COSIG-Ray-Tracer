using COSIG_RayTracer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Triangle : Object3D
    {
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

        private readonly bool[] addedVector = { false, false, false };

        public Vector3 Normalized_normal { get; set; }

        public Triangle(int materialIndex)
        {
            MaterialIndex = materialIndex;
        }

        public void AddVector(double x, double y, double z)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!addedVector[i])
                {
                    vectors[i] = new Vector3((float)x, (float)y, (float)z);
                    addedVector[i] = true;
                    if (i == 2) Normalized_normal = Vector3.Normalize(Vector3.Cross(vectors[1] - vectors[0], vectors[2] - vectors[0]));
                    break;
                }
            }

        }

        public override bool Intersect(Ray ray, Hit hit)
        {
            // |A|
            Matrix4x4 matrix_A = new Matrix4x4(
                vectors[0].X - vectors[1].X, vectors[0].X - vectors[2].X, ray.Direction_Normalized.X, 0,
                vectors[0].Y - vectors[1].Y, vectors[0].Y - vectors[2].Y, ray.Direction_Normalized.Y, 0,
                vectors[0].Z - vectors[1].Z, vectors[0].Z - vectors[2].Z, ray.Direction_Normalized.Z, 0,
                0, 0, 0, 1);
            float A_Det = matrix_A.GetDeterminant();

            // B
            Matrix4x4 matrix_AB = new Matrix4x4(
                vectors[0].X - ray.Origin.X, vectors[0].X - vectors[2].X, ray.Direction_Normalized.X, 0,
                vectors[0].Y - ray.Origin.Y, vectors[0].Y - vectors[2].Y, ray.Direction_Normalized.Y, 0,
                vectors[0].Z - ray.Origin.Z, vectors[0].Z - vectors[2].Z, ray.Direction_Normalized.Z, 0,
                0, 0, 0, 1);
            float B = matrix_AB.GetDeterminant() / A_Det;
            if (B <= -1.0E-6) return false;

            // Y
            Matrix4x4 matrix_AY = new Matrix4x4(
                vectors[0].X - vectors[1].X, vectors[0].X - ray.Origin.X, ray.Direction_Normalized.X, 0,
                vectors[0].Y - vectors[1].Y, vectors[0].Y - ray.Origin.Y, ray.Direction_Normalized.Y, 0,
                vectors[0].Z - vectors[1].Z, vectors[0].Z - ray.Origin.Z, ray.Direction_Normalized.Z, 0,
                0, 0, 0, 1);
            float Y = matrix_AY.GetDeterminant() / A_Det;
            if (Y <= -1.0E-6 || B + Y >= 1.0 + 1.0E-6) return false;            

            Vector3 P = vectors[0] + B * (vectors[1] - vectors[0]) + Y * (vectors[2] - vectors[0]);

            Vector3 v = P - ray.Origin;

            hit.T = v.Length(); 
            if (hit.T > 1.0E-6 && hit.T < hit.Tmin)
            {
                hit.Tmin = hit.T;
                hit.Found = true;
                hit.Material = Material;
                hit.Point = P;
                hit.Normal = Normalized_normal; // Normal already calculated
                return true;
            }
            return false;
        }
    }
}
