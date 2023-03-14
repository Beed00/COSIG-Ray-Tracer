using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracer.Objects
{
    internal class Ray
    {
        public Vector3 Origin { get; set; }

        public Vector3 Direction_Normalized { get; set; }

        public Ray(Vector3 origin, Vector3 direction_Normalized)
        {
            Origin = origin;
            Direction_Normalized = direction_Normalized;
        }
    }
}
