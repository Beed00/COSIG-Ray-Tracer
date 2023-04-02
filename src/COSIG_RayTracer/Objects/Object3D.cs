using COSIG_RayTracing_Parser__ConsoleApp_.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracer.Objects
{
    abstract class Object3D
    {
        public abstract bool Intersect(Ray ray, Hit hit);
    }
}
