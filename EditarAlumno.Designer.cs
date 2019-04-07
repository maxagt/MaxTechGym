namespace MaxTechGym
{
    partial class EditarAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarAlumno));
            this.txtEnroll = new System.Windows.Forms.TextBox();
            this.registrarAlumno = new System.Windows.Forms.Button();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.fechaNacimientoLabel = new System.Windows.Forms.Label();
            this.fechaNacimientoBox = new System.Windows.Forms.DateTimePicker();
            this.generoBox = new System.Windows.Forms.ComboBox();
            this.generoLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.comoLabel = new System.Windows.Forms.Label();
            this.comoBox = new System.Windows.Forms.ComboBox();
            this.telefonoLabel = new System.Windows.Forms.Label();
            this.telefonoBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.municipioBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.calleLabel = new System.Windows.Forms.Label();
            this.fechaCortePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEnroll
            // 
            this.txtEnroll.Enabled = false;
            this.txtEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnroll.Location = new System.Drawing.Point(24, 286);
            this.txtEnroll.Multiline = true;
            this.txtEnroll.Name = "txtEnroll";
            this.txtEnroll.Size = new System.Drawing.Size(355, 94);
            this.txtEnroll.TabIndex = 10;
            // 
            // registrarAlumno
            // 
            this.registrarAlumno.Enabled = false;
            this.registrarAlumno.Location = new System.Drawing.Point(701, 370);
            this.registrarAlumno.Name = "registrarAlumno";
            this.registrarAlumno.Size = new System.Drawing.Size(113, 23);
            this.registrarAlumno.TabIndex = 11;
            this.registrarAlumno.Text = "Actualizar datos";
            this.registrarAlumno.UseVisualStyleBackColor = true;
            this.registrarAlumno.Click += new System.EventHandler(this.registrarAlumno_Click);
            // 
            // nombreBox
            // 
            this.nombreBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreBox.Location = new System.Drawing.Point(24, 45);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(264, 20);
            this.nombreBox.TabIndex = 1;
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreLabel.Location = new System.Drawing.Point(21, 29);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(93, 13);
            this.nombreLabel.TabIndex = 13;
            this.nombreLabel.Text = "Nombre completo:";
            // 
            // fechaNacimientoLabel
            // 
            this.fechaNacimientoLabel.AutoSize = true;
            this.fechaNacimientoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaNacimientoLabel.Location = new System.Drawing.Point(21, 77);
            this.fechaNacimientoLabel.Name = "fechaNacimientoLabel";
            this.fechaNacimientoLabel.Size = new System.Drawing.Size(109, 13);
            this.fechaNacimientoLabel.TabIndex = 14;
            this.fechaNacimientoLabel.Text = "Fecha de nacimiento:";
            // 
            // fechaNacimientoBox
            // 
            this.fechaNacimientoBox.CustomFormat = "dd/MM/yyyy";
            this.fechaNacimientoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaNacimientoBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaNacimientoBox.Location = new System.Drawing.Point(24, 93);
            this.fechaNacimientoBox.Name = "fechaNacimientoBox";
            this.fechaNacimientoBox.Size = new System.Drawing.Size(119, 20);
            this.fechaNacimientoBox.TabIndex = 2;
            this.fechaNacimientoBox.Value = new System.DateTime(2014, 1, 11, 2, 28, 11, 0);
            // 
            // generoBox
            // 
            this.generoBox.AccessibleDescription = "";
            this.generoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.generoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generoBox.FormattingEnabled = true;
            this.generoBox.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.generoBox.Location = new System.Drawing.Point(24, 142);
            this.generoBox.Name = "generoBox";
            this.generoBox.Size = new System.Drawing.Size(134, 21);
            this.generoBox.TabIndex = 3;
            // 
            // generoLabel
            // 
            this.generoLabel.AutoSize = true;
            this.generoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generoLabel.Location = new System.Drawing.Point(21, 126);
            this.generoLabel.Name = "generoLabel";
            this.generoLabel.Size = new System.Drawing.Size(45, 13);
            this.generoLabel.TabIndex = 16;
            this.generoLabel.Text = "Genero:";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(21, 171);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(96, 13);
            this.emailLabel.TabIndex = 17;
            this.emailLabel.Text = "Correo electronico:";
            // 
            // emailBox
            // 
            this.emailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailBox.Location = new System.Drawing.Point(24, 187);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(170, 20);
            this.emailBox.TabIndex = 4;
            // 
            // comoLabel
            // 
            this.comoLabel.AutoSize = true;
            this.comoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comoLabel.Location = new System.Drawing.Point(21, 220);
            this.comoLabel.Name = "comoLabel";
            this.comoLabel.Size = new System.Drawing.Size(96, 13);
            this.comoLabel.TabIndex = 19;
            this.comoLabel.Text = "Como te enteraste:";
            // 
            // comoBox
            // 
            this.comoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comoBox.FormattingEnabled = true;
            this.comoBox.Items.AddRange(new object[] {
            "Recomendacion",
            "Vive o pasa por aqui",
            "Revista",
            "Facebook",
            "Volante",
            "Otro"});
            this.comoBox.Location = new System.Drawing.Point(24, 236);
            this.comoBox.Name = "comoBox";
            this.comoBox.Size = new System.Drawing.Size(134, 21);
            this.comoBox.TabIndex = 5;
            // 
            // telefonoLabel
            // 
            this.telefonoLabel.AutoSize = true;
            this.telefonoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonoLabel.Location = new System.Drawing.Point(6, 126);
            this.telefonoLabel.Name = "telefonoLabel";
            this.telefonoLabel.Size = new System.Drawing.Size(52, 13);
            this.telefonoLabel.TabIndex = 21;
            this.telefonoLabel.Text = "Telefono:";
            // 
            // telefonoBox
            // 
            this.telefonoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonoBox.Location = new System.Drawing.Point(9, 143);
            this.telefonoBox.Name = "telefonoBox";
            this.telefonoBox.Size = new System.Drawing.Size(133, 20);
            this.telefonoBox.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comoBox);
            this.groupBox1.Controls.Add(this.txtEnroll);
            this.groupBox1.Controls.Add(this.comoLabel);
            this.groupBox1.Controls.Add(this.emailBox);
            this.groupBox1.Controls.Add(this.emailLabel);
            this.groupBox1.Controls.Add(this.generoLabel);
            this.groupBox1.Controls.Add(this.generoBox);
            this.groupBox1.Controls.Add(this.fechaNacimientoBox);
            this.groupBox1.Controls.Add(this.fechaNacimientoLabel);
            this.groupBox1.Controls.Add(this.nombreLabel);
            this.groupBox1.Controls.Add(this.nombreBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 412);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos generales";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(25, 386);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 17);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "Actualizar huella";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Captura de huella digital:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.municipioBox);
            this.groupBox2.Controls.Add(this.telefonoLabel);
            this.groupBox2.Controls.Add(this.telefonoBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.direccion);
            this.groupBox2.Controls.Add(this.calleLabel);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(433, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 184);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Domicilio";
            // 
            // municipioBox
            // 
            this.municipioBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.municipioBox.Location = new System.Drawing.Point(9, 96);
            this.municipioBox.Name = "municipioBox";
            this.municipioBox.Size = new System.Drawing.Size(139, 20);
            this.municipioBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Municipio:";
            // 
            // direccion
            // 
            this.direccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direccion.Location = new System.Drawing.Point(9, 45);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(303, 20);
            this.direccion.TabIndex = 6;
            // 
            // calleLabel
            // 
            this.calleLabel.AutoSize = true;
            this.calleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calleLabel.Location = new System.Drawing.Point(6, 29);
            this.calleLabel.Name = "calleLabel";
            this.calleLabel.Size = new System.Drawing.Size(166, 13);
            this.calleLabel.TabIndex = 0;
            this.calleLabel.Text = "Direccion, calle numero y colonia:";
            // 
            // fechaCortePicker
            // 
            this.fechaCortePicker.CustomFormat = "dd/MM/yyyy";
            this.fechaCortePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaCortePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaCortePicker.Location = new System.Drawing.Point(9, 45);
            this.fechaCortePicker.Name = "fechaCortePicker";
            this.fechaCortePicker.Size = new System.Drawing.Size(119, 20);
            this.fechaCortePicker.TabIndex = 22;
            this.fechaCortePicker.Value = new System.DateTime(2014, 1, 11, 2, 28, 11, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Fecha de corte:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fechaCortePicker);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(433, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(379, 91);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estatus";
            // 
            // EditarAlumno
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(851, 437);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.registrarAlumno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar datos de asociado";
            this.Closed += new System.EventHandler(this.EditarAlumno_Closed);
            this.Load += new System.EventHandler(this.EditarAlumno_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.TextBox txtEnroll;
        private System.Windows.Forms.Button registrarAlumno;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.Label fechaNacimientoLabel;
        private System.Windows.Forms.DateTimePicker fechaNacimientoBox;
        private System.Windows.Forms.ComboBox generoBox;
        private System.Windows.Forms.Label generoLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label comoLabel;
        private System.Windows.Forms.ComboBox comoBox;
        private System.Windows.Forms.Label telefonoLabel;
        private System.Windows.Forms.TextBox telefonoBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox municipioBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label calleLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker fechaCortePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}