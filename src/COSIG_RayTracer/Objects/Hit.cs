using COSIG_RayTracing_Parser__ConsoleApp_.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracer.Objects
{
    internal class Hit
    {
        public bool Found { get; set; }
        public Material Material { get; set; }
        public Vector3 Point { get; set; }
        public Vector3 Normal { get; set; }
        public double T { get; set; }
        public double Tmin { get; set; }

        public Hit()
        {
            Found = false;
        }
    }
}
