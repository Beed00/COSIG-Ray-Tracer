using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Image
    {
        // Resolution
        private int res_horizontal;
        private int res_vertical;

        public int Res_horizontal
        {
            get => res_horizontal;
            set => res_horizontal = Math.Max(1, value);
        }
        public int Res_vertical
        {
            get => res_vertical;
            set => res_vertical = Math.Max(1, value);
        }

        public void SetResolution(int horizontal, int vertical)
        {
            Res_horizontal = horizontal;
            Res_vertical = vertical;
        }

        // Background Colour
        public Colour3 BackgroundColour { get; set; }        

        public void SetBackgroundColour(double red, double green, double blue)
        {
            BackgroundColour = new Colour3(red, green, blue);
        }

        // Constructor
        public Image()
        {
            BackgroundColour = new Colour3();
        }

    }
}
