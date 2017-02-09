using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Principal
{
    public partial class FrmModificar : System.Web.UI.Page
    {
        public string problema = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!Page.IsPostBack)
            {
                
                
                if (Request.QueryString["folio"] != null)
                {
                    string perfill = "";

                    EntUsuario objj = (EntUsuario)Session["usuario"];
                    EntUsuario objsss = (EntUsuario)Session["perfil"];
                    if (objj != null)
                    {

                        perfill = objsss.perfil;
                    }

                    int folio = Convert.ToInt32(Request.QueryString["folio"]);
                    EntIngenieros obj = NegIngenieros.buscarreporte(folio);
                    TxtUsuario.Text = obj.reporta;

                    List<EntUbicacion> lista = NegUbicacion.listarubicacion();
                    foreach(EntUbicacion c in lista)
                    {
                        ListItem li = new ListItem(c.ubicacion, c.idubicacion.ToString());
                        Cmbubicacion.Items.Add(li);

                    }
                    Cmbubicacion.SelectedValue = obj.idubicacion.ToString();

                    string saberarea = Cmbubicacion.SelectedItem.Text;
                    if (saberarea!="CEDI" | saberarea!="Corporativo")
                    {
                        saberarea = "Sucursal";
                    }

                    List<EntUbicacion> lis = NegUbicacion.areastrabaall(saberarea);
                    foreach(EntUbicacion r in lis)
                    {
                        ListItem lii = new ListItem(r.area, r.idarea.ToString());
                        Cmbcentrotrabajo.Items.Add(lii);
                    }
                    Cmbcentrotrabajo.SelectedValue = obj.area;
                    Cmbnumero.Text =Convert.ToString(obj.numeromaquina);


                    List<EntAtienden> listar = NegIngenieros.buscarati();
                    foreach (EntAtienden c in listar)
                    {
                      ListItem li = new ListItem(c.nombre,c.idingenieros.ToString());
                        Cmbingenieros.Items.Add(li);
                    }
                    Cmbingenieros.SelectedValue = obj.idingenieros.ToString();

                    List<EntDispositivos> listaa = NegIngenieros.listardispositivos();
                    foreach(EntDispositivos c in listaa)
                    {
                        ListItem li = new ListItem(c.descripcion, c.iddispositivo.ToString());
                        Cmbdispositivo.Items.Add(li);
                    }
                    Cmbdispositivo.SelectedValue = obj.iddispositivo.ToString();

                     Txtinicial.Text = Convert.ToString(obj.fechainicio);
                    TxtSolicitud.Text = obj.solicitud;
                    Txtobservaciones.Text = obj.observaciones;
                    Txtingatendio.Text = obj.atendioreporte;
                    Txtsolucion.Text = obj.solucion;
                    Txtusuariocerro.Text = obj.cerroreporte;
                    Txtfechaasignado.Text =Convert.ToString(obj.fechaasignado);
                    if(perfill!="SOPORTE")
                    {
                        
                    }
                    else
                    {
                        Btnasignar.Enabled = false;
                    }
                    
                }
                else
                {
                    Response.Redirect("FrmPrincipal.aspx");
                }
            }
        }

        protected void Btnmodificar_Click(object sender, EventArgs e)
        {
            if(Txtsolucion.Enabled==true)
            {
                if (Txtinicial.Text!="" && TxtUsuario.Text!="" && Cmbubicacion.Text!="" && Cmbdispositivo.Text!="" && TxtSolicitud.Text!="" && Txtobservaciones.Text!="" && Txtsolucion.Text!= "Pendiente por atender" && Txtsolucion.Text!="" && Txtusuariocerro.Text!= "Pendiente por atender" && Txtfinal.Text!="" && Cmbingenieros.Text!=Convert.ToString(0))
                {
                    EntIngenieros obj = new EntIngenieros();

                    obj.fechainicio =DateTime.Parse(Txtinicial.Text);
                    obj.fechafinal = DateTime.Parse(Txtfinal.Text);
                    obj.reporta = TxtUsuario.Text;

                    string reg = null;
                    string ubi = null;
                    string dispo = "";
                    string inge = "";


                    int ati = 0;
                    int iddispo = 0;
                    int idubi = 0;
                    int cord = 0;
                    cord = Convert.ToInt32(Cmbubicacion.SelectedValue);
                    EntUbicacion objs = NegCordinador.listarcordinador(cord);
                    reg = objs.region;
                    ubi = objs.ubicacion;
                    idubi = objs.idubicacion;


                    iddispo = Convert.ToInt32(Cmbdispositivo.SelectedValue);
                    EntDispositivos obbj = NegDispositivo.listardispositivos(iddispo);
                    dispo = obbj.descripcion;


                    ati = Convert.ToInt32(Cmbingenieros.SelectedValue);
                    EntAtienden oobbjj = NegAtienden.listaratienden(ati);
                    inge = oobbjj.nombre;

                    obj.idubicacion = idubi;
                    obj.ubicacion = ubi;
                    obj.solicitud = TxtSolicitud.Text;
                    obj.observaciones = Txtobservaciones.Text;
                    obj.cerroreporte = Txtusuariocerro.Text;
                    obj.ingenierocerro = inge;
                    obj.dispositivofalla = dispo;
                    obj.atendioreporte = Txtingatendio.Text;
                    obj.cordinadorzona = reg;

                    string actual = "";
                    //actual = DateTime.Now.ToShortDateString();

                    DateTime fechainicial = Convert.ToDateTime(Txtinicial.Text);
                    DateTime fechafinal = Convert.ToDateTime(Txtfinal.Text);

                    //TimeSpan dias = fechafinal - fechainicial;
                    actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);

                    obj.diastrancurridos = Convert.ToInt32(actual);


                    string tiemporesp = "";

                    if (Convert.ToInt32(actual) > 2)
                    {
                        tiemporesp = Convert.ToString("Fuera de tiempo");
                    }
                    else
                    {
                        tiemporesp = Convert.ToString("A tiempo");
                    }

                    obj.tiemporespuesta = tiemporesp;
                    obj.statusreporte= "Cerrado";
                    obj.solucion = Txtsolucion.Text;
                    obj.idmenu = 2;
                    obj.idingenieros = ati;
                    obj.iddispositivo = iddispo;
                    obj.fechaasignado = DateTime.Parse(Txtfechaasignado.Text);

                    obj.area = Cmbcentrotrabajo.SelectedItem.Text;
                    obj.idarea = Convert.ToInt32(Cmbcentrotrabajo.SelectedValue);
                    obj.numeromaquina = Convert.ToInt32(Cmbnumero.Text);


                    obj.folio = Convert.ToInt32(Request.QueryString["folio"]);
                    if (NegIngenieros.modificarreporte(obj) == 1)
                    {
                        Response.Redirect("FrmPrincipal.aspx");
                    }
                    else
                    {
                        Lblerror.Text = "No se pudo modificar el reporte";
                        Lblerror.Visible = true;
                    }
                }
                else
                {
                    Lblerror.Text = "Falta ingresar datos";
                    Lblerror.Visible = true;
                }
            }
            else
            {
                if (Txtinicial.Text != "" && TxtUsuario.Text != "" && Cmbubicacion.Text != "" && Cmbdispositivo.Text != "" && TxtSolicitud.Text != "" && Txtobservaciones.Text != "" && Cmbingenieros.Text != Convert.ToString(0))
                {
                    EntIngenieros obj = new EntIngenieros();

                    obj.fechainicio = DateTime.Parse(Txtinicial.Text);

                    string fechatemporal = DateTime.Now.ToShortDateString();
                    Txtfinal.Text = "10-10-1999";

                    obj.fechafinal =DateTime.Parse(Txtfinal.Text);
                    obj.reporta = TxtUsuario.Text;

                    string reg = null;
                    string ubi = null;
                    string dispo = "";
                    string inge = "";


                    int ati = 0;
                    int iddispo = 0;
                    int idubi = 0;
                    int cord = 0;
                    cord = Convert.ToInt32(Cmbubicacion.SelectedValue);
                    EntUbicacion objs = NegCordinador.listarcordinador(cord);
                    reg = objs.region;
                    ubi = objs.ubicacion;
                    idubi = objs.idubicacion;


                    iddispo = Convert.ToInt32(Cmbdispositivo.SelectedValue);
                    EntDispositivos obbj = NegDispositivo.listardispositivos(iddispo);
                    dispo = obbj.descripcion;


                    ati = Convert.ToInt32(Cmbingenieros.SelectedValue);
                    EntAtienden oobbjj = NegAtienden.listaratienden(ati);
                    inge = oobbjj.nombre;

                    obj.idubicacion = idubi;
                    obj.ubicacion = ubi;
                    obj.solicitud = TxtSolicitud.Text;
                    obj.observaciones = Txtobservaciones.Text;
                    obj.cerroreporte = Txtusuariocerro.Text;
                    obj.ingenierocerro = inge;
                    obj.dispositivofalla = dispo;
                    obj.atendioreporte = Txtingatendio.Text;
                    obj.cordinadorzona = reg;

                    string actual = "";
                    actual = DateTime.Now.ToShortDateString();

                    DateTime fechainicial = Convert.ToDateTime(Txtinicial.Text);
                    DateTime fechafinal = Convert.ToDateTime(actual);

                
                    actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);
                    obj.diastrancurridos =Convert.ToInt32(actual);

                    string tiemporesp = "";

                    if (Convert.ToInt32(actual) > 2)
                    {
                        tiemporesp = Convert.ToString("Fuera de tiempo");
                    }
                    else
                    {
                        tiemporesp = Convert.ToString("A tiempo");
                    }

                    obj.tiemporespuesta = tiemporesp;
                    obj.statusreporte = "En Proceso";
                    obj.solucion = "Pendiente por atender";
                    obj.idmenu = 1;
                    obj.idingenieros = ati;
                    obj.iddispositivo = iddispo;
                    obj.fechaasignado =DateTime.Parse(fechatemporal);
                    obj.area = Cmbcentrotrabajo.SelectedItem.Text;
                    obj.idarea =Convert.ToInt32(Cmbcentrotrabajo.SelectedValue);
                    obj.numeromaquina = Convert.ToInt32(Cmbnumero.Text);

                    obj.folio = Convert.ToInt32(Request.QueryString["folio"]);
                    if (NegIngenieros.modificarreporte(obj) == 1)
                    {
                        Response.Redirect("FrmPrincipal.aspx");
                    }
                    else
                    {
                        Lblerror.Text = "No se pudo modificar el reporte";
                        Lblerror.Visible = true;
                    }
                }
                else
                {
                    Lblerror.Text = "Falta ingresar datos";
                    Lblerror.Visible = true;
                }
            }
        }
            
        

        protected void Imgfinal_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Txtinicial.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void Imginicial_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            Txtfinal.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }

        protected void Btnasignar_Click(object sender, EventArgs e)
        {
            Imginicial.Enabled = true;
            TxtUsuario.Enabled = true;
            Cmbubicacion.Enabled = true;
            Cmbdispositivo.Enabled = true;
            TxtSolicitud.Enabled = true;
            Txtobservaciones.Enabled = true;
            Txtsolucion.Enabled = false;
            Txtusuariocerro.Enabled = false;
            Cmbingenieros.Enabled = true;
            Imgfinal.Enabled = false;
            Btnmodificar.Enabled = true;
            Cmbcentrotrabajo.Enabled = true;
            RdbHd.Enabled = true;
            RdbSf.Enabled = true;
        }

        protected void Btncerrar_Click(object sender, EventArgs e)
        {
            Imginicial.Enabled = false;
            Txtusuariocerro.Enabled = false;
            Cmbubicacion.Enabled = false;
            Cmbdispositivo.Enabled = false;
            TxtSolicitud.Enabled = false;
            Txtobservaciones.Enabled = false;
            Txtsolucion.Enabled = true;
            Txtusuariocerro.Enabled = true;
            Cmbingenieros.Enabled = false;
            Imgfinal.Enabled = true;
            Btnmodificar.Enabled = true;
            Cmbcentrotrabajo.Enabled = false;
            RdbHd.Enabled = false;
            RdbSf.Enabled = false;
            Cmbnumero.Enabled = false;
        }

        protected void Cmbingenieros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Cmbubicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbcentrotrabajo.Enabled = true;

            string ubi = "";
            int valor = 0;
            valor = Convert.ToInt32(Cmbubicacion.Text);
            if (valor == 14)
            {
                ubi = "CEDI";
            }
            else if (valor == 43)
            {
                ubi = "Corporativo";
            }
            else
            {
                ubi = "Sucursal";
            }
            List<EntUbicacion> listar = NegUbicacion.areastrabajo(ubi);
            Cmbcentrotrabajo.Items.Clear();
            foreach (EntUbicacion oobbjj in listar)
            {
                ListItem item = new ListItem(oobbjj.area);
                Cmbcentrotrabajo.Items.Add(item);
            }
            Cmbnumero.Enabled = false;
        }

        protected void Cmbcentrotrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmbcentrotrabajo.SelectedItem.Text == "Auto Servicio" | Cmbcentrotrabajo.SelectedItem.Text == "Mostrador" | Cmbcentrotrabajo.SelectedItem.Text=="Kiosco"| Cmbcentrotrabajo.SelectedItem.Text=="Mayoreo")
            {
                Cmbnumero.Enabled = true;
            }
            else
            {
                Cmbnumero.Text = "1";
                Cmbnumero.Enabled = false;
            }
        }

        protected void RdbHd_CheckedChanged(object sender, EventArgs e)
        {
            Cmbdispositivo.Items.Clear();
            problema = "Hardware";
            RdbSf.Checked = false;
            List<EntDispositivos> Listas = NegIngenieros.listardispositivos(problema);
            foreach (EntDispositivos obj in Listas)
            {
                ListItem item = new ListItem(obj.descripcion, obj.iddispositivo.ToString());
                Cmbdispositivo.Items.Add(item);

            }

        }

        protected void RdbSf_CheckedChanged(object sender, EventArgs e)
        {
            Cmbdispositivo.Items.Clear();
            problema = "Software";
            RdbHd.Checked = false;
            List<EntDispositivos> Listas = NegIngenieros.listardispositivos(problema);
            foreach (EntDispositivos obj in Listas)
            {
                ListItem item = new ListItem(obj.descripcion, obj.iddispositivo.ToString());
                Cmbdispositivo.Items.Add(item);

            }
        }
    }
}