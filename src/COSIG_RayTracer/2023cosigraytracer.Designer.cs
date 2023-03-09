namespace COSIG_RayTracer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.recursionDepthSlider = new System.Windows.Forms.DomainUpDown();
            this.recursionDepth1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.elapsedTimeTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(50, 349);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(101, 23);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(50, 399);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save Image";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(649, 349);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(101, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(649, 399);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(101, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // recursionDepthSlider
            // 
            this.recursionDepthSlider.Items.Add("10");
            this.recursionDepthSlider.Items.Add("9");
            this.recursionDepthSlider.Items.Add("8");
            this.recursionDepthSlider.Items.Add("7");
            this.recursionDepthSlider.Items.Add("6");
            this.recursionDepthSlider.Items.Add("5");
            this.recursionDepthSlider.Items.Add("4");
            this.recursionDepthSlider.Items.Add("3");
            this.recursionDepthSlider.Items.Add("2");
            this.recursionDepthSlider.Items.Add("1");
            this.recursionDepthSlider.Items.Add("0");
            this.recursionDepthSlider.Location = new System.Drawing.Point(426, 350);
            this.recursionDepthSlider.Name = "recursionDepthSlider";
            this.recursionDepthSlider.Size = new System.Drawing.Size(51, 22);
            this.recursionDepthSlider.TabIndex = 4;
            // 
            // recursionDepth1
            // 
            this.recursionDepth1.AutoSize = true;
            this.recursionDepth1.Location = new System.Drawing.Point(313, 352);
            this.recursionDepth1.Name = "recursionDepth1";
            this.recursionDepth1.Size = new System.Drawing.Size(107, 16);
            this.recursionDepth1.TabIndex = 5;
            this.recursionDepth1.Text = "Recursion Depth";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(50, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 250);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(321, 153);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(150, 23);
            this.progressBar.TabIndex = 8;
            this.progressBar.Value = 70;
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(569, 12);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(98, 16);
            this.elapsedTimeLabel.TabIndex = 9;
            this.elapsedTimeLabel.Text = "Elapsed Time: ";
            this.elapsedTimeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.elapsedTimeLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.recursionDepth1);
            this.Controls.Add(this.recursionDepthSlider);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Name = "Form1";
            this.Text = "2023 COSIG RayTracer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.DomainUpDown recursionDepthSlider;
        private System.Windows.Forms.Label recursionDepth1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Timer elapsedTimeTimer;
    }
}

