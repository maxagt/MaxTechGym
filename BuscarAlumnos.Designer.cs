namespace MaxTechGym
{
    partial class BuscarAlumnos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarAlumnos));
            this.listaAlumnos = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.realizarPago = new System.Windows.Forms.ToolStripMenuItem();
            this.editar = new System.Windows.Forms.ToolStripMenuItem();
            this.verVisitas = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarBox = new System.Windows.Forms.TextBox();
            this.buscarAlumno = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.detalleDeAsociadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.listaAlumnos)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaAlumnos
            // 
            this.listaAlumnos.AllowUserToAddRows = false;
            this.listaAlumnos.AllowUserToDeleteRows = false;
            this.listaAlumnos.AllowUserToResizeRows = false;
            this.listaAlumnos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.listaAlumnos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.nombre,
            this.edad,
            this.email});
            this.listaAlumnos.Location = new System.Drawing.Point(65, 80);
            this.listaAlumnos.MultiSelect = false;
            this.listaAlumnos.Name = "listaAlumnos";
            this.listaAlumnos.ReadOnly = true;
            this.listaAlumnos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.listaAlumnos.RowHeadersVisible = false;
            this.listaAlumnos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listaAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaAlumnos.Size = new System.Drawing.Size(650, 355);
            this.listaAlumnos.TabIndex = 3;
            this.listaAlumnos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.listaAlumnos_CellMouseDown);
            // 
            // numero
            // 
            this.numero.HeaderText = "Numero";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 70;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nombre.Width = 300;
            // 
            // edad
            // 
            this.edad.HeaderText = "Edad";
            this.edad.Name = "edad";
            this.edad.ReadOnly = true;
            this.edad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.edad.Width = 70;
            // 
            // email
            // 
            this.email.HeaderText = "Correo electronico";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 200;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realizarPago,
            this.editar,
            this.verVisitas,
            this.detalleDeAsociadoToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(181, 114);
            // 
            // realizarPago
            // 
            this.realizarPago.Name = "realizarPago";
            this.realizarPago.Size = new System.Drawing.Size(180, 22);
            this.realizarPago.Text = "Realizar pago";
            this.realizarPago.Click += new System.EventHandler(this.realizarPago_Click);
            // 
            // editar
            // 
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(180, 22);
            this.editar.Text = "Editar";
            this.editar.Click += new System.EventHandler(this.editar_Click);
            // 
            // verVisitas
            // 
            this.verVisitas.Name = "verVisitas";
            this.verVisitas.Size = new System.Drawing.Size(180, 22);
            this.verVisitas.Text = "Ver visitas";
            this.verVisitas.Click += new System.EventHandler(this.verVisitas_Click);
            // 
            // buscarBox
            // 
            this.buscarBox.Location = new System.Drawing.Point(65, 33);
            this.buscarBox.Name = "buscarBox";
            this.buscarBox.Size = new System.Drawing.Size(205, 20);
            this.buscarBox.TabIndex = 1;
            this.buscarBox.Enter += new System.EventHandler(this.buscarBox_Enter);
            // 
            // buscarAlumno
            // 
            this.buscarAlumno.Location = new System.Drawing.Point(276, 32);
            this.buscarAlumno.Name = "buscarAlumno";
            this.buscarAlumno.Size = new System.Drawing.Size(76, 21);
            this.buscarAlumno.TabIndex = 2;
            this.buscarAlumno.Text = "Buscar";
            this.buscarAlumno.UseVisualStyleBackColor = true;
            this.buscarAlumno.Click += new System.EventHandler(this.buscarAlumno_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Buscar por nombre o numero:";
            // 
            // detalleDeAsociadoToolStripMenuItem
            // 
            this.detalleDeAsociadoToolStripMenuItem.Name = "detalleDeAsociadoToolStripMenuItem";
            this.detalleDeAsociadoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.detalleDeAsociadoToolStripMenuItem.Text = "Detalle de asociado";
            this.detalleDeAsociadoToolStripMenuItem.Click += new System.EventHandler(this.detalleDeAsociadoToolStripMenuItem_Click);
            // 
            // BuscarAlumnos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buscarAlumno);
            this.Controls.Add(this.buscarBox);
            this.Controls.Add(this.listaAlumnos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "BuscarAlumnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda de asociados";
            this.Closed += new System.EventHandler(this.BuscarAlumnos_Closed);
            this.Load += new System.EventHandler(this.BuscarAlumnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaAlumnos)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listaAlumnos;
        private System.Windows.Forms.TextBox buscarBox;
        private System.Windows.Forms.Button buscarAlumno;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem editar;
        private System.Windows.Forms.ToolStripMenuItem realizarPago;
        private System.Windows.Forms.ToolStripMenuItem verVisitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem detalleDeAsociadoToolStripMenuItem;
    }
}