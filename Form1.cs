using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diseño_Programador
{
    public partial class Form1 : Form
    {
        int MedidaOpcion = 0;
        int OpcionImagenTamaño = 0;
        int EspacioAdicional = 20;

        string LocationOfIntroImage = "H";

        //Vraibles para el timer
        bool AutorizarAnimacionDetectar = false;
        bool AutorizarAnimacionLbl = false;
        bool AutorizarContadorCambioDetLbl = false;
        int ContadorAnimacionDetectar = 0;
        int ValorMinAnimacionDetectar = 0;
        int ValorMaxAnimacionDetectar = 100;
        int ContadorCambioPanelDetectarLbl = 0;
        int ValorMxContadorCambio = 5;
        int StepAnimacion = 20;
        bool AutorizarTraslacionDetectar = false;
        int ContadorTraslacionDetectar = 0;
        double ExponenecialContador = 0;
        bool AutorizarTraslacionInversaDetectar = false;
        bool AutorizarRegresarPantalla1 = false;
        bool AutorizarTranslacionInvertidaPantalla1 = false;
        int LastValue = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Dimensiones de la Forma
            this.Height = 600; //800 pixeles de longitug horizontal
            this.Width = 800; //1000 pixeles de longitud veritical

            ActualizarPantalla();// Se actualizan cada componente del sistema
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ActualizarPantalla()
        {
            this.BackColor = Color.FromArgb(255, 255, 255, 255);
            //Diseño Barra de opciones superior
            this.PanelBarra.Visible = true;
            this.PanelBarra.BackColor = Color.FromArgb(255, 0, 32, 96);
            this.PanelBarra.Height = 5 * this.Height / 100;
            this.PanelBarra.Width = this.Width;
            this.PanelBarra.Location = new Point(0, 0);
            //this.PanelBarra.BringToFront();

            MedidaOpcion = this.PanelBarra.Height;
            OpcionImagenTamaño = 30 * this.PanelBarra.Height / 30;

            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);

            //string LocationOfIntroImage = directory + PantallaSeleccionOpciones(OpcionSeleccionada);

            //Diseño Opcion Minimizar barra
            MostrarPanelMinimo(directory, 0);

            //Diseño Opcion Maximizar barra
            MostrarPanelMaximo(directory, 1);

            //Diseño Opcion Salir barra
            MostrarPanelSalir(directory, 2);

            MostarPanelDetectarPlaca();

            MostrarSeleccionOpciones();
            this.SelPuerto.Visible = false;

            MostrarPanelRegPantalla1();
            this.RegresarDet.Visible = false;
        }

        public void MostrarPanelRegPantalla1()
        {
            this.RegresarDet.Visible = true;
            this.RegresarDet.BackColor = Color.FromArgb(255, 120, 120, 120);
            this.RegresarDet.Height = this.Height / 10;
            this.RegresarDet.Width = 22 * this.Width / 100;
            this.RegresarDet.Location = new Point(-this.RegresarDet.Width, this.Height - 5*EspacioAdicional);
            this.RegPantalla2.Text = "Regresar\n";
            this.RegPantalla2.Font = new Font("Arial", 24, FontStyle.Bold);
            this.RegPantalla2.ForeColor = Color.FromArgb(255, 255, 255, 255);
            this.RegPantalla2.BackColor = Color.FromArgb(255, 120, 120, 120);
            //this.Lbl.Width = 7 * this.PanelDetectar.Width / 10;
            //this.Lbl.Height =  7 * this.PanelDetectar.Height / 10;
            this.RegPantalla2.Location = new Point(5 * this.PanelDetectar.Width / 100, 5 * this.PanelDetectar.Height / 100);
            this.RegresarDet.Controls.Add(RegPantalla2);
        }

        public void MostarPanelDetectarPlaca()
        {
            this.PanelDetectar.Visible = true;
            this.PanelDetectar.BackColor = Color.FromArgb(255, 0, 96, 110);
            this.PanelDetectar.Height = this.Width/6;
            this.PanelDetectar.Width = this.Height/3;
            this.PanelDetectar.Location = new Point(EspacioAdicional, this.PanelSalir.Height + EspacioAdicional);
            //Label Lbl = new Label();
            this.Lbl.Text = "Detectar\nPlaca";
            this.Lbl.Font = new Font("Arial", 24, FontStyle.Bold);
            this.Lbl.ForeColor = Color.FromArgb(255, 255, 255, 255);
            this.Lbl.BackColor = Color.FromArgb(255, 0, 96, 110 );
            //this.Lbl.Width = 7 * this.PanelDetectar.Width / 10;
            //this.Lbl.Height =  7 * this.PanelDetectar.Height / 10;
            this.Lbl.Location = new Point(5 * this.PanelDetectar.Width / 100, 5 * this.PanelDetectar.Height / 100);

            this.PanelDetectar.Controls.Add(Lbl);
            //LocationOfIntroImage = direct + PantallaSeleccionOpciones(a);
            //this.PanelMin.Controls.Clear();
            //ShowImages(LocationOfIntroImage, a);
        }

        public void ShowImages(string Location , int a)
        {
            /*
            PictureBox pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            pb.Image = Image.FromFile(Location);
            if (a == 0 || a == 3)
            {
                pb.Image = new Bitmap(pb.Image, this.PanelMin.Width, pb.Image.Height);
                this.PanelMin.Controls.Add(pb);
            }
            else if (a == 1 || a == 4)
            {
                pb.Image = new Bitmap(pb.Image, this.PanelMax.Width, pb.Image.Height);
                this.PanelMax.Controls.Add(pb);
            }
            else if (a == 2 || a==5)
            {
                pb.Image = new Bitmap(pb.Image, this.PanelSalir.Width, pb.Image.Height);
                this.PanelSalir.Controls.Add(pb);
            }
            */

            Image NewImage = new Bitmap(Location);
            if (a == 0 || a == 3)
            {
                this.PanelMin.BackgroundImage = NewImage;
            }
            else if (a == 1 || a == 4)
            {
                this.PanelMax.BackgroundImage = NewImage;
            }
            else if (a == 2 || a == 5)
            {
                this.PanelSalir.BackgroundImage = NewImage;
            }

            //ScroolText.AutoScroll = true;
            //ScroolText.Controls.Add(pb);
        }

        public static string PantallaSeleccionOpciones(int a)
        {
            string[] TextoOpciones = new string[13];
            TextoOpciones[0] = "\\Imagenes\\OpcionMin.png";
            TextoOpciones[1] = "\\Imagenes\\OpcionMax.png";
            TextoOpciones[2] = "\\Imagenes\\OpcionSalir.png";
            TextoOpciones[3] = "\\Imagenes\\OpcionMinHover.png";
            TextoOpciones[4] = "\\Imagenes\\OpcionMaxHover.png";
            TextoOpciones[5] = "\\Imagenes\\OpcionSalirHover.png";

            if (a == -1)
            {
                return "\\Imagenes\\Intro.png";
            }
            else
            {
                return TextoOpciones[a];
            }
        }

        public void MostrarPanelMinimo(string direct , int a)
        {
            this.PanelMin.Visible = true;
            //this.PanelMin.BackColor = Color.FromArgb(255, 255, 0, 0);
            this.PanelMin.Height = MedidaOpcion;
            this.PanelMin.Width = MedidaOpcion;
            this.PanelMin.Location = new Point(this.Width - 3 * OpcionImagenTamaño - EspacioAdicional, 0);
            LocationOfIntroImage = direct + PantallaSeleccionOpciones(a);
            this.PanelMin.Controls.Clear();
            ShowImages(LocationOfIntroImage, a);
        }

        public void MostrarPanelMaximo(string direct, int a)
        {
            this.PanelMax.Visible = true;
            //this.PanelMin.BackColor = Color.FromArgb(255, 255, 0, 0);
            this.PanelMax.Height = MedidaOpcion;
            this.PanelMax.Width = MedidaOpcion;
            this.PanelMax.Location = new Point(this.Width - 2 * OpcionImagenTamaño - EspacioAdicional, 0);
            LocationOfIntroImage = direct + PantallaSeleccionOpciones(a);
            this.PanelMax.Controls.Clear();
            ShowImages(LocationOfIntroImage, a);
        }

        public void MostrarPanelSalir(string direct, int a)
        {
            this.PanelSalir.Visible = true;
            //this.PanelMin.BackColor = Color.FromArgb(255, 255, 0, 0);
            this.PanelSalir.Height = MedidaOpcion;
            this.PanelSalir.Width = MedidaOpcion;
            this.PanelSalir.Location = new Point(this.Width - 1 * OpcionImagenTamaño - EspacioAdicional, 0);
            LocationOfIntroImage = direct + PantallaSeleccionOpciones(a);
            this.PanelSalir.Controls.Clear();
            ShowImages(LocationOfIntroImage, a);
        }

        // *****************************************************************
        private void PanelMin_MouseHover_1(object sender, EventArgs e)
        {
            // Update the mouse event label to indicate the MouseHover event occurred.
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            MostrarPanelMinimo(directory, 3);
            Console.WriteLine("Panel Minimo 1");
        }

        private void PanelMin_MouseLeave_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseLeave event occurred.
            MostrarPanelMinimo(directory, 0);
            Console.WriteLine("Panel Minimo 0");
        }

        private void PanelMax_MouseHover_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseHover event occurred.
            MostrarPanelMinimo(directory, 4);
        }

        private void PanelMax_MouseLeave_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseLeave event occurred.
            MostrarPanelMinimo(directory, 1);
        }

        private void PanelSalir_MouseHover_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseHover event occurred.
            MostrarPanelMinimo(directory, 5);
        }

        private void PanelSalir_MouseLeave_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseLeave event occurred.
            MostrarPanelMinimo(directory, 2);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void PanelMin_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Panel Minimo Pulsado");
        }

        private void PanelBarra_MouseHover(object sender, EventArgs e)
        {
            Console.WriteLine("Panel Barra 1");
        }

        private void PanelDetectar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelDetectar_MouseHover(object sender, EventArgs e)
        {
            AutorizarAnimacionDetectar = true;
        }

        public void AnimacionPanelDetectar()
        {
             //this.PanelDetectar.Width = this.PanelDetectar.Width + (a)*this.PanelDetectar.Width / 1000;
             this.PanelDetectar.BackColor = Color.FromArgb(255, 0, 96, 110 + ContadorAnimacionDetectar);
             this.Lbl.BackColor = this.PanelDetectar.BackColor;
        }

        private void PanelDetectar_MouseLeave(object sender, EventArgs e)
        {
            AutorizarAnimacionDetectar = false;          
        }

        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            //AnimacionPanelDetectar();
            AutorizarAnimacionDetectar = true;
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            AutorizarAnimacionDetectar = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool RecuadroDetectar = (Control.MousePosition.X >= (this.Left + 2 * this.PanelDetectar.Location.X) && Control.MousePosition.X <= (this.PanelDetectar.Width + this.Left + this.PanelDetectar.Location.X) && Control.MousePosition.Y >= (15 * this.PanelDetectar.Location.Y / 10 + this.Top) && Control.MousePosition.Y <= (8 * this.PanelDetectar.Location.Y / 5 + this.PanelDetectar.Height + this.Top));
            if ( !AutorizarTraslacionInversaDetectar && !AutorizarTraslacionDetectar && (AutorizarAnimacionDetectar || RecuadroDetectar) )
            {
                if (ContadorAnimacionDetectar <= ValorMaxAnimacionDetectar)
                {
                    ContadorAnimacionDetectar += StepAnimacion;
                    AnimacionPanelDetectar();
                }
            }
            else if (!AutorizarTraslacionInversaDetectar && !AutorizarTraslacionDetectar && !AutorizarAnimacionDetectar && ContadorAnimacionDetectar > 0 && !RecuadroDetectar)
            {
                ContadorAnimacionDetectar -= 10;
                AnimacionPanelDetectar();
            }
            else if (!AutorizarTraslacionInversaDetectar && AutorizarTraslacionDetectar)
            {
                TraslacionPanelDetectar();
            }
            if (AutorizarTraslacionInversaDetectar)
            {
                if (this.SelPuerto.Location.X < 8)
                {
                    ExponenecialContador++;
                    int dat = this.SelPuerto.Location.X +((((int)(Math.Exp((ExponenecialContador / 8))))) );
                    this.SelPuerto.Location = new Point(dat, this.SelPuerto.Location.Y);
                    this.RegresarDet.Location = new Point(dat, this.Height - 8 * EspacioAdicional);
                }
                else if (this.SelPuerto.Location.X >= 8)
                {
                    ExponenecialContador = 0;
                    AutorizarTraslacionInversaDetectar = false;
 
                }
            }
            if (AutorizarRegresarPantalla1)
            {
                TraslacionRegresarPantalla1();
            }

        }

        public void TraslacionRegresarPantalla1()
        {
            if (this.RegresarDet.Location.X > -this.RegresarDet.Width)
            {
                ExponenecialContador++;
                int dat = this.PanelDetectar.Location.X - (int)(Math.Exp(ExponenecialContador / 8));
                this.SelPuerto.Location = new Point(dat, this.SelPuerto.Location.Y);
                this.RegresarDet.Location = new Point(dat, this.Height - 8 * EspacioAdicional);
            }
            else if (this.RegresarDet.Location.X <= -this.RegresarDet.Width)
            {
                this.PanelDetectar.Visible = false;
                //LastValue = (int)(Math.Exp(ExponenecialContador / 8));
                Console.WriteLine(LastValue.ToString());
                ExponenecialContador = 0;
                AutorizarRegresarPantalla1 = false;
                this.SelPuerto.Visible = true;
                this.RegresarDet.Visible = true;
                //MostrarSeleccionOpciones();
            }
        }

        public void TraslacionPanelDetectar()
        {
            if (this.PanelDetectar.Location.X > -this.PanelDetectar.Width)
            {
                ExponenecialContador++;
                int dat = this.PanelDetectar.Location.X - (int)(Math.Exp(ExponenecialContador/8) );
                this.PanelDetectar.Location = new Point(dat , this.PanelDetectar.Location.Y);
            }
            else if (this.PanelDetectar.Location.X <= -this.PanelDetectar.Width)
            {
                this.PanelDetectar.Visible = false;
                LastValue = (int)(Math.Exp(ExponenecialContador / 8));
                Console.WriteLine(LastValue.ToString());
                ExponenecialContador = 0;
                AutorizarTraslacionInversaDetectar = true;
                this.SelPuerto.Visible = true;
                this.RegresarDet.Visible = true;
                //MostrarSeleccionOpciones();
            }
        }

        public void MostrarSeleccionOpciones()
        {
            this.SelPuerto.Visible = true;
            this.SelPuerto.Text = "Seleccione\nPuerto\nSerial";
            this.SelPuerto.Font = new Font("Arial", 24, FontStyle.Bold);
            this.SelPuerto.ForeColor = Color.FromArgb(255, 255, 255, 255);
            this.SelPuerto.BackColor = Color.FromArgb(255, 0, 96, 110);
            this.SelPuerto.Width = 7 * this.PanelDetectar.Width / 10;
            this.SelPuerto.Height = 7 * this.PanelDetectar.Height / 10;
            this.SelPuerto.Location = new Point(-this.SelPuerto.Width, this.PanelDetectar.Location.Y);
        }

        private void PanelDetectar_MouseClick(object sender, MouseEventArgs e)
        {
            AutorizarTraslacionDetectar = true;
        }

        private void Lbl_MouseClick(object sender, MouseEventArgs e)
        {
            AutorizarTraslacionDetectar = true;
        }

        private void SelPuerto_Click(object sender, EventArgs e)
        {

        }

        private void RegresarDet_MouseClick(object sender, MouseEventArgs e)
        {
            AutorizarRegresarPantalla1 = true;
        }

        private void RegPantalla2_MouseClick(object sender, MouseEventArgs e)
        {
            AutorizarRegresarPantalla1 = true;
        }
    }
}
