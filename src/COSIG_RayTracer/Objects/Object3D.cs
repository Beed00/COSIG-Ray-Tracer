namespace COSIG_RayTracer.Objects
{
    abstract class Object3D
    {
        public abstract bool Intersect(Ray ray, Hit hit);
    }
}
