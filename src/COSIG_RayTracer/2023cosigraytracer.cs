using COSIG_RayTracer.Objects;
using COSIG_RayTracing_Parser__ConsoleApp_;
using COSIG_RayTracing_Parser__ConsoleApp_.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace COSIG_RayTracer
{
    public partial class RayTracerWindow : Form
    {
        private bool isDebuggingRun = false;

        private Parser parsedContent = new Parser();
        private bool paintReady = false;

        private int timer = 0;
        private int loadLevel = 0;
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
            parsedContent = new Parser();
            parsedContent.LoadFile(filePath);

            if (isDebuggingRun)
            {
                Tests.ParserTest(parsedContent.imageCount, parsedContent.Transformations, parsedContent.Camera,
                            parsedContent.Lights, parsedContent.Materials, parsedContent.TriangleMeshes,
                            parsedContent.Spheres, parsedContent.Boxes);

                Tests.NormalsTest(parsedContent.TriangleMeshes);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void elapsedTimeTimer_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value < 100)
            {
                timer++;
                tickLabel.Text = timer.ToString();
            }
            else
            {
                elapsedTimeTimer.Stop();
                timer = 0;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int max_recursivity = 1;
            //startPrimaryRays();
            double fov_radians = parsedContent.Camera.Field_of_view * Math.PI / 180;
            double height = 2.0 * parsedContent.Camera.Distance * Math.Tan(fov_radians / 2.0);
            double width = height * parsedContent.Image.Res_horizontal / parsedContent.Image.Res_vertical;

            double pixelDimension = height / parsedContent.Image.Res_vertical;

            parsedContent.Image.InitializePixels();


            /* comecem por calcular o ponto origin de onde irão partir todos os raios primários (o ponto 
            correspondente à posição da câmara, ou seja, o ponto(0.0, 0.0, distance)) */
            Vector3 origin = new Vector3(0.0f, 0.0f, (float)parsedContent.Camera.Distance);

            for (int j = 0; j < parsedContent.Image.Res_vertical; j++)
            { // ciclo para percorrer todas as linhas da imagem

                for (int i = 0; i < parsedContent.Image.Res_horizontal; i++)
                { // ciclo para percorrer todas as colunas (píxeis) da linha j {

                    // calculem as coordenadas P.x, P.y e P.z do centro do píxel[i][j]

                    parsedContent.Image.Pixels[i, j].X = (float)((i + 0.5) * pixelDimension - width / 2.0);
                    /* a origem do sistema de eixos coordenados está 
                    localizada no centro do plano de projecção, mas o píxel[0][0] está localizado no canto
                    superior esquerdo da imagem; daí a subtracção de width / 2.0 à coordenada x do píxel */

                    parsedContent.Image.Pixels[i, j].Y = (float)(-(j + 0.5) * pixelDimension + height / 2.0); /* a origem do sistema de eixos coordenados está 
                    localizada no centro do plano de projecção, mas o píxel[0][0] está localizado no canto
                    superior esquerdo da imagem; daí a adição de height / 2.0 à coordenada y do píxel */

                    parsedContent.Image.Pixels[i, j].Z = 0; // o plano de projecção é o plano z = 0.0;

                    /* sabendo que o raio que passa pelo centro do píxel[i][j] (o ponto (P.x, P.y, P.z)) tem 
                     origem na posição da câmara(o ponto(0.0, 0.0, distance)), calculem o vector direction
                    que define a direcção do referido raio */

                    Vector3 direction = new Vector3(
                        parsedContent.Image.Pixels[i, j].X - 0,
                        parsedContent.Image.Pixels[i, j].Y - 0,
                        parsedContent.Image.Pixels[i, j].Z - (float)parsedContent.Camera.Distance
                        ); // ou seja, direction = new Vector3(P.x, P.y, -distance);

                    /* normalizem o vector direcção do raio (é importante que este vector seja mantido 
                    sempre normalizado) */
                    Vector3 direction_normalized = Vector3.Normalize(direction);

                    // agora que já conhecem quer a origem, quer a direcção do raio, deverão construí-lo

                    Ray ray = new Ray(origin, direction_normalized);

                    if (isDebuggingRun && j < 10 && i < 10)
                    {
                        Console.WriteLine("Linha " + j + ", Coluna " + i
                            + ", X= " + ray.Direction_Normalized.X
                            + ", Y= " + ray.Direction_Normalized.Y
                            + ", Z= " + ray.Direction_Normalized.Z);
                    }

                    /* uma vez construído o raio, deverão invocar a função traceRay(), a qual irá 
                    acompanhar recursivamente o percurso do referido raio; quando regressar, esta
                    função deverá retornar uma cor color */

                    Colour3 colour = TraceRay(ray, max_recursivity, i, j); /* em que ray designa o raio a ser acompanhado e rec um 
                    inteiro que contém o nível máximo de recursividade

/* (continua)
Limitação das componentes primárias(R, G e B) das cores obtidas
(continuação) */

                    /* limitem as componentes primárias (R, G e B) da cor color. Se alguma delas for < 0.0, 
                    façam - na = 0.0(isto nunca deverá acontecer); se alguma delas for > 1.0, façam - na =
                    1.0(isto poderá e irá acontecer, pois alguns dos materiais definidos no ficheiro
                    descritivo da cena 3D reflectem(e / ou refractam) mais luz do que a luz que sobre eles
                    incide */
                    colour.Red = colour.Red;        // não me parece ser necessário mas fica aqui para já
                    colour.Green = colour.Green;    // não me parece ser necessário mas fica aqui para já
                    colour.Blue = colour.Blue;      // não me parece ser necessário mas fica aqui para já

                    /* (continua)
                    Conversão das componentes primárias(R, G e B) das cores obtidas e
                    coloração dos píxeis constituintes da imagem                    
                    (continuação) */

                    /* convertam as componentes primárias da cor color num formato compatível com o 
                    do contentor da imagem; assumindo que estão a trabalhar com 32 bits / píxel(8 bits
                    para a componente R, 8 para G, 8 para B e 8 para A), a conversão a realizar consistirá
                    em multiplicar cada componente por 255.0 e convertê-la para um inteiro ou um byte
                    sem sinal.Por último, deverão colorir o píxel[i][j] com a cor color assim convertida */

                    parsedContent.Image.Pixels_RGB[i, j, 0] = (int)(255.0 * colour.Red);
                    parsedContent.Image.Pixels_RGB[i, j, 1] = (int)(255.0 * colour.Green);
                    parsedContent.Image.Pixels_RGB[i, j, 2] = (int)(255.0 * colour.Blue);
                    //Console.WriteLine("Pixel " + i + "," + j + ": R_" + parsedContent.Image.Pixels_Red[i, j] + "G_" + parsedContent.Image.Pixels_Green[i, j] + "B_" + parsedContent.Image.Pixels_Blue[i, j]);

                    // Progress Bar
                    progressBar.Value = (j * parsedContent.Image.Res_horizontal + i + 1) * 100 / (parsedContent.Image.Res_vertical * parsedContent.Image.Res_horizontal);
                    //Console.WriteLine(j * parsedContent.Image.Res_horizontal + i + 1 + " of " + parsedContent.Image.Res_vertical * parsedContent.Image.Res_horizontal);
                }
            }
            Console.WriteLine("Reached the End");
            paintReady = true;
            pictureBox1.Invalidate();
        }

        private Colour3 TraceRay(Ray ray, int max_recursion, int i, int j)
        {
            Hit hit = new Hit
            {
                Tmin = double.MaxValue // usem um valor muito elevado. Por exemplo, hit.tmin = 1.0E12;
            };
            foreach (Object3D obj in parsedContent.GetAllObjects3D()) // ciclo para percorrer todos os objectos da cena
            {
                obj.Intersect(ray, hit);
            }
            if (hit.Found)
            {
                Colour3 color = new Colour3(0.0, 0.0, 0.0); // inicialização
                foreach (Light light in parsedContent.Lights)
                { // ciclo para percorrer todas as fontes de luz da cena
                    // cálculo da componente de reflexão ambiente com origem na fonte de luz light
                    color += light.Intensity * hit.Material.Colour * hit.Material.Ambient;

                    // cálculo da componente de reflexão difusa com origem na fonte de luz light
                    /* comecem por construir o vector l que une o ponto de intersecção ao ponto
                    correspondente à posição da fonte de luz light */
                    Vector4 lightPos4 = Transformation.TransformVector4(light.Transformation.TransformationMatrix, new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
                    Vector3 transformedLightPoint3 = new Vector3(lightPos4.X / lightPos4.W, lightPos4.Y / lightPos4.W, lightPos4.Z / lightPos4.W);

                    Vector3 l = transformedLightPoint3 - hit.Point;

                    // normalizem o vector l
                    l = Vector3.Normalize(l);

                    /* calculem o co-seno do ângulo de incidência da luz. Este é igual ao produto 
                    escalar do vector normal pelo vector l(assumindo que ambos os vectores são
                    unitários) */
                    float cosTheta = Vector3.Dot(hit.Normal, l); // em que “∙” designa o produto escalar de vectores 3D
                    /* calculem a componente de reflexão difusa e adicionem a cor resultante à cor 
                    color.Tenham, no entanto, em consideração que só interessa calcular esta
                    componente se o ângulo de incidência θ for inferior a 90.0° (por outras palavras,
                    se cosTheta > 0.0).Um ângulo de incidência superior àquele valor significa que o
                    raio luminoso está a incidir no lado de trás da superfície do objecto intersectado */
                    if (cosTheta > 0.0)
                    {
                        color += light.Intensity * hit.Material.Colour * hit.Material.Diffuse * cosTheta;
                    }
                }
                return color / parsedContent.Lights.Count; /* em que sceneLights.length designa o número de 
                fontes de luz existentes na cena; se houver intersecção, retorna a cor correspondente
                à componente de luz ambiente reflectida pelo objecto intersectado mais próximo da
                origem do raio */
            }

            else
                return parsedContent.Image.BackgroundColour; // caso contrário, retorna a cor de fundo
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (paintReady)
            {
                Graphics g = e.Graphics;
                float hStart = (pictureBox1.Width - parsedContent.Image.Res_horizontal) / 2;
                float vStart = (pictureBox1.Height - parsedContent.Image.Res_vertical) / 2;
                for (int i = 0; i < parsedContent.Image.Res_horizontal; i++)
                {
                    for (int j = 0; j < parsedContent.Image.Res_vertical; j++)
                    {
                        Color c = Color.FromArgb(parsedContent.Image.Pixels_RGB[i, j, 0], parsedContent.Image.Pixels_RGB[i, j, 1], parsedContent.Image.Pixels_RGB[i, j, 2]);
                        SolidBrush brush = new SolidBrush(c);
                        g.FillRectangle(brush, hStart + i, vStart + j, 1, 1);
                    }
                }

                Console.WriteLine("All done");
            }
        }
    }
}
