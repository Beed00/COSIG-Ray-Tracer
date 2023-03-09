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
        public RayTracerWindow()
        {
            InitializeComponent();
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
            Console.WriteLine("FileSize: " + size);
            Console.WriteLine("Result: " + result);
            Console.WriteLine("FilePath: " + openFileDialog.FileName);
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
    }
}
