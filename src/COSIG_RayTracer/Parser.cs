using COSIG_RayTracing_Parser__ConsoleApp_.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_
{
    internal class Parser
    {
        private string[] objectTypes = { "Image", "Transformation", "Material", "Camera", "Light", "Triangles", "Box", "Sphere" };
        public int imageCount = 0;
        public int cameraCount = 0;
        public Image Image { get; set; }
        public List<Transformation> Transformations { get; set; }
        public Camera Camera { get; set; }
        public List<Light> Lights { get; set; }
        public List<Material> Materials { get; set; }
        public List<Triangles> Triangles { get; set; }
        public List<Sphere> Spheres { get; set; }
        public List<Box> Boxs { get; set; }

        public Parser()
        {
            Image = new Image();
            Transformations = new List<Transformation>();
            Camera = new Camera();
            Lights = new List<Light>();
            Materials = new List<Material>();
            Triangles = new List<Triangles>();
            Spheres = new List<Sphere>();
            Boxs = new List<Box>();
        }

        public void LoadFile(string filePath)
        {
            // Open the file for reading
            using (StreamReader reader = new StreamReader(filePath))
            {
                string currentObjectType = "";

                // Read and format each line
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        string formattedLine = line.Replace("{", "")
                                                   .Replace("}", "")
                                                   .Replace("\t", " ")
                                                   .Trim();
                        if (!string.IsNullOrEmpty(formattedLine))
                        {
                            string[] lineElements = formattedLine.Split(' ');

                            int index = Array.IndexOf(objectTypes, lineElements[0]);
                            if (index != -1)
                            {
                                currentObjectType = objectTypes[index];
                                switch (currentObjectType)
                                {
                                    case "Image":
                                        imageCount++;
                                        break;
                                    case "Transformation":
                                        Transformations.Add(new Transformation());
                                        break;
                                    case "Material":
                                        Materials.Add(new Material());
                                        break;
                                    case "Camera":
                                        cameraCount++;
                                        break;
                                    case "Light":
                                        Lights.Add(new Light());
                                        break;
                                    case "Triangles":
                                        Triangles.Add(new Triangles());
                                        break;
                                    case "Box":
                                        Boxs.Add(new Box());
                                        break;
                                    case "Sphere":
                                        Spheres.Add(new Sphere());
                                        break;
                                    default: break;
                                }
                            }
                            else
                            {
                                switch (currentObjectType)
                                {
                                    case "Image":
                                        if (imageCount == 1)
                                        {
                                            if (lineElements.Length == 2) // Resolution (horizontal, vertical)
                                            {
                                                Image.SetResolution(Convert.ToInt32(lineElements[0]), Convert.ToInt32(lineElements[1]));
                                            }
                                            else if (lineElements.Length == 3) // Background Colour (R, G, B)
                                            {
                                                Image.SetBackgroundColour(Convert.ToDouble(lineElements[0]), Convert.ToDouble(lineElements[1]), Convert.ToDouble(lineElements[2]));
                                            }
                                        }
                                        break;
                                    case "Transformation":
                                        switch (lineElements[0])
                                        {
                                            case "T":
                                                Transformations[Transformations.Count - 1].SetTranslation(Convert.ToDouble(lineElements[1]), Convert.ToDouble(lineElements[2]), Convert.ToDouble(lineElements[3]));
                                                break;
                                            case "Rx":
                                                Transformations[Transformations.Count - 1].Rotation_x = Convert.ToDouble(lineElements[1]);
                                                break;
                                            case "Ry":
                                                Transformations[Transformations.Count - 1].Rotation_y = Convert.ToDouble(lineElements[1]);
                                                break;
                                            case "Rz":
                                                Transformations[Transformations.Count - 1].Rotation_z = Convert.ToDouble(lineElements[1]);
                                                break;
                                            case "S":
                                                Transformations[Transformations.Count - 1].SetScale(Convert.ToDouble(lineElements[1]), Convert.ToDouble(lineElements[2]), Convert.ToDouble(lineElements[3]));
                                                break;
                                            default: break;
                                        }
                                        break;
                                    case "Camera":
                                        if (cameraCount == 1)
                                        {
                                            if (Camera.TransformationIndex == -1)
                                            {
                                                Camera.TransformationIndex = Convert.ToInt32(lineElements[0]);
                                            }
                                            else if (Camera.Distance == -1)
                                            {
                                                Camera.Distance = Convert.ToDouble(lineElements[0]);
                                            }
                                            else
                                            {
                                                Camera.Field_of_view = Convert.ToDouble(lineElements[0]);
                                            }
                                        }
                                        break;
                                    case "Light":
                                        if (lineElements.Length == 1) // Transformation (index)
                                        {
                                            Lights[Lights.Count - 1].TransformationIndex = Convert.ToInt32(lineElements[0]);
                                        }
                                        else if (lineElements.Length == 3) // Intensity (R, G, B)
                                        {
                                            Lights[Lights.Count - 1].SetIntensity(Convert.ToDouble(lineElements[0]), Convert.ToDouble(lineElements[1]), Convert.ToDouble(lineElements[2]));
                                        }
                                        break;
                                    case "Material":
                                        if (lineElements.Length == 3) // Color (R, G, B)
                                        {
                                            Materials[Materials.Count - 1].SetColour(Convert.ToDouble(lineElements[0]), Convert.ToDouble(lineElements[1]), Convert.ToDouble(lineElements[2]));
                                        }
                                        else if (lineElements.Length == 5) // Coefficients (Ambient, Diffuse, Specular, Refraction, Refractive_index)
                                        {
                                            Materials[Materials.Count - 1].SetCoefficients(Convert.ToDouble(lineElements[0]), Convert.ToDouble(lineElements[1]), Convert.ToDouble(lineElements[2]), Convert.ToDouble(lineElements[3]), Convert.ToDouble(lineElements[4]));
                                        }
                                        break;
                                    case "Triangles":
                                        Triangles lastTriangles = Triangles.Last();
                                        if (lastTriangles.TransformationIndex == -1)
                                        {
                                            lastTriangles.TransformationIndex = Convert.ToInt32(lineElements[0]);
                                        }
                                        else if (lineElements.Length == 1) // Material (index)
                                        {
                                            lastTriangles.AddMaterialIndex(Convert.ToInt32(lineElements[0]));
                                        }
                                        else // Vertex
                                        {
                                            lastTriangles.AddVector(Convert.ToDouble(lineElements[0]), Convert.ToDouble(lineElements[1]), Convert.ToDouble(lineElements[2]));
                                        }
                                        break;
                                    case "Box":
                                        Box lastBox = Boxs.Last();
                                        if (lastBox.TransformationIndex == -1)
                                        {
                                            lastBox.TransformationIndex = Convert.ToInt32(lineElements[0]);
                                        }
                                        else if (lastBox.MaterialIndex == -1)
                                        {
                                            lastBox.MaterialIndex = Convert.ToInt32(lineElements[0]);
                                        }
                                        break;
                                    case "Sphere":
                                        Sphere lastSphere = Spheres.Last();
                                        if (lastSphere.TransformationIndex == -1)
                                        {
                                            lastSphere.TransformationIndex = Convert.ToInt32(lineElements[0]);
                                        }
                                        else if (lastSphere.MaterialIndex == -1)
                                        {
                                            lastSphere.MaterialIndex = Convert.ToInt32(lineElements[0]);
                                        }
                                        break;
                                    default: break;
                                }
                            }
                        }
                    }
                }

                // camera - T
                Camera.Transformation = Transformations[Camera.TransformationIndex];

                // Lights - T
                foreach (Light light in Lights)
                {
                    light.Transformation = Transformations[light.TransformationIndex];
                }

                // Triangles - T & M
                foreach (Triangles triangle in Triangles)
                {
                    triangle.Transformation = Transformations[triangle.TransformationIndex];
                    foreach (Triangle tri in triangle.getTriangles())
                    {
                        tri.Material = Materials[tri.MaterialIndex];
                    }
                }

                // Spheres - T & M
                foreach (Sphere sphere in Spheres)
                {
                    sphere.Transformation = Transformations[sphere.TransformationIndex];
                    sphere.Material = Materials[sphere.MaterialIndex];
                }
                // Boxs - T & M
                foreach (Box box in Boxs)
                {
                    box.Transformation = Transformations[box.TransformationIndex];
                    box.Material = Materials[box.MaterialIndex];
                }
            }
        }
    }
}
