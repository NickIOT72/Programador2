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
        int CantidaPDFGuia = 16;

        //Definicion de variables (Paneles y labels)
        const int PANELBARRA = 0;
        const int PANELMIN = 1;
        const int PANELMAX = 2;
        const int PANELSALIR = 3;
        const int PANELTITULO = 4;
        const int LABELTITULO1 = 5;
        const int LABELTITULO2 = 6;
        const int PANELDETECTAR = 7;
        const int LABELDETECTAR = 8;
        const int PANELCONF = 9;
        const int LABELCONF = 10;
        const int PANELLECT = 11;
        const int LABELLECT = 12;
        const int PANELSALIRSIS = 13;
        const int LABELSALIRSIS = 14;
        const int FPANELGUIA = 15;

        //Dimesiones de PANTALLA PRINCIPA
        int ANCHOPANELBARRA = 0;
        int ANCHOPANELMIN = 1;
        int ANCHOPANELMAX = 2;
        int ANCHOPANELSALIR = 3;
        int ANCHOPANELTITULO = 4;
        int ANCHOLABELTITULO1 = 5;
        int ANCHOLABELTITULO2 = 6;
        int ANCHOPANELDETECTAR = 7;
        int ANCHOLABELDETECTAR = 8;
        int ANCHOPANELCONF = 9;
        int ANCHOLABELCONF = 10;
        int ANCHOPANELLECT = 11;
        int ANCHOLABELLECT = 12;
        int ANCHOPANELSALIRSIS = 13;
        int ANCHOLABELSALIRSIS = 14;
        int ANCHOFPANELGUIA = 15;

        int LARGOPANELBARRA = 0;
        int LARGOPANELMIN = 1;
        int LARGOPANELMAX = 2;
        int LARGOPANELSALIR = 3;
        int LARGOPANELTITULO = 4;
        int LARGOLABELTITULO1 = 5;
        int LARGOLABELTITULO2 = 6;
        int LARGOPANELDETECTAR = 7;
        int LARGOLABELDETECTAR = 8;
        int LARGOPANELCONF = 9;
        int LARGOLABELCONF = 10;
        int LARGOPANELLECT = 11;
        int LARGOLABELLECT = 12;
        int LARGOPANELSALIRSIS = 13;
        int LARGOLABELSALIRSIS = 14;
        int LARGOFPANELGUIA = 15;

        //Variables Poscion de paneles
        int POSXPANELBARRA = 0;
        int POSXPANELMIN = 1;
        int POSXPANELMAX = 2;
        int POSXPANELSALIR = 3;
        int POSXPANELTITULO = 4;
        int POSXLABELTITULO1 = 5;
        int POSXLABELTITULO2 = 6;
        int POSXPANELDETECTAR = 7;
        int POSXLABELDETECTAR = 8;
        int POSXPANELCONF = 9;
        int POSXLABELCONF = 10;
        int POSXPANELLECT = 11;
        int POSXLABELLECT = 12;
        int POSXPANELSALIRSIS = 13;
        int POSXLABELSALIRSIS = 14;
        int POSXFPANELGUIA = 15;

        int POSYPANELBARRA = 0;
        int POSYPANELMIN = 1;
        int POSYPANELMAX = 2;
        int POSYPANELSALIR = 3;
        int POSYPANELTITULO = 4;
        int POSYLABELTITULO1 = 5;
        int POSYLABELTITULO2 = 6;
        int POSYPANELDETECTAR = 7;
        int POSYLABELDETECTAR = 8;
        int POSYPANELCONF = 9;
        int POSYLABELCONF = 10;
        int POSYPANELLECT = 11;
        int POSYLABELLECT = 12;
        int POSYPANELSALIRSIS = 13;
        int POSYLABELSALIRSIS = 14;
        int POSYFPANELGUIA = 15;

        //Varibles para la animacion
        bool[] AnimPanelDetectar = new bool[4];

        //Creacion de Paneles
        //private System.Windows.Forms.Panel PanelTitulo;
        //private System.Windows.Forms.Label LabelTitulo1;

        public Form1()
        {
            // Funcion de paneles
            /*this.PanelTitulo = new System.Windows.Forms.Panel();
            this.LabelTitulo1 = new System.Windows.Forms.Label();*/

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Dimensiones de la Forma
            this.Height = 600; //800 pixeles de longitug horizontal
            this.Width = 800; //1000 pixeles de longitud veritical

            ActualizarDimesiones();
            ActualizarPosiciones();
            OcultarElementos();
            ActualizarPantalla();// Se actualizan cada componente del sistema
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void OcultarElementos()
        {
            this.PanelBarra.Visible = false;
            this.PanelTitulo.Visible = false;
            this.PanelMin.Visible = false;
            this.PanelMax.Visible = false;
            this.PanelSalir.Visible = false;
            this.LabelTitulo1.Visible = false;
            this.LabelTitulo2.Visible = false;
            this.PanelDetectar.Visible = false;
            this.LabelDetectar.Visible = false;
            this.PanelConf.Visible = false;
            this.LabelConf.Visible = false;
            this.PanelLect.Visible = false;
            this.LabelLect.Visible = false;
            this.PanelSalirSis.Visible = false;
            this.LabelSalirSis.Visible = false;
            this.FPanelGuia2.Visible = false;
        }

        public void ActualizarDimesiones()
        {
            //DimensionesPantalla1
            ANCHOPANELBARRA = this.Width;
            ANCHOPANELMIN = 5*this.Width/100;
            ANCHOPANELMAX = 5*this.Width/100;
            ANCHOPANELSALIR = 5*this.Width/100;
            ANCHOPANELTITULO =this.Width;
            //ANCHOLABELTITULO1 = 5;
            //ANCHOLABELTITULO2 = 6;
            ANCHOPANELDETECTAR = 20*this.Width/100;
            //ANCHOLABELDETECTAR = 8;
            ANCHOPANELCONF = 20*this.Width/100;
            //ANCHOLABELCONF = 10;
            ANCHOPANELLECT = 45*this.Width/100;
            //ANCHOLABELLECT = 12;
            ANCHOPANELSALIRSIS = 45*this.Width/100;
            //ANCHOLABELSALIRSIS = 14;
            ANCHOFPANELGUIA = 40*this.Width/100;
            
            LARGOPANELBARRA = 5*this.Height/100;
            LARGOPANELMIN = 5*this.Height/100;
            LARGOPANELMAX = 5*this.Height/100;
            LARGOPANELSALIR = 5*this.Height/100;
            LARGOPANELTITULO = 10*this.Height/100;
            //LARGOLABELTITULO1 = 5;
            //LARGOLABELTITULO2 = 6;
            LARGOPANELDETECTAR = 15*this.Height/100;//29
            //LARGOLABELDETECTAR = 8;
            LARGOPANELCONF = 29*this.Height/100;
            //LARGOLABELCONF = 10;
            LARGOPANELLECT = 18*this.Height/100;
            //LARGOLABELLECT = 12;
            LARGOPANELSALIRSIS = 18*this.Height/100;
            //LARGOLABELSALIRSIS = 14;
            LARGOFPANELGUIA = 65*this.Height/100;
        }

        public void ActualizarPosiciones()
        {
            //Variables Pantalla 1
            POSXPANELBARRA = 0;
            POSXPANELMIN = this.Width - 3*ANCHOPANELMIN;
            POSXPANELMAX = this.Width - 2*ANCHOPANELMIN;
            POSXPANELSALIR = this.Width - 1*ANCHOPANELMIN;
            POSXPANELTITULO = 0;
            POSXLABELTITULO1 = 2*ANCHOPANELTITULO/100;
            POSXLABELTITULO2 = 80*ANCHOPANELTITULO/100;
            POSXPANELDETECTAR = 5*this.Width/100;
            POSXLABELDETECTAR = 5*ANCHOPANELDETECTAR/100;
            POSXPANELCONF = 10*this.Width/100 + ANCHOPANELDETECTAR;
            POSXLABELCONF = 5*ANCHOPANELCONF/100;
            POSXPANELLECT = 5*this.Width/100;
            POSXLABELLECT = 15*ANCHOPANELLECT/100;
            POSXPANELSALIRSIS = 5*this.Width/100;
            POSXLABELSALIRSIS = 35*ANCHOPANELSALIRSIS/100;
            POSXFPANELGUIA = 55*this.Width/100;;

            POSYPANELBARRA = 0;
            POSYPANELMIN = 0;
            POSYPANELMAX = 0;
            POSYPANELSALIR = 0;
            POSYPANELTITULO = LARGOPANELBARRA;
            POSYLABELTITULO1 = 5*LARGOPANELBARRA/100;
            POSYLABELTITULO2 = 5*LARGOPANELBARRA/100;
            POSYPANELDETECTAR = 20*this.Height/100;
            POSYLABELDETECTAR = 5*LARGOPANELDETECTAR/100;
            POSYPANELCONF = POSYPANELDETECTAR;
            POSYLABELCONF = 5*LARGOPANELDETECTAR/100;
            POSYPANELLECT = 51*this.Height/100;
            POSYLABELLECT = 30*LARGOPANELLECT/100;
            POSYPANELSALIRSIS = 71*this.Height/100;
            POSYLABELSALIRSIS = 30*LARGOPANELSALIRSIS/100;
            POSYFPANELGUIA = POSYPANELDETECTAR;
        }

        public void ActualizarPantalla()
        {
            this.BackColor = Color.FromArgb(255, 255, 255, 255);

            //Diseño Barra de opciones superior
            CrearPanel(PANELBARRA,255,0,32,96,ANCHOPANELBARRA,LARGOPANELBARRA,POSXPANELBARRA,POSYPANELBARRA);

            //Definicion de variables
            MedidaOpcion = this.PanelBarra.Height;
            OpcionImagenTamaño = 30 * this.PanelBarra.Height / 30;
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);

            //Diseño Opcion Minimizar barra
            MostrarPanelMMS(directory, 0);

            //Diseño Opcion Maximizar barra
            MostrarPanelMMS(directory, 1);

            //Diseño Opcion Salir barra
            MostrarPanelMMS(directory, 2);

            //Diseño Panel TituloMostarPanelDetectarPlaca
            CrearPanel(PANELTITULO,255,236,126,7,ANCHOPANELTITULO,LARGOPANELTITULO,POSXPANELTITULO,POSYPANELTITULO);
            CrearLabel(PANELTITULO, LABELTITULO1 ,"Programador",255,0,200,55, POSXLABELTITULO1, POSYLABELTITULO1,24);
            CrearLabel(PANELTITULO,LABELTITULO2,"TECNAS C.A",255,0,200,55,POSXLABELTITULO2, POSYLABELTITULO2,24);

            //Diseño de Detectar Placa
            CrearPanel(PANELDETECTAR,255, 0, 96, 110,ANCHOPANELDETECTAR,LARGOPANELDETECTAR,POSXPANELDETECTAR,POSYPANELDETECTAR);
            CrearLabel(PANELDETECTAR,LABELDETECTAR,"Detectar\nPlaca",255,255,255,255,POSXLABELDETECTAR,POSYLABELDETECTAR,24);

            //Diseño de Configuracion
            CrearPanel(PANELCONF,255, 80, 80, 80,ANCHOPANELCONF,LARGOPANELCONF,POSXPANELCONF,POSYPANELCONF);
            CrearLabel(PANELCONF,LABELCONF,"Configu-\nracion de\nPlaca",255,255,255,255,POSXLABELCONF,POSYLABELCONF,24);

            //Diseño de Lectura de datos
            CrearPanel(PANELLECT, 255, 80, 80, 80, ANCHOPANELLECT, LARGOPANELLECT, POSXPANELLECT, POSYPANELLECT);
            CrearLabel(PANELLECT, LABELLECT, "Lectura de Datos", 255, 255, 255, 255, POSXLABELLECT, POSYLABELLECT, 24);

            //Diseño De Opcion Salir
            CrearPanel(PANELSALIRSIS, 255, 225, 15, 15, ANCHOPANELSALIRSIS, LARGOPANELSALIRSIS, POSXPANELSALIRSIS, POSYPANELSALIRSIS);
            CrearLabel(PANELSALIRSIS, LABELSALIRSIS, "SALIR", 255, 255, 255, 255, POSXLABELSALIRSIS, POSYLABELSALIRSIS, 24);

            CrearFPanel(FPANELGUIA, 255, 0, 255, 0, ANCHOFPANELGUIA, LARGOFPANELGUIA, POSXFPANELGUIA, POSYFPANELGUIA);

            /*//();
            this.PanelDetectar.Visible = false;

            //MostrarSeleccionOpciones();
            this.SelPuerto.Visible = false;

            //MostrarPanelRegPantalla1();
            this.RegresarDet.Visible = false;
            this.RegPantalla2.Visible = false;*/
        }

        public void CrearFPanel(int P1, int L, int R, int G, int B, int W, int H, int X, int Y)
        {
            var P = this.FPanelGuia2;
            int S = 0;
            //******** Estableciomiento de Cantidad de paginas del PDF
            int[] SelectorFlowPanel = new int[13];
            SelectorFlowPanel[0] = CantidaPDFGuia;
            //******** Establecimiento de Texto Correspodiente del PDF
            string[] TextoPDFFlowPanel = new string[13];
            TextoPDFFlowPanel[0] = "articulo_cientifico-page-";
            //******** Establecimiento de Texto Locacion de los documentos
            string[] LocationDePDF = new string[13];
            LocationDePDF[0] = "\\Imagenes\\Guia\\";

            switch (P1)
            {
                case FPANELGUIA:
                    P = this.FPanelGuia2;
                    S = 0;
                    break;
                default:
                    return;
            }
            P.Visible = true;
            P.BackColor = Color.FromArgb(L, R, G, B);
            P.Height = H;
            P.Width = W;
            P.Location = new Point(X, Y);
            
            int NumeroDePaginas = SelectorFlowPanel[S];
            string TextoPDF = TextoPDFFlowPanel[S];
            string LocData = LocationDePDF[S];

            var Locat = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string Directory = System.IO.Path.GetDirectoryName(Locat);
            P.Controls.Clear();

            Console.WriteLine(Directory + LocData + TextoPDF + "1" + ".jpg");
     
            for (int i = 1; i <= NumeroDePaginas; i++)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.AutoSize;
                pb.Image = Image.FromFile(Directory + LocData + TextoPDF + i.ToString() + ".jpg");
                pb.Image = new Bitmap(pb.Image, 90*P.Width/100, 90*pb.Image.Height/100);
                P.AutoScroll = true;
                P.Controls.Add(pb);

                /*Image NewImage = new Bitmap(LocData + TextoPDF + i.ToString() + ".png", P.Width, P.Height);
                P.BackgroundImage = NewImage;
                P.AutoScroll = true;
                P.Controls.Add(NewImage);*/
            }
        }
        public void CrearPanel(int P1, int L, int R, int G, int B, int W, int H, int X, int Y)
        {
            var P = this.PanelBarra;
            switch (P1)
            {
                case PANELBARRA:
                    P = this.PanelBarra;
                    break;
                case PANELCONF:
                    P = this.PanelConf;
                    break;
                case PANELDETECTAR:
                    P = this.PanelDetectar;
                    break;
                case PANELLECT:
                    P = this.PanelLect;
                    break;
                case PANELMAX:
                    P = this.PanelMax;
                    break;
                case PANELMIN:
                    P = this.PanelMin;
                    break;
                case PANELSALIR:
                    P = this.PanelSalir;
                    break;
                case PANELSALIRSIS:
                    P = this.PanelSalirSis;
                    break;
                case PANELTITULO:
                    P = this.PanelTitulo;
                    break;
                default:
                    return;
            }
            P.Visible = true;
            P.BackColor = Color.FromArgb(L, R, G, B);
            P.Height = H;
            P.Width = W;
            P.Location = new Point(X, Y);
        }

        public void CrearLabel(int P1, int L1, string a, int L, int R, int G, int B, int X, int Y, int S)
        {
            var P = this.PanelBarra;
            switch (P1)
            {
                case PANELBARRA:
                    P = this.PanelBarra;
                    break;
                case PANELCONF:
                    P = this.PanelConf;
                    break;
                case PANELDETECTAR:
                    P = this.PanelDetectar;
                    break;
                case PANELLECT:
                    P = this.PanelLect;
                    break;
                case PANELMAX:
                    P = this.PanelMax;
                    break;
                case PANELMIN:
                    P = this.PanelMin;
                    break;
                case PANELSALIR:
                    P = this.PanelSalir;
                    break;
                case PANELSALIRSIS:
                    P = this.PanelSalirSis;
                    break;
                case PANELTITULO:
                    P = this.PanelTitulo;
                    break;
                default:
                    return;
            }
            var l = this.LabelTitulo1;
            switch (L1)
            {
                case LABELCONF:
                    l = this.LabelConf;
                    break;
                case LABELDETECTAR:
                    l = this.LabelDetectar;
                    break;
                case LABELLECT:
                    l = this.LabelLect;
                    break;
                case LABELSALIRSIS:
                    l = this.LabelSalirSis;
                    break;
                case LABELTITULO1:
                    l = this.LabelTitulo1;
                    break;
                case LABELTITULO2:
                    l = this.LabelTitulo2;
                    break;
                default:
                    return;
            }
            l.Visible = true;
            l.Text = a;
            l.Font = new Font("Arial", S, FontStyle.Bold);
            l.ForeColor = Color.FromArgb(L, R, G, B);
            l.BackColor = P.BackColor;
            l.Location = new Point(X, Y);
            P.Controls.Add(l);
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
            this.LabelDetectar.Text = "Detectar\nPlaca";
            this.LabelDetectar.Font = new Font("Arial", 24, FontStyle.Bold);
            this.LabelDetectar.ForeColor = Color.FromArgb(255, 255, 255, 255);
            this.LabelDetectar.BackColor = Color.FromArgb(255, 0, 96, 110 );
            //this.Lbl.Width = 7 * this.PanelDetectar.Width / 10;
            //this.Lbl.Height =  7 * this.PanelDetectar.Height / 10;
            this.LabelDetectar.Location = new Point(5 * this.PanelDetectar.Width / 100, 5 * this.PanelDetectar.Height / 100);

            this.PanelDetectar.Controls.Add(LabelDetectar);
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

        public void MostrarPanelMMS(string direct , int a)
        {
            CrearPanel(a%3+1,0,0,0,0,MedidaOpcion,MedidaOpcion,this.Width - (3-a%3) * OpcionImagenTamaño - EspacioAdicional,0);
            LocationOfIntroImage = direct + PantallaSeleccionOpciones(a);
            if (a%3 == 0)
            {
                this.PanelMin.Controls.Clear();
            }
            else if (a%3 == 1)
            {
                this.PanelMax.Controls.Clear();
            }
            else if (a%3 == 2)
            {
                this.PanelSalir.Controls.Clear();
            }
            ShowImages(LocationOfIntroImage, a);
        }

        public void MostrarPanelMaximo(string direct, int a)
        {
            CrearPanel(1,0,0,0,0,MedidaOpcion,MedidaOpcion,this.Width - 2 * OpcionImagenTamaño - EspacioAdicional,0);
            LocationOfIntroImage = direct + PantallaSeleccionOpciones(a);
            this.PanelMax.Controls.Clear();
            ShowImages(LocationOfIntroImage, a);
        }

        public void MostrarPanelSalir(string direct, int a)
        {
            CrearPanel(1,0,0,0,0,MedidaOpcion,MedidaOpcion,this.Width - 1 * OpcionImagenTamaño - EspacioAdicional,0);
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
            MostrarPanelMMS(directory, 3);
            Console.WriteLine("Panel Minimo 1");
        }

        private void PanelMin_MouseLeave_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseLeave event occurred.
            MostrarPanelMMS(directory, 0);
            Console.WriteLine("Panel Minimo 0");
        }

        private void PanelMax_MouseHover_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseHover event occurred.
            MostrarPanelMMS(directory, 4);
        }

        private void PanelMax_MouseLeave_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseLeave event occurred.
            MostrarPanelMMS(directory, 1);
        }

        private void PanelSalir_MouseHover_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseHover event occurred.
            MostrarPanelMMS(directory, 5);
        }

        private void PanelSalir_MouseLeave_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseLeave event occurred.
            MostrarPanelMMS(directory, 2);
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
             this.LabelDetectar.BackColor = this.PanelDetectar.BackColor;
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

            int MouseYPos = Control.MousePosition.Y;
            int MouseXPos = Control.MousePosition.X;

            /*bool RecuadroDetectar = (Control.MousePosition.X >= (this.Left + 2 * this.PanelDetectar.Location.X) && Control.MousePosition.X <= (this.PanelDetectar.Width + this.Left + this.PanelDetectar.Location.X) && Control.MousePosition.Y >= (15 * this.PanelDetectar.Location.Y / 10 + this.Top) && Control.MousePosition.Y <= (8 * this.PanelDetectar.Location.Y / 5 + this.PanelDetectar.Height + this.Top));
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
                if (this.SelPuerto.Location.X < 15)
                {
                    ExponenecialContador++;
                    int dat = this.SelPuerto.Location.X +((((int)(Math.Exp((ExponenecialContador*1 / 6))))) );
                    this.SelPuerto.Location = new Point(dat, this.SelPuerto.Location.Y);
                    this.RegresarDet.Location = new Point(dat, this.Height - 8 * EspacioAdicional);
                }
                else if (this.SelPuerto.Location.X >= 15)
                {
                    ExponenecialContador = 0;
                    AutorizarTraslacionInversaDetectar = false;
 
                }
            }
            if (AutorizarRegresarPantalla1)
            {
                TraslacionRegresarPantalla1();
            }*/

        }

        public void TraslacionRegresarPantalla1()
        {
            if (this.RegresarDet.Location.X > -this.RegresarDet.Width)
            {
                ExponenecialContador++;
                int dat = this.PanelDetectar.Location.X - (int)(Math.Exp(ExponenecialContador*0.01 / 8));
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
