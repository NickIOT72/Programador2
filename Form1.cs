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
        int ContadorAnimacionDetectar = 0;
        double ExponenecialContador = 0;
        int LastValue = 0;
        int CantidaPDFGuia = 16;

        //Variables del sistema
        int[,] Paneles = new int[10, 10];
        int[,] Labels1 = new int[10, 10];
        int[,] Labels2 = new int[10, 10];
        int[,] MinYMax = new int[10, 2];
        int[,] PanelAncho = new int[10, 10];
        int[,] PanelLargo = new int[10, 10];
        int[,] PanelPosX = new int[10, 10];
        int[,] PanelPosY = new int[10, 10];
        int[,] Label1PosX = new int[10, 10];
        int[,] Label1PosY = new int[10, 10];
        int[,] Label2PosX = new int[10, 10];
        int[,] Label2PosY = new int[10, 10];
        int[,] PanelRed = new int[10, 10];
        int[,] PanelBlue = new int[10, 10];
        int[,] PanelGreen = new int[10, 10];
        string[,] Label1Title = new string[10, 10];
        string[,] Label2Title = new string[10, 10];

        bool AutorizarCambioPantallaGeneral = false;
        bool AutorizarCambioPantalla1a2 = false;
        bool AutorizarTraslacion = false;
        bool AutorizarTraslacionInv = false;
        int[] DimParaTraslacion = new int[13];
        int NumeroDePantalla = 1;
        const int TransparenciaColor = 255;

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
        const int LABELDETECTAR2 = 16;
        const int LABELCONF2 = 17;
        const int LABELLECT2 = 18;
        const int LABELSALIRSIS2 = 19;
        const int PANELREGRESAR = 20;
        const int LABELREGRESAR = 21;

        //Varibles para la animacion
        int[] ContadorCambioColor = new int[13];
        int[] ContadorCambioTamaño = new int[13];
        int[] ContadorAparicionTexto = new int[13];
        int[] ContadorMovimientoTexto = new int[13];

        int[] DimensionadoCambioTamaño = new int[13];

        int ContadorSalida = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Dimensiones de la Forma
            this.Height = 600; //800 pixeles de longitug horizontal
            this.Width = 800; //1000 pixeles de longitud veritical
            EstablecerValoresGloblales();
            ActualizarColores();
            ActualizarDimesiones();
            ActualizarPosiciones();
            OcultarElementos();
            ActualizarPantalla();// Se actualizan cada componente del sistema

        }

        public void EstablecerValoresGloblales()
        {
            //LimipiarVaraibles
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    Paneles[i, j] = -1;
                    Labels1[i, j] = -1;
                    Labels2[i, j] = -1;
                    MinYMax[i, j / 9] = 0;
                    PanelAncho[i, j] = -1;
                    PanelLargo[i, j] = -1;
                    PanelPosX[i, j] = -1;
                    PanelPosY[i, j] = -1;
                    Label1PosX[i, j] = -1;
                    Label1PosY[i, j] = -1;
                    Label2PosX[i, j] = -1;
                    Label2PosY[i, j] = -1;
                    PanelRed[i, j] = 255;
                    PanelGreen[i, j] = 255;
                    PanelBlue[i, j] = 255;
                    Label1Title[i, j] = "";
                    Label2Title[i, j] = "";
                }
            }

            //Establecer valores para Varaible Paneles
            //Pantalla 1
            Paneles[0, 0] = PANELDETECTAR;
            Paneles[1, 0] = PANELCONF;
            Paneles[2, 0] = PANELLECT;
            Paneles[3, 0] = PANELSALIRSIS;
            //Pantalla 2
            Paneles[0, 1] = PANELREGRESAR;

            //Pantalla 1
            Labels1[0, 0] = LABELDETECTAR;
            Labels1[1, 0] = LABELCONF;
            Labels1[2, 0] = LABELLECT;
            Labels1[3, 0] = LABELSALIRSIS;
            //Pantalla 2
            Labels1[0, 1] = LABELREGRESAR;

            //Pantalla 1
            Labels2[0, 0] = LABELDETECTAR2;
            Labels2[1, 0] = LABELCONF2;
            Labels2[2, 0] = LABELLECT2;
            Labels2[3, 0] = LABELSALIRSIS2;
            //Pantalla 2
            //Labels2[0,1] = LABELREGRESAR2;

            MinYMax[0, 0] = 0;
            MinYMax[0, 1] = 4;
            MinYMax[1, 0] = 0;
            MinYMax[1, 1] = 1;

            //Pantalla1
            Label1Title[0, 0] = "Detectar\nPlaca";
            Label1Title[1, 0] = "Configu-\nracion";
            Label1Title[2, 0] = "Lectura de Datos";
            Label1Title[3, 0] = "SALIR";
            //Pantalla 2
            Label2Title[0, 0] = "Regresar";

            //Pantalla1
            Label2Title[0, 0] = "Conecte La placa\nAl sistema";
            Label2Title[1, 0] = "Establezca conexion con la\nplaca para habilitar esta \nopcion";
            Label2Title[2, 0] = "Establezca conexion con la\nplaca para habilitar esta \nopcion";
            Label2Title[3, 0] = "Gracias por usar nuestro Sitema";
            //Pantalla 2
            //Label2Title[0,0] = "Regresar";


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ActualizarColores()
        {
            //Colores paneles pantalla1
            PanelRed[0, 0] = 0;
            PanelRed[1, 0] = 80;
            PanelRed[2, 0] = 80;
            PanelRed[3, 0] = 100;

            PanelGreen[0, 0] = 96;
            PanelGreen[1, 0] = 80;
            PanelGreen[2, 0] = 80;
            PanelGreen[3, 0] = 15;

            PanelBlue[0, 0] = 110;
            PanelBlue[1, 0] = 80;
            PanelBlue[2, 0] = 80;
            PanelBlue[3, 0] = 15;

            //Colores paneles pantalla 1
            PanelRed[0, 1] = 0;
            PanelGreen[0, 1] = 96;
            PanelBlue[0, 1] = 15;
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
            this.LabelDectectar2.Visible = false;
            this.LabelConf2.Visible = false;
            this.LabelLect2.Visible = false;
            this.LabelSalirSis2.Visible = false;
            this.PanelRegresar.Visible = false;
            this.LabelRegresar.Visible = false;
        }

        public void ActualizarDimesiones()
        {

            //Dimesiones de PANTALLA PRINCIPA
            int ANCHOPANELDETECTAR = 7;
            int ANCHOLABELDETECTAR = 8;
            int ANCHOPANELCONF = 9;
            int ANCHOLABELCONF = 10;
            int ANCHOPANELLECT = 11;
            int ANCHOLABELLECT = 12;
            int ANCHOPANELSALIRSIS = 13;
            int ANCHOLABELSALIRSIS = 14;
            int ANCHOFPANELGUIA = 15;
            int ANCHOPANELREGRESAR = 16;
            int ANCHOLABELREGRESAR = 17;

            int LARGOPANELDETECTAR = 7;
            int LARGOLABELDETECTAR = 8;
            int LARGOPANELCONF = 9;
            int LARGOLABELCONF = 10;
            int LARGOPANELLECT = 11;
            int LARGOLABELLECT = 12;
            int LARGOPANELSALIRSIS = 13;
            int LARGOLABELSALIRSIS = 14;
            int LARGOFPANELGUIA = 15;
            int LARGOPANELREGRESAR = 16;
            int LARGOLABELREGRESAR = 17;

            //DimensionesPantalla1
            ANCHOPANELDETECTAR = 20 * this.Width / 100;
            ANCHOPANELCONF = 20 * this.Width / 100;
            ANCHOPANELLECT = 45 * this.Width / 100;
            ANCHOPANELSALIRSIS = 45 * this.Width / 100;
            ANCHOFPANELGUIA = 40 * this.Width / 100;
            //Dimesiones Pantalla2
            ANCHOPANELREGRESAR = 30 * this.Width / 100;

            //DImesion Y pantalla1
            LARGOPANELDETECTAR = 14 * this.Height / 100;//29
            LARGOPANELCONF = 14 * this.Height / 100;
            LARGOPANELLECT = 9 * this.Height / 100;
            LARGOPANELSALIRSIS = 9 * this.Height / 100;
            LARGOFPANELGUIA = 65 * this.Height / 100;
            //Dimesion Y pantalla 2
            LARGOPANELREGRESAR = 20 * this.Width / 100;

            //Guardar en Variables globales
            //Ancho Pantalla1
            PanelAncho[0, 0] = ANCHOPANELDETECTAR;
            PanelAncho[1, 0] = ANCHOPANELCONF;
            PanelAncho[2, 0] = ANCHOPANELLECT;
            PanelAncho[3, 0] = ANCHOPANELSALIRSIS;
            //Ancho Pantalla2
            PanelAncho[0, 1] = ANCHOPANELREGRESAR;

            //Largo Pantalla 1
            PanelLargo[0, 0] = LARGOPANELDETECTAR;
            PanelLargo[1, 0] = LARGOPANELCONF;
            PanelLargo[2, 0] = LARGOPANELLECT;
            PanelLargo[3, 0] = LARGOPANELSALIRSIS;
            //Largo Pantalla 2
            PanelLargo[0, 1] = LARGOPANELREGRESAR;

        }

        public void ActualizarPosiciones()
        {
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
            int POSXLABELDETECTAR2 = 8;
            int POSXLABELCONF2 = 10;
            int POSXLABELLECT2 = 12;
            int POSXLABELSALIRSIS2 = 14;
            int POSXPANELREGRESAR = 16;
            int POSXLABELREGRESAR = 17;
            int POSXLABELREGRESAR2 = 18;

            int POSYPANELDETECTAR = 7;
            int POSYLABELDETECTAR = 8;
            int POSYPANELCONF = 9;
            int POSYLABELCONF = 10;
            int POSYPANELLECT = 11;
            int POSYLABELLECT = 12;
            int POSYPANELSALIRSIS = 13;
            int POSYLABELSALIRSIS = 14;
            int POSYFPANELGUIA = 15;
            int POSYLABELDETECTAR2 = 16;
            int POSYLABELCONF2 = 10;
            int POSYLABELLECT2 = 12;
            int POSYLABELSALIRSIS2 = 14;
            int POSYPANELREGRESAR = 16;
            int POSYLABELREGRESAR = 17;
            int POSYLABELREGRESAR2 = 18;

            int ANCHOPANELDETECTAR = 7;
            int ANCHOLABELDETECTAR = 8;
            int ANCHOPANELCONF = 9;
            int ANCHOLABELCONF = 10;
            int ANCHOPANELLECT = 11;
            int ANCHOLABELLECT = 12;
            int ANCHOPANELSALIRSIS = 13;
            int ANCHOLABELSALIRSIS = 14;
            int ANCHOFPANELGUIA = 15;
            int ANCHOPANELREGRESAR = 16;
            int ANCHOLABELREGRESAR = 17;

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
            int LARGOPANELREGRESAR = 16;
            int LARGOLABELREGRESAR = 17;

            //Variables Pantalla 1
            POSXPANELBARRA = 0;
            POSXPANELMIN = this.Width - 3 * 5 * this.Width / 100;
            POSXPANELMAX = this.Width - 2 * 5 * this.Width / 100;
            POSXPANELSALIR = this.Width - 1 * 5 * this.Width / 100;
            POSXPANELTITULO = 0;
            POSXLABELTITULO1 = 2 * this.Width / 100;
            POSXLABELTITULO2 = 80 * this.Width / 100;
            POSXLABELREGRESAR2 = 5 * PanelAncho[0, 1] / 100;
            //Pantalla 1
            POSXPANELDETECTAR = 5 * this.Width / 100;
            POSXLABELDETECTAR = 5 * PanelAncho[0, 0] / 100;
            POSXPANELCONF = 10 * this.Width / 100 + PanelAncho[0, 0];
            POSXLABELCONF = 5 * PanelAncho[1, 0] / 100;
            POSXPANELLECT = 5 * this.Width / 100;
            POSXLABELLECT = 10 * PanelAncho[2, 0] / 100;
            POSXLABELLECT2 = 10 * PanelAncho[2, 0] / 100;
            POSXPANELSALIRSIS = 5 * this.Width / 100;
            POSXLABELSALIRSIS = 35 * PanelAncho[3, 0] / 100;
            POSXLABELSALIRSIS2 = 5 * PanelAncho[3, 0] / 100;
            POSXFPANELGUIA = 55 * this.Width / 100;
            POSXLABELDETECTAR2 = 5 * PanelAncho[0, 0] / 100;
            POSXLABELCONF2 = 5 * PanelAncho[1, 0] / 100;
            POSXPANELREGRESAR = 5 * this.Width / 100;
            POSXLABELREGRESAR = 5 * PanelAncho[0, 1] / 100;
            //POSYLABELREGRESAR2 = 100 * ANCHOPANELREGRESAR / 100;

            POSYPANELDETECTAR = 20 * this.Height / 100;
            POSYLABELDETECTAR = 5 * PanelLargo[0, 0] / 100;
            POSYLABELDETECTAR2 = 100 * PanelLargo[0, 0] / 100;
            POSYPANELCONF = POSYPANELDETECTAR;
            POSYLABELCONF = 5 * PanelLargo[0, 0] / 100;
            POSYLABELCONF2 = 100 * PanelLargo[0, 0] / 100;
            POSYPANELLECT = 51 * this.Height / 100;
            POSYLABELLECT = 10 * PanelLargo[2, 0] / 100;
            POSYLABELLECT2 = 100 * PanelLargo[2, 0] / 100;
            POSYPANELSALIRSIS = 71 * this.Height / 100;
            POSYLABELSALIRSIS = 10 * PanelLargo[3, 0] / 100;
            POSYLABELSALIRSIS2 = 100 * PanelLargo[3, 0] / 100;
            POSYFPANELGUIA = POSYPANELDETECTAR;
            POSYPANELREGRESAR = 5 * this.Width / 100;
            POSYLABELREGRESAR = 5 * PanelLargo[0, 1] / 100;

            //Guardar en Variables globales
            //Pantalla 1
            PanelPosX[0, 0] = POSXPANELDETECTAR;
            PanelPosX[1, 0] = POSXPANELCONF;
            PanelPosX[2, 0] = POSXPANELLECT;
            PanelPosX[3, 0] = POSXPANELSALIRSIS;
            //Pantalla 2
            PanelPosX[0, 1] = POSXPANELREGRESAR;

            //Pantalla 1
            Label1PosY[0, 0] = POSYLABELDETECTAR;
            Label1PosY[1, 0] = POSYLABELCONF;
            Label1PosY[2, 0] = POSYLABELLECT;
            Label1PosY[3, 0] = POSYLABELSALIRSIS;
            //Pantalla 2
            Label1PosY[0, 1] = POSYLABELREGRESAR;

            //Pantalla 1
            Label1PosX[0, 0] = POSXLABELDETECTAR;
            Label1PosX[1, 0] = POSXLABELCONF;
            Label1PosX[2, 0] = POSXLABELLECT;
            Label1PosX[3, 0] = POSXLABELSALIRSIS;
            //Pantalla 2
            Label1PosX[0, 1] = POSXPANELREGRESAR;

            //Pantalla 1
            PanelPosY[0, 0] = POSYPANELDETECTAR;
            PanelPosY[1, 0] = POSYPANELCONF;
            PanelPosY[2, 0] = POSYPANELLECT;
            PanelPosY[3, 0] = POSYPANELSALIRSIS;
            //Pantalla 2
            PanelPosY[0, 1] = POSYPANELREGRESAR;

            //Pantalla 1
            Label2PosY[0, 0] = POSYLABELDETECTAR2;
            Label2PosY[1, 0] = POSYLABELCONF2;
            Label2PosY[2, 0] = POSYLABELLECT2;
            Label2PosY[3, 0] = POSYLABELSALIRSIS2;
            //Pantalla 2
            //Label2PosY[0,1] = POSYLABELREGRESAR2;

            //Pantalla 1
            Label2PosX[0, 0] = POSXLABELDETECTAR2;
            Label2PosX[1, 0] = POSXLABELCONF2;
            Label2PosX[2, 0] = POSXLABELLECT2;
            Label2PosX[3, 0] = POSXLABELSALIRSIS2;
            //Pantalla 2
            //Label2PosX[0,1] = POSXPANELREGRESAR2;

        }

        public void ActualizarPantalla()
        {
            this.BackColor = Color.FromArgb(255, 255, 255, 255);
            PantallaInicial();
            MostrarPantalla();
        }

        public void PantallaInicial()
        {
            int ANCHOPANELBARRA = 0;
            int ANCHOPANELMIN = 1;
            int ANCHOPANELMAX = 2;
            int ANCHOPANELSALIR = 3;
            int ANCHOPANELTITULO = 4;
            int ANCHOLABELTITULO1 = 5;
            int ANCHOLABELTITULO2 = 6;

            int POSXPANELBARRA = 0;
            int POSXPANELMIN = 1;
            int POSXPANELMAX = 2;
            int POSXPANELSALIR = 3;
            int POSXPANELTITULO = 4;
            int POSXLABELTITULO1 = 5;
            int POSXLABELTITULO2 = 6;

            int POSYPANELBARRA = 0;
            int POSYPANELMIN = 1;
            int POSYPANELMAX = 2;
            int POSYPANELSALIR = 3;
            int POSYPANELTITULO = 4;
            int POSYLABELTITULO1 = 5;
            int POSYLABELTITULO2 = 6;

            int LARGOPANELBARRA = 0;
            int LARGOPANELMIN = 1;
            int LARGOPANELMAX = 2;
            int LARGOPANELSALIR = 3;
            int LARGOPANELTITULO = 4;
            int LARGOLABELTITULO1 = 5;
            int LARGOLABELTITULO2 = 6;

            ANCHOPANELBARRA = this.Width;
            ANCHOPANELMIN = 5 * this.Width / 100;
            ANCHOPANELMAX = 5 * this.Width / 100;
            ANCHOPANELSALIR = 5 * this.Width / 100;
            ANCHOPANELTITULO = this.Width;

            LARGOPANELBARRA = 5 * this.Height / 100;
            LARGOPANELMIN = 5 * this.Height / 100;
            LARGOPANELMAX = 5 * this.Height / 100;
            LARGOPANELSALIR = 5 * this.Height / 100;
            LARGOPANELTITULO = 10 * this.Height / 100;

            //Variables Pantalla 1
            POSXPANELBARRA = 0;
            POSXPANELMIN = this.Width - 3 * ANCHOPANELMIN;
            POSXPANELMAX = this.Width - 2 * ANCHOPANELMIN;
            POSXPANELSALIR = this.Width - 1 * ANCHOPANELMIN;
            POSXPANELTITULO = 0;
            POSXLABELTITULO1 = 2 * ANCHOPANELTITULO / 100;
            POSXLABELTITULO2 = 80 * ANCHOPANELTITULO / 100;

            POSYPANELBARRA = 0;
            POSYPANELMIN = 0;
            POSYPANELMAX = 0;
            POSYPANELSALIR = 0;
            POSYPANELTITULO = LARGOPANELBARRA;
            POSYLABELTITULO1 = 5 * LARGOPANELBARRA / 100;
            POSYLABELTITULO2 = 5 * LARGOPANELBARRA / 100;

            //Diseño Barra de opciones superior
            CrearPanel(PANELBARRA, 255, 0, 32, 96, ANCHOPANELBARRA, LARGOPANELBARRA, POSXPANELBARRA, POSYPANELBARRA);
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
            CrearPanel(PANELTITULO, 255, 236, 126, 7, ANCHOPANELTITULO, LARGOPANELTITULO, POSXPANELTITULO, POSYPANELTITULO);
            CrearLabel(PANELTITULO, LABELTITULO1, "Programador", 255, 0, 200, 55, POSXLABELTITULO1, POSYLABELTITULO1, 24);
            CrearLabel(PANELTITULO, LABELTITULO2, "TECNAS C.A", 255, 0, 200, 55, POSXLABELTITULO2, POSYLABELTITULO2, 24);


        }

        public void MostrarPantalla()
        {
            for (int i = MinYMax[NumeroDePantalla - 1,0]; i < MinYMax[NumeroDePantalla - 1, 1]; i++)
            {
                if (Paneles[i, NumeroDePantalla - 1] != -1)
                {
                    CrearPanel(Paneles[i, NumeroDePantalla - 1], TransparenciaColor, PanelRed[i, NumeroDePantalla - 1], PanelGreen[i, NumeroDePantalla - 1], PanelBlue[i, NumeroDePantalla - 1], PanelAncho[i, NumeroDePantalla - 1], PanelLargo[i, NumeroDePantalla - 1], PanelPosX[i, NumeroDePantalla - 1], PanelPosY[i, NumeroDePantalla - 1]);
                }
                if (Labels1[i, NumeroDePantalla - 1] != -1)
                {
                    CrearLabel(Paneles[i, NumeroDePantalla - 1], Labels1[i, NumeroDePantalla - 1], Label1Title[i, NumeroDePantalla - 1], 255, 255, 255, 255, Label1PosX[i, NumeroDePantalla - 1], Label1PosY[i, NumeroDePantalla - 1], 24);
                }
                if (Labels2[i, NumeroDePantalla - 1] != -1)
                {
                    CrearLabel(Paneles[i, NumeroDePantalla - 1], Labels2[i, NumeroDePantalla - 1], Label2Title[i, NumeroDePantalla - 1], 255, 255, 255, 255, Label2PosX[i, NumeroDePantalla - 1], Label2PosY[i, NumeroDePantalla - 1], 10);
                }
            }

            /*
            //Diseño de PanelFGuia
            CrearFPanel(FPANELGUIA, 255, 0, 255, 0, ANCHOFPANELGUIA, LARGOFPANELGUIA, POSXFPANELGUIA, POSYFPANELGUIA);*/
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

            //Console.WriteLine(Directory + LocData + TextoPDF + "1" + ".jpg");

            for (int i = 1; i <= NumeroDePaginas; i++)
            {
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.AutoSize;
                pb.Image = Image.FromFile(Directory + LocData + TextoPDF + i.ToString() + ".jpg");
                pb.Image = new Bitmap(pb.Image, 90 * P.Width / 100, 90 * pb.Image.Height / 100);
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
                case LABELCONF2:
                    l = this.LabelConf2;
                    break;
                case LABELDETECTAR:
                    l = this.LabelDetectar;
                    break;
                case LABELDETECTAR2:
                    l = this.LabelDectectar2;
                    break;
                case LABELLECT:
                    l = this.LabelLect;
                    break;
                case LABELLECT2:
                    l = this.LabelLect2;
                    break;
                case LABELSALIRSIS:
                    l = this.LabelSalirSis;
                    break;
                case LABELSALIRSIS2:
                    l = this.LabelSalirSis2;
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
            this.PanelRegresar.Visible = true;
            this.PanelRegresar.BackColor = Color.FromArgb(255, 120, 120, 120);
            this.PanelRegresar.Height = this.Height / 10;
            this.PanelRegresar.Width = 22 * this.Width / 100;
            this.PanelRegresar.Location = new Point(-this.PanelRegresar.Width, this.Height - 5 * EspacioAdicional);
            this.LabelRegresar.Text = "Regresar\n";
            this.LabelRegresar.Font = new Font("Arial", 24, FontStyle.Bold);
            this.LabelRegresar.ForeColor = Color.FromArgb(255, 255, 255, 255);
            this.LabelRegresar.BackColor = Color.FromArgb(255, 120, 120, 120);
            this.LabelRegresar.Location = new Point(5 * this.PanelDetectar.Width / 100, 5 * this.PanelDetectar.Height / 100);
            this.PanelRegresar.Controls.Add(LabelRegresar);
        }

        public void MostarPanelDetectarPlaca()
        {
            this.PanelDetectar.Visible = true;
            this.PanelDetectar.BackColor = Color.FromArgb(255, 0, 96, 110);
            this.PanelDetectar.Height = this.Width / 6;
            this.PanelDetectar.Width = this.Height / 3;
            this.PanelDetectar.Location = new Point(EspacioAdicional, this.PanelSalir.Height + EspacioAdicional);
            //Label Lbl = new Label();
            this.LabelDetectar.Text = "Detectar\nPlaca";
            this.LabelDetectar.Font = new Font("Arial", 24, FontStyle.Bold);
            this.LabelDetectar.ForeColor = Color.FromArgb(255, 255, 255, 255);
            this.LabelDetectar.BackColor = Color.FromArgb(255, 0, 96, 110);
            //this.Lbl.Width = 7 * this.PanelDetectar.Width / 10;
            //this.Lbl.Height =  7 * this.PanelDetectar.Height / 10;
            this.LabelDetectar.Location = new Point(5 * this.PanelDetectar.Width / 100, 5 * this.PanelDetectar.Height / 100);

            this.PanelDetectar.Controls.Add(LabelDetectar);
            //LocationOfIntroImage = direct + PantallaSeleccionOpciones(a);
            //this.PanelMin.Controls.Clear();
            //ShowImages(LocationOfIntroImage, a);
        }

        public void ShowImages(string Location, int a)
        {
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

        public void MostrarPanelMMS(string direct, int a)
        {
            CrearPanel(a % 3 + 1, 0, 0, 0, 0, MedidaOpcion, MedidaOpcion, this.Width - (3 - a % 3) * OpcionImagenTamaño - EspacioAdicional, 0);
            LocationOfIntroImage = direct + PantallaSeleccionOpciones(a);
            if (a % 3 == 0)
            {
                this.PanelMin.Controls.Clear();
            }
            else if (a % 3 == 1)
            {
                this.PanelMax.Controls.Clear();
            }
            else if (a % 3 == 2)
            {
                this.PanelSalir.Controls.Clear();
            }
            ShowImages(LocationOfIntroImage, a);
        }

        public void MostrarPanelMaximo(string direct, int a)
        {
            CrearPanel(1, 0, 0, 0, 0, MedidaOpcion, MedidaOpcion, this.Width - 2 * OpcionImagenTamaño - EspacioAdicional, 0);
            LocationOfIntroImage = direct + PantallaSeleccionOpciones(a);
            this.PanelMax.Controls.Clear();
            ShowImages(LocationOfIntroImage, a);
        }

        public void MostrarPanelSalir(string direct, int a)
        {
            CrearPanel(1, 0, 0, 0, 0, MedidaOpcion, MedidaOpcion, this.Width - 1 * OpcionImagenTamaño - EspacioAdicional, 0);
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
            //Console.WriteLine("Panel Minimo 1");
        }

        private void PanelMin_MouseLeave_1(object sender, EventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            // Update the mouse event label to indicate the MouseLeave event occurred.
            MostrarPanelMMS(directory, 0);
            //Console.WriteLine("Panel Minimo 0");
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
            //Console.WriteLine("Panel Minimo Pulsado");
        }

        private void PanelBarra_MouseHover(object sender, EventArgs e)
        {
            //Console.WriteLine("Panel Barra 1");
        }

        private void PanelDetectar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelDetectar_MouseHover(object sender, EventArgs e)
        {
            //AutorizarAnimacionDetectar = true;
        }

        public void AnimacionPanelDetectar()
        {
            //this.PanelDetectar.Width = this.PanelDetectar.Width + (a)*this.PanelDetectar.Width / 1000;
            this.PanelDetectar.BackColor = Color.FromArgb(255, 0, 96, 110 + ContadorAnimacionDetectar);
            this.LabelDetectar.BackColor = this.PanelDetectar.BackColor;
        }

        private void PanelDetectar_MouseLeave(object sender, EventArgs e)
        {
            //AutorizarAnimacionDetectar = false;          
        }

        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            //AnimacionPanelDetectar();
            //AutorizarAnimacionDetectar = true;
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            //AutorizarAnimacionDetectar = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Variables para posicion del Mouse
            int MouseYPos = Control.MousePosition.Y;
            int MouseXPos = Control.MousePosition.X;

            if (true)
            {
                // Variables para Recuadro Detectar Placa
                int[] DectX1 = new int[13];
                int[] DectX2 = new int[13];
                int[] DectY1 = new int[13];
                int[] DectY2 = new int[13];
                //TextoOpciones[0] = "\\Imagenes\\OpcionMin.png";
                int[] PosXVAL = new int[13];
                int[] PosYVAL = new int[13];
                //
                int[] P1 = new int[13];
                int k = 0;
                while (Paneles[k, NumeroDePantalla - 1] != -1 && k < MinYMax[NumeroDePantalla - 1, 1])
                {
                    P1[k] = Paneles[k, NumeroDePantalla - 1];
                    PosXVAL[k] = PanelPosX[k, NumeroDePantalla - 1];
                    PosYVAL[k] = PanelPosY[k, NumeroDePantalla - 1];
                    k++;
                }

                //***********************

                for (int i = MinYMax[NumeroDePantalla - 1, 0]; i < MinYMax[NumeroDePantalla - 1, 1]; i++)
                {

                    var P = this.PanelBarra;
                    switch (P1[i])
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

                    DectX1[i] = this.Left + PosXVAL[i] + 1 * this.Height / 100;
                    DectX2[i] = DectX1[i] + P.Width;
                    DectY1[i] = this.Top + PosYVAL[i] + 5 * this.Height / 100;
                    DectY2[i] = DectY1[i] + P.Height;
                }
                int ContadorTraslacion = 0;
                for (int i = MinYMax[NumeroDePantalla - 1, 0]; i < MinYMax[NumeroDePantalla - 1, 1]; i++)
                {
                    if (!AutorizarTraslacion && !AutorizarTraslacionInv)
                    {
                        if (MouseXPos >= DectX1[i] && MouseXPos <= DectX2[i] && MouseYPos >= DectY1[i] && MouseYPos <= DectY2[i])
                        {
                            if (ContadorCambioColor[i] < 100)
                            {
                                AnimacionCambioColor(1, i);
                            }
                            if (ContadorCambioTamaño[i] < 50)
                            {
                                AnimacionCambioDimesionRecuadro(1, i);
                            }
                            if (ContadorAparicionTexto[i] < 255 && ContadorCambioTamaño[i] >= 25)
                            {
                                AnimacionAparicionTexto(1, i);
                            }
                        }
                        else
                        {
                            if (ContadorCambioColor[i] > 0 && ContadorCambioTamaño[i] < 10)
                            {
                                AnimacionCambioColor(0, i);
                            }
                            if (ContadorCambioTamaño[i] > 0 && ContadorAparicionTexto[i] < 50)
                            {
                                AnimacionCambioDimesionRecuadro(0, i);
                            }
                            if (ContadorAparicionTexto[i] > 0)
                            {
                                AnimacionAparicionTexto(0, i);
                            }
                        }
                    }
                    else if (AutorizarTraslacion && !AutorizarTraslacionInv)
                    {
                        //Console.WriteLine("Modo Traslacion");
                        if (ContadorCambioTamaño[i] > 0)
                        {
                            AnimacionCambioDimesionRecuadro(0, i);
                        }
                        else if (ContadorCambioTamaño[i] <= 0 )
                        {
                            ContadorTraslacion++;
                            if (ContadorTraslacion == MinYMax[NumeroDePantalla - 1, 1])
                            {
                                AutorizarTraslacionInv = true;
                                //AutorizarTraslacion = false;
                                Console.WriteLine("AutorizarTraslacionInv: " + AutorizarTraslacionInv.ToString());
                                ContadorTraslacion = 0;
                            }
                        }
                    }
                    else if (!AutorizarTraslacion && AutorizarTraslacionInv)
                    {
                        if (ContadorCambioTamaño[i] < 50)
                        {
                            AnimacionCambioDimesionRecuadro(1, i);
                        }
                        else if (ContadorCambioTamaño[i] >= 50)
                        {
                            ContadorTraslacion++;
                            if (ContadorTraslacion == MinYMax[NumeroDePantalla - 1, 1])
                            {
                                AutorizarTraslacionInv = false;
                                AutorizarCambioPantalla1a2 = false;
                                AutorizarCambioPantallaGeneral = false;
                                for (int j = MinYMax[NumeroDePantalla - 1, 0]; j < MinYMax[NumeroDePantalla - 1, 1]; j++)
                                {
                                    ContadorCambioColor[j] = 0;
                                    ContadorAparicionTexto[j] = 0;
                                    ContadorCambioTamaño[j] = 0;
                                }
                            }
                        }
                    }

                }
                if (AutorizarCambioPantalla1a2 && !AutorizarTraslacion && !AutorizarTraslacionInv)
                {
                    AutorizarTraslacion = true;
                    EstablecerCocientes();
                }
                else if (AutorizarTraslacion && AutorizarTraslacionInv)
                {
                    AutorizarTraslacion = false;
                }
            }
            
        }

        public void EstablecerCocientes()
        {
            if (NumeroDePantalla == 1)
            {
                DimensionadoCambioTamaño[0] = this.PanelDetectar.Height;
                //Console.WriteLine("X1: " + DimensionadoCambioTamaño[0].ToString());
                DimensionadoCambioTamaño[1] = this.PanelConf.Height;
                DimensionadoCambioTamaño[2] = this.PanelLect.Height;
                DimensionadoCambioTamaño[3] = this.PanelSalirSis.Height;
            }
            else if (NumeroDePantalla == 2)
            {
                DimensionadoCambioTamaño[0] = this.PanelRegresar.Height;
            }
            for (int j = MinYMax[NumeroDePantalla - 1, 0]; j < MinYMax[NumeroDePantalla - 1, 1]; j++)
            {
                ContadorCambioColor[j] = 0;
                ContadorAparicionTexto[j] = 0;
                ContadorCambioTamaño[j] = 50;
            }
        }

        public void AnimacionAparicionTexto(int a, int i)
        {
            if (a == 1 && ContadorAparicionTexto[i] < 255)
            {
                ContadorAparicionTexto[i] = ContadorAparicionTexto[i] + 20;
            }
            else if (a == 0 && ContadorAparicionTexto[i] > 0)
            {
                ContadorAparicionTexto[i] = ContadorAparicionTexto[i] - 20;
            }
            if (ContadorAparicionTexto[i] > 255)
            {
                ContadorAparicionTexto[i] = 255;
            }
            else if (ContadorAparicionTexto[i] < 0)
            {
                ContadorAparicionTexto[i] = 0;
            }

            //this.LabelDectectar2.ForeColor = Color.FromArgb(ContadorAparicionTexto[i], 255, 255, 255);
        }

        public void AnimacionCambioDimesionRecuadro(int a, int i)
        {

            int dat = 0;
            int[,] A = new int[13, 5];
            //Console.WriteLine("AutorizarTraslacion: " + AutorizarTraslacion.ToString());
            //Console.WriteLine("AutorizarTraslacionInv: " + AutorizarTraslacionInv.ToString());
            //Console.WriteLine("AutorizarCambioPantallaGeneral: " + AutorizarCambioPantallaGeneral.ToString());
            //Console.WriteLine("AutorizarCambioPantalla1a2: " + AutorizarCambioPantalla1a2.ToString());
            if (!AutorizarTraslacion && !AutorizarTraslacionInv)
            {
                A[0, 0] = 14 * this.Height / 100;
                A[1, 0] = 14 * this.Height / 100;
                A[2, 0] = 9 * this.Height / 100;
                A[3, 0] = 9 * this.Height / 100;
                A[0, 1] = 5 * this.Height / 100;
                //Console.WriteLine("X1: " + A[i, NumeroDePantalla - 1].ToString());
            }
            else if (AutorizarTraslacion && !AutorizarTraslacionInv)
            {
                A[0, 0] = DimensionadoCambioTamaño[0];
                A[1, 0] = DimensionadoCambioTamaño[1];
                A[2, 0] = DimensionadoCambioTamaño[2];
                A[3, 0] = DimensionadoCambioTamaño[3];
                A[0, 1] = DimensionadoCambioTamaño[0];
                //Console.WriteLine("X2: " + A[i, NumeroDePantalla - 1].ToString());
            }
            else if (!AutorizarTraslacion && AutorizarTraslacionInv)
            {
                A[0, 0] = PanelLargo[0, 0];
                A[1, 0] = PanelLargo[1, 0];
                A[2, 0] = PanelLargo[2, 0];
                A[3, 0] = PanelLargo[3, 0];
                A[0, 1] = PanelLargo[0, 1];
                Console.WriteLine("X4: " + A[i, NumeroDePantalla - 1].ToString() + "i: " + i.ToString() + "Pantalla: " + NumeroDePantalla.ToString());
            }

            dat = (int)((A[i, NumeroDePantalla - 1] ) * (1 - Math.Exp(-ContadorCambioTamaño[i] * 0.1 / 2)));

            if (a == 1 && dat < A[i, NumeroDePantalla - 1] && ContadorCambioTamaño[i] < 50)
            {
                ContadorCambioTamaño[i]++;
            }
            else if (a == 0 && ContadorCambioTamaño[i] > 0)
            {
                ContadorCambioTamaño[i]--;
            }
            if (ContadorCambioTamaño[i] < 0)
            {
                ContadorCambioTamaño[i] = 0;
            }
            //LARGOPANELDETECTAR = LARGOPANELDETECTAR + dat;
            //
            int[] P1 = new int[13];
            P1[0] = PANELDETECTAR;
            P1[1] = PANELCONF;
            P1[2] = PANELLECT;
            P1[3] = PANELSALIRSIS;
            int[] P2 = new int[13];
            P2[0] = PanelLargo[0, 0];
            P2[1] = PanelLargo[1, 0];
            P2[2] = PanelLargo[2, 0];
            P2[3] = PanelLargo[3, 0];
            var P = this.PanelBarra;
            switch (P1[i])
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
            if (!AutorizarTraslacion && !AutorizarTraslacionInv)
            {
                P.Height = P2[i] + dat;
                //Console.WriteLine("X7: " + P.Height.ToString());
            }
            else if (AutorizarTraslacion && !AutorizarTraslacionInv || !AutorizarTraslacion && AutorizarTraslacionInv)
            {
                P.Height = dat;
                //Console.WriteLine("X3: " + P.Height.ToString());
            }
            
        }

        public void AnimacionCambioColor(int a, int i)
        {
            if (a == 1 && ContadorCambioColor[i] < 120)
            {
                ContadorCambioColor[i] = ContadorCambioColor[i] + 10;
            }
            else if (a == 0 && ContadorCambioColor[i] > 0)
            {
                ContadorCambioColor[i] = ContadorCambioColor[i] - 10;
            }


            int[] P1 = new int[13];
            P1[0] = PANELDETECTAR;
            P1[1] = PANELCONF;
            P1[2] = PANELLECT;
            P1[3] = PANELSALIRSIS;
            int[] L1 = new int[13];
            L1[0] = LABELDETECTAR;
            L1[1] = LABELCONF;
            L1[2] = LABELLECT;
            L1[3] = LABELSALIRSIS;
            int[] L2 = new int[13];
            L2[0] = LABELDETECTAR2;
            L2[1] = LABELCONF2;
            L2[2] = LABELLECT2;
            L2[3] = LABELSALIRSIS2;

            int[] ColorSelAlpha = new int[3];
            int[] ColorSelRed = new int[3];
            int[] ColorSelGreen = new int[3];
            int[] ColorSelBlue = new int[3];

            var P = this.PanelBarra;
            switch (P1[i])
            {
                case PANELBARRA:
                    P = this.PanelBarra;
                    break;
                case PANELCONF:
                    P = this.PanelConf;
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = 80 + ContadorCambioColor[i];
                    ColorSelGreen[0] = 80 + ContadorCambioColor[i];
                    ColorSelBlue[0] = 80 + ContadorCambioColor[i];
                    break;
                case PANELDETECTAR:
                    P = this.PanelDetectar;
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = 0;
                    ColorSelGreen[0] = 96;
                    ColorSelBlue[0] = 110 + ContadorCambioColor[i];
                    break;
                case PANELLECT:
                    P = this.PanelLect;
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = 80 + ContadorCambioColor[i];
                    ColorSelGreen[0] = 80 + ContadorCambioColor[i];
                    ColorSelBlue[0] = 80 + ContadorCambioColor[i];
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
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = 100 + ContadorCambioColor[i];
                    ColorSelGreen[0] = 15;
                    ColorSelBlue[0] = 15;
                    break;
                case PANELTITULO:
                    P = this.PanelTitulo;
                    break;
                default:
                    return;
            }
            var l = this.LabelTitulo1;
            switch (L1[i])
            {
                case LABELCONF:
                    l = this.LabelConf;
                    break;
                case LABELCONF2:
                    l = this.LabelConf2;
                    break;
                case LABELDETECTAR:
                    l = this.LabelDetectar;
                    break;
                case LABELDETECTAR2:
                    l = this.LabelDectectar2;
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
            var l2 = this.LabelTitulo1;
            switch (L2[i])
            {
                case LABELCONF2:
                    l2 = this.LabelConf2;
                    break;
                case LABELDETECTAR2:
                    l2 = this.LabelDectectar2;
                    break;
                case LABELLECT2:
                    l2 = this.LabelLect2;
                    break;
                case LABELSALIRSIS2:
                    l2 = this.LabelSalirSis2;
                    break;

                default:
                    return;
            }

            P.BackColor = Color.FromArgb(ColorSelAlpha[0], ColorSelRed[0], ColorSelGreen[0], ColorSelBlue[0]);
            l.BackColor = P.BackColor;
            l2.BackColor = P.BackColor;
        }

        public void TraslacionRegresarPantalla1()
        {
            if (this.PanelRegresar.Location.X > -this.PanelRegresar.Width)
            {
                ExponenecialContador++;
                int dat = this.PanelDetectar.Location.X - (int)(Math.Exp(ExponenecialContador * 0.01 / 8));
                this.SelPuerto.Location = new Point(dat, this.SelPuerto.Location.Y);
                this.PanelRegresar.Location = new Point(dat, this.Height - 8 * EspacioAdicional);
            }
            else if (this.PanelRegresar.Location.X <= -this.PanelRegresar.Width)
            {
                this.PanelDetectar.Visible = false;
                //LastValue = (int)(Math.Exp(ExponenecialContador / 8));
                //Console.WriteLine(LastValue.ToString());
                ExponenecialContador = 0;
                //AutorizarRegresarPantalla1 = false;
                this.SelPuerto.Visible = true;
                this.PanelRegresar.Visible = true;
                //MostrarSeleccionOpciones();
            }
        }

        public void TraslacionPanelDetectar()
        {
            if (this.PanelDetectar.Location.X > -this.PanelDetectar.Width)
            {
                ExponenecialContador++;
                int dat = this.PanelDetectar.Location.X - (int)(Math.Exp(ExponenecialContador / 8));
                this.PanelDetectar.Location = new Point(dat, this.PanelDetectar.Location.Y);
            }
            else if (this.PanelDetectar.Location.X <= -this.PanelDetectar.Width)
            {
                this.PanelDetectar.Visible = false;
                LastValue = (int)(Math.Exp(ExponenecialContador / 8));
                //Console.WriteLine(LastValue.ToString());
                ExponenecialContador = 0;
                //AutorizarTraslacionInversaDetectar = true;
                this.SelPuerto.Visible = true;
                this.PanelRegresar.Visible = true;
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
            if (!AutorizarCambioPantallaGeneral)
            {
                AutorizarCambioPantallaGeneral = true;
                AutorizarCambioPantalla1a2 = true;
            }
        }

        private void Lbl_MouseClick(object sender, MouseEventArgs e)
        {
            if (!AutorizarCambioPantallaGeneral)
            {
                AutorizarCambioPantallaGeneral = true;
                AutorizarCambioPantalla1a2 = true;
            }
        }

        private void SelPuerto_Click(object sender, EventArgs e)
        {

        }

        private void RegresarDet_MouseClick(object sender, MouseEventArgs e)
        {
            //AutorizarRegresarPantalla1 = true;
        }

        private void RegPantalla2_MouseClick(object sender, MouseEventArgs e)
        {
            //AutorizarRegresarPantalla1 = true;
        }

        private void LabelDectectar2_Click(object sender, EventArgs e)
        {

        }

        private void LabelDectectar2_MouseClick(object sender, MouseEventArgs e)
        {
            if (!AutorizarCambioPantallaGeneral)
            {
                AutorizarCambioPantallaGeneral = true;
                AutorizarCambioPantalla1a2 = true;
            }
        }

    }
}
