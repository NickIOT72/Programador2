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
            this.Lbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SelPuerto = new System.Windows.Forms.Label();
            this.RegresarDet = new System.Windows.Forms.Panel();
            this.RegPantalla2 = new System.Windows.Forms.Label();
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
            this.PanelDetectar.Location = new System.Drawing.Point(299, 12);
            this.PanelDetectar.Name = "PanelDetectar";
            this.PanelDetectar.Size = new System.Drawing.Size(59, 29);
            this.PanelDetectar.TabIndex = 4;
            this.PanelDetectar.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDetectar_Paint);
            this.PanelDetectar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelDetectar_MouseClick);
            this.PanelDetectar.MouseLeave += new System.EventHandler(this.PanelDetectar_MouseLeave);
            this.PanelDetectar.MouseHover += new System.EventHandler(this.PanelDetectar_MouseHover);
            // 
            // Lbl
            // 
            this.Lbl.AutoSize = true;
            this.Lbl.Location = new System.Drawing.Point(311, 44);
            this.Lbl.Name = "Lbl";
            this.Lbl.Size = new System.Drawing.Size(35, 13);
            this.Lbl.TabIndex = 5;
            this.Lbl.Text = "label1";
            this.Lbl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Lbl_MouseClick);
            this.Lbl.MouseLeave += new System.EventHandler(this.Lbl_MouseLeave);
            this.Lbl.MouseHover += new System.EventHandler(this.Lbl_MouseHover);
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
            this.SelPuerto.Location = new System.Drawing.Point(383, 12);
            this.SelPuerto.Name = "SelPuerto";
            this.SelPuerto.Size = new System.Drawing.Size(35, 13);
            this.SelPuerto.TabIndex = 6;
            this.SelPuerto.Text = "label1";
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
            this.RegPantalla2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RegPantalla2_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 261);
            this.Controls.Add(this.RegPantalla2);
            this.Controls.Add(this.RegresarDet);
            this.Controls.Add(this.SelPuerto);
            this.Controls.Add(this.Lbl);
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
        private System.Windows.Forms.Label Lbl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label SelPuerto;
        private System.Windows.Forms.Panel RegresarDet;
        private System.Windows.Forms.Label RegPantalla2;
    }
}

