using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Triangle
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
    }
}
