namespace Diseño_Programador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PanelBarra = new System.Windows.Forms.Panel();
            this.PanelMin = new System.Windows.Forms.Panel();
            this.PanelMax = new System.Windows.Forms.Panel();
            this.PanelSalir = new System.Windows.Forms.Panel();
            this.PanelDetectar = new System.Windows.Forms.Panel();
            this.LabelDetectar = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SelPuerto = new System.Windows.Forms.Label();
            this.PanelRregresar = new System.Windows.Forms.Panel();
            this.LabelRRegresar = new System.Windows.Forms.Label();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.LabelTitulo1 = new System.Windows.Forms.Label();
            this.PanelConf = new System.Windows.Forms.Panel();
            this.LabelTitulo2 = new System.Windows.Forms.Label();
            this.LabelConf = new System.Windows.Forms.Label();
            this.LabelLect = new System.Windows.Forms.Label();
            this.PanelLect = new System.Windows.Forms.Panel();
            this.LabelSalirSis = new System.Windows.Forms.Label();
            this.PanelSalirSis = new System.Windows.Forms.Panel();
            this.FPanelGuia2 = new System.Windows.Forms.FlowLayoutPanel();
            this.LabelDectectar2 = new System.Windows.Forms.Label();
            this.LabelConf2 = new System.Windows.Forms.Label();
            this.LabelLect2 = new System.Windows.Forms.Label();
            this.LabelSalirSis2 = new System.Windows.Forms.Label();
            this.PanelSelPuerto = new System.Windows.Forms.Panel();
            this.LabelSelPuerto = new System.Windows.Forms.Label();
            this.LabelCOM = new System.Windows.Forms.Label();
            this.PanelCOM = new System.Windows.Forms.Panel();
            this.LabelConectar = new System.Windows.Forms.Label();
            this.PanelConectar = new System.Windows.Forms.Panel();
            this.LabelEquipo = new System.Windows.Forms.Label();
            this.PanelEquipo = new System.Windows.Forms.Panel();
            this.LabelEquipoData = new System.Windows.Forms.Label();
            this.PanelEquipoData = new System.Windows.Forms.Panel();
            this.LabelNSerie = new System.Windows.Forms.Label();
            this.PanelNSerie = new System.Windows.Forms.Panel();
            this.LabelNSerieData = new System.Windows.Forms.Label();
            this.PanelNSerieData = new System.Windows.Forms.Panel();
            this.LabelVersion = new System.Windows.Forms.Label();
            this.PanelVersion = new System.Windows.Forms.Panel();
            this.LabelVersionData = new System.Windows.Forms.Label();
            this.PanelVersionData = new System.Windows.Forms.Panel();
            this.LabelCabina = new System.Windows.Forms.Label();
            this.PanelCabina = new System.Windows.Forms.Panel();
            this.LabelCabinaData = new System.Windows.Forms.Label();
            this.PanelCabinaData = new System.Windows.Forms.Panel();
            this.LabelRegresar = new System.Windows.Forms.Label();
            this.PanelRegresar = new System.Windows.Forms.Panel();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.PanelStatus = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PanelBarra
            // 
            this.PanelBarra.Location = new System.Drawing.Point(12, 12);
            this.PanelBarra.Name = "PanelBarra";
            this.PanelBarra.Size = new System.Drawing.Size(48, 23);
            this.PanelBarra.TabIndex = 0;
            this.PanelBarra.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.PanelBarra.MouseHover += new System.EventHandler(this.PanelBarra_MouseHover);
            // 
            // PanelMin
            // 
            this.PanelMin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PanelMin.Location = new System.Drawing.Point(88, 12);
            this.PanelMin.Name = "PanelMin";
            this.PanelMin.Size = new System.Drawing.Size(39, 25);
            this.PanelMin.TabIndex = 1;
            this.PanelMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelMin_MouseClick);
            this.PanelMin.MouseLeave += new System.EventHandler(this.PanelMin_MouseLeave_1);
            this.PanelMin.MouseHover += new System.EventHandler(this.PanelMin_MouseHover_1);
            // 
            // PanelMax
            // 
            this.PanelMax.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PanelMax.Location = new System.Drawing.Point(148, 12);
            this.PanelMax.Name = "PanelMax";
            this.PanelMax.Size = new System.Drawing.Size(51, 26);
            this.PanelMax.TabIndex = 2;
            this.PanelMax.MouseLeave += new System.EventHandler(this.PanelMax_MouseLeave_1);
            this.PanelMax.MouseHover += new System.EventHandler(this.PanelMax_MouseHover_1);
            // 
            // PanelSalir
            // 
            this.PanelSalir.BackColor = System.Drawing.SystemColors.Desktop;
            this.PanelSalir.Location = new System.Drawing.Point(223, 12);
            this.PanelSalir.Name = "PanelSalir";
            this.PanelSalir.Size = new System.Drawing.Size(57, 29);
            this.PanelSalir.TabIndex = 3;
            this.PanelSalir.MouseLeave += new System.EventHandler(this.PanelSalir_MouseLeave_1);
            this.PanelSalir.MouseHover += new System.EventHandler(this.PanelSalir_MouseHover_1);
            // 
            // PanelDetectar
            // 
            this.PanelDetectar.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelDetectar.Location = new System.Drawing.Point(370, 12);
            this.PanelDetectar.Name = "PanelDetectar";
            this.PanelDetectar.Size = new System.Drawing.Size(59, 29);
            this.PanelDetectar.TabIndex = 4;
            this.PanelDetectar.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDetectar_Paint);
            this.PanelDetectar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelDetectar_MouseClick);
            this.PanelDetectar.MouseLeave += new System.EventHandler(this.PanelDetectar_MouseLeave);
            this.PanelDetectar.MouseHover += new System.EventHandler(this.PanelDetectar_MouseHover);
            // 
            // LabelDetectar
            // 
            this.LabelDetectar.AutoSize = true;
            this.LabelDetectar.Location = new System.Drawing.Point(367, 47);
            this.LabelDetectar.Name = "LabelDetectar";
            this.LabelDetectar.Size = new System.Drawing.Size(35, 13);
            this.LabelDetectar.TabIndex = 5;
            this.LabelDetectar.Text = "label1";
            this.LabelDetectar.Visible = false;
            this.LabelDetectar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Lbl_MouseClick);
            this.LabelDetectar.MouseLeave += new System.EventHandler(this.Lbl_MouseLeave);
            this.LabelDetectar.MouseHover += new System.EventHandler(this.Lbl_MouseHover);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SelPuerto
            // 
            this.SelPuerto.AutoSize = true;
            this.SelPuerto.Location = new System.Drawing.Point(794, 170);
            this.SelPuerto.Name = "SelPuerto";
            this.SelPuerto.Size = new System.Drawing.Size(35, 13);
            this.SelPuerto.TabIndex = 6;
            this.SelPuerto.Text = "label1";
            this.SelPuerto.Visible = false;
            this.SelPuerto.Click += new System.EventHandler(this.SelPuerto_Click);
            // 
            // PanelRregresar
            // 
            this.PanelRregresar.BackColor = System.Drawing.SystemColors.GrayText;
            this.PanelRregresar.Location = new System.Drawing.Point(719, 139);
            this.PanelRregresar.Name = "PanelRregresar";
            this.PanelRregresar.Size = new System.Drawing.Size(42, 17);
            this.PanelRregresar.TabIndex = 7;
            this.PanelRregresar.Visible = false;
            this.PanelRregresar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RegresarDet_MouseClick);
            // 
            // LabelRRegresar
            // 
            this.LabelRRegresar.AutoSize = true;
            this.LabelRRegresar.Location = new System.Drawing.Point(716, 159);
            this.LabelRRegresar.Name = "LabelRRegresar";
            this.LabelRRegresar.Size = new System.Drawing.Size(35, 13);
            this.LabelRRegresar.TabIndex = 8;
            this.LabelRRegresar.Text = "label1";
            this.LabelRRegresar.Visible = false;
            this.LabelRRegresar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RegPantalla2_MouseClick);
            // 
            // PanelTitulo
            // 
            this.PanelTitulo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelTitulo.Location = new System.Drawing.Point(306, 12);
            this.PanelTitulo.Name = "PanelTitulo";
            this.PanelTitulo.Size = new System.Drawing.Size(40, 20);
            this.PanelTitulo.TabIndex = 9;
            // 
            // LabelTitulo1
            // 
            this.LabelTitulo1.AutoSize = true;
            this.LabelTitulo1.Location = new System.Drawing.Point(303, 35);
            this.LabelTitulo1.Name = "LabelTitulo1";
            this.LabelTitulo1.Size = new System.Drawing.Size(35, 13);
            this.LabelTitulo1.TabIndex = 10;
            this.LabelTitulo1.Text = "label1";
            // 
            // PanelConf
            // 
            this.PanelConf.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelConf.Location = new System.Drawing.Point(446, 12);
            this.PanelConf.Name = "PanelConf";
            this.PanelConf.Size = new System.Drawing.Size(56, 23);
            this.PanelConf.TabIndex = 11;
            // 
            // LabelTitulo2
            // 
            this.LabelTitulo2.AutoSize = true;
            this.LabelTitulo2.Location = new System.Drawing.Point(303, 47);
            this.LabelTitulo2.Name = "LabelTitulo2";
            this.LabelTitulo2.Size = new System.Drawing.Size(35, 13);
            this.LabelTitulo2.TabIndex = 12;
            this.LabelTitulo2.Text = "label1";
            // 
            // LabelConf
            // 
            this.LabelConf.AutoSize = true;
            this.LabelConf.Location = new System.Drawing.Point(454, 38);
            this.LabelConf.Name = "LabelConf";
            this.LabelConf.Size = new System.Drawing.Size(35, 13);
            this.LabelConf.TabIndex = 13;
            this.LabelConf.Text = "label1";
            // 
            // LabelLect
            // 
            this.LabelLect.AutoSize = true;
            this.LabelLect.Location = new System.Drawing.Point(527, 38);
            this.LabelLect.Name = "LabelLect";
            this.LabelLect.Size = new System.Drawing.Size(35, 13);
            this.LabelLect.TabIndex = 15;
            this.LabelLect.Text = "label1";
            // 
            // PanelLect
            // 
            this.PanelLect.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelLect.Location = new System.Drawing.Point(521, 12);
            this.PanelLect.Name = "PanelLect";
            this.PanelLect.Size = new System.Drawing.Size(56, 23);
            this.PanelLect.TabIndex = 14;
            // 
            // LabelSalirSis
            // 
            this.LabelSalirSis.AutoSize = true;
            this.LabelSalirSis.Location = new System.Drawing.Point(603, 38);
            this.LabelSalirSis.Name = "LabelSalirSis";
            this.LabelSalirSis.Size = new System.Drawing.Size(35, 13);
            this.LabelSalirSis.TabIndex = 17;
            this.LabelSalirSis.Text = "label1";
            // 
            // PanelSalirSis
            // 
            this.PanelSalirSis.BackColor = System.Drawing.SystemColors.Highlight;
            this.PanelSalirSis.Location = new System.Drawing.Point(595, 12);
            this.PanelSalirSis.Name = "PanelSalirSis";
            this.PanelSalirSis.Size = new System.Drawing.Size(56, 23);
            this.PanelSalirSis.TabIndex = 16;
            // 
            // FPanelGuia2
            // 
            this.FPanelGuia2.Location = new System.Drawing.Point(789, 139);
            this.FPanelGuia2.Name = "FPanelGuia2";
            this.FPanelGuia2.Size = new System.Drawing.Size(49, 28);
            this.FPanelGuia2.TabIndex = 18;
            // 
            // LabelDectectar2
            // 
            this.LabelDectectar2.AutoSize = true;
            this.LabelDectectar2.Location = new System.Drawing.Point(367, 61);
            this.LabelDectectar2.Name = "LabelDectectar2";
            this.LabelDectectar2.Size = new System.Drawing.Size(35, 13);
            this.LabelDectectar2.TabIndex = 19;
            this.LabelDectectar2.Text = "label1";
            this.LabelDectectar2.Click += new System.EventHandler(this.LabelDectectar2_Click);
            this.LabelDectectar2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LabelDectectar2_MouseClick);
            // 
            // LabelConf2
            // 
            this.LabelConf2.AutoSize = true;
            this.LabelConf2.Location = new System.Drawing.Point(454, 51);
            this.LabelConf2.Name = "LabelConf2";
            this.LabelConf2.Size = new System.Drawing.Size(35, 13);
            this.LabelConf2.TabIndex = 20;
            this.LabelConf2.Text = "label1";
            // 
            // LabelLect2
            // 
            this.LabelLect2.AutoSize = true;
            this.LabelLect2.Location = new System.Drawing.Point(527, 51);
            this.LabelLect2.Name = "LabelLect2";
            this.LabelLect2.Size = new System.Drawing.Size(35, 13);
            this.LabelLect2.TabIndex = 21;
            this.LabelLect2.Text = "label1";
            // 
            // LabelSalirSis2
            // 
            this.LabelSalirSis2.AutoSize = true;
            this.LabelSalirSis2.Location = new System.Drawing.Point(603, 51);
            this.LabelSalirSis2.Name = "LabelSalirSis2";
            this.LabelSalirSis2.Size = new System.Drawing.Size(35, 13);
            this.LabelSalirSis2.TabIndex = 22;
            this.LabelSalirSis2.Text = "label1";
            // 
            // PanelSelPuerto
            // 
            this.PanelSelPuerto.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelSelPuerto.Location = new System.Drawing.Point(12, 78);
            this.PanelSelPuerto.Name = "PanelSelPuerto";
            this.PanelSelPuerto.Size = new System.Drawing.Size(31, 17);
            this.PanelSelPuerto.TabIndex = 23;
            // 
            // LabelSelPuerto
            // 
            this.LabelSelPuerto.AutoSize = true;
            this.LabelSelPuerto.Location = new System.Drawing.Point(12, 98);
            this.LabelSelPuerto.Name = "LabelSelPuerto";
            this.LabelSelPuerto.Size = new System.Drawing.Size(35, 13);
            this.LabelSelPuerto.TabIndex = 24;
            this.LabelSelPuerto.Text = "label1";
            // 
            // LabelCOM
            // 
            this.LabelCOM.AutoSize = true;
            this.LabelCOM.Location = new System.Drawing.Point(58, 98);
            this.LabelCOM.Name = "LabelCOM";
            this.LabelCOM.Size = new System.Drawing.Size(35, 13);
            this.LabelCOM.TabIndex = 26;
            this.LabelCOM.Text = "label2";
            // 
            // PanelCOM
            // 
            this.PanelCOM.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelCOM.Location = new System.Drawing.Point(58, 78);
            this.PanelCOM.Name = "PanelCOM";
            this.PanelCOM.Size = new System.Drawing.Size(31, 17);
            this.PanelCOM.TabIndex = 25;
            // 
            // LabelConectar
            // 
            this.LabelConectar.AutoSize = true;
            this.LabelConectar.Location = new System.Drawing.Point(109, 98);
            this.LabelConectar.Name = "LabelConectar";
            this.LabelConectar.Size = new System.Drawing.Size(35, 13);
            this.LabelConectar.TabIndex = 28;
            this.LabelConectar.Text = "label3";
            // 
            // PanelConectar
            // 
            this.PanelConectar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelConectar.Location = new System.Drawing.Point(109, 78);
            this.PanelConectar.Name = "PanelConectar";
            this.PanelConectar.Size = new System.Drawing.Size(31, 17);
            this.PanelConectar.TabIndex = 27;
            // 
            // LabelEquipo
            // 
            this.LabelEquipo.AutoSize = true;
            this.LabelEquipo.Location = new System.Drawing.Point(157, 98);
            this.LabelEquipo.Name = "LabelEquipo";
            this.LabelEquipo.Size = new System.Drawing.Size(35, 13);
            this.LabelEquipo.TabIndex = 30;
            this.LabelEquipo.Text = "label4";
            // 
            // PanelEquipo
            // 
            this.PanelEquipo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelEquipo.Location = new System.Drawing.Point(157, 78);
            this.PanelEquipo.Name = "PanelEquipo";
            this.PanelEquipo.Size = new System.Drawing.Size(31, 17);
            this.PanelEquipo.TabIndex = 29;
            // 
            // LabelEquipoData
            // 
            this.LabelEquipoData.AutoSize = true;
            this.LabelEquipoData.Location = new System.Drawing.Point(198, 98);
            this.LabelEquipoData.Name = "LabelEquipoData";
            this.LabelEquipoData.Size = new System.Drawing.Size(35, 13);
            this.LabelEquipoData.TabIndex = 26;
            this.LabelEquipoData.Text = "label5";
            // 
            // PanelEquipoData
            // 
            this.PanelEquipoData.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelEquipoData.Location = new System.Drawing.Point(198, 78);
            this.PanelEquipoData.Name = "PanelEquipoData";
            this.PanelEquipoData.Size = new System.Drawing.Size(31, 17);
            this.PanelEquipoData.TabIndex = 25;
            // 
            // LabelNSerie
            // 
            this.LabelNSerie.AutoSize = true;
            this.LabelNSerie.Location = new System.Drawing.Point(249, 98);
            this.LabelNSerie.Name = "LabelNSerie";
            this.LabelNSerie.Size = new System.Drawing.Size(35, 13);
            this.LabelNSerie.TabIndex = 32;
            this.LabelNSerie.Text = "label6";
            // 
            // PanelNSerie
            // 
            this.PanelNSerie.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelNSerie.Location = new System.Drawing.Point(249, 78);
            this.PanelNSerie.Name = "PanelNSerie";
            this.PanelNSerie.Size = new System.Drawing.Size(31, 17);
            this.PanelNSerie.TabIndex = 31;
            // 
            // LabelNSerieData
            // 
            this.LabelNSerieData.AutoSize = true;
            this.LabelNSerieData.Location = new System.Drawing.Point(306, 98);
            this.LabelNSerieData.Name = "LabelNSerieData";
            this.LabelNSerieData.Size = new System.Drawing.Size(35, 13);
            this.LabelNSerieData.TabIndex = 34;
            this.LabelNSerieData.Text = "label7";
            // 
            // PanelNSerieData
            // 
            this.PanelNSerieData.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelNSerieData.Location = new System.Drawing.Point(306, 78);
            this.PanelNSerieData.Name = "PanelNSerieData";
            this.PanelNSerieData.Size = new System.Drawing.Size(31, 17);
            this.PanelNSerieData.TabIndex = 33;
            // 
            // LabelVersion
            // 
            this.LabelVersion.AutoSize = true;
            this.LabelVersion.Location = new System.Drawing.Point(347, 98);
            this.LabelVersion.Name = "LabelVersion";
            this.LabelVersion.Size = new System.Drawing.Size(35, 13);
            this.LabelVersion.TabIndex = 36;
            this.LabelVersion.Text = "label8";
            // 
            // PanelVersion
            // 
            this.PanelVersion.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelVersion.Location = new System.Drawing.Point(347, 78);
            this.PanelVersion.Name = "PanelVersion";
            this.PanelVersion.Size = new System.Drawing.Size(31, 17);
            this.PanelVersion.TabIndex = 35;
            // 
            // LabelVersionData
            // 
            this.LabelVersionData.AutoSize = true;
            this.LabelVersionData.Location = new System.Drawing.Point(398, 98);
            this.LabelVersionData.Name = "LabelVersionData";
            this.LabelVersionData.Size = new System.Drawing.Size(35, 13);
            this.LabelVersionData.TabIndex = 38;
            this.LabelVersionData.Text = "label9";
            // 
            // PanelVersionData
            // 
            this.PanelVersionData.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelVersionData.Location = new System.Drawing.Point(398, 78);
            this.PanelVersionData.Name = "PanelVersionData";
            this.PanelVersionData.Size = new System.Drawing.Size(31, 17);
            this.PanelVersionData.TabIndex = 37;
            // 
            // LabelCabina
            // 
            this.LabelCabina.AutoSize = true;
            this.LabelCabina.Location = new System.Drawing.Point(446, 98);
            this.LabelCabina.Name = "LabelCabina";
            this.LabelCabina.Size = new System.Drawing.Size(41, 13);
            this.LabelCabina.TabIndex = 26;
            this.LabelCabina.Text = "label10";
            // 
            // PanelCabina
            // 
            this.PanelCabina.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelCabina.Location = new System.Drawing.Point(446, 78);
            this.PanelCabina.Name = "PanelCabina";
            this.PanelCabina.Size = new System.Drawing.Size(31, 17);
            this.PanelCabina.TabIndex = 25;
            // 
            // LabelCabinaData
            // 
            this.LabelCabinaData.AutoSize = true;
            this.LabelCabinaData.Location = new System.Drawing.Point(495, 98);
            this.LabelCabinaData.Name = "LabelCabinaData";
            this.LabelCabinaData.Size = new System.Drawing.Size(41, 13);
            this.LabelCabinaData.TabIndex = 40;
            this.LabelCabinaData.Text = "label11";
            // 
            // PanelCabinaData
            // 
            this.PanelCabinaData.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelCabinaData.Location = new System.Drawing.Point(495, 78);
            this.PanelCabinaData.Name = "PanelCabinaData";
            this.PanelCabinaData.Size = new System.Drawing.Size(31, 17);
            this.PanelCabinaData.TabIndex = 39;
            // 
            // LabelRegresar
            // 
            this.LabelRegresar.AutoSize = true;
            this.LabelRegresar.Location = new System.Drawing.Point(546, 98);
            this.LabelRegresar.Name = "LabelRegresar";
            this.LabelRegresar.Size = new System.Drawing.Size(41, 13);
            this.LabelRegresar.TabIndex = 42;
            this.LabelRegresar.Text = "label12";
            // 
            // PanelRegresar
            // 
            this.PanelRegresar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelRegresar.Location = new System.Drawing.Point(546, 78);
            this.PanelRegresar.Name = "PanelRegresar";
            this.PanelRegresar.Size = new System.Drawing.Size(31, 17);
            this.PanelRegresar.TabIndex = 41;
            this.PanelRegresar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelRegresar_MouseClick);
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(595, 98);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(41, 13);
            this.LabelStatus.TabIndex = 44;
            this.LabelStatus.Text = "label13";
            // 
            // PanelStatus
            // 
            this.PanelStatus.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelStatus.Location = new System.Drawing.Point(595, 78);
            this.PanelStatus.Name = "PanelStatus";
            this.PanelStatus.Size = new System.Drawing.Size(31, 17);
            this.PanelStatus.TabIndex = 43;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 225);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.PanelStatus);
            this.Controls.Add(this.LabelRegresar);
            this.Controls.Add(this.PanelRegresar);
            this.Controls.Add(this.LabelCabinaData);
            this.Controls.Add(this.PanelCabinaData);
            this.Controls.Add(this.LabelCabina);
            this.Controls.Add(this.LabelVersionData);
            this.Controls.Add(this.PanelCabina);
            this.Controls.Add(this.PanelVersionData);
            this.Controls.Add(this.LabelVersion);
            this.Controls.Add(this.PanelVersion);
            this.Controls.Add(this.LabelNSerieData);
            this.Controls.Add(this.PanelNSerieData);
            this.Controls.Add(this.LabelNSerie);
            this.Controls.Add(this.PanelNSerie);
            this.Controls.Add(this.LabelEquipoData);
            this.Controls.Add(this.LabelEquipo);
            this.Controls.Add(this.PanelEquipoData);
            this.Controls.Add(this.PanelEquipo);
            this.Controls.Add(this.LabelConectar);
            this.Controls.Add(this.PanelConectar);
            this.Controls.Add(this.LabelCOM);
            this.Controls.Add(this.PanelCOM);
            this.Controls.Add(this.LabelSelPuerto);
            this.Controls.Add(this.PanelSelPuerto);
            this.Controls.Add(this.LabelSalirSis2);
            this.Controls.Add(this.LabelLect2);
            this.Controls.Add(this.LabelConf2);
            this.Controls.Add(this.LabelDectectar2);
            this.Controls.Add(this.FPanelGuia2);
            this.Controls.Add(this.LabelSalirSis);
            this.Controls.Add(this.PanelSalirSis);
            this.Controls.Add(this.LabelLect);
            this.Controls.Add(this.PanelLect);
            this.Controls.Add(this.LabelConf);
            this.Controls.Add(this.LabelTitulo2);
            this.Controls.Add(this.PanelConf);
            this.Controls.Add(this.LabelTitulo1);
            this.Controls.Add(this.PanelTitulo);
            this.Controls.Add(this.LabelRRegresar);
            this.Controls.Add(this.PanelRregresar);
            this.Controls.Add(this.SelPuerto);
            this.Controls.Add(this.LabelDetectar);
            this.Controls.Add(this.PanelDetectar);
            this.Controls.Add(this.PanelSalir);
            this.Controls.Add(this.PanelMax);
            this.Controls.Add(this.PanelMin);
            this.Controls.Add(this.PanelBarra);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelBarra;
        private System.Windows.Forms.Panel PanelMin;
        private System.Windows.Forms.Panel PanelMax;
        private System.Windows.Forms.Panel PanelSalir;
        private System.Windows.Forms.Panel PanelDetectar;
        private System.Windows.Forms.Label LabelDetectar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label SelPuerto;
        private System.Windows.Forms.Panel PanelRregresar;
        private System.Windows.Forms.Label LabelRRegresar;
        private System.Windows.Forms.Panel PanelTitulo;
        private System.Windows.Forms.Label LabelTitulo1;
        private System.Windows.Forms.Panel PanelConf;
        private System.Windows.Forms.Label LabelTitulo2;
        private System.Windows.Forms.Label LabelConf;
        private System.Windows.Forms.Label LabelLect;
        private System.Windows.Forms.Panel PanelLect;
        private System.Windows.Forms.Label LabelSalirSis;
        private System.Windows.Forms.Panel PanelSalirSis;
        private System.Windows.Forms.FlowLayoutPanel FPanelGuia2;
        private System.Windows.Forms.Label LabelDectectar2;
        private System.Windows.Forms.Label LabelConf2;
        private System.Windows.Forms.Label LabelLect2;
        private System.Windows.Forms.Label LabelSalirSis2;
        private System.Windows.Forms.Panel PanelSelPuerto;
        private System.Windows.Forms.Label LabelSelPuerto;
        private System.Windows.Forms.Label LabelCOM;
        private System.Windows.Forms.Panel PanelCOM;
        private System.Windows.Forms.Label LabelConectar;
        private System.Windows.Forms.Panel PanelConectar;
        private System.Windows.Forms.Label LabelEquipo;
        private System.Windows.Forms.Panel PanelEquipo;
        private System.Windows.Forms.Label LabelEquipoData;
        private System.Windows.Forms.Panel PanelEquipoData;
        private System.Windows.Forms.Label LabelNSerie;
        private System.Windows.Forms.Panel PanelNSerie;
        private System.Windows.Forms.Label LabelNSerieData;
        private System.Windows.Forms.Panel PanelNSerieData;
        private System.Windows.Forms.Label LabelVersion;
        private System.Windows.Forms.Panel PanelVersion;
        private System.Windows.Forms.Label LabelVersionData;
        private System.Windows.Forms.Panel PanelVersionData;
        private System.Windows.Forms.Label LabelCabina;
        private System.Windows.Forms.Panel PanelCabina;
        private System.Windows.Forms.Label LabelCabinaData;
        private System.Windows.Forms.Panel PanelCabinaData;
        private System.Windows.Forms.Label LabelRegresar;
        private System.Windows.Forms.Panel PanelRegresar;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.Panel PanelStatus;
    }
}