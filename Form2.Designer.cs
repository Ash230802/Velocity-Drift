namespace VelocityDrift
{
    partial class Form2
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Timers.Timer();
            this.Score = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Label();
            this.roadLine2 = new System.Windows.Forms.PictureBox();
            this.roadLine1 = new System.Windows.Forms.PictureBox();
            this.RoadSpacerRight = new System.Windows.Forms.PictureBox();
            this.RoadSpacerLeft = new System.Windows.Forms.PictureBox();
            this.RoadBoundaryRight = new System.Windows.Forms.PictureBox();
            this.RoadBoundaryLeft = new System.Windows.Forms.PictureBox();
            this.roadLine8 = new System.Windows.Forms.PictureBox();
            this.roadLine7 = new System.Windows.Forms.PictureBox();
            this.roadLine6 = new System.Windows.Forms.PictureBox();
            this.roadLine5 = new System.Windows.Forms.PictureBox();
            this.roadLine4 = new System.Windows.Forms.PictureBox();
            this.roadLine3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.timer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadSpacerRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadSpacerLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadBoundaryRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadBoundaryLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000D;
            this.timer2.SynchronizingObject = this;
            this.timer2.Elapsed += new System.Timers.ElapsedEventHandler(this.timer2_Elapsed);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.BackColor = System.Drawing.Color.Chartreuse;
            this.Score.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.Location = new System.Drawing.Point(585, 9);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(60, 19);
            this.Score.TabIndex = 22;
            this.Score.Text = "Score:";
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.BackColor = System.Drawing.Color.Chartreuse;
            this.Timer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer.Location = new System.Drawing.Point(585, 50);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(58, 19);
            this.Timer.TabIndex = 23;
            this.Timer.Text = "Timer:";
            // 
            // roadLine2
            // 
            this.roadLine2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roadLine2.Location = new System.Drawing.Point(337, 134);
            this.roadLine2.Name = "roadLine2";
            this.roadLine2.Size = new System.Drawing.Size(15, 121);
            this.roadLine2.TabIndex = 26;
            this.roadLine2.TabStop = false;
            // 
            // roadLine1
            // 
            this.roadLine1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roadLine1.Location = new System.Drawing.Point(336, -9);
            this.roadLine1.Name = "roadLine1";
            this.roadLine1.Size = new System.Drawing.Size(15, 121);
            this.roadLine1.TabIndex = 25;
            this.roadLine1.TabStop = false;
            // 
            // RoadSpacerRight
            // 
            this.RoadSpacerRight.BackColor = System.Drawing.Color.Chartreuse;
            this.RoadSpacerRight.Location = new System.Drawing.Point(574, -10);
            this.RoadSpacerRight.Name = "RoadSpacerRight";
            this.RoadSpacerRight.Size = new System.Drawing.Size(230, 464);
            this.RoadSpacerRight.TabIndex = 20;
            this.RoadSpacerRight.TabStop = false;
            // 
            // RoadSpacerLeft
            // 
            this.RoadSpacerLeft.BackColor = System.Drawing.Color.Chartreuse;
            this.RoadSpacerLeft.Location = new System.Drawing.Point(-5, -10);
            this.RoadSpacerLeft.Name = "RoadSpacerLeft";
            this.RoadSpacerLeft.Size = new System.Drawing.Size(230, 464);
            this.RoadSpacerLeft.TabIndex = 19;
            this.RoadSpacerLeft.TabStop = false;
            // 
            // RoadBoundaryRight
            // 
            this.RoadBoundaryRight.BackColor = System.Drawing.Color.Yellow;
            this.RoadBoundaryRight.Location = new System.Drawing.Point(563, -10);
            this.RoadBoundaryRight.Name = "RoadBoundaryRight";
            this.RoadBoundaryRight.Size = new System.Drawing.Size(15, 464);
            this.RoadBoundaryRight.TabIndex = 9;
            this.RoadBoundaryRight.TabStop = false;
            // 
            // RoadBoundaryLeft
            // 
            this.RoadBoundaryLeft.BackColor = System.Drawing.Color.Yellow;
            this.RoadBoundaryLeft.Location = new System.Drawing.Point(222, -10);
            this.RoadBoundaryLeft.Name = "RoadBoundaryLeft";
            this.RoadBoundaryLeft.Size = new System.Drawing.Size(15, 464);
            this.RoadBoundaryLeft.TabIndex = 8;
            this.RoadBoundaryLeft.TabStop = false;
            // 
            // roadLine8
            // 
            this.roadLine8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roadLine8.Location = new System.Drawing.Point(449, 420);
            this.roadLine8.Name = "roadLine8";
            this.roadLine8.Size = new System.Drawing.Size(15, 121);
            this.roadLine8.TabIndex = 7;
            this.roadLine8.TabStop = false;
            // 
            // roadLine7
            // 
            this.roadLine7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roadLine7.Location = new System.Drawing.Point(449, 277);
            this.roadLine7.Name = "roadLine7";
            this.roadLine7.Size = new System.Drawing.Size(15, 121);
            this.roadLine7.TabIndex = 6;
            this.roadLine7.TabStop = false;
            // 
            // roadLine6
            // 
            this.roadLine6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roadLine6.Location = new System.Drawing.Point(449, 134);
            this.roadLine6.Name = "roadLine6";
            this.roadLine6.Size = new System.Drawing.Size(15, 121);
            this.roadLine6.TabIndex = 5;
            this.roadLine6.TabStop = false;
            // 
            // roadLine5
            // 
            this.roadLine5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roadLine5.Location = new System.Drawing.Point(449, -9);
            this.roadLine5.Name = "roadLine5";
            this.roadLine5.Size = new System.Drawing.Size(15, 121);
            this.roadLine5.TabIndex = 4;
            this.roadLine5.TabStop = false;
            // 
            // roadLine4
            // 
            this.roadLine4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roadLine4.Location = new System.Drawing.Point(336, 420);
            this.roadLine4.Name = "roadLine4";
            this.roadLine4.Size = new System.Drawing.Size(15, 121);
            this.roadLine4.TabIndex = 3;
            this.roadLine4.TabStop = false;
            // 
            // roadLine3
            // 
            this.roadLine3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roadLine3.Location = new System.Drawing.Point(337, 277);
            this.roadLine3.Name = "roadLine3";
            this.roadLine3.Size = new System.Drawing.Size(15, 121);
            this.roadLine3.TabIndex = 2;
            this.roadLine3.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.roadLine2);
            this.Controls.Add(this.roadLine1);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.RoadSpacerRight);
            this.Controls.Add(this.RoadSpacerLeft);
            this.Controls.Add(this.RoadBoundaryRight);
            this.Controls.Add(this.RoadBoundaryLeft);
            this.Controls.Add(this.roadLine8);
            this.Controls.Add(this.roadLine7);
            this.Controls.Add(this.roadLine6);
            this.Controls.Add(this.roadLine5);
            this.Controls.Add(this.roadLine4);
            this.Controls.Add(this.roadLine3);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.timer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadSpacerRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadSpacerLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadBoundaryRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoadBoundaryLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadLine3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox roadLine3;
        private System.Windows.Forms.PictureBox roadLine4;
        private System.Windows.Forms.PictureBox roadLine5;
        private System.Windows.Forms.PictureBox roadLine6;
        private System.Windows.Forms.PictureBox roadLine7;
        private System.Windows.Forms.PictureBox roadLine8;
        private System.Windows.Forms.PictureBox RoadBoundaryLeft;
        private System.Windows.Forms.PictureBox RoadBoundaryRight;
        private System.Timers.Timer timer2;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.PictureBox RoadSpacerRight;
        private System.Windows.Forms.PictureBox RoadSpacerLeft;
        private System.Windows.Forms.PictureBox roadLine1;
        private System.Windows.Forms.PictureBox roadLine2;
    }
}