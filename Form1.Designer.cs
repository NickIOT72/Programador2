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
            this.RegresarDet = new System.Windows.Forms.Panel();
            this.RegPantalla2 = new System.Windows.Forms.Label();
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
            this.SelPuerto.Location = new System.Drawing.Point(15, 117);
            this.SelPuerto.Name = "SelPuerto";
            this.SelPuerto.Size = new System.Drawing.Size(35, 13);
            this.SelPuerto.TabIndex = 6;
            this.SelPuerto.Text = "label1";
            this.SelPuerto.Visible = false;
            this.SelPuerto.Click += new System.EventHandler(this.SelPuerto_Click);
            // 
            // RegresarDet
            // 
            this.RegresarDet.BackColor = System.Drawing.SystemColors.GrayText;
            this.RegresarDet.Location = new System.Drawing.Point(18, 61);
            this.RegresarDet.Name = "RegresarDet";
            this.RegresarDet.Size = new System.Drawing.Size(42, 17);
            this.RegresarDet.TabIndex = 7;
            this.RegresarDet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RegresarDet_MouseClick);
            // 
            // RegPantalla2
            // 
            this.RegPantalla2.AutoSize = true;
            this.RegPantalla2.Location = new System.Drawing.Point(15, 81);
            this.RegPantalla2.Name = "RegPantalla2";
            this.RegPantalla2.Size = new System.Drawing.Size(35, 13);
            this.RegPantalla2.TabIndex = 8;
            this.RegPantalla2.Text = "label1";
            this.RegPantalla2.Visible = false;
            this.RegPantalla2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RegPantalla2_MouseClick);
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
            this.LabelLect.Location = new System.Drawing.Point(527, 47);
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
            this.LabelSalirSis.Location = new System.Drawing.Point(601, 47);
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
            this.FPanelGuia2.Location = new System.Drawing.Point(88, 61);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 261);
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
            this.Controls.Add(this.RegPantalla2);
            this.Controls.Add(this.RegresarDet);
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
        private System.Windows.Forms.Panel RegresarDet;
        private System.Windows.Forms.Label RegPantalla2;
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
    }
}