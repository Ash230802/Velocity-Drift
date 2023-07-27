namespace VelocityDrift
{
    partial class Form3
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.START = new System.Windows.Forms.Button();
            this.QUIT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VelocityDrift.Properties.Resources.VELOCITY_DRIFT1;
            this.pictureBox1.Location = new System.Drawing.Point(-4, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(803, 459);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // START
            // 
            this.START.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.START.Cursor = System.Windows.Forms.Cursors.Default;
            this.START.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.START.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.START.Location = new System.Drawing.Point(229, 366);
            this.START.Name = "START";
            this.START.Size = new System.Drawing.Size(115, 54);
            this.START.TabIndex = 2;
            this.START.Text = "START";
            this.START.UseVisualStyleBackColor = false;
            this.START.Click += new System.EventHandler(this.START_Click);
            this.START.MouseEnter += new System.EventHandler(this.START_MouseEnter);
            this.START.MouseLeave += new System.EventHandler(this.START_MouseLeave);
            // 
            // QUIT
            // 
            this.QUIT.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.QUIT.Cursor = System.Windows.Forms.Cursors.Default;
            this.QUIT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QUIT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.QUIT.Location = new System.Drawing.Point(363, 366);
            this.QUIT.Name = "QUIT";
            this.QUIT.Size = new System.Drawing.Size(115, 54);
            this.QUIT.TabIndex = 3;
            this.QUIT.Text = "QUIT";
            this.QUIT.UseVisualStyleBackColor = false;
            this.QUIT.Click += new System.EventHandler(this.QUIT_Click);
            this.QUIT.MouseEnter += new System.EventHandler(this.QUIT_MouseEnter);
            this.QUIT.MouseLeave += new System.EventHandler(this.QUIT_MouseLeave);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.QUIT);
            this.Controls.Add(this.START);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button START;
        private System.Windows.Forms.Button QUIT;
    }
}