using System.Windows.Forms;

namespace COSIG_RayTracer
{
    partial class RayTracerWindow
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
            this.imageWindow = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.elapsedTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.tickLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadButton.Location = new System.Drawing.Point(100, 676);
            this.loadButton.Margin = new System.Windows.Forms.Padding(6);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(202, 45);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(100, 773);
            this.saveButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(202, 45);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save Image";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(1298, 676);
            this.startButton.Margin = new System.Windows.Forms.Padding(6);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(202, 45);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(1298, 773);
            this.exitButton.Margin = new System.Windows.Forms.Padding(6);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(202, 45);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // recursionDepthSlider
            // 
            this.recursionDepthSlider.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.recursionDepthSlider.Location = new System.Drawing.Point(852, 678);
            this.recursionDepthSlider.Margin = new System.Windows.Forms.Padding(6);
            this.recursionDepthSlider.Name = "recursionDepthSlider";
            this.recursionDepthSlider.Size = new System.Drawing.Size(102, 38);
            this.recursionDepthSlider.TabIndex = 4;
            this.recursionDepthSlider.Text = "0";
            this.recursionDepthSlider.SelectedItemChanged += new System.EventHandler(this.recursionDepthSlider_SelectedItemChanged);
            // 
            // recursionDepth1
            // 
            this.recursionDepth1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.recursionDepth1.AutoSize = true;
            this.recursionDepth1.Location = new System.Drawing.Point(626, 682);
            this.recursionDepth1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.recursionDepth1.Name = "recursionDepth1";
            this.recursionDepth1.Size = new System.Drawing.Size(225, 32);
            this.recursionDepth1.TabIndex = 5;
            this.recursionDepth1.Text = "Recursion Depth";
            this.recursionDepth1.Click += new System.EventHandler(this.recursionDepth1_Click);
            // 
            // imageWindow
            // 
            this.imageWindow.Location = new System.Drawing.Point(15, 15);
            this.imageWindow.Margin = new System.Windows.Forms.Padding(6);
            this.imageWindow.Name = "imageWindow";
            this.imageWindow.Size = new System.Drawing.Size(83, 54);
            this.imageWindow.TabIndex = 7;
            this.imageWindow.TabStop = false;
            this.imageWindow.Click += new System.EventHandler(this.imageWindow_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar.Location = new System.Drawing.Point(641, 763);
            this.progressBar.Margin = new System.Windows.Forms.Padding(6);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 45);
            this.progressBar.TabIndex = 8;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(1138, 23);
            this.elapsedTimeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(203, 32);
            this.elapsedTimeLabel.TabIndex = 9;
            this.elapsedTimeLabel.Text = "Elapsed Time: ";
            this.elapsedTimeLabel.Visible = false;
            this.elapsedTimeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // elapsedTimeTimer
            // 
            this.elapsedTimeTimer.Tick += new System.EventHandler(this.elapsedTimeTimer_Tick);
            // 
            // tickLabel
            // 
            this.tickLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tickLabel.AutoSize = true;
            this.tickLabel.Location = new System.Drawing.Point(1322, 23);
            this.tickLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tickLabel.Name = "tickLabel";
            this.tickLabel.Size = new System.Drawing.Size(0, 32);
            this.tickLabel.TabIndex = 10;
            this.tickLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tickLabel.Click += new System.EventHandler(this.tickLabel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(52, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1500, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // RayTracerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1600, 912);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tickLabel);
            this.Controls.Add(this.elapsedTimeLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.imageWindow);
            this.Controls.Add(this.recursionDepth1);
            this.Controls.Add(this.recursionDepthSlider);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "RayTracerWindow";
            this.Text = "2023 COSIG RayTracer";
            this.Load += new System.EventHandler(this.RayTracerWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageWindow)).EndInit();
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
        private System.Windows.Forms.PictureBox imageWindow;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Timer elapsedTimeTimer;
        private System.Windows.Forms.Label tickLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

