using COSIG_RayTracer.Objects;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class TriangleMesh : Object3D
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
            triangles[triangles.Count - 1].AddVector(x, y, z);
        }

        public List<Triangle> getTriangles()
        {
            return triangles;
        }

        public override bool Intersect(Ray ray, Hit hit)
        {
            Vector4 origin4 = Transformation.TransformVector4(Transformation.InvertedTransformationMatrix, new Vector4(ray.Origin.X, ray.Origin.Y, ray.Origin.Z, 1.0f));
            Vector4 direction4 = Transformation.TransformVector4(Transformation.InvertedTransformationMatrix, new Vector4(ray.Direction_Normalized.X, ray.Direction_Normalized.Y, ray.Direction_Normalized.Z, 0.0f));
            Ray invertTransformedRay = new Ray(
                new Vector3(origin4.X / origin4.W, origin4.Y / origin4.W, origin4.Z / origin4.W),
                Vector3.Normalize(new Vector3(direction4.X, direction4.Y, direction4.Z))
                );
            bool intersects = false;
            foreach (Triangle triangle in triangles)
            {
                bool newIntersection = triangle.Intersect(ray, invertTransformedRay, hit, Transformation);
                intersects = newIntersection || intersects;
            }
            return intersects;
        }
    }
}
