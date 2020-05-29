namespace Snake
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblScore = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblHighScore = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.pictureBox.Location = new System.Drawing.Point(24, 14);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(620, 632);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(650, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Score:";
			// 
			// lblScore
			// 
			this.lblScore.AutoSize = true;
			this.lblScore.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblScore.Location = new System.Drawing.Point(730, 13);
			this.lblScore.Name = "lblScore";
			this.lblScore.Size = new System.Drawing.Size(22, 23);
			this.lblScore.TabIndex = 2;
			this.lblScore.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(650, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Highscore:";
			// 
			// lblHighScore
			// 
			this.lblHighScore.AutoSize = true;
			this.lblHighScore.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHighScore.Location = new System.Drawing.Point(773, 38);
			this.lblHighScore.Name = "lblHighScore";
			this.lblHighScore.Size = new System.Drawing.Size(22, 23);
			this.lblHighScore.TabIndex = 4;
			this.lblHighScore.Text = "0";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(883, 661);
			this.Controls.Add(this.lblHighScore);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblScore);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Snake";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblScore;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblHighScore;
	}
}

