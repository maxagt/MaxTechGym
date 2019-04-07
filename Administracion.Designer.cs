namespace MaxTechGym
{
    partial class Administracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administracion));
            this.AdminTabs = new System.Windows.Forms.TabControl();
            this.Precios = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.listaPrecios = new System.Windows.Forms.DataGridView();
            this.contextMenuPrecios = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarElementoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteElement = new System.Windows.Forms.ToolStripMenuItem();
            this.Envioemail = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.GuardarConfiguracion = new System.Windows.Forms.Button();
            this.generalConfig = new System.Windows.Forms.TabPage();
            this.offsetPicker = new System.Windows.Forms.NumericUpDown();
            this.hourOffset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.colorButton = new System.Windows.Forms.Button();
            this.color = new System.Windows.Forms.ColorDialog();
            this.file = new System.Windows.Forms.OpenFileDialog();
            this.AdminTabs.SuspendLayout();
            this.Precios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaPrecios)).BeginInit();
            this.contextMenuPrecios.SuspendLayout();
            this.Envioemail.SuspendLayout();
            this.generalConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminTabs
            // 
            this.AdminTabs.Controls.Add(this.Precios);
            this.AdminTabs.Controls.Add(this.Envioemail);
            this.AdminTabs.Controls.Add(this.generalConfig);
            this.AdminTabs.Location = new System.Drawing.Point(31, 35);
            this.AdminTabs.Margin = new System.Windows.Forms.Padding(2);
            this.AdminTabs.Name = "AdminTabs";
            this.AdminTabs.SelectedIndex = 0;
            this.AdminTabs.Size = new System.Drawing.Size(581, 500);
            this.AdminTabs.TabIndex = 2;
            // 
            // Precios
            // 
            this.Precios.BackColor = System.Drawing.Color.Gainsboro;
            this.Precios.Controls.Add(this.label9);
            this.Precios.Controls.Add(this.listaPrecios);
            this.Precios.Location = new System.Drawing.Point(4, 22);
            this.Precios.Margin = new System.Windows.Forms.Padding(2);
            this.Precios.Name = "Precios";
            this.Precios.Padding = new System.Windows.Forms.Padding(2);
            this.Precios.Size = new System.Drawing.Size(573, 474);
            this.Precios.TabIndex = 1;
            this.Precios.Text = "Precios y productos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(309, 430);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Boton derecho en la lista para mas opciones.";
            // 
            // listaPrecios
            // 
            this.listaPrecios.AllowUserToAddRows = false;
            this.listaPrecios.AllowUserToResizeRows = false;
            this.listaPrecios.BackgroundColor = System.Drawing.SystemColors.Control;
            this.listaPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaPrecios.ContextMenuStrip = this.contextMenuPrecios;
            this.listaPrecios.Location = new System.Drawing.Point(44, 30);
            this.listaPrecios.MultiSelect = false;
            this.listaPrecios.Name = "listaPrecios";
            this.listaPrecios.RowHeadersVisible = false;
            this.listaPrecios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listaPrecios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaPrecios.Size = new System.Drawing.Size(484, 397);
            this.listaPrecios.TabIndex = 2;
            this.listaPrecios.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.listaPrecios_CellMouseDown);
            this.listaPrecios.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.listaPrecios_EditingControlShowing);
            this.listaPrecios.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.listaPrecios_RowsRemoved);
            this.listaPrecios.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaPrecios_RowValidated);
            // 
            // contextMenuPrecios
            // 
            this.contextMenuPrecios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarElementoToolStripMenuItem,
            this.deleteElement});
            this.contextMenuPrecios.Name = "contextMenuPrecios";
            this.contextMenuPrecios.Size = new System.Drawing.Size(170, 48);
            this.contextMenuPrecios.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuPrecios_Opening);
            // 
            // agregarElementoToolStripMenuItem
            // 
            this.agregarElementoToolStripMenuItem.Name = "agregarElementoToolStripMenuItem";
            this.agregarElementoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.agregarElementoToolStripMenuItem.Text = "Agregar elemento";
            this.agregarElementoToolStripMenuItem.Click += new System.EventHandler(this.agregarElementoToolStripMenuItem_Click);
            // 
            // deleteElement
            // 
            this.deleteElement.Name = "deleteElement";
            this.deleteElement.Size = new System.Drawing.Size(169, 22);
            this.deleteElement.Text = "Borrar elemento";
            this.deleteElement.Click += new System.EventHandler(this.borrarElementoToolStripMenuItem_Click);
            // 
            // Envioemail
            // 
            this.Envioemail.BackColor = System.Drawing.Color.Gainsboro;
            this.Envioemail.Controls.Add(this.label7);
            this.Envioemail.Controls.Add(this.richTextBox2);
            this.Envioemail.Controls.Add(this.label1);
            this.Envioemail.Controls.Add(this.richTextBox1);
            this.Envioemail.Location = new System.Drawing.Point(4, 22);
            this.Envioemail.Margin = new System.Windows.Forms.Padding(2);
            this.Envioemail.Name = "Envioemail";
            this.Envioemail.Padding = new System.Windows.Forms.Padding(2);
            this.Envioemail.Size = new System.Drawing.Size(573, 474);
            this.Envioemail.TabIndex = 0;
            this.Envioemail.Text = "Configuracion de correos";
            this.Envioemail.Click += new System.EventHandler(this.Envioemail_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 255);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mensaje para mis archivos de venta";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(34, 271);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(500, 162);
            this.richTextBox2.TabIndex = 18;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mensaje para el cliente";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(34, 55);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(500, 159);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // GuardarConfiguracion
            // 
            this.GuardarConfiguracion.Location = new System.Drawing.Point(478, 558);
            this.GuardarConfiguracion.Margin = new System.Windows.Forms.Padding(2);
            this.GuardarConfiguracion.Name = "GuardarConfiguracion";
            this.GuardarConfiguracion.Size = new System.Drawing.Size(130, 25);
            this.GuardarConfiguracion.TabIndex = 6;
            this.GuardarConfiguracion.Text = "Guardar configuracion";
            this.GuardarConfiguracion.UseVisualStyleBackColor = true;
            // 
            // generalConfig
            // 
            this.generalConfig.Controls.Add(this.offsetPicker);
            this.generalConfig.Controls.Add(this.hourOffset);
            this.generalConfig.Controls.Add(this.button1);
            this.generalConfig.Controls.Add(this.colorButton);
            this.generalConfig.Location = new System.Drawing.Point(4, 22);
            this.generalConfig.Name = "generalConfig";
            this.generalConfig.Padding = new System.Windows.Forms.Padding(3);
            this.generalConfig.Size = new System.Drawing.Size(573, 474);
            this.generalConfig.TabIndex = 2;
            this.generalConfig.Text = "Configuracion general";
            this.generalConfig.UseVisualStyleBackColor = true;
            // 
            // offsetPicker
            // 
            this.offsetPicker.Location = new System.Drawing.Point(237, 147);
            this.offsetPicker.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.offsetPicker.Minimum = new decimal(new int[] {
            23,
            0,
            0,
            -2147483648});
            this.offsetPicker.Name = "offsetPicker";
            this.offsetPicker.Size = new System.Drawing.Size(82, 20);
            this.offsetPicker.TabIndex = 6;
            // 
            // hourOffset
            // 
            this.hourOffset.Location = new System.Drawing.Point(26, 144);
            this.hourOffset.Name = "hourOffset";
            this.hourOffset.Size = new System.Drawing.Size(164, 23);
            this.hourOffset.TabIndex = 5;
            this.hourOffset.Text = "Actualizar Desfase de horario";
            this.hourOffset.UseVisualStyleBackColor = true;
            this.hourOffset.Click += new System.EventHandler(this.hourOffset_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Seleccionar imagen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(26, 40);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(164, 23);
            this.colorButton.TabIndex = 0;
            this.colorButton.Text = "Selecciona color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // color
            // 
            this.color.AnyColor = true;
            this.color.FullOpen = true;
            // 
            // file
            // 
            this.file.FileName = "openFileDialog1";
            // 
            // Administracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(644, 623);
            this.Controls.Add(this.AdminTabs);
            this.Controls.Add(this.GuardarConfiguracion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Administracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.Administracion_Load);
            this.AdminTabs.ResumeLayout(false);
            this.Precios.ResumeLayout(false);
            this.Precios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaPrecios)).EndInit();
            this.contextMenuPrecios.ResumeLayout(false);
            this.Envioemail.ResumeLayout(false);
            this.Envioemail.PerformLayout();
            this.generalConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.offsetPicker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl AdminTabs;
        private System.Windows.Forms.TabPage Envioemail;
        private System.Windows.Forms.TabPage Precios;
        private System.Windows.Forms.Button GuardarConfiguracion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.DataGridView listaPrecios;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip contextMenuPrecios;
        private System.Windows.Forms.ToolStripMenuItem agregarElementoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteElement;
        private System.Windows.Forms.TabPage generalConfig;
        private System.Windows.Forms.ColorDialog color;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog file;
        private System.Windows.Forms.NumericUpDown offsetPicker;
        private System.Windows.Forms.Button hourOffset;
    }
}