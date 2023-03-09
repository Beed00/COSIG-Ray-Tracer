using COSIG_RayTracing_Parser__ConsoleApp_.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_
{
    internal class Tests
    {
        public static void ParserTest(int imageCount, List<Transformation> transformations, Camera camera,
                                        List<Light> lights, List<Material> materials, List<Triangles> triangles,
                                        List<Sphere> spheres, List<Box> boxs)
        {
            // Listagem de alguns atributos do ficheiro descritivo da cena 3D
            var sb = new System.Text.StringBuilder();
            sb.Append(String.Format("\n\n{0,-20} {1,12} {2,20} {3,20} {4,20}\n\n", "Name of Segment", "Num of Segments", "Transformation Index", "Material Index", "Num of Triangles"));
            sb.Append(String.Format("{0,-20} {1,12} {2,20} {3,20} {4,20}\n", "Image", imageCount, "-", "-", "-"));
            sb.Append(String.Format("{0,-20} {1,12} {2,20} {3,20} {4,20}\n", "Transformation", transformations.Count, "-", "-", "-"));
            sb.Append(String.Format("{0,-20} {1,12} {2,20} {3,20} {4,20}\n", "Camera", "1", camera.TransformationIndex, "-", "-"));

            string aux = "";
            foreach (Light str in lights)
                aux += str.TransformationIndex + ";";
            sb.Append(String.Format("{0,-20} {1,12} {2,20} {3,20} {4,20}\n", "Light", lights.Count, aux, "-", "-"));

            sb.Append(String.Format("{0,-20} {1,12} {2,20} {3,20} {4,20}\n", "Material", materials.Count, "-", "-", "-"));

            foreach (Triangles str in triangles)
            {
                aux = "";
                foreach (Triangle tri in str.getTriangles())
                {
                    if (Array.IndexOf(aux.Split(';'), Convert.ToString(tri.MaterialIndex)) == -1)
                    {
                        aux += tri.MaterialIndex + ";";
                    }
                }
                sb.Append(String.Format("{0,-20} {1,12} {2,20} {3,20} {4,20}\n", "Triangles", "1", str.TransformationIndex, aux, str.getTriangles().Count));
            }

            aux = "";
            string aux2 = "";
            foreach (Sphere str in spheres)
            {
                aux += str.TransformationIndex + ";";
                aux2 += str.MaterialIndex + ";";
            }
            sb.Append(String.Format("{0,-20} {1,12} {2,20} {3,20} {4,20}\n", "Sphere", spheres.Count, aux, aux2, "-"));

            aux = "";
            aux2 = "";
            foreach (Box str in boxs)
            {
                aux += str.TransformationIndex + ";";
                aux2 += str.MaterialIndex + ";";
            }
            sb.Append(String.Format("{0,-20} {1,12} {2,20} {3,20} {4,20}\n", "Box", boxs.Count, aux, aux2, "-"));

            Console.WriteLine(sb);
        }

        internal static void NormalsTest(List<Triangles> triangles)
        {
            var sb = new System.Text.StringBuilder();
            sb.Append(String.Format("\n\n{0,-20} {1,12} {2,20} {3,20}\n\n", "Objeto", "Componente X", "Componente Y", "Componente Z"));

            for (int j = 0; j < triangles.Count; j++)
            {
                sb.Append(String.Format("{0,-20}\n", "Objeto " + (j+1)));
                for (int i = 0; i < Math.Min(10, triangles[j].getTriangles().Count); i++)
                {
                    Vector3 nNormal = triangles[j].getTriangles()[i].Normalized_normal;
                    sb.Append(String.Format("{0,-20} {1,12} {2,20} {3,20}\n", "", nNormal.X, nNormal.Y, nNormal.Z));
                }
                sb.Append(String.Format("\n"));
            }

            Console.WriteLine(sb);
        }
    }
}
