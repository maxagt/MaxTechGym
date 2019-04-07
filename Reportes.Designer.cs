namespace MaxTechGym
{
    partial class Reportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reportes));
            this.Menu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listaAlumnos = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdeudoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buscar = new System.Windows.Forms.Button();
            this.edad_hasta = new System.Windows.Forms.ComboBox();
            this.edad_de = new System.Windows.Forms.ComboBox();
            this.estatus = new System.Windows.Forms.ComboBox();
            this.sexo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.internet = new System.Windows.Forms.TabPage();
            this.calculoUtilidades = new System.Windows.Forms.Button();
            this.utilidadesNetas = new System.Windows.Forms.Label();
            this.totalDeGastos = new System.Windows.Forms.Label();
            this.GastosLabel = new System.Windows.Forms.Label();
            this.Otros = new System.Windows.Forms.Label();
            this.OtrosTextBox = new System.Windows.Forms.TextBox();
            this.Recepcion = new System.Windows.Forms.Label();
            this.RecepcionTextBox = new System.Windows.Forms.TextBox();
            this.Publicidad = new System.Windows.Forms.Label();
            this.PublicidadTextBox = new System.Windows.Forms.TextBox();
            this.AuxiliarCoach = new System.Windows.Forms.Label();
            this.AuxiliarCoachTextBox = new System.Windows.Forms.TextBox();
            this.Nutriologa = new System.Windows.Forms.Label();
            this.NutriologaTextBox = new System.Windows.Forms.TextBox();
            this.SueldoCoach = new System.Windows.Forms.Label();
            this.SueldoCochTextBox = new System.Windows.Forms.TextBox();
            this.limpieza = new System.Windows.Forms.Label();
            this.LimpiezaTextBox = new System.Windows.Forms.TextBox();
            this.Cable = new System.Windows.Forms.Label();
            this.InterenetTextBox = new System.Windows.Forms.TextBox();
            this.Agua = new System.Windows.Forms.Label();
            this.AguaTextBox = new System.Windows.Forms.TextBox();
            this.luz = new System.Windows.Forms.Label();
            this.LuzTextBox = new System.Windows.Forms.TextBox();
            this.renta = new System.Windows.Forms.Label();
            this.RentaTextBox = new System.Windows.Forms.TextBox();
            this.adeudosNuevosLabel = new System.Windows.Forms.Label();
            this.adeudosPagadosLabel = new System.Windows.Forms.Label();
            this.AdeudoLabel = new System.Windows.Forms.Label();
            this.totalAPagarLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.buscaPagos = new System.Windows.Forms.Button();
            this.listaPagos = new System.Windows.Forms.DataGridView();
            this.asociado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPago = new System.Windows.Forms.ComboBox();
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.dateInicio = new System.Windows.Forms.DateTimePicker();
            this.formaPago = new System.Windows.Forms.Label();
            this.fin = new System.Windows.Forms.Label();
            this.inicio = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.visitaspicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.listaDeVisitas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adeudo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaAlumnos)).BeginInit();
            this.internet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaPagos)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaDeVisitas)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.tabPage1);
            this.Menu.Controls.Add(this.internet);
            this.Menu.Controls.Add(this.tabPage2);
            this.Menu.Location = new System.Drawing.Point(24, 21);
            this.Menu.Name = "Menu";
            this.Menu.SelectedIndex = 0;
            this.Menu.Size = new System.Drawing.Size(832, 555);
            this.Menu.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.listaAlumnos);
            this.tabPage1.Controls.Add(this.buscar);
            this.tabPage1.Controls.Add(this.edad_hasta);
            this.tabPage1.Controls.Add(this.edad_de);
            this.tabPage1.Controls.Add(this.estatus);
            this.tabPage1.Controls.Add(this.sexo);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(824, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Asociados";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // listaAlumnos
            // 
            this.listaAlumnos.AllowUserToAddRows = false;
            this.listaAlumnos.AllowUserToDeleteRows = false;
            this.listaAlumnos.AllowUserToResizeColumns = false;
            this.listaAlumnos.AllowUserToResizeRows = false;
            this.listaAlumnos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.Nombre,
            this.fechaVencimiento,
            this.AdeudoCol});
            this.listaAlumnos.Location = new System.Drawing.Point(300, 21);
            this.listaAlumnos.Name = "listaAlumnos";
            this.listaAlumnos.RowHeadersVisible = false;
            this.listaAlumnos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listaAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaAlumnos.Size = new System.Drawing.Size(518, 412);
            this.listaAlumnos.TabIndex = 8;
            // 
            // numero
            // 
            this.numero.HeaderText = "Numero";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 50;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nombre.Width = 250;
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.HeaderText = "Fecha de Vencimiento";
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.ReadOnly = true;
            this.fechaVencimiento.Width = 140;
            // 
            // AdeudoCol
            // 
            this.AdeudoCol.HeaderText = "Adeudo";
            this.AdeudoCol.Name = "AdeudoCol";
            this.AdeudoCol.ReadOnly = true;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(173, 174);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(85, 26);
            this.buscar.TabIndex = 7;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // edad_hasta
            // 
            this.edad_hasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edad_hasta.FormattingEnabled = true;
            this.edad_hasta.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90"});
            this.edad_hasta.Location = new System.Drawing.Point(201, 113);
            this.edad_hasta.Name = "edad_hasta";
            this.edad_hasta.Size = new System.Drawing.Size(57, 21);
            this.edad_hasta.TabIndex = 6;
            // 
            // edad_de
            // 
            this.edad_de.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edad_de.FormattingEnabled = true;
            this.edad_de.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90"});
            this.edad_de.Location = new System.Drawing.Point(138, 113);
            this.edad_de.Name = "edad_de";
            this.edad_de.Size = new System.Drawing.Size(57, 21);
            this.edad_de.TabIndex = 5;
            // 
            // estatus
            // 
            this.estatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.estatus.FormattingEnabled = true;
            this.estatus.Items.AddRange(new object[] {
            "Todos",
            "Vigente",
            "Vencido",
            "Adeudo"});
            this.estatus.Location = new System.Drawing.Point(136, 76);
            this.estatus.Name = "estatus";
            this.estatus.Size = new System.Drawing.Size(121, 21);
            this.estatus.TabIndex = 4;
            // 
            // sexo
            // 
            this.sexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexo.FormattingEnabled = true;
            this.sexo.Items.AddRange(new object[] {
            "Todos",
            "Masculino",
            "Femenino"});
            this.sexo.Location = new System.Drawing.Point(136, 43);
            this.sexo.Name = "sexo";
            this.sexo.Size = new System.Drawing.Size(121, 21);
            this.sexo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Edad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estatus pago:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sexo:";
            // 
            // internet
            // 
            this.internet.BackColor = System.Drawing.Color.Transparent;
            this.internet.Controls.Add(this.calculoUtilidades);
            this.internet.Controls.Add(this.utilidadesNetas);
            this.internet.Controls.Add(this.totalDeGastos);
            this.internet.Controls.Add(this.GastosLabel);
            this.internet.Controls.Add(this.Otros);
            this.internet.Controls.Add(this.OtrosTextBox);
            this.internet.Controls.Add(this.Recepcion);
            this.internet.Controls.Add(this.RecepcionTextBox);
            this.internet.Controls.Add(this.Publicidad);
            this.internet.Controls.Add(this.PublicidadTextBox);
            this.internet.Controls.Add(this.AuxiliarCoach);
            this.internet.Controls.Add(this.AuxiliarCoachTextBox);
            this.internet.Controls.Add(this.Nutriologa);
            this.internet.Controls.Add(this.NutriologaTextBox);
            this.internet.Controls.Add(this.SueldoCoach);
            this.internet.Controls.Add(this.SueldoCochTextBox);
            this.internet.Controls.Add(this.limpieza);
            this.internet.Controls.Add(this.LimpiezaTextBox);
            this.internet.Controls.Add(this.Cable);
            this.internet.Controls.Add(this.InterenetTextBox);
            this.internet.Controls.Add(this.Agua);
            this.internet.Controls.Add(this.AguaTextBox);
            this.internet.Controls.Add(this.luz);
            this.internet.Controls.Add(this.LuzTextBox);
            this.internet.Controls.Add(this.renta);
            this.internet.Controls.Add(this.RentaTextBox);
            this.internet.Controls.Add(this.adeudosNuevosLabel);
            this.internet.Controls.Add(this.adeudosPagadosLabel);
            this.internet.Controls.Add(this.AdeudoLabel);
            this.internet.Controls.Add(this.totalAPagarLabel);
            this.internet.Controls.Add(this.totalLabel);
            this.internet.Controls.Add(this.buscaPagos);
            this.internet.Controls.Add(this.listaPagos);
            this.internet.Controls.Add(this.tipoPago);
            this.internet.Controls.Add(this.dateFin);
            this.internet.Controls.Add(this.dateInicio);
            this.internet.Controls.Add(this.formaPago);
            this.internet.Controls.Add(this.fin);
            this.internet.Controls.Add(this.inicio);
            this.internet.Location = new System.Drawing.Point(4, 22);
            this.internet.Name = "internet";
            this.internet.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.internet.Size = new System.Drawing.Size(824, 529);
            this.internet.TabIndex = 2;
            this.internet.Text = "Utilidad";
            this.internet.Click += new System.EventHandler(this.internet_Click);
            // 
            // calculoUtilidades
            // 
            this.calculoUtilidades.Location = new System.Drawing.Point(695, 492);
            this.calculoUtilidades.Name = "calculoUtilidades";
            this.calculoUtilidades.Size = new System.Drawing.Size(112, 24);
            this.calculoUtilidades.TabIndex = 16;
            this.calculoUtilidades.Text = "Calcular utilidades";
            this.calculoUtilidades.UseVisualStyleBackColor = true;
            this.calculoUtilidades.Click += new System.EventHandler(this.calculoUtilidades_Click);
            // 
            // utilidadesNetas
            // 
            this.utilidadesNetas.AutoSize = true;
            this.utilidadesNetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilidadesNetas.ForeColor = System.Drawing.Color.RoyalBlue;
            this.utilidadesNetas.Location = new System.Drawing.Point(583, 445);
            this.utilidadesNetas.Name = "utilidadesNetas";
            this.utilidadesNetas.Size = new System.Drawing.Size(128, 16);
            this.utilidadesNetas.TabIndex = 37;
            this.utilidadesNetas.Text = "Utilidades Netas:";
            // 
            // totalDeGastos
            // 
            this.totalDeGastos.AutoSize = true;
            this.totalDeGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDeGastos.Location = new System.Drawing.Point(583, 419);
            this.totalDeGastos.Name = "totalDeGastos";
            this.totalDeGastos.Size = new System.Drawing.Size(121, 16);
            this.totalDeGastos.TabIndex = 36;
            this.totalDeGastos.Text = "Total de gastos:";
            // 
            // GastosLabel
            // 
            this.GastosLabel.AutoSize = true;
            this.GastosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GastosLabel.Location = new System.Drawing.Point(17, 386);
            this.GastosLabel.Name = "GastosLabel";
            this.GastosLabel.Size = new System.Drawing.Size(61, 18);
            this.GastosLabel.TabIndex = 35;
            this.GastosLabel.Text = "Gastos:";
            // 
            // Otros
            // 
            this.Otros.AutoSize = true;
            this.Otros.Location = new System.Drawing.Point(405, 473);
            this.Otros.Name = "Otros";
            this.Otros.Size = new System.Drawing.Size(35, 13);
            this.Otros.TabIndex = 34;
            this.Otros.Text = "Otros:";
            // 
            // OtrosTextBox
            // 
            this.OtrosTextBox.Location = new System.Drawing.Point(475, 469);
            this.OtrosTextBox.Name = "OtrosTextBox";
            this.OtrosTextBox.Size = new System.Drawing.Size(81, 20);
            this.OtrosTextBox.TabIndex = 15;
            this.OtrosTextBox.Text = "0";
            this.OtrosTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OtrosTextBox_KeyPress);
            // 
            // Recepcion
            // 
            this.Recepcion.AutoSize = true;
            this.Recepcion.Location = new System.Drawing.Point(17, 499);
            this.Recepcion.Name = "Recepcion";
            this.Recepcion.Size = new System.Drawing.Size(62, 13);
            this.Recepcion.TabIndex = 32;
            this.Recepcion.Text = "Recepcion:";
            // 
            // RecepcionTextBox
            // 
            this.RecepcionTextBox.Location = new System.Drawing.Point(99, 496);
            this.RecepcionTextBox.Name = "RecepcionTextBox";
            this.RecepcionTextBox.Size = new System.Drawing.Size(81, 20);
            this.RecepcionTextBox.TabIndex = 8;
            this.RecepcionTextBox.Text = "0";
            this.RecepcionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RecepcionTextBox_KeyPress);
            // 
            // Publicidad
            // 
            this.Publicidad.AutoSize = true;
            this.Publicidad.Location = new System.Drawing.Point(208, 499);
            this.Publicidad.Name = "Publicidad";
            this.Publicidad.Size = new System.Drawing.Size(59, 13);
            this.Publicidad.TabIndex = 30;
            this.Publicidad.Text = "Publicidad:";
            // 
            // PublicidadTextBox
            // 
            this.PublicidadTextBox.Location = new System.Drawing.Point(291, 496);
            this.PublicidadTextBox.Name = "PublicidadTextBox";
            this.PublicidadTextBox.Size = new System.Drawing.Size(81, 20);
            this.PublicidadTextBox.TabIndex = 12;
            this.PublicidadTextBox.Text = "0";
            this.PublicidadTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PublicidadTextBox_KeyPress);
            // 
            // AuxiliarCoach
            // 
            this.AuxiliarCoach.AutoSize = true;
            this.AuxiliarCoach.Location = new System.Drawing.Point(16, 473);
            this.AuxiliarCoach.Name = "AuxiliarCoach";
            this.AuxiliarCoach.Size = new System.Drawing.Size(74, 13);
            this.AuxiliarCoach.TabIndex = 28;
            this.AuxiliarCoach.Text = "Auxiliar Coach";
            // 
            // AuxiliarCoachTextBox
            // 
            this.AuxiliarCoachTextBox.Location = new System.Drawing.Point(99, 470);
            this.AuxiliarCoachTextBox.Name = "AuxiliarCoachTextBox";
            this.AuxiliarCoachTextBox.Size = new System.Drawing.Size(81, 20);
            this.AuxiliarCoachTextBox.TabIndex = 7;
            this.AuxiliarCoachTextBox.Text = "0";
            this.AuxiliarCoachTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AuxiliarCoachTextBox_KeyPress);
            // 
            // Nutriologa
            // 
            this.Nutriologa.AutoSize = true;
            this.Nutriologa.Location = new System.Drawing.Point(402, 421);
            this.Nutriologa.Name = "Nutriologa";
            this.Nutriologa.Size = new System.Drawing.Size(58, 13);
            this.Nutriologa.TabIndex = 26;
            this.Nutriologa.Text = "Nutriologo:";
            // 
            // NutriologaTextBox
            // 
            this.NutriologaTextBox.Location = new System.Drawing.Point(475, 418);
            this.NutriologaTextBox.Name = "NutriologaTextBox";
            this.NutriologaTextBox.Size = new System.Drawing.Size(81, 20);
            this.NutriologaTextBox.TabIndex = 13;
            this.NutriologaTextBox.Text = "0";
            this.NutriologaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NutriologaTextBox_KeyPress);
            // 
            // SueldoCoach
            // 
            this.SueldoCoach.AutoSize = true;
            this.SueldoCoach.Location = new System.Drawing.Point(16, 447);
            this.SueldoCoach.Name = "SueldoCoach";
            this.SueldoCoach.Size = new System.Drawing.Size(77, 13);
            this.SueldoCoach.TabIndex = 24;
            this.SueldoCoach.Text = "Sueldo Coach:";
            // 
            // SueldoCochTextBox
            // 
            this.SueldoCochTextBox.Location = new System.Drawing.Point(99, 444);
            this.SueldoCochTextBox.Name = "SueldoCochTextBox";
            this.SueldoCochTextBox.Size = new System.Drawing.Size(81, 20);
            this.SueldoCochTextBox.TabIndex = 6;
            this.SueldoCochTextBox.Text = "0";
            this.SueldoCochTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SueldoCochTextBox_KeyPress);
            // 
            // limpieza
            // 
            this.limpieza.AutoSize = true;
            this.limpieza.Location = new System.Drawing.Point(208, 476);
            this.limpieza.Name = "limpieza";
            this.limpieza.Size = new System.Drawing.Size(54, 13);
            this.limpieza.TabIndex = 22;
            this.limpieza.Text = "Limpieza: ";
            // 
            // LimpiezaTextBox
            // 
            this.LimpiezaTextBox.Location = new System.Drawing.Point(291, 473);
            this.LimpiezaTextBox.Name = "LimpiezaTextBox";
            this.LimpiezaTextBox.Size = new System.Drawing.Size(81, 20);
            this.LimpiezaTextBox.TabIndex = 11;
            this.LimpiezaTextBox.Text = "0";
            this.LimpiezaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LimpiezaTextBox_KeyPress);
            // 
            // Cable
            // 
            this.Cable.AutoSize = true;
            this.Cable.Location = new System.Drawing.Point(208, 450);
            this.Cable.Name = "Cable";
            this.Cable.Size = new System.Drawing.Size(68, 13);
            this.Cable.TabIndex = 20;
            this.Cable.Text = "Internet / tel:";
            // 
            // InterenetTextBox
            // 
            this.InterenetTextBox.Location = new System.Drawing.Point(291, 447);
            this.InterenetTextBox.Name = "InterenetTextBox";
            this.InterenetTextBox.Size = new System.Drawing.Size(81, 20);
            this.InterenetTextBox.TabIndex = 10;
            this.InterenetTextBox.Text = "0";
            this.InterenetTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InterenetTextBox_KeyPress);
            // 
            // Agua
            // 
            this.Agua.AutoSize = true;
            this.Agua.Location = new System.Drawing.Point(405, 447);
            this.Agua.Name = "Agua";
            this.Agua.Size = new System.Drawing.Size(35, 13);
            this.Agua.TabIndex = 18;
            this.Agua.Text = "Agua:";
            // 
            // AguaTextBox
            // 
            this.AguaTextBox.Location = new System.Drawing.Point(475, 443);
            this.AguaTextBox.Name = "AguaTextBox";
            this.AguaTextBox.Size = new System.Drawing.Size(81, 20);
            this.AguaTextBox.TabIndex = 14;
            this.AguaTextBox.Text = "0";
            this.AguaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AguaTextBox_KeyPress);
            // 
            // luz
            // 
            this.luz.AutoSize = true;
            this.luz.Location = new System.Drawing.Point(210, 421);
            this.luz.Name = "luz";
            this.luz.Size = new System.Drawing.Size(27, 13);
            this.luz.TabIndex = 16;
            this.luz.Text = "Luz:";
            // 
            // LuzTextBox
            // 
            this.LuzTextBox.Location = new System.Drawing.Point(292, 418);
            this.LuzTextBox.Name = "LuzTextBox";
            this.LuzTextBox.Size = new System.Drawing.Size(81, 20);
            this.LuzTextBox.TabIndex = 9;
            this.LuzTextBox.Text = "0";
            this.LuzTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LuzTextBox_KeyPress);
            // 
            // renta
            // 
            this.renta.AutoSize = true;
            this.renta.Location = new System.Drawing.Point(17, 421);
            this.renta.Name = "renta";
            this.renta.Size = new System.Drawing.Size(42, 13);
            this.renta.TabIndex = 14;
            this.renta.Text = "Renta: ";
            // 
            // RentaTextBox
            // 
            this.RentaTextBox.Location = new System.Drawing.Point(99, 418);
            this.RentaTextBox.Name = "RentaTextBox";
            this.RentaTextBox.Size = new System.Drawing.Size(81, 20);
            this.RentaTextBox.TabIndex = 5;
            this.RentaTextBox.Text = "0";
            this.RentaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RentaTextBox_KeyPress);
            // 
            // adeudosNuevosLabel
            // 
            this.adeudosNuevosLabel.AutoSize = true;
            this.adeudosNuevosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adeudosNuevosLabel.Location = new System.Drawing.Point(33, 276);
            this.adeudosNuevosLabel.Name = "adeudosNuevosLabel";
            this.adeudosNuevosLabel.Size = new System.Drawing.Size(0, 16);
            this.adeudosNuevosLabel.TabIndex = 12;
            // 
            // adeudosPagadosLabel
            // 
            this.adeudosPagadosLabel.AutoSize = true;
            this.adeudosPagadosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adeudosPagadosLabel.Location = new System.Drawing.Point(17, 253);
            this.adeudosPagadosLabel.Name = "adeudosPagadosLabel";
            this.adeudosPagadosLabel.Size = new System.Drawing.Size(141, 16);
            this.adeudosPagadosLabel.TabIndex = 11;
            this.adeudosPagadosLabel.Text = "Adeudos pagados: $0";
            // 
            // AdeudoLabel
            // 
            this.AdeudoLabel.AutoSize = true;
            this.AdeudoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdeudoLabel.Location = new System.Drawing.Point(33, 276);
            this.AdeudoLabel.Name = "AdeudoLabel";
            this.AdeudoLabel.Size = new System.Drawing.Size(0, 16);
            this.AdeudoLabel.TabIndex = 10;
            // 
            // totalAPagarLabel
            // 
            this.totalAPagarLabel.AutoSize = true;
            this.totalAPagarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAPagarLabel.Location = new System.Drawing.Point(17, 228);
            this.totalAPagarLabel.Name = "totalAPagarLabel";
            this.totalAPagarLabel.Size = new System.Drawing.Size(117, 16);
            this.totalAPagarLabel.TabIndex = 9;
            this.totalAPagarLabel.Text = "Nuevos pagos: $0";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.totalLabel.Location = new System.Drawing.Point(17, 276);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(110, 16);
            this.totalLabel.TabIndex = 8;
            this.totalLabel.Text = "Total pagado: $0";
            // 
            // buscaPagos
            // 
            this.buscaPagos.Location = new System.Drawing.Point(121, 171);
            this.buscaPagos.Name = "buscaPagos";
            this.buscaPagos.Size = new System.Drawing.Size(86, 28);
            this.buscaPagos.TabIndex = 4;
            this.buscaPagos.Text = "Buscar";
            this.buscaPagos.UseVisualStyleBackColor = true;
            this.buscaPagos.Click += new System.EventHandler(this.buscaPagos_Click);
            // 
            // listaPagos
            // 
            this.listaPagos.AllowUserToAddRows = false;
            this.listaPagos.AllowUserToDeleteRows = false;
            this.listaPagos.AllowUserToResizeColumns = false;
            this.listaPagos.AllowUserToResizeRows = false;
            this.listaPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.asociado,
            this.aPagar,
            this.cantidad,
            this.concepto});
            this.listaPagos.Location = new System.Drawing.Point(233, 6);
            this.listaPagos.Name = "listaPagos";
            this.listaPagos.ReadOnly = true;
            this.listaPagos.RowHeadersVisible = false;
            this.listaPagos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listaPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaPagos.Size = new System.Drawing.Size(588, 355);
            this.listaPagos.TabIndex = 17;
            // 
            // asociado
            // 
            this.asociado.HeaderText = "Nombre";
            this.asociado.Name = "asociado";
            this.asociado.ReadOnly = true;
            this.asociado.Width = 230;
            // 
            // aPagar
            // 
            this.aPagar.HeaderText = "Total a pagar";
            this.aPagar.Name = "aPagar";
            this.aPagar.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Pagado";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 50;
            // 
            // concepto
            // 
            this.concepto.HeaderText = "Concepto";
            this.concepto.Name = "concepto";
            this.concepto.ReadOnly = true;
            this.concepto.Width = 185;
            // 
            // tipoPago
            // 
            this.tipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoPago.FormattingEnabled = true;
            this.tipoPago.Items.AddRange(new object[] {
            "Todos",
            "Efectivo",
            "Tarjeta",
            "Cheque"});
            this.tipoPago.Location = new System.Drawing.Point(101, 122);
            this.tipoPago.Name = "tipoPago";
            this.tipoPago.Size = new System.Drawing.Size(106, 21);
            this.tipoPago.TabIndex = 3;
            // 
            // dateFin
            // 
            this.dateFin.CustomFormat = "dd/MM/yyyy";
            this.dateFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFin.Location = new System.Drawing.Point(101, 83);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(106, 20);
            this.dateFin.TabIndex = 2;
            // 
            // dateInicio
            // 
            this.dateInicio.CustomFormat = "dd/MM/yyyy";
            this.dateInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateInicio.Location = new System.Drawing.Point(101, 46);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(106, 20);
            this.dateInicio.TabIndex = 1;
            // 
            // formaPago
            // 
            this.formaPago.AutoSize = true;
            this.formaPago.Location = new System.Drawing.Point(17, 125);
            this.formaPago.Name = "formaPago";
            this.formaPago.Size = new System.Drawing.Size(81, 13);
            this.formaPago.TabIndex = 2;
            this.formaPago.Text = "Forma de pago:";
            // 
            // fin
            // 
            this.fin.AutoSize = true;
            this.fin.Location = new System.Drawing.Point(17, 90);
            this.fin.Name = "fin";
            this.fin.Size = new System.Drawing.Size(62, 13);
            this.fin.TabIndex = 1;
            this.fin.Text = "Fecha final:";
            // 
            // inicio
            // 
            this.inicio.AutoSize = true;
            this.inicio.Location = new System.Drawing.Point(17, 52);
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(69, 13);
            this.inicio.TabIndex = 0;
            this.inicio.Text = "Fecha inicial:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.visitaspicker);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.listaDeVisitas);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(824, 529);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Visitas por dia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Ambos";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox3.Location = new System.Drawing.Point(27, 329);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 18);
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Adeudo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Vencido";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(27, 365);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 18);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Location = new System.Drawing.Point(27, 295);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 18);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // visitaspicker
            // 
            this.visitaspicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.visitaspicker.Location = new System.Drawing.Point(27, 43);
            this.visitaspicker.Name = "visitaspicker";
            this.visitaspicker.Size = new System.Drawing.Size(109, 20);
            this.visitaspicker.TabIndex = 19;
            this.visitaspicker.ValueChanged += new System.EventHandler(this.visitaspicker_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Visitas for dia:";
            // 
            // listaDeVisitas
            // 
            this.listaDeVisitas.AllowUserToAddRows = false;
            this.listaDeVisitas.AllowUserToDeleteRows = false;
            this.listaDeVisitas.AllowUserToResizeColumns = false;
            this.listaDeVisitas.AllowUserToResizeRows = false;
            this.listaDeVisitas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listaDeVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaDeVisitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.Adeudo});
            this.listaDeVisitas.Location = new System.Drawing.Point(173, 27);
            this.listaDeVisitas.MultiSelect = false;
            this.listaDeVisitas.Name = "listaDeVisitas";
            this.listaDeVisitas.ReadOnly = true;
            this.listaDeVisitas.RowHeadersVisible = false;
            this.listaDeVisitas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listaDeVisitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaDeVisitas.Size = new System.Drawing.Size(616, 363);
            this.listaDeVisitas.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Fecha ingreso";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha de Vencimiento";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // Adeudo
            // 
            this.Adeudo.HeaderText = "Adeudo";
            this.Adeudo.Name = "Adeudo";
            this.Adeudo.ReadOnly = true;
            this.Adeudo.ToolTipText = "Adeudo";
            this.Adeudo.Width = 80;
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 588);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            this.Menu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaAlumnos)).EndInit();
            this.internet.ResumeLayout(false);
            this.internet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaPagos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaDeVisitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Menu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage internet;
        private System.Windows.Forms.ComboBox edad_hasta;
        private System.Windows.Forms.ComboBox edad_de;
        private System.Windows.Forms.ComboBox estatus;
        private System.Windows.Forms.ComboBox sexo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.DataGridView listaAlumnos;
        private System.Windows.Forms.DataGridView listaPagos;
        private System.Windows.Forms.ComboBox tipoPago;
        private System.Windows.Forms.DateTimePicker dateFin;
        private System.Windows.Forms.DateTimePicker dateInicio;
        private System.Windows.Forms.Label formaPago;
        private System.Windows.Forms.Label fin;
        private System.Windows.Forms.Label inicio;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Button buscaPagos;
        private System.Windows.Forms.DataGridViewTextBoxColumn asociado;
        private System.Windows.Forms.DataGridViewTextBoxColumn aPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView listaDeVisitas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adeudo;
        private System.Windows.Forms.DateTimePicker visitaspicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label totalAPagarLabel;
        private System.Windows.Forms.Label AdeudoLabel;
        private System.Windows.Forms.Label adeudosNuevosLabel;
        private System.Windows.Forms.Label adeudosPagadosLabel;
        private System.Windows.Forms.Label Cable;
        private System.Windows.Forms.TextBox InterenetTextBox;
        private System.Windows.Forms.Label Agua;
        private System.Windows.Forms.TextBox AguaTextBox;
        private System.Windows.Forms.Label luz;
        private System.Windows.Forms.TextBox LuzTextBox;
        private System.Windows.Forms.Label renta;
        private System.Windows.Forms.TextBox RentaTextBox;
        private System.Windows.Forms.Label SueldoCoach;
        private System.Windows.Forms.TextBox SueldoCochTextBox;
        private System.Windows.Forms.Label limpieza;
        private System.Windows.Forms.TextBox LimpiezaTextBox;
        private System.Windows.Forms.Label Publicidad;
        private System.Windows.Forms.TextBox PublicidadTextBox;
        private System.Windows.Forms.Label AuxiliarCoach;
        private System.Windows.Forms.TextBox AuxiliarCoachTextBox;
        private System.Windows.Forms.Label Nutriologa;
        private System.Windows.Forms.TextBox NutriologaTextBox;
        private System.Windows.Forms.Label Otros;
        private System.Windows.Forms.TextBox OtrosTextBox;
        private System.Windows.Forms.Label Recepcion;
        private System.Windows.Forms.TextBox RecepcionTextBox;
        private System.Windows.Forms.Label utilidadesNetas;
        private System.Windows.Forms.Label totalDeGastos;
        private System.Windows.Forms.Label GastosLabel;
        private System.Windows.Forms.Button calculoUtilidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdeudoCol;
    }
}