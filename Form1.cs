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
        const int MartrixDim = 20;

        //Variables del sistema
        int[,] Paneles = new int[MartrixDim, MartrixDim];
        int[,] Labels1 = new int[MartrixDim, MartrixDim];
        int[,] Labels2 = new int[MartrixDim, MartrixDim];
        int[,] MinYMax = new int[MartrixDim, 2];
        int[,] PanelAncho = new int[MartrixDim, MartrixDim];
        int[,] PanelLargo = new int[MartrixDim, MartrixDim];
        int[,] PanelPosX = new int[MartrixDim, MartrixDim];
        int[,] PanelPosY = new int[MartrixDim, MartrixDim];
        int[,] Label1PosX = new int[MartrixDim, MartrixDim];
        int[,] Label1PosY = new int[MartrixDim, MartrixDim];
        int[,] Label2PosX = new int[MartrixDim, MartrixDim];
        int[,] Label2PosY = new int[MartrixDim, MartrixDim];
        int[,] PanelRed = new int[MartrixDim, MartrixDim];
        int[,] PanelBlue = new int[MartrixDim, MartrixDim];
        int[,] PanelGreen = new int[MartrixDim, MartrixDim];
        string[,] Label1Title = new string[MartrixDim, MartrixDim];
        string[,] Label2Title = new string[MartrixDim, MartrixDim];

        //d


        bool AutorizarCambioPantallaGeneral = false;
        bool AutorizarCambioPantalla1a2 = false;
        bool AutorizarCambioPantalla2a1 = false;
        bool AutorizarTraslacion = false;
        bool AutorizarTraslacionInv = false;
        int[] DimParaTraslacion = new int[13];
        int NumeroDePantalla = 1;
        const int TransparenciaColor = 255;

        //Definicion de variables (Paneles y labels)
        //Barra Principal
        const int PANELBARRA = 0;
        const int PANELMIN = 1;
        const int PANELMAX = 2;
        const int PANELSALIR = 3;
        const int PANELTITULO = 4;
        const int LABELTITULO1 = 5;
        const int LABELTITULO2 = 6;
        //Pantalla 1
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
        //Pantalla2
        const int PANELREGRESAR = 20;
        const int LABELREGRESAR = 21;
        const int PANELSELPUERTO = 22;
        const int LABELSELPUERTO = 23;
        const int PANELCOM = 24;
        const int LABELCOM = 25;
        const int PANELEQUIPO = 26;
        const int LABELEQUIPO = 27;
        const int PANELEQUIPODATA = 28;
        const int LABELEQUIPODATA = 29;
        const int PANELNSERIE = 30;
        const int LABELNSERIE = 31;
        const int PANELNSERIEDATA = 32;
        const int LABELNSERIEDATA = 33;
        const int PANELVERSION = 34;
        const int LABELVERSION = 35;
        const int PANELCABINA = 36;
        const int LABELCABINA = 37;
        const int PANELCABINADATA = 38;
        const int LABELCABINADATA = 39;
        const int PANELSTATUS = 40;
        const int LABELSTATUS = 41;
        const int PANELCONECTAR = 42;
        const int LABELCONECTAR = 43;
        const int PANELVERSIONDATA = 44;
        const int LABELVERSIONDATA = 45;

        //Varibles para la animacion
        int[,] ContadorCambioColor = new int[MartrixDim, MartrixDim];
        int[,] ContadorCambioTamaño = new int[MartrixDim, MartrixDim];
        int[,] ContadorAparicionTexto = new int[MartrixDim, MartrixDim];
        int[,] ContadorMovimientoTexto = new int[MartrixDim, MartrixDim];

        int[] DimensionadoCambioTamaño = new int[13];

        int ContadorSalida = 0;

        //************** Form 2 Estrucutura
        private Form _F2;
        //private Panel PanelSeleccion;

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

        public void F2Display()
        {
            Form _F2 = new Form();
            _F2.Height = 600;
            _F2.Width = 300;
            Panel PanelSeleccion = new Panel();
            _F2.Controls.Add(PanelSeleccion);
            _F2.Show(this);
        }

        public void EstablecerValoresGloblales()
        {
            //LimipiarVaraibles
            for (int i = 0; i < MartrixDim; i++)
            {
                for (int j = 0; j < MartrixDim; j++)
                {
                    Paneles[i, j] = -1;
                    Labels1[i, j] = -1;
                    Labels2[i, j] = -1;
                    MinYMax[i, j / (MartrixDim-1)] = 0;
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
            Paneles[0, 1] = PANELSELPUERTO;
            Paneles[1, 1] = PANELCOM;
            Paneles[2, 1] = PANELCONECTAR;
            Paneles[3, 1] = PANELEQUIPO;
            Paneles[4, 1] = PANELEQUIPODATA;
            Paneles[5, 1] = PANELNSERIE;
            Paneles[6, 1] = PANELNSERIEDATA;
            Paneles[7, 1] = PANELVERSION;
            Paneles[8, 1] = PANELVERSIONDATA;
            Paneles[9, 1] = PANELCABINA;
            Paneles[10, 1] = PANELCABINADATA;
            Paneles[11, 1] = PANELREGRESAR;
            Paneles[12, 1] = PANELSTATUS;

            //Establecer variables de Labels1
            //Pantalla 1
            Labels1[0, 0] = LABELDETECTAR;
            Labels1[1, 0] = LABELCONF;
            Labels1[2, 0] = LABELLECT;
            Labels1[3, 0] = LABELSALIRSIS;
            //Pantalla 2
            Labels1[0, 1] = LABELSELPUERTO;
            Labels1[1, 1] = LABELCOM;
            Labels1[2, 1] = LABELCONECTAR;
            Labels1[3, 1] = LABELEQUIPO;
            Labels1[4, 1] = LABELEQUIPODATA;
            Labels1[5, 1] = LABELNSERIE;
            Labels1[6, 1] = LABELNSERIEDATA;
            Labels1[7, 1] = LABELVERSION;
            Labels1[8, 1] = LABELVERSIONDATA;
            Labels1[9, 1] = LABELCABINA;
            Labels1[10, 1] = LABELCABINADATA;
            Labels1[11, 1] = LABELREGRESAR;
            Labels1[12, 1] = LABELSTATUS;

            //Establecer Variables de Labels2
            //Pantalla 1
            Labels2[0, 0] = LABELDETECTAR2;
            Labels2[1, 0] = LABELCONF2;
            Labels2[2, 0] = LABELLECT2;
            Labels2[3, 0] = LABELSALIRSIS2;
            //Pantalla 2
            /*Labels2[0, 1] = LABELSELPUERTO;
            Labels2[1, 1] = LABELCOM;
            Labels2[2, 1] = LABELCONECTAR;
            Labels2[3, 1] = LABELEQUIPODATA;
            Labels2[4, 1] = LABELNSERIE;
            Labels2[5, 1] = LABELNSERIEDATA;
            Labels2[6, 1] = LABELVERSION;
            Labels2[7, 1] = LABELVERSIONDATA;
            Labels2[8, 1] = LABELCABINA;
            Labels2[9, 1] = LABELCABINADATA;
            Labels2[10, 1] = LABELREGRESAR;
            Labels2[11, 1] = LABELSTATUS;*/



            //MInimos y maximos de cada Pantalla
            MinYMax[0, 0] = 0;
            MinYMax[0, 1] = 4;
            MinYMax[1, 0] = 0;
            MinYMax[1, 1] = 13;

            //Pantalla1
            Label1Title[0, 0] = "Detectar\nPlaca";
            Label1Title[1, 0] = "Configu-\nracion";
            Label1Title[2, 0] = "Lectura de Datos";
            Label1Title[3, 0] = "SALIR";
            //Pantalla 2
            Label1Title[0, 1] = "Seleccione";
            Label1Title[1, 1] = "Puerto";
            Label1Title[2, 1] = "Conectar";
            Label1Title[3, 1] = "Equipo";
            Label1Title[4, 1] = "";
            Label1Title[5, 1] = "N° de Serie";
            Label1Title[6, 1] = "";
            Label1Title[7, 1] = "Version";
            Label1Title[8, 1] = "";
            Label1Title[9, 1] = "Cabina";
            Label1Title[10, 1] = "";
            Label1Title[11, 1] = "Regresar";
            Label1Title[12, 1] = "";

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

            //Colores paneles pantalla 2
            /*PanelRed[1, 1] = 0;
            PanelRed[2, 1] = 0;
            PanelRed[4, 1] = 0;
            PanelRed[6, 1] = 0;
            PanelRed[8, 1] = 0;
            PanelRed[10, 1] = 0;
            PanelRed[11, 1] = 0;

            PanelGreen[1, 1] = 96;
            PanelGreen[2, 1] = 220;
            PanelGreen[4, 1] = 255;
            PanelGreen[6, 1] = 255;
            PanelGreen[8, 1] = 255;
            PanelGreen[10, 1] = 255;
            PanelGreen[11, 1] = 255;

            PanelBlue[1, 1] = 15;
            PanelBlue[2, 1] = 220;
            PanelBlue[4, 1] = 200;
            PanelBlue[6, 1] = 200;
            PanelBlue[8, 1] = 200;
            PanelBlue[10, 1] = 200;
            PanelBlue[11, 1] = 200;*/

            for (int j = 0; j < MinYMax[1, 1]; j++)
            {
                PanelRed[j, 1] = 0;
                PanelGreen[j, 1] = 96;
                PanelBlue[j, 1] = 15;
            }
        }
        public void OcultarElementos()
        {
            //Pantalla Principal
            this.PanelBarra.Visible = false;
            this.PanelTitulo.Visible = false;
            this.PanelMin.Visible = false;
            this.PanelMax.Visible = false;
            this.PanelSalir.Visible = false;
            this.LabelTitulo1.Visible = false;
            this.LabelTitulo2.Visible = false;
            //Pantalla 1
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
            this.PanelRregresar.Visible = false;
            this.LabelRRegresar.Visible = false;
            //Pantalla 2
            this.PanelSelPuerto.Visible = false;
            this.LabelSelPuerto.Visible = false;
            this.PanelCOM.Visible = false;
            this.LabelCOM.Visible = false;
            this.PanelConectar.Visible = false;
            this.LabelConectar.Visible = false;
            this.PanelEquipo.Visible = false;
            this.LabelEquipo.Visible = false;
            this.PanelEquipoData.Visible = false;
            this.LabelEquipoData.Visible = false;
            this.PanelNSerie.Visible = false;
            this.LabelNSerie.Visible = false;
            this.PanelNSerieData.Visible = false;
            this.LabelNSerieData.Visible = false;
            this.PanelVersion.Visible = false;
            this.LabelVersion.Visible = false;
            this.PanelVersionData.Visible = false;
            this.LabelVersionData.Visible = false;
            this.PanelCabina.Visible = false;
            this.LabelCabina.Visible = false;
            this.PanelCabinaData.Visible = false;
            this.LabelCabinaData.Visible = false;
            this.PanelRegresar.Visible = false;
            this.LabelRegresar.Visible = false;
            this.PanelStatus.Visible = false;
            this.LabelStatus.Visible = false;

        }
        public void ActualizarDimesiones()
        {

            //Dimesiones de PANTALLA PRINCIPAL
            //ANCHO de Panel
            // Pantalla 1
            int ANCHOPANELDETECTAR = 7;
            int ANCHOPANELCONF = 9;
            int ANCHOPANELLECT = 11;
            int ANCHOPANELSALIRSIS = 13;
            int ANCHOFPANELGUIA = 15;
            // Pantalla 2
            int ANCHOPANELSELPUERTO = 1;
            int ANCHOPANELCOM = 1;
            int ANCHOPANELCONECTAR = 1;
            int ANCHOPANELEQUIPO = 1;
            int ANCHOPANELEQUIPODATA = 1;
            int ANCHOPANELNSERIE = 1;
            int ANCHOPANELNSERIEDATA = 1;
            int ANCHOPANELVERSION = 1;
            int ANCHOPANELVERSIONDATA = 1;
            int ANCHOPANELCABINA = 1;
            int ANCHOPANELCABINADATA = 1;
            int ANCHOPANELREGRESAR = 1;
            int ANCHOPANELSTATUS = 1;

            //Largo de Panel
            // Pantalla 1
            int LARGOPANELDETECTAR = 7;
            int LARGOPANELCONF = 9;
            int LARGOPANELLECT = 11;
            int LARGOPANELSALIRSIS = 13;
            int LARGOFPANELGUIA = 15;
            // Pantalla 2
            int LARGOPANELSELPUERTO = 1;
            int LARGOPANELCOM = 1;
            int LARGOPANELCONECTAR = 1;
            int LARGOPANELEQUIPO = 1;
            int LARGOPANELEQUIPODATA = 1;
            int LARGOPANELNSERIE = 1;
            int LARGOPANELNSERIEDATA = 1;
            int LARGOPANELVERSION = 1;
            int LARGOPANELVERSIONDATA = 1;
            int LARGOPANELCABINA = 1;
            int LARGOPANELCABINADATA = 1;
            int LARGOPANELREGRESAR = 1;
            int LARGOPANELSTATUS = 1;

            //DimensionesPantalla1
            ANCHOPANELDETECTAR = 20 * this.Width / 100;
            ANCHOPANELCONF = 20 * this.Width / 100;
            ANCHOPANELLECT = 45 * this.Width / 100;
            ANCHOPANELSALIRSIS = 45 * this.Width / 100;
            ANCHOFPANELGUIA = 40 * this.Width / 100;
            //Dimesiones Pantalla2
            ANCHOPANELSELPUERTO = 20 * this.Width / 100;
            ANCHOPANELCOM = 20 * this.Width / 100;
            ANCHOPANELCONECTAR = 20 * this.Width / 100;
            ANCHOPANELEQUIPO = 20 * this.Width / 100;
            ANCHOPANELEQUIPODATA = 20 * this.Width / 100;
            ANCHOPANELNSERIE = 20 * this.Width / 100;
            ANCHOPANELNSERIEDATA = 20 * this.Width / 100;
            ANCHOPANELVERSION = 20 * this.Width / 100;
            ANCHOPANELVERSIONDATA = 20 * this.Width / 100;
            ANCHOPANELCABINA = 20 * this.Width / 100;
            ANCHOPANELCABINADATA = 20 * this.Width / 100;
            ANCHOPANELREGRESAR = 20 * this.Width / 100;
            ANCHOPANELSTATUS = 20 * this.Width / 100;

            //DImesion Y pantalla1
            LARGOPANELDETECTAR = 14 * this.Height / 100;//29
            LARGOPANELCONF = 14 * this.Height / 100;
            LARGOPANELLECT = 9 * this.Height / 100;
            LARGOPANELSALIRSIS = 9 * this.Height / 100;
            LARGOFPANELGUIA = 65 * this.Height / 100;
            //Dimesion Y pantalla 2
            LARGOPANELSELPUERTO = 10 * this.Height / 100;
            LARGOPANELCOM = 10 * this.Height / 100;
            LARGOPANELCONECTAR = 10 * this.Height / 100;
            LARGOPANELEQUIPO = 10 * this.Height / 100;
            LARGOPANELEQUIPODATA = 10 * this.Height / 100;
            LARGOPANELNSERIE = 10 * this.Height / 100;
            LARGOPANELNSERIEDATA = 10 * this.Height / 100;
            LARGOPANELVERSION = 10 * this.Height / 100;
            LARGOPANELVERSIONDATA = 10 * this.Height / 100;
            LARGOPANELCABINA = 10 * this.Height / 100;
            LARGOPANELCABINADATA = 10 * this.Height / 100;
            LARGOPANELREGRESAR = 10 * this.Height / 100;
            LARGOPANELSTATUS = 10 * this.Height / 100;

            //Guardar en Variables globales
            //Ancho Pantalla1
            PanelAncho[0, 0] = ANCHOPANELDETECTAR;
            PanelAncho[1, 0] = ANCHOPANELCONF;
            PanelAncho[2, 0] = ANCHOPANELLECT;
            PanelAncho[3, 0] = ANCHOPANELSALIRSIS;
            //Ancho Pantalla2
            PanelAncho[0, 1] = ANCHOPANELSELPUERTO;
            PanelAncho[1, 1] = ANCHOPANELCOM;
            PanelAncho[2, 1] = ANCHOPANELCONECTAR;
            PanelAncho[3, 1] = ANCHOPANELEQUIPO;
            PanelAncho[4, 1] = ANCHOPANELEQUIPODATA;
            PanelAncho[5, 1] = ANCHOPANELNSERIE;
            PanelAncho[6, 1] = ANCHOPANELNSERIEDATA;
            PanelAncho[7, 1] = ANCHOPANELVERSION;
            PanelAncho[8, 1] = ANCHOPANELVERSIONDATA;
            PanelAncho[9, 1] = ANCHOPANELCABINA;
            PanelAncho[10, 1] = ANCHOPANELCABINADATA;
            PanelAncho[11, 1] = ANCHOPANELREGRESAR;
            PanelAncho[12, 1] = ANCHOPANELSTATUS;

            //Largo Pantalla 1
            PanelLargo[0, 0] = LARGOPANELDETECTAR;
            PanelLargo[1, 0] = LARGOPANELCONF;
            PanelLargo[2, 0] = LARGOPANELLECT;
            PanelLargo[3, 0] = LARGOPANELSALIRSIS;
            //Largo Pantalla 2
            PanelLargo[0, 1] = LARGOPANELSELPUERTO;
            PanelLargo[1, 1] = LARGOPANELCOM;
            PanelLargo[2, 1] = LARGOPANELCONECTAR;
            PanelLargo[3, 1] = LARGOPANELEQUIPO;
            PanelLargo[4, 1] = LARGOPANELEQUIPODATA;
            PanelLargo[5, 1] = LARGOPANELNSERIE;
            PanelLargo[6, 1] = LARGOPANELNSERIEDATA;
            PanelLargo[7, 1] = LARGOPANELVERSION;
            PanelLargo[8, 1] = LARGOPANELVERSIONDATA;
            PanelLargo[9, 1] = LARGOPANELCABINA;
            PanelLargo[10, 1] = LARGOPANELCABINADATA;
            PanelLargo[11, 1] = LARGOPANELREGRESAR;
            PanelLargo[12, 1] = LARGOPANELSTATUS;
        }
        public void ActualizarPosiciones()
        {
            //Location X de Pantallas
            //Panel Barra Principal
            int POSXPANELBARRA = 0;
            int POSXPANELMIN = 1;
            int POSXPANELMAX = 2;
            int POSXPANELSALIR = 3;
            int POSXPANELTITULO = 4;
            int POSXLABELTITULO1 = 5;
            int POSXLABELTITULO2 = 6;
            // Pantalla 1
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
            // Pantalla 2
            int POSXPANELSELPUERTO = 1;
            int POSXPANELCOM = 1;
            int POSXPANELCONECTAR = 1;
            int POSXPANELEQUIPO = 1;
            int POSXPANELEQUIPODATA = 1;
            int POSXPANELNSERIE = 1;
            int POSXPANELNSERIEDATA = 1;
            int POSXPANELVERSION = 1;
            int POSXPANELVERSIONDATA = 1;
            int POSXPANELCABINA = 1;
            int POSXPANELCABINADATA = 1;
            int POSXPANELREGRESAR = 1;
            int POSXPANELSTATUS = 1;
            int POSXLABELSELPUERTO = 1;
            int POSXLABELCOM = 1;
            int POSXLABELCONECTAR = 1;
            int POSXLABELEQUIPO = 1;
            int POSXLABELEQUIPODATA = 1;
            int POSXLABELNSERIE = 1;
            int POSXLABELNSERIEDATA = 1;
            int POSXLABELVERSION = 1;
            int POSXLABELVERSIONDATA = 1;
            int POSXLABELCABINA = 1;
            int POSXLABELCABINADATA = 1;
            int POSXLABELREGRESAR = 1;
            int POSXLABELSTATUS = 1;


            //Location Y
            //Pantalla Principal
            int POSYPANELBARRA = 0;
            int POSYPANELMIN = 1;
            int POSYPANELMAX = 2;
            int POSYPANELSALIR = 3;
            int POSYPANELTITULO = 4;
            int POSYLABELTITULO1 = 5;
            int POSYLABELTITULO2 = 6;
            //Pantalla1
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
            //Pantalla 2
            int POSYPANELSELPUERTO = 1;
            int POSYPANELCOM = 1;
            int POSYPANELCONECTAR = 1;
            int POSYPANELEQUIPO = 1;
            int POSYPANELEQUIPODATA = 1;
            int POSYPANELNSERIE = 1;
            int POSYPANELNSERIEDATA = 1;
            int POSYPANELVERSION = 1;
            int POSYPANELVERSIONDATA = 1;
            int POSYPANELCABINA = 1;
            int POSYPANELCABINADATA = 1;
            int POSYPANELREGRESAR = 1;
            int POSYPANELSTATUS = 1;
            int POSYLABELSELPUERTO = 1;
            int POSYLABELCOM = 1;
            int POSYLABELCONECTAR = 1;
            int POSYLABELEQUIPO = 1;
            int POSYLABELEQUIPODATA = 1;
            int POSYLABELNSERIE = 1;
            int POSYLABELNSERIEDATA = 1;
            int POSYLABELVERSION = 1;
            int POSYLABELVERSIONDATA = 1;
            int POSYLABELCABINA = 1;
            int POSYLABELCABINADATA = 1;
            int POSYLABELREGRESAR = 1;
            int POSYLABELSTATUS = 1;

            //Asignacion de Valores a las varaibles
            //Pantalla Principal
            POSXPANELBARRA = 0;
            POSXPANELMIN = this.Width - 3 * 5 * this.Width / 100;
            POSXPANELMAX = this.Width - 2 * 5 * this.Width / 100;
            POSXPANELSALIR = this.Width - 1 * 5 * this.Width / 100;
            POSXPANELTITULO = 0;
            POSXLABELTITULO1 = 2 * this.Width / 100;
            POSXLABELTITULO2 = 80 * this.Width / 100;
            //Pantalla 1
            POSXPANELDETECTAR = 5 * this.Width / 100;
            POSXLABELDETECTAR = 5 * PanelAncho[0, 0] / 100;
            POSXLABELDETECTAR2 = 5 * PanelAncho[0, 0] / 100;
            POSXPANELCONF = 10 * this.Width / 100 + PanelAncho[0, 0];
            POSXLABELCONF = 5 * PanelAncho[1, 0] / 100;
            POSXLABELCONF2 = 5 * PanelAncho[1, 0] / 100;
            POSXPANELLECT = 5 * this.Width / 100;
            POSXLABELLECT = 10 * PanelAncho[2, 0] / 100;
            POSXLABELLECT2 = 10 * PanelAncho[2, 0] / 100;
            POSXPANELSALIRSIS = 5 * this.Width / 100;
            POSXLABELSALIRSIS = 35 * PanelAncho[3, 0] / 100;
            POSXLABELSALIRSIS2 = 5 * PanelAncho[3, 0] / 100;
            POSXFPANELGUIA = 55 * this.Width / 100;
            //Pantalla 2
            POSXPANELSELPUERTO = 5 * this.Width / 100;
            POSXPANELCOM = 30 * this.Width / 100;
            POSXPANELCONECTAR = 55 * this.Width / 100;
            POSXPANELEQUIPO = 5 * this.Width / 100;
            POSXPANELEQUIPODATA = 30 * this.Width / 100;
            POSXPANELNSERIE = 55 * this.Width / 100;
            POSXPANELNSERIEDATA = 80 * this.Width / 100;
            POSXPANELVERSION = 5 * this.Width / 100;
            POSXPANELVERSIONDATA = 30 * this.Width / 100;
            POSXPANELCABINA = 55 * this.Width / 100;
            POSXPANELCABINADATA = 80 * this.Width / 100;
            POSXPANELREGRESAR = 5 * this.Width / 100;
            POSXPANELSTATUS = 30 * this.Width / 100;
            POSXLABELSELPUERTO = 5 * PanelAncho[0, 1] / 100;
            POSXLABELCOM = 5 * PanelAncho[1, 1] / 100;
            POSXLABELCONECTAR = 5 * PanelAncho[2, 1] / 100;
            POSXLABELEQUIPO = 5 * PanelAncho[3, 1] / 100;
            POSXLABELEQUIPODATA = 5 * PanelAncho[4, 1] / 100;
            POSXLABELNSERIE = 5 * PanelAncho[5, 1] / 100;
            POSXLABELNSERIEDATA = 5 * PanelAncho[6, 1] / 100;
            POSXLABELVERSION = 5 * PanelAncho[7, 1] / 100;
            POSXLABELVERSIONDATA = 5 * PanelAncho[8, 1] / 100;
            POSXLABELCABINA = 5 * PanelAncho[9, 1] / 100;
            POSXLABELCABINADATA = 5 * PanelAncho[10, 1] / 100;
            POSXLABELREGRESAR = 5 * PanelAncho[11, 1] / 100;
            POSXLABELSTATUS = 5 * PanelAncho[12, 1] / 100;

            //Aginacion Location Y
            //Pantalla principal
            POSYPANELBARRA = 0;
            POSYPANELMIN = 0;
            POSYPANELMAX = 0;
            POSYPANELSALIR = 0;
            POSYPANELTITULO = 0;
            POSYLABELTITULO1 = 2 * this.Width / 100;
            POSYLABELTITULO2 = 80 * this.Width / 100;
            //Pantalla1
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
            //Pantalla2 
            POSYPANELSELPUERTO = 20 * this.Height / 100;
            POSYPANELCOM = 20 * this.Height / 100;
            POSYPANELCONECTAR = 20 * this.Height / 100;
            POSYPANELEQUIPO = 35 * this.Height / 100;
            POSYPANELEQUIPODATA = 35 * this.Height / 100;
            POSYPANELNSERIE = 35 * this.Height / 100;
            POSYPANELNSERIEDATA = 35 * this.Height / 100;
            POSYPANELVERSION = 50 * this.Height / 100;
            POSYPANELVERSIONDATA = 50 * this.Height / 100;
            POSYPANELCABINA = 50 * this.Height / 100;
            POSYPANELCABINADATA = 50 * this.Height / 100;
            POSYPANELREGRESAR = 65 * this.Height / 100;
            POSYPANELSTATUS = 65 * this.Height / 100;
            POSYLABELSELPUERTO = 5 * PanelLargo[0, 1] / 100;
            POSYLABELCOM = 5 * PanelLargo[1, 1] / 100;
            POSYLABELCONECTAR = 5 * PanelLargo[2, 1] / 100;
            POSYLABELEQUIPO = 5 * PanelLargo[3, 1] / 100;
            POSYLABELEQUIPODATA = 5 * PanelLargo[4, 1] / 100;
            POSYLABELNSERIE = 5 * PanelLargo[5, 1] / 100;
            POSYLABELNSERIEDATA = 5 * PanelLargo[6, 1] / 100;
            POSYLABELVERSION = 5 * PanelLargo[7, 1] / 100;
            POSYLABELVERSIONDATA = 5 * PanelLargo[8, 1] / 100;
            POSYLABELCABINA = 5 * PanelLargo[9, 1] / 100;
            POSYLABELCABINADATA = 5 * PanelLargo[10, 1] / 100;
            POSYLABELREGRESAR = 5 * PanelLargo[11, 1] / 100;
            POSYLABELSTATUS = 5 * PanelLargo[12, 1] / 100;

            //Guardar en Variables globales
            //Pantalla 1
            PanelPosX[0, 0] = POSXPANELDETECTAR;
            PanelPosX[1, 0] = POSXPANELCONF;
            PanelPosX[2, 0] = POSXPANELLECT;
            PanelPosX[3, 0] = POSXPANELSALIRSIS;
            //Pantalla 2
            PanelPosX[0, 1] = POSXPANELSELPUERTO;
            PanelPosX[1, 1] = POSXPANELCOM;
            PanelPosX[2, 1] = POSXPANELCONECTAR;
            PanelPosX[3, 1] = POSXPANELEQUIPO;
            PanelPosX[4, 1] = POSXPANELEQUIPODATA;
            PanelPosX[5, 1] = POSXPANELNSERIE;
            PanelPosX[6, 1] = POSXPANELNSERIEDATA;
            PanelPosX[7, 1] = POSXPANELVERSION;
            PanelPosX[8, 1] = POSXPANELVERSIONDATA;
            PanelPosX[9, 1] = POSXPANELCABINA;
            PanelPosX[10, 1] = POSXPANELCABINADATA;
            PanelPosX[11, 1] = POSXPANELREGRESAR;
            PanelPosX[12, 1] = POSXPANELSTATUS;

            //Pantalla 1
            PanelPosY[0, 0] = POSYPANELDETECTAR;
            PanelPosY[1, 0] = POSYPANELCONF;
            PanelPosY[2, 0] = POSYPANELLECT;
            PanelPosY[3, 0] = POSYPANELSALIRSIS;
            //Pantalla 2
            PanelPosY[0, 1] = POSYPANELSELPUERTO;
            PanelPosY[1, 1] = POSYPANELCOM;
            PanelPosY[2, 1] = POSYPANELCONECTAR;
            PanelPosY[3, 1] = POSYPANELEQUIPO;
            PanelPosY[4, 1] = POSYPANELEQUIPODATA;
            PanelPosY[5, 1] = POSYPANELNSERIE;
            PanelPosY[6, 1] = POSYPANELNSERIEDATA;
            PanelPosY[7, 1] = POSYPANELVERSION;
            PanelPosY[8, 1] = POSYPANELVERSIONDATA;
            PanelPosY[9, 1] = POSYPANELCABINA;
            PanelPosY[10, 1] = POSYPANELCABINADATA;
            PanelPosY[11, 1] = POSYPANELREGRESAR;
            PanelPosY[12, 1] = POSYPANELSTATUS;

            //Pantalla 1
            Label1PosX[0, 0] = POSXLABELDETECTAR;
            Label1PosX[1, 0] = POSXLABELCONF;
            Label1PosX[2, 0] = POSXLABELLECT;
            Label1PosX[3, 0] = POSXLABELSALIRSIS;
            //Pantalla 2
            Label1PosX[0, 1] = POSXLABELSELPUERTO;
            Label1PosX[1, 1] = POSXLABELCOM;
            Label1PosX[2, 1] = POSXLABELCONECTAR;
            Label1PosX[3, 1] = POSXLABELEQUIPO;
            Label1PosX[4, 1] = POSXLABELEQUIPODATA;
            Label1PosX[5, 1] = POSXLABELNSERIE;
            Label1PosX[6, 1] = POSXLABELNSERIEDATA;
            Label1PosX[7, 1] = POSXLABELVERSION;
            Label1PosX[8, 1] = POSXLABELVERSIONDATA;
            Label1PosX[9, 1] = POSXLABELCABINA;
            Label1PosX[10, 1] = POSXLABELCABINADATA;
            Label1PosX[11, 1] = POSXLABELREGRESAR;
            Label1PosX[12, 1] = POSXLABELSTATUS;

            //Pantalla 1
            Label1PosY[0, 0] = POSYLABELDETECTAR;
            Label1PosY[1, 0] = POSYLABELCONF;
            Label1PosY[2, 0] = POSYLABELLECT;
            Label1PosY[3, 0] = POSYLABELSALIRSIS;
            //Pantalla 2
            Label1PosX[0, 1] = POSYLABELSELPUERTO;
            Label1PosX[1, 1] = POSYLABELCOM;
            Label1PosX[2, 1] = POSYLABELCONECTAR;
            Label1PosX[3, 1] = POSYLABELEQUIPO;
            Label1PosX[4, 1] = POSYLABELEQUIPODATA;
            Label1PosX[5, 1] = POSYLABELNSERIE;
            Label1PosX[6, 1] = POSYLABELNSERIEDATA;
            Label1PosX[7, 1] = POSYLABELVERSION;
            Label1PosX[8, 1] = POSYLABELVERSIONDATA;
            Label1PosX[9, 1] = POSYLABELCABINA;
            Label1PosX[10, 1] = POSYLABELCABINADATA;
            Label1PosX[11, 1] = POSYLABELREGRESAR;
            Label1PosX[12, 1] = POSYLABELSTATUS;

            //Pantalla 1
            Label2PosX[0, 0] = POSXLABELDETECTAR2;
            Label2PosX[1, 0] = POSXLABELCONF2;
            Label2PosX[2, 0] = POSXLABELLECT2;
            Label2PosX[3, 0] = POSXLABELSALIRSIS2;
            //Pantalla 2

            //Pantalla 1
            Label2PosY[0, 0] = POSYLABELDETECTAR2;
            Label2PosY[1, 0] = POSYLABELCONF2;
            Label2PosY[2, 0] = POSYLABELLECT2;
            Label2PosY[3, 0] = POSYLABELSALIRSIS2;
            //Pantalla 2

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
                    //Console.WriteLine("Panel_" + Paneles[i, NumeroDePantalla - 1].ToString());
                    CrearPanel(Paneles[i, NumeroDePantalla - 1], TransparenciaColor, PanelRed[i, NumeroDePantalla - 1], PanelGreen[i, NumeroDePantalla - 1], PanelBlue[i, NumeroDePantalla - 1], PanelAncho[i, NumeroDePantalla - 1], PanelLargo[i, NumeroDePantalla - 1], PanelPosX[i, NumeroDePantalla - 1], PanelPosY[i, NumeroDePantalla - 1]);
                }
                if (Labels1[i, NumeroDePantalla - 1] != -1)
                {
                    //Console.WriteLine("Label1_" + Labels1[i, NumeroDePantalla - 1].ToString());
                    CrearLabel(Paneles[i, NumeroDePantalla - 1], Labels1[i, NumeroDePantalla - 1], Label1Title[i, NumeroDePantalla - 1], 255, 255, 255, 255, Label1PosX[i, NumeroDePantalla - 1], Label1PosY[i, NumeroDePantalla - 1], 24);
                }
                if (Labels2[i, NumeroDePantalla - 1] != -1)
                {
                    //Console.WriteLine("Label2_" + Labels2[i, NumeroDePantalla - 1].ToString());
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
                //Pantalla 1
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
                //Pantalla 2
                case PANELSELPUERTO:
                    P = this.PanelSelPuerto;
                    break;
                case PANELCOM:
                    P = this.PanelCOM;
                    break;
                case PANELCONECTAR:
                    P = this.PanelConectar;
                    break;
                case PANELEQUIPO:
                    P = this.PanelEquipo;
                    break;
                case PANELEQUIPODATA:
                    P = this.PanelEquipoData;
                    break;
                case PANELNSERIE:
                    P = this.PanelNSerie;
                    break;
                case PANELNSERIEDATA:
                    P = this.PanelNSerieData;
                    break;
                case PANELVERSION:
                    P = this.PanelVersion;
                    break;
                case PANELVERSIONDATA:
                    P = this.PanelVersionData;
                    break;
                case PANELCABINA:
                    P = this.PanelCabina;
                    break;
                case PANELCABINADATA:
                    P = this.PanelCabinaData;
                    break;
                case PANELREGRESAR:
                    P = this.PanelRegresar;
                    break;
                case PANELSTATUS:
                    P = this.PanelStatus;
                    break;
                //default
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
                //Pantalla Pantalla
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
                //Pantalla 2
                case PANELSELPUERTO:
                    P = this.PanelSelPuerto;
                    break;
                case PANELCOM:
                    P = this.PanelCOM;
                    break;
                case PANELCONECTAR:
                    P = this.PanelConectar;
                    break;
                case PANELEQUIPO:
                    P = this.PanelEquipo;
                    break;
                case PANELEQUIPODATA:
                    P = this.PanelEquipoData;
                    break;
                case PANELVERSION:
                    P = this.PanelVersion;
                    break;
                case PANELVERSIONDATA:
                    P = this.PanelVersionData;
                    break;
                case PANELCABINA:
                    P = this.PanelCabina;
                    break;
                case PANELCABINADATA:
                    P = this.PanelCabinaData;
                    break;
                case PANELREGRESAR:
                    P = this.PanelRegresar;
                    break;
                case PANELSTATUS:
                    P = this.PanelStatus;
                    break;
                case PANELNSERIE:
                    P = this.PanelNSerie;
                    break;
                case PANELNSERIEDATA:
                    P = this.PanelNSerieData;
                    break;
                default:
                    return;
            }
            var l = this.LabelTitulo1;
            switch (L1)
            {
                //Pantalla 1
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
                //Pantalla 2
                case LABELSELPUERTO:
                    l = this.LabelSelPuerto;
                    break;
                case LABELCOM:
                    l = this.LabelCOM;
                    break;
                case LABELCONECTAR:
                    l = this.LabelConectar;
                    break;
                case LABELEQUIPO:
                    l = this.LabelEquipo;
                    break;
                case LABELEQUIPODATA:
                    l = this.LabelEquipoData;
                    break;
                case LABELVERSION:
                    l = this.LabelVersion;
                    break;
                case LABELVERSIONDATA:
                    l = this.LabelVersionData;
                    break;
                case LABELCABINA:
                    l = this.LabelCabina;
                    break;
                case LABELCABINADATA:
                    l = this.LabelCabinaData;
                    break;
                case LABELREGRESAR:
                    l = this.LabelRegresar;
                    break;
                case LABELSTATUS:
                    l = this.LabelStatus;
                    break;
                case LABELNSERIE:
                    l = this.LabelNSerie;
                    break;
                case LABELNSERIEDATA:
                    l = this.LabelNSerieData;
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
            this.PanelRregresar.Visible = true;
            this.PanelRregresar.BackColor = Color.FromArgb(255, 120, 120, 120);
            this.PanelRregresar.Height = this.Height / 10;
            this.PanelRregresar.Width = 22 * this.Width / 100;
            this.PanelRregresar.Location = new Point(-this.PanelRregresar.Width, this.Height - 5 * EspacioAdicional);
            this.LabelRRegresar.Text = "Regresar\n";
            this.LabelRRegresar.Font = new Font("Arial", 24, FontStyle.Bold);
            this.LabelRRegresar.ForeColor = Color.FromArgb(255, 255, 255, 255);
            this.LabelRRegresar.BackColor = Color.FromArgb(255, 120, 120, 120);
            this.LabelRRegresar.Location = new Point(5 * this.PanelDetectar.Width / 100, 5 * this.PanelDetectar.Height / 100);
            this.PanelRregresar.Controls.Add(LabelRRegresar);
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
        //********************Timer
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
                        //Pantalla 1
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
                        //Pantalla 2
                        case PANELSELPUERTO:
                            P = this.PanelSelPuerto;
                            break;
                        case PANELCOM:
                            P = this.PanelCOM;
                            break;
                        case PANELCONECTAR:
                            P = this.PanelConectar;
                            break;
                        case PANELEQUIPO:
                            P = this.PanelEquipo;
                            break;
                        case PANELEQUIPODATA:
                            P = this.PanelEquipoData;
                            break;
                        case PANELVERSION:
                            P = this.PanelVersion;
                            break;
                        case PANELVERSIONDATA:
                            P = this.PanelVersionData;
                            break;
                        case PANELCABINA:
                            P = this.PanelCabina;
                            break;
                        case PANELCABINADATA:
                            P = this.PanelCabinaData;
                            break;
                        case PANELREGRESAR:
                            P = this.PanelRegresar;
                            break;
                        case PANELSTATUS:
                            P = this.PanelStatus;
                            break;
                        case PANELNSERIE:
                            P = this.PanelNSerie;
                            break;
                        case PANELNSERIEDATA:
                            P = this.PanelNSerieData;
                            break;
                        //Default
                        default:
                            return;
                    }

                    DectX1[i] = this.Left + PosXVAL[i] + 1 * this.Height / 100;
                    DectX2[i] = DectX1[i] + P.Width;
                    DectY1[i] = this.Top + PosYVAL[i] + 5 * this.Height / 100;
                    DectY2[i] = DectY1[i] + P.Height;
                    /*if (i == 0)
                    {
                        Console.WriteLine("X1: " + DectX1[0].ToString() + "X2: " + DectX2[0].ToString() + "Y1: " + DectY1[0].ToString() + "Y2: " + DectY2[0].ToString());
                        Console.WriteLine("X: " + MouseXPos.ToString() + "Y: " + MouseYPos.ToString());
                        Console.WriteLine("ContadorColor: " + ContadorCambioColor[0, NumeroDePantalla - 1].ToString());
                    }*/
                    
                }
                int ContadorTraslacion = 0;
                for (int i = MinYMax[NumeroDePantalla - 1, 0]; i < MinYMax[NumeroDePantalla - 1, 1]; i++)
                {
                    if (!AutorizarTraslacion && !AutorizarTraslacionInv)
                    {
                        if (MouseXPos >= DectX1[i] && MouseXPos <= DectX2[i] && MouseYPos >= DectY1[i] && MouseYPos <= DectY2[i])
                        {
                            if (ContadorCambioColor[i, NumeroDePantalla - 1] < 120)
                            {
                                AnimacionCambioColor(1, i);
                            }
                            if (ContadorCambioTamaño[i, NumeroDePantalla - 1] < 50 )
                            {
                                AnimacionCambioDimesionRecuadro(1, i);
                            }
                            if (ContadorAparicionTexto[i, NumeroDePantalla - 1] < 255 && ContadorCambioTamaño[i, NumeroDePantalla - 1] >= 25)
                            {
                                AnimacionAparicionTexto(1, i);
                            }
                        }
                        else
                        {
                            if (ContadorCambioColor[i, NumeroDePantalla - 1] > 0 /*&& ContadorCambioTamaño[i, NumeroDePantalla - 1] < 10*/)
                            {
                                AnimacionCambioColor(0, i);
                            }
                            if (ContadorCambioTamaño[i, NumeroDePantalla - 1] > 0 && ContadorAparicionTexto[i, NumeroDePantalla - 1] < 50)
                            {
                                AnimacionCambioDimesionRecuadro(0, i);
                            }
                            if (ContadorAparicionTexto[i, NumeroDePantalla - 1] > 0)
                            {
                                AnimacionAparicionTexto(0, i);
                            }
                        }
                    }
                    else if (AutorizarTraslacion && !AutorizarTraslacionInv)
                    {
                        //Console.WriteLine("Modo Traslacion");
                        if (ContadorCambioTamaño[i, NumeroDePantalla - 1] > 0)
                        {
                            AnimacionCambioDimesionRecuadro(0, i);
                        }
                        else if (ContadorCambioTamaño[i, NumeroDePantalla - 1] <= 0 )
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
                        if (ContadorCambioTamaño[i, NumeroDePantalla - 1] < 50)
                        {
                            AnimacionCambioDimesionRecuadro(1, i);
                        }
                        else if (ContadorCambioTamaño[i, NumeroDePantalla - 1] >= 50)
                        {
                            ContadorTraslacion++;
                            //Console.WriteLine("Contador: " + ContadorTraslacion.ToString() + "//Res:" + (MinYMax[NumeroDePantalla - 1, 0] - MinYMax[NumeroDePantalla - 1, 1]).ToString());
                            if (ContadorTraslacion == (MinYMax[NumeroDePantalla - 1, 1] - MinYMax[NumeroDePantalla - 1, 0]))
                            {
                                //Console.WriteLine("Pantalla Nueva: " + NumeroDePantalla.ToString());
                                AutorizarTraslacionInv = false;
                                AutorizarCambioPantalla1a2 = false;
                                AutorizarCambioPantalla2a1 = false;
                                AutorizarCambioPantallaGeneral = false;
                                for (int j = MinYMax[NumeroDePantalla - 1, 0]; j < MinYMax[NumeroDePantalla - 1, 1]; j++)
                                {
                                    ContadorCambioColor[j, NumeroDePantalla - 1] = 0;
                                    ContadorAparicionTexto[j, NumeroDePantalla - 1] = 0;
                                    ContadorCambioTamaño[j, NumeroDePantalla - 1] = 0;
                                }
                                //Console.WriteLine("Pantalla Nueva 2 : " + NumeroDePantalla.ToString());
                            }
                        }
                    }

                }
                if ((AutorizarCambioPantalla1a2 || AutorizarCambioPantalla2a1) && !AutorizarTraslacion && !AutorizarTraslacionInv)
                {
                    AutorizarTraslacion = true;
                    EstablecerCocientes();
                }
                else if (AutorizarTraslacion && AutorizarTraslacionInv)
                {
                    AutorizarTraslacion = false;
                    PonerInvisibleElementosPantalla();
                    MostrarPantalla();
                }
            }
            
        }

        public void PonerInvisibleElementosPantalla()
        {
            if (AutorizarCambioPantalla1a2 == true)
            {
                // Pantalla 1
                this.PanelDetectar.Visible = false;
                this.PanelConf.Visible = false;
                this.PanelLect.Visible = false;
                this.PanelSalirSis.Visible = false;
                // Pantalla 2
                this.PanelRegresar.Visible = true;

                NumeroDePantalla = 2;
                for (int j = MinYMax[NumeroDePantalla - 1, 0]; j < MinYMax[NumeroDePantalla - 1, 1]; j++)
                {
                    ContadorCambioColor[j, NumeroDePantalla - 1] = 0;
                    ContadorAparicionTexto[j, NumeroDePantalla - 1] = 0;
                    ContadorCambioTamaño[j, NumeroDePantalla - 1] = 0;
                }
            }
            else if (AutorizarCambioPantalla2a1 == true)
            {
                // Pantalla 1
                this.PanelDetectar.Visible = true;
                this.PanelConf.Visible = true;
                this.PanelLect.Visible = true;
                this.PanelSalirSis.Visible = true;
                // Pantalla 2
                this.PanelRegresar.Visible = false;

                NumeroDePantalla = 1;
                for (int j = MinYMax[NumeroDePantalla - 1, 0]; j < MinYMax[NumeroDePantalla - 1, 1]; j++)
                {
                    ContadorCambioColor[j, NumeroDePantalla - 1] = 0;
                    ContadorAparicionTexto[j, NumeroDePantalla - 1] = 0;
                    ContadorCambioTamaño[j, NumeroDePantalla - 1] = 0;
                }
            }
        }

        public void EstablecerCocientes()
        {
            /*
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
                DimensionadoCambioTamaño[11] = this.PanelRregresar.Height;
            }*/

            //RetornarValorDeClase(0);

            for (int j = MinYMax[NumeroDePantalla - 1, 0]; j < MinYMax[NumeroDePantalla - 1, 1]; j++)
            {
                ContadorCambioColor[j, NumeroDePantalla - 1] = 0;
                ContadorAparicionTexto[j, NumeroDePantalla - 1] = 0;
                ContadorCambioTamaño[j, NumeroDePantalla - 1] = 50;
            }
        }

        public void AnimacionAparicionTexto(int a, int i)
        {
            if (a == 1 && ContadorAparicionTexto[i, NumeroDePantalla - 1] < 255)
            {
                ContadorAparicionTexto[i, NumeroDePantalla - 1] = ContadorAparicionTexto[i, NumeroDePantalla - 1] + 20;
            }
            else if (a == 0 && ContadorAparicionTexto[i, NumeroDePantalla - 1] > 0)
            {
                ContadorAparicionTexto[i, NumeroDePantalla - 1] = ContadorAparicionTexto[i, NumeroDePantalla - 1] - 20;
            }
            if (ContadorAparicionTexto[i, NumeroDePantalla - 1] > 255)
            {
                ContadorAparicionTexto[i, NumeroDePantalla - 1] = 255;
            }
            else if (ContadorAparicionTexto[i, NumeroDePantalla - 1] < 0)
            {
                ContadorAparicionTexto[i, NumeroDePantalla - 1] = 0;
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
                 A[i,NumeroDePantalla - 1] = PanelLargo[i,NumeroDePantalla - 1] * 3 / 4;
            }
            else if (AutorizarTraslacion && !AutorizarTraslacionInv)
            {
                 A[i,NumeroDePantalla - 1] = DimensionadoCambioTamaño[i];
            }
            else if (!AutorizarTraslacion && AutorizarTraslacionInv)
            {
                 A[i,NumeroDePantalla - 1] = PanelLargo[i,NumeroDePantalla - 1];
            }
            
            dat = (int)((A[i, NumeroDePantalla - 1] ) * (1 - Math.Exp(-ContadorCambioTamaño[i, NumeroDePantalla - 1] * 0.1 / 2)));

            if (a == 1 && dat < A[i, NumeroDePantalla - 1] && ContadorCambioTamaño[i, NumeroDePantalla - 1] < 50)
            {
                if (NumeroDePantalla == 3)
                {
                    Console.WriteLine("X4: " + A[i, NumeroDePantalla - 1].ToString() + " i: " + i.ToString() + " Pantalla: " + NumeroDePantalla.ToString());
                }
                ContadorCambioTamaño[i, NumeroDePantalla - 1]++;
            }
            else if (a == 0 && ContadorCambioTamaño[i, NumeroDePantalla - 1] > 0)
            {
                
                ContadorCambioTamaño[i, NumeroDePantalla - 1]--;
            }
            if (ContadorCambioTamaño[i, NumeroDePantalla - 1] < 0)
            {
                ContadorCambioTamaño[i, NumeroDePantalla - 1] = 0;
            }
            //LARGOPANELDETECTAR = LARGOPANELDETECTAR + dat;
            //
            var P = this.PanelBarra;
            switch (Paneles[i,NumeroDePantalla - 1])
            {
                //*******Pantalla 1
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
                //***************Pantalla2
                case PANELREGRESAR:
                    P = this.PanelRegresar;
                    break;
                default:
                    return;
            }
            if (!AutorizarTraslacion && !AutorizarTraslacionInv)
            {
                P.Height = PanelLargo[i,NumeroDePantalla - 1] + dat;
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

            int[] ColorSelAlpha = new int[3];
            int[] ColorSelRed = new int[3];
            int[] ColorSelGreen = new int[3];
            int[] ColorSelBlue = new int[3];

            var P = this.PanelBarra;
            switch (Paneles[i,NumeroDePantalla-1])
            {
                case PANELBARRA:
                    P = this.PanelBarra;
                    break;
                case PANELCONF:
                    P = this.PanelConf;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = 80 + ContadorCambioColor[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = 80 + ContadorCambioColor[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = 80 + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELDETECTAR:
                    P = this.PanelDetectar;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = 0;
                    ColorSelGreen[0] = 96;
                    ColorSelBlue[0] = 110 + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELLECT:
                    P = this.PanelLect;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = 80 + ContadorCambioColor[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = 80 + ContadorCambioColor[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = 80 + ContadorCambioColor[i, NumeroDePantalla - 1];
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
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = 100 + ContadorCambioColor[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = 15;
                    ColorSelBlue[0] = 15;
                    break;
                case PANELTITULO:
                    P = this.PanelTitulo;
                    break;
                //Pantalla 2
                case PANELSELPUERTO:
                    P = this.PanelSelPuerto;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i,NumeroDePantalla-1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    //Console.WriteLine("A: " + ColorSelAlpha[0].ToString() + " R: " + ColorSelRed[0].ToString() + " G: " + ColorSelGreen[0].ToString() + " B: " + ColorSelBlue[0].ToString());
                    break;
                case PANELCOM:
                    P = this.PanelCOM;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELCONECTAR:
                    P = this.PanelConectar;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELEQUIPO:
                    P = this.PanelEquipo;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELEQUIPODATA:
                    P = this.PanelEquipoData;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELVERSION:
                    P = this.PanelVersion;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELVERSIONDATA:
                    P = this.PanelVersionData;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELCABINA:
                    P = this.PanelCabina;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELCABINADATA:
                    P = this.PanelCabinaData;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELREGRESAR:
                    P = this.PanelRegresar;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELSTATUS:
                    P = this.PanelStatus;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELNSERIE:
                    P = this.PanelNSerie;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                case PANELNSERIEDATA:
                    P = this.PanelNSerieData;
                    VerificacionDeColor(a, i);
                    ColorSelAlpha[0] = 255;
                    ColorSelRed[0] = PanelRed[i, NumeroDePantalla - 1];
                    ColorSelGreen[0] = PanelGreen[i, NumeroDePantalla - 1];
                    ColorSelBlue[0] = PanelBlue[i, NumeroDePantalla - 1] + ContadorCambioColor[i, NumeroDePantalla - 1];
                    break;
                default:
                    return;
            }
            var l = this.LabelTitulo1;
            switch (Labels1[i, NumeroDePantalla - 1])
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
                //Pantalla 2
                case LABELSELPUERTO:
                    l = this.LabelSelPuerto;
                    break;
                case LABELCOM:
                    l = this.LabelCOM;
                    break;
                case LABELCONECTAR:
                    l = this.LabelConectar;
                    break;
                case LABELEQUIPO:
                    l = this.LabelEquipo;
                    break;
                case LABELEQUIPODATA:
                    l = this.LabelEquipoData;
                    break;
                case LABELVERSION:
                    l = this.LabelVersion;
                    break;
                case LABELVERSIONDATA:
                    l = this.LabelVersionData;
                    break;
                case LABELCABINA:
                    l = this.LabelCabina;
                    break;
                case LABELCABINADATA:
                    l = this.LabelCabinaData;
                    break;
                case LABELREGRESAR:
                    l = this.LabelRegresar;
                    break;
                case LABELSTATUS:
                    l = this.LabelStatus;
                    break;
                case LABELNSERIE:
                    l = this.LabelNSerie;
                    break;
                case LABELNSERIEDATA:
                    l = this.LabelNSerieData;
                    break;
                //Default
                default:
                    return;
            }
            var l2 = this.LabelTitulo1;
            switch (Labels2[i, NumeroDePantalla - 1])
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

        public void VerificacionDeColor(int a, int i)
        {
            if (a == 1 && ContadorCambioColor[i, NumeroDePantalla - 1] < 120)
            {
                ContadorCambioColor[i, NumeroDePantalla - 1] = ContadorCambioColor[i, NumeroDePantalla - 1] + 10;
            }
            else if (a == 0 && ContadorCambioColor[i, NumeroDePantalla - 1] > 0)
            {
                ContadorCambioColor[i, NumeroDePantalla - 1] = ContadorCambioColor[i, NumeroDePantalla - 1] - 10;
            }
        }

        public void TraslacionRegresarPantalla1()
        {
            if (this.PanelRregresar.Location.X > -this.PanelRregresar.Width)
            {
                ExponenecialContador++;
                int dat = this.PanelDetectar.Location.X - (int)(Math.Exp(ExponenecialContador * 0.01 / 8));
                this.SelPuerto.Location = new Point(dat, this.SelPuerto.Location.Y);
                this.PanelRregresar.Location = new Point(dat, this.Height - 8 * EspacioAdicional);
            }
            else if (this.PanelRregresar.Location.X <= -this.PanelRregresar.Width)
            {
                this.PanelDetectar.Visible = false;
                //LastValue = (int)(Math.Exp(ExponenecialContador / 8));
                //Console.WriteLine(LastValue.ToString());
                ExponenecialContador = 0;
                //AutorizarRegresarPantalla1 = false;
                this.SelPuerto.Visible = true;
                this.PanelRregresar.Visible = true;
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
                this.PanelRregresar.Visible = true;
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

        private void PanelRegresar_MouseClick(object sender, MouseEventArgs e)
        {
            if (!AutorizarCambioPantallaGeneral)
            {
                AutorizarCambioPantallaGeneral = true;
                AutorizarCambioPantalla2a1 = true;
                Console.WriteLine("Cambio 2 a 1");
            }
        }
    }


}
