namespace Agar
{
    partial class Agar
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
            this.Kep = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.Kep)).BeginInit();
            this.SuspendLayout();
            // 
            // Kep
            // 
            this.Kep.Location = new System.Drawing.Point(12, 12);
            this.Kep.Name = "Kep";
            this.Kep.Size = new System.Drawing.Size(600, 600);
            this.Kep.TabIndex = 2;
            this.Kep.TabStop = false;
            this.Kep.Click += new System.EventHandler(this.Kep_Click);
            // 
            // Agar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 623);
            this.Controls.Add(this.Kep);
            this.KeyPreview = true;
            this.Name = "Agar";
            this.Text = "Agar";
            ((System.ComponentModel.ISupportInitialize)(this.Kep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox Kep;

    }
}

