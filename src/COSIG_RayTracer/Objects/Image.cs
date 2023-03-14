using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace COSIG_RayTracing_Parser__ConsoleApp_.Objects
{
    internal class Image
    {
        // Resolution
        private int res_horizontal = 1;
        private int res_vertical = 1;

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

        public Vector3[,] Pixels { get; set; }
        public int[,] Pixels_Red { get; set; }
        public int[,] Pixels_Green { get; set; }
        public int[,] Pixels_Blue { get; set; }

        // Constructor
        public Image()
        {
            BackgroundColour = new Colour3();
        }

        public void InitializePixels()
        {
            Pixels = new Vector3[res_horizontal, res_vertical];
            Pixels_Red = new int[res_horizontal, res_vertical];
            Pixels_Green = new int[res_horizontal, res_vertical];
            Pixels_Blue = new int[res_horizontal, res_vertical];
        }
    }
}