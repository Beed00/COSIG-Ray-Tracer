using COSIG_RayTracing_Parser__ConsoleApp_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSIG_RayTracer
{
    public partial class RayTracerWindow : Form
    {
        private int timer = 0;
        public RayTracerWindow()
        {
            InitializeComponent();
            elapsedTimeTimer.Interval = (1000);
        }

        private void RayTracerWindow_Load(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Shows the dialog.
            if (result == DialogResult.OK) // Tests result.
            {
                string file = openFileDialog.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }

            elapsedTimeTimer.Start();

            Console.WriteLine("FileSize: " + size);
            Console.WriteLine("Result: " + result);
            Console.WriteLine("FilePath: " + openFileDialog.FileName);

            //"C:/Users/emonteiro/OneDrive - Hitachi Solutions/Desktop/Mestrado ISEP/1ano/2semestre/COSIG/Test_Scene_1.txt";
            string filePath = openFileDialog.FileName;
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
            timer++;
            tickLabel.Text = timer.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void imageWindow_Click(object sender, EventArgs e)
        {

        }

        private void recursionDepthSlider_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void recursionDepth1_Click(object sender, EventArgs e)
        {

        }

        private void tickLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
