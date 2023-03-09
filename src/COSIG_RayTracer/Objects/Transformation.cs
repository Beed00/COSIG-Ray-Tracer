using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Transformation
    {
        // Translation
        public double Translation_x { get; set; }
        public double Translation_y { get; set; }
        public double Translation_z { get; set; }

        public void SetTranslation(double x, double y, double z)
        {
            Translation_x = x;
            Translation_y = y;
            Translation_z = z;
        }

        // Rotation
        public double Rotation_x { get; set; }
        public double Rotation_y { get; set; }
        public double Rotation_z { get; set; }

        // Scale
        public double Scale_x { get; set; }
        public double Scale_y { get; set; }
        public double Scale_z { get; set; }

        public void SetScale(double x, double y, double z)
        {
            Scale_x = x;
            Scale_y = y;
            Scale_z = z;
        }

        public Transformation()
        {
            Translation_x = 0;
            Translation_y = 0;
            Translation_z = 0;

            Rotation_x = 0;
            Rotation_y = 0;
            Rotation_z = 0;

            Scale_x = 0;
            Scale_y = 0;
            Scale_z = 0;
        }
    }
}
