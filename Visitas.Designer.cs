namespace MaxTechGym
{
    partial class Visitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visitas));
            this.listaVisitasBox = new System.Windows.Forms.ListBox();
            this.nombreAsociado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listaVisitasBox
            // 
            this.listaVisitasBox.FormattingEnabled = true;
            this.listaVisitasBox.Location = new System.Drawing.Point(27, 27);
            this.listaVisitasBox.Name = "listaVisitasBox";
            this.listaVisitasBox.ScrollAlwaysVisible = true;
            this.listaVisitasBox.Size = new System.Drawing.Size(303, 394);
            this.listaVisitasBox.TabIndex = 0;
            // 
            // nombreAsociado
            // 
            this.nombreAsociado.AutoSize = true;
            this.nombreAsociado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreAsociado.Location = new System.Drawing.Point(27, 8);
            this.nombreAsociado.Name = "nombreAsociado";
            this.nombreAsociado.Size = new System.Drawing.Size(48, 13);
            this.nombreAsociado.TabIndex = 1;
            this.nombreAsociado.Text = "nombre";
            // 
            // Visitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 447);
            this.Controls.Add(this.nombreAsociado);
            this.Controls.Add(this.listaVisitasBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(376, 486);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(376, 486);
            this.Name = "Visitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visitas del asociado";
            this.Load += new System.EventHandler(this.Visitas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listaVisitasBox;
        private System.Windows.Forms.Label nombreAsociado;
    }
}