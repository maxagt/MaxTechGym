namespace MaxTechGym
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.buscarAlumno = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Administracion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(409, 176);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(120, 83);
            this.btnEnroll.TabIndex = 3;
            this.btnEnroll.Text = "Agregar Asociado";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(157, 176);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(120, 83);
            this.btnIdentify.TabIndex = 1;
            this.btnIdentify.Text = "Asistencia";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // buscarAlumno
            // 
            this.buscarAlumno.Location = new System.Drawing.Point(283, 176);
            this.buscarAlumno.Name = "buscarAlumno";
            this.buscarAlumno.Size = new System.Drawing.Size(120, 83);
            this.buscarAlumno.TabIndex = 2;
            this.buscarAlumno.Text = "Buscar Asociado";
            this.buscarAlumno.UseVisualStyleBackColor = true;
            this.buscarAlumno.Click += new System.EventHandler(this.buscarAlumnos_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 83);
            this.button1.TabIndex = 4;
            this.button1.Text = "Reportes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Administracion
            // 
            this.Administracion.Location = new System.Drawing.Point(283, 265);
            this.Administracion.Name = "Administracion";
            this.Administracion.Size = new System.Drawing.Size(120, 83);
            this.Administracion.TabIndex = 5;
            this.Administracion.Text = "Administracion";
            this.Administracion.UseVisualStyleBackColor = true;
            this.Administracion.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MaxTechGym.Properties.Resources.ibarra_prom1;
            this.pictureBox1.Location = new System.Drawing.Point(234, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 130);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(674, 394);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Administracion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buscarAlumno);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.btnIdentify);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(690, 433);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(690, 433);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de administracion - Ibarra Boxing Promotions";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.Shown += new System.EventHandler(this.Form_Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnEnroll;
        internal System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button buscarAlumno;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Administracion;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}