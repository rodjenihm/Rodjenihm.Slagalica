namespace Rodjenihm.Slagalica
{
    partial class PlayForm
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
            this.gbInputLetters = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gbInputLetters
            // 
            this.gbInputLetters.Location = new System.Drawing.Point(23, 61);
            this.gbInputLetters.Name = "gbInputLetters";
            this.gbInputLetters.Size = new System.Drawing.Size(725, 100);
            this.gbInputLetters.TabIndex = 0;
            this.gbInputLetters.TabStop = false;
            this.gbInputLetters.Text = "Slova";
            // 
            // PlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbInputLetters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PlayForm";
            this.Text = "Slagalica - Igraj";
            this.Load += new System.EventHandler(this.PlayForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInputLetters;
    }
}