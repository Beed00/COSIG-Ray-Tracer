using COSIG_RayTracing_Parser__ConsoleApp_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSIG_RayTracer
{
    public partial class RayTracerWindow : Form
    {
        public RayTracerWindow()
        {
            InitializeComponent();
        }

        private void RayTracerWindow_Load(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            string filePath = "C:/Users/emonteiro/OneDrive - Hitachi Solutions/Desktop/Mestrado ISEP/1ano/2semestre/COSIG/Test_Scene_1.txt";
            Parser parsedContent = new Parser();
            parsedContent.LoadFile(filePath);

            Tests.ParserTest(parsedContent.imageCount, parsedContent.Transformations, parsedContent.Camera,
                            parsedContent.Lights, parsedContent.Materials, parsedContent.Triangles,
                            parsedContent.Spheres, parsedContent.Boxs);

            Tests.NormalsTest(parsedContent.Triangles);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void elapsedTimeTimer_Tick(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
