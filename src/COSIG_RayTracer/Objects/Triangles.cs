using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Triangles
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

        // Triangles
        private List<Triangle> triangles = new List<Triangle>();

        public void AddMaterialIndex(int materialIndex)
        {
            triangles.Add(new Triangle(materialIndex));
        }
        //public void AddMaterial(Material material)
        //{
        //    triangles.Add(new Triangle(material));
        //}

        public void AddVector(double x, double y, double z)
        {
            triangles[triangles.Count-1].AddVector(x, y, z);
        }

        public List<Triangle> getTriangles()
        {
            return triangles;
        }
    }
}
