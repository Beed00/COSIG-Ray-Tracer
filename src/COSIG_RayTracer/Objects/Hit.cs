using COSIG_RayTracing_Parser__ConsoleApp_.Objects;
using System.Numerics;

namespace COSIG_RayTracer.Objects
{
    internal class Hit
    {
        public bool Found { get; set; }
        public Material Material { get; set; }
        public Vector3 Point { get; set; }
        public Vector3 Normal { get; set; }
        public float T { get; set; }
        public float Tmin { get; set; }

        public Hit()
        {
            Found = false;
        }
    }
}
