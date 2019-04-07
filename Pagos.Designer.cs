namespace MaxTechGym
{
    partial class Pagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagos));
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreAlumno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.concepto = new System.Windows.Forms.ComboBox();
            this.formaPagoLabel = new System.Windows.Forms.Label();
            this.formaPagoCombo = new System.Windows.Forms.ComboBox();
            this.cantidadAPagar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.adeudo = new System.Windows.Forms.TextBox();
            this.botonPago = new System.Windows.Forms.Button();
            this.comentarios = new System.Windows.Forms.TextBox();
            this.comentariosLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(24, 20);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(110, 13);
            this.nombreLabel.TabIndex = 0;
            this.nombreLabel.Text = "Nombre del asociado:";
            // 
            // nombreAlumno
            // 
            this.nombreAlumno.AutoSize = true;
            this.nombreAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreAlumno.Location = new System.Drawing.Point(137, 20);
            this.nombreAlumno.Name = "nombreAlumno";
            this.nombreAlumno.Size = new System.Drawing.Size(150, 13);
            this.nombreAlumno.TabIndex = 1;
            this.nombreAlumno.Text = "Max Azael Gurrola Torres";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Concepto:";
            // 
            // concepto
            // 
            this.concepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.concepto.FormattingEnabled = true;
            this.concepto.Location = new System.Drawing.Point(27, 70);
            this.concepto.Name = "concepto";
            this.concepto.Size = new System.Drawing.Size(220, 21);
            this.concepto.TabIndex = 3;
            this.concepto.SelectedIndexChanged += new System.EventHandler(this.concepto_SelectedIndexChanged);
            // 
            // formaPagoLabel
            // 
            this.formaPagoLabel.AutoSize = true;
            this.formaPagoLabel.Location = new System.Drawing.Point(24, 101);
            this.formaPagoLabel.Name = "formaPagoLabel";
            this.formaPagoLabel.Size = new System.Drawing.Size(81, 13);
            this.formaPagoLabel.TabIndex = 4;
            this.formaPagoLabel.Text = "Forma de pago:";
            // 
            // formaPagoCombo
            // 
            this.formaPagoCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formaPagoCombo.FormattingEnabled = true;
            this.formaPagoCombo.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta",
            "Cheque"});
            this.formaPagoCombo.Location = new System.Drawing.Point(27, 117);
            this.formaPagoCombo.Name = "formaPagoCombo";
            this.formaPagoCombo.Size = new System.Drawing.Size(126, 21);
            this.formaPagoCombo.TabIndex = 5;
            // 
            // cantidadAPagar
            // 
            this.cantidadAPagar.Location = new System.Drawing.Point(285, 70);
            this.cantidadAPagar.Name = "cantidadAPagar";
            this.cantidadAPagar.Size = new System.Drawing.Size(107, 20);
            this.cantidadAPagar.TabIndex = 6;
            this.cantidadAPagar.Text = "0";
            this.cantidadAPagar.TextChanged += new System.EventHandler(this.cantidadAPagar_TextChanged);
            this.cantidadAPagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cantidadAPagar_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cantidad pagada:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "$";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Adeudo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "$";
            // 
            // adeudo
            // 
            this.adeudo.Location = new System.Drawing.Point(415, 70);
            this.adeudo.Name = "adeudo";
            this.adeudo.Size = new System.Drawing.Size(104, 20);
            this.adeudo.TabIndex = 10;
            this.adeudo.Text = "0";
            this.adeudo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.adeudo_KeyPress);
            // 
            // botonPago
            // 
            this.botonPago.Location = new System.Drawing.Point(529, 118);
            this.botonPago.Name = "botonPago";
            this.botonPago.Size = new System.Drawing.Size(104, 26);
            this.botonPago.TabIndex = 12;
            this.botonPago.Text = "Hacer pago";
            this.botonPago.UseVisualStyleBackColor = true;
            this.botonPago.Click += new System.EventHandler(this.botonPago_Click);
            // 
            // comentarios
            // 
            this.comentarios.Location = new System.Drawing.Point(182, 118);
            this.comentarios.Name = "comentarios";
            this.comentarios.Size = new System.Drawing.Size(220, 20);
            this.comentarios.TabIndex = 13;
            // 
            // comentariosLabel
            // 
            this.comentariosLabel.AutoSize = true;
            this.comentariosLabel.Location = new System.Drawing.Point(179, 101);
            this.comentariosLabel.Name = "comentariosLabel";
            this.comentariosLabel.Size = new System.Drawing.Size(68, 13);
            this.comentariosLabel.TabIndex = 14;
            this.comentariosLabel.Text = "Comentarios:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(535, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Fecha de pago:";
            // 
            // fecha
            // 
            this.fecha.CustomFormat = "dd/MM/yyyy";
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fecha.Location = new System.Drawing.Point(538, 70);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(95, 20);
            this.fecha.TabIndex = 16;
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 175);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comentariosLabel);
            this.Controls.Add(this.comentarios);
            this.Controls.Add(this.botonPago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.adeudo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cantidadAPagar);
            this.Controls.Add(this.formaPagoCombo);
            this.Controls.Add(this.formaPagoLabel);
            this.Controls.Add(this.concepto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nombreAlumno);
            this.Controls.Add(this.nombreLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.Pagos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.Label nombreAlumno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox concepto;
        private System.Windows.Forms.Label formaPagoLabel;
        private System.Windows.Forms.ComboBox formaPagoCombo;
        private System.Windows.Forms.TextBox cantidadAPagar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox adeudo;
        private System.Windows.Forms.Button botonPago;
        private System.Windows.Forms.TextBox comentarios;
        private System.Windows.Forms.Label comentariosLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker fecha;

    }
}