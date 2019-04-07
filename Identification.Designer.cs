namespace MaxTechGym
{
    partial class Identification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Identification));
            this.pbFingerprint = new System.Windows.Forms.PictureBox();
            this.nombre = new System.Windows.Forms.Label();
            this.adeudos = new System.Windows.Forms.Label();
            this.totalVisitas = new System.Windows.Forms.Label();
            this.vencimiento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.detalleAlumno = new System.Windows.Forms.GroupBox();
            this.asistencia = new System.Windows.Forms.Label();
            this.adeudoDesc = new System.Windows.Forms.Label();
            this.vencimientoDesc = new System.Windows.Forms.Label();
            this.ultimaVisitaDesc = new System.Windows.Forms.Label();
            this.totalVisitasDesc = new System.Windows.Forms.Label();
            this.noAsociadoDesc = new System.Windows.Forms.Label();
            this.adeudo = new System.Windows.Forms.Label();
            this.nombreDesc = new System.Windows.Forms.Label();
            this.noAsociado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).BeginInit();
            this.detalleAlumno.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFingerprint
            // 
            this.pbFingerprint.BackColor = System.Drawing.Color.White;
            this.pbFingerprint.Location = new System.Drawing.Point(653, 12);
            this.pbFingerprint.Name = "pbFingerprint";
            this.pbFingerprint.Size = new System.Drawing.Size(343, 340);
            this.pbFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFingerprint.TabIndex = 7;
            this.pbFingerprint.TabStop = false;
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre.Location = new System.Drawing.Point(17, 30);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(125, 31);
            this.nombre.TabIndex = 8;
            this.nombre.Text = "Nombre:";
            // 
            // adeudos
            // 
            this.adeudos.AutoSize = true;
            this.adeudos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adeudos.Location = new System.Drawing.Point(17, 242);
            this.adeudos.Name = "adeudos";
            this.adeudos.Size = new System.Drawing.Size(122, 31);
            this.adeudos.TabIndex = 9;
            this.adeudos.Text = "Adeudo:";
            // 
            // totalVisitas
            // 
            this.totalVisitas.AutoSize = true;
            this.totalVisitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVisitas.Location = new System.Drawing.Point(17, 112);
            this.totalVisitas.Name = "totalVisitas";
            this.totalVisitas.Size = new System.Drawing.Size(225, 31);
            this.totalVisitas.TabIndex = 10;
            this.totalVisitas.Text = "Total de Visitas:";
            // 
            // vencimiento
            // 
            this.vencimiento.AutoSize = true;
            this.vencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vencimiento.Location = new System.Drawing.Point(17, 197);
            this.vencimiento.Name = "vencimiento";
            this.vencimiento.Size = new System.Drawing.Size(183, 31);
            this.vencimiento.TabIndex = 11;
            this.vencimiento.Text = "Vencimiento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ultima visita:";
            // 
            // detalleAlumno
            // 
            this.detalleAlumno.Controls.Add(this.asistencia);
            this.detalleAlumno.Controls.Add(this.adeudoDesc);
            this.detalleAlumno.Controls.Add(this.vencimientoDesc);
            this.detalleAlumno.Controls.Add(this.ultimaVisitaDesc);
            this.detalleAlumno.Controls.Add(this.totalVisitasDesc);
            this.detalleAlumno.Controls.Add(this.noAsociadoDesc);
            this.detalleAlumno.Controls.Add(this.adeudo);
            this.detalleAlumno.Controls.Add(this.nombreDesc);
            this.detalleAlumno.Controls.Add(this.noAsociado);
            this.detalleAlumno.Controls.Add(this.label1);
            this.detalleAlumno.Controls.Add(this.vencimiento);
            this.detalleAlumno.Controls.Add(this.totalVisitas);
            this.detalleAlumno.Controls.Add(this.adeudos);
            this.detalleAlumno.Controls.Add(this.nombre);
            this.detalleAlumno.Location = new System.Drawing.Point(21, 12);
            this.detalleAlumno.Name = "detalleAlumno";
            this.detalleAlumno.Size = new System.Drawing.Size(613, 340);
            this.detalleAlumno.TabIndex = 14;
            this.detalleAlumno.TabStop = false;
            this.detalleAlumno.Text = "Detalle del alumno";
            // 
            // asistencia
            // 
            this.asistencia.AutoSize = true;
            this.asistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asistencia.ForeColor = System.Drawing.Color.Green;
            this.asistencia.Location = new System.Drawing.Point(302, 297);
            this.asistencia.Name = "asistencia";
            this.asistencia.Size = new System.Drawing.Size(288, 31);
            this.asistencia.TabIndex = 22;
            this.asistencia.Text = "Asistencia registrada";
            this.asistencia.Visible = false;
            // 
            // adeudoDesc
            // 
            this.adeudoDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adeudoDesc.ForeColor = System.Drawing.SystemColors.Desktop;
            this.adeudoDesc.Location = new System.Drawing.Point(0, 0);
            this.adeudoDesc.Name = "adeudoDesc";
            this.adeudoDesc.Size = new System.Drawing.Size(139, 23);
            this.adeudoDesc.TabIndex = 23;
            this.adeudoDesc.Text = "Detalle del Asociado";
            // 
            // vencimientoDesc
            // 
            this.vencimientoDesc.AutoSize = true;
            this.vencimientoDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vencimientoDesc.Location = new System.Drawing.Point(195, 197);
            this.vencimientoDesc.Name = "vencimientoDesc";
            this.vencimientoDesc.Size = new System.Drawing.Size(0, 31);
            this.vencimientoDesc.TabIndex = 20;
            // 
            // ultimaVisitaDesc
            // 
            this.ultimaVisitaDesc.AutoSize = true;
            this.ultimaVisitaDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultimaVisitaDesc.Location = new System.Drawing.Point(195, 154);
            this.ultimaVisitaDesc.Name = "ultimaVisitaDesc";
            this.ultimaVisitaDesc.Size = new System.Drawing.Size(0, 31);
            this.ultimaVisitaDesc.TabIndex = 19;
            // 
            // totalVisitasDesc
            // 
            this.totalVisitasDesc.AutoSize = true;
            this.totalVisitasDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalVisitasDesc.Location = new System.Drawing.Point(237, 112);
            this.totalVisitasDesc.Name = "totalVisitasDesc";
            this.totalVisitasDesc.Size = new System.Drawing.Size(0, 31);
            this.totalVisitasDesc.TabIndex = 18;
            // 
            // noAsociadoDesc
            // 
            this.noAsociadoDesc.AutoSize = true;
            this.noAsociadoDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noAsociadoDesc.Location = new System.Drawing.Point(302, 71);
            this.noAsociadoDesc.Name = "noAsociadoDesc";
            this.noAsociadoDesc.Size = new System.Drawing.Size(0, 31);
            this.noAsociadoDesc.TabIndex = 17;
            // 
            // adeudo
            // 
            this.adeudo.AutoSize = true;
            this.adeudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adeudo.Location = new System.Drawing.Point(135, 241);
            this.adeudo.Name = "adeudo";
            this.adeudo.Size = new System.Drawing.Size(0, 31);
            this.adeudo.TabIndex = 16;
            // 
            // nombreDesc
            // 
            this.nombreDesc.AutoSize = true;
            this.nombreDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreDesc.Location = new System.Drawing.Point(137, 30);
            this.nombreDesc.Name = "nombreDesc";
            this.nombreDesc.Size = new System.Drawing.Size(0, 31);
            this.nombreDesc.TabIndex = 15;
            // 
            // noAsociado
            // 
            this.noAsociado.AutoSize = true;
            this.noAsociado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noAsociado.Location = new System.Drawing.Point(17, 71);
            this.noAsociado.Name = "noAsociado";
            this.noAsociado.Size = new System.Drawing.Size(290, 31);
            this.noAsociado.TabIndex = 14;
            this.noAsociado.Text = "Numero de asociado:";
            // 
            // Identification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1008, 381);
            this.Controls.Add(this.detalleAlumno);
            this.Controls.Add(this.pbFingerprint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 420);
            this.MinimumSize = new System.Drawing.Size(1024, 420);
            this.Name = "Identification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asistencia";
            this.TopMost = true;
            this.Closed += new System.EventHandler(this.Identification_Closed);
            this.Load += new System.EventHandler(this.Identification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerprint)).EndInit();
            this.detalleAlumno.ResumeLayout(false);
            this.detalleAlumno.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox pbFingerprint;
        private System.Windows.Forms.Label nombre;
        private System.Windows.Forms.Label adeudos;
        private System.Windows.Forms.Label totalVisitas;
        private System.Windows.Forms.Label vencimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox detalleAlumno;
        private System.Windows.Forms.Label noAsociado;
        private System.Windows.Forms.Label asistencia;
        private System.Windows.Forms.Label adeudoDesc;
        private System.Windows.Forms.Label vencimientoDesc;
        private System.Windows.Forms.Label ultimaVisitaDesc;
        private System.Windows.Forms.Label totalVisitasDesc;
        private System.Windows.Forms.Label noAsociadoDesc;
        private System.Windows.Forms.Label adeudo;
        private System.Windows.Forms.Label nombreDesc;
    }
}