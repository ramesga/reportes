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

    
    public partial class FrmAgregar : System.Web.UI.Page
    {
        //int idatiend = 0;
        public string problema = "";
        public string aarea = "";
      
        public int idaarea = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                
                List<EntUbicacion> lista = NegUbicacion.listarubicacion();
                foreach (EntUbicacion obj in lista)
                {
                    ListItem item = new ListItem(obj.ubicacion,obj.idubicacion.ToString());
                    Cmbubicacion.Items.Add(item);
                    //Txtcordinador.Text = obj.region;
                    
                }

                string ubi = "";
                
                ubi = Cmbubicacion.Text;
                if (ubi != "CEDI" | ubi != "Corporativo")
                {
                    ubi = "Sucursal";
                }
                List<EntUbicacion> listar = NegUbicacion.areastrabajo(ubi);
                foreach (EntUbicacion oobbjj in listar)
                {
                    ListItem itemm = new ListItem(oobbjj.area);
                    Cmbcentrotrabajo.Items.Add(itemm);
                }

                problema = "Hardware";
                List<EntDispositivos> Listas = NegIngenieros.listardispositivos(problema);
                foreach (EntDispositivos obj in Listas)
                {
                    ListItem item = new ListItem(obj.descripcion);
                    Cmbdispositivos.Items.Add(item);
                    
                }

                EntUsuario Obj = (EntUsuario)Session["usuario"];
                if (Obj != null)
                {
                    Txtingatendio.Text = Obj.nombre + " " + Obj.apellido;
                }

                List<EntAtienden> Listar = NegIngenieros.listaridingenieros();
                foreach (EntAtienden obj in Listar)
                {
                    ListItem item = new ListItem(obj.nombre,obj.idingenieros.ToString());
                    cmbatiende.Items.Add(item);

                }
                
            
                //idatiend=Obj.i

                
                Calendar1.Visible = false;
                Calendar2.Visible = false;
            }
        }

        protected void Btnguardar_Click(object sender, EventArgs e)
        {
            if(Txtsolucion.Enabled==false)
            {
                if (Txtinicial.Text!="" && TxtUsuario.Text!="" && Cmbubicacion.Text!="" && Cmbdispositivos.Text!="" && TxtObservaciones.Text!="" )
                {
                    string reg = null;
                    string ubi = null;
                    string dispo = "";
                    int idubi = 0;
                    int cord = 0;
                    int iddispo = 0;
                    dispo = Cmbdispositivos.Text;
                                       
                    cord = Convert.ToInt32(Cmbubicacion.SelectedValue);
                    EntUbicacion objs = NegCordinador.listarcordinador(cord);
                    reg = objs.region;
                    ubi = objs.ubicacion;
                    idubi = objs.idubicacion;

                    aarea =Cmbcentrotrabajo.SelectedValue;
                    List <EntUbicacion> llista = NegUbicacion.areastrabajovalor(aarea);
                    foreach (EntUbicacion objeto in llista)
                    {
                        aarea = objeto.area;
                        idaarea = objeto.idarea;
                    }

                    //iddispo = Convert.ToInt32(Cmbdispositivos.SelectedValue);

                    List< EntDispositivos> liista = NegDispositivo.buscarid(dispo);
                    foreach (EntDispositivos objetoo in liista )
                    {
                        iddispo = objetoo.iddispositivo;
                    }
                    
                    //iddispo = Cmbdispositivos.SelectedItem.Text;
                    TxtFinal.Text = "10-10-1999";

                    EntIngenieros obj = new EntIngenieros();
                    
                    obj.fechainicio = DateTime.Parse(Txtinicial.Text);
                    obj.fechafinal = DateTime.Parse(TxtFinal.Text);
                    obj.reporta = TxtUsuario.Text;
                    obj.ubicacion = ubi;
                    obj.solicitud = TxtSolicitud.Text;
                    obj.observaciones = TxtObservaciones.Text;
                    obj.cerroreporte = "Pendiente por atender";
                    obj.ingenierocerro = "Pendiente por asignar";
                    obj.dispositivofalla = dispo;
                    obj.atendioreporte = Txtingatendio.Text;
                    obj.cordinadorzona = reg;
                    obj.diastrancurridos = 0;
                    obj.tiemporespuesta = "A Tiempo";
                    obj.statusreporte = "Abierto";
                    obj.solucion = "Pendiente por atender";
                    obj.idmenu = 1;
                    obj.idubicacion = idubi;
                    obj.idingenieros = 0;
                    obj.iddispositivo = iddispo;
                    obj.fechaasignado = DateTime.Parse(Txtinicial.Text);
                    obj.area = aarea;
                    obj.idarea = idaarea;
                    obj.numeromaquina =Convert.ToInt32(Cmbnumero.Text);
                    if (NegIngenieros.agregarrreporte(obj) == 1)
                    {
                        Response.Redirect("FrmPrincipal.aspx");
                    }
                    else
                    {
                        LblError.Text = "No se pudo Agregar";
                        LblError.Visible = true;
                    }
                }
                else
                {
                    LblError.Text = "Falta proporcionar datos";
                    LblError.Visible = true;
                }
            }
            else
            {
                if(Txtinicial.Text!="" && TxtUsuario.Text!="" && Cmbubicacion.Text!="" && Cmbdispositivos.Text!="" && TxtSolicitud.Text!="" && Txtsolucion.Text!="" && TxtUsuariocerro.Text!="" && TxtFinal.Text!="" && cmbatiende.Text!= "Pendiente por asignar")
                {
                    string reg = null;
                    string ubi = null;
                    string dispo = "";
                    string inge = "";


                    int  ati = 0;
                    int iddispo = 0;
                    int idubi = 0;
                    int cord = 0;
                    cord = Convert.ToInt32(Cmbubicacion.SelectedValue);
                    EntUbicacion objs = NegCordinador.listarcordinador(cord);
                    reg = objs.region;
                    ubi = objs.ubicacion;
                    idubi = objs.idubicacion;


                    //iddispo = Convert.ToInt32(Cmbdispositivos.SelectedValue);
                    //EntDispositivos obbj = NegDispositivo.listardispositivos(iddispo);
                    //dispo = obbj.descripcion;

                    dispo = Cmbdispositivos.SelectedItem.Text;

                    List<EntDispositivos> liista = NegDispositivo.buscarid(dispo);
                    foreach (EntDispositivos objetoo in liista)
                    {
                        iddispo = objetoo.iddispositivo;
                    }

                    ati = Convert.ToInt32(cmbatiende.SelectedValue);
                    EntAtienden oobbjj = NegAtienden.listaratienden(ati);
                    inge = oobbjj.nombre;

                    aarea = Cmbcentrotrabajo.SelectedValue;
                    List<EntUbicacion> llista = NegUbicacion.areastrabajovalor(aarea);
                    foreach (EntUbicacion objeto in llista)
                    {
                        aarea = objeto.area;
                        idaarea = objeto.idarea;
                    }

                    EntIngenieros obj = new EntIngenieros();
                    obj.fechainicio = DateTime.Parse(Txtinicial.Text);
                    obj.fechafinal = DateTime.Parse(TxtFinal.Text);
                    obj.reporta = TxtUsuario.Text;
                    obj.idubicacion = idubi;
                    obj.ubicacion = ubi;
                    obj.solicitud = TxtSolicitud.Text;
                    obj.observaciones = "Solucionado";
                    obj.cerroreporte = TxtUsuariocerro.Text;
                    obj.ingenierocerro = inge;
                    obj.dispositivofalla = dispo;
                    obj.atendioreporte = Txtingatendio.Text;
                    obj.cordinadorzona = reg;
                    obj.diastrancurridos = 0;
                    obj.tiemporespuesta = "A Tiempo";
                    obj.statusreporte = "Cerrado";
                    obj.solucion = Txtsolucion.Text;
                    obj.idmenu = 2;
                    obj.idingenieros = ati;
                    obj.iddispositivo = iddispo;
                    obj.fechaasignado = DateTime.Parse(Txtinicial.Text);
                    obj.area = aarea;
                    obj.idarea = idaarea;
                    obj.numeromaquina = Convert.ToInt32(Cmbnumero.Text);
                    if (NegIngenieros.agregarrreporte(obj) == 1)
                    {
                        Response.Redirect("FrmPrincipal.aspx");
                    }
                    else
                    {
                        LblError.Text = "No se pudo Agregar";
                        LblError.Visible = true;
                    }
                }
                else
                {
                    LblError.Text = "Falta proporcionar datos";
                    LblError.Visible = true;
                }
            }
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Txtinicial.Text = Calendar1.SelectedDate.ToShortDateString();        
            Calendar1.Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
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

        protected void Txtinicial_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Cmbubicacion_Click(object sender, EventArgs e)
        //protected void Cmbubicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<EntUbicacion> listas = NegIngenieros.listarubicaciones();
            foreach (EntUbicacion obj in listas)
            {
                ListItem item = new ListItem(obj.ubicacion, obj.region);
                Cmbubicacion.Items.Add(item);
            }
            string ubi = "";
            ubi = Cmbubicacion.Text;
            if (ubi!="CEDI"| ubi!="Corporativo")
            {
                ubi = "Sucursal";
            }
            List<EntUbicacion> listar = NegUbicacion.areastrabajo(ubi);
            foreach(EntUbicacion oobbjj in listar)
            {
                ListItem item = new ListItem(oobbjj.area);
                Cmbcentrotrabajo.Items.Add(item);
            }
            Cmbnumero.Enabled = false;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
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

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TxtFinal.Text = Calendar2.SelectedDate.ToShortDateString();
            //+ Calendar1.SelectedDate.ToShortTimeString();
            Calendar2.Visible = false;
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Btnreporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<EntAtienden> listar = NegIngenieros.buscarati();
            //foreach (EntAtienden obj in listar)
            //{
              //  ListItem item = new ListItem(obj.nombre);
                //CmbIngenieros.Items.Add(item);
            //}
        }

        protected void BtnAbierto_Click(object sender, EventArgs e)
        {
            ImageButton1.Enabled = true;
            TxtUsuario.Enabled = true;
            Cmbubicacion.Enabled = true;
            Cmbdispositivos.Enabled = true;
            TxtSolicitud.Enabled = true;
            TxtObservaciones.Text = "";
            TxtObservaciones.Enabled = true;
            Txtsolucion.Enabled = false;
            Txtsolucion.Text = "Pendiente por atender";
            TxtUsuariocerro.Enabled = false;
            TxtUsuariocerro.Text = "Pendiente por atender";
            TxtFinal.Text = DateTime.Now.ToShortDateString();
            Txtsolucion.Enabled = false;
            TxtUsuariocerro.Enabled = false;
            cmbatiende.Enabled = false;
            ImageButton2.Enabled = false;
            Btnguardar.Enabled = true;
            Cmbcentrotrabajo.Enabled = true;
            RdbHd.Enabled = true;
            RdbSf.Enabled = true;
        }

        protected void BtnCerrado_Click(object sender, EventArgs e)
        {
            ImageButton1.Enabled = true;
            TxtUsuario.Enabled = true;
            Cmbubicacion.Enabled = true;
            Cmbdispositivos.Enabled = true;
            TxtSolicitud.Enabled = true;
            TxtObservaciones.Enabled =false;
            TxtObservaciones.Text = "Solucionado";
            Txtsolucion.Text = "";
            Txtsolucion.Enabled = true;
            TxtUsuariocerro.Text = "";
            TxtUsuariocerro.Enabled = true;
            TxtFinal.Text = "";
            cmbatiende.Enabled = true;
            ImageButton2.Enabled = true;
            Btnguardar.Enabled = true;
            Cmbcentrotrabajo.Enabled = true;
            RdbHd.Enabled = true;
            RdbSf.Enabled = true;
        }

        protected void cmbatiende_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Cmbubicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbcentrotrabajo.Enabled = true;
            
            string ubi = "";
            int valor = 0;
            valor =Convert.ToInt32(Cmbubicacion.Text);
            if (valor ==14 )
            {
                ubi = "CEDI";
            }
            else if(valor==43)
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
            
            if (Cmbcentrotrabajo.Text =="Auto Servicio" | Cmbcentrotrabajo.Text=="Mostrador" | Cmbcentrotrabajo.SelectedItem.Text == "Kiosco" | Cmbcentrotrabajo.SelectedItem.Text == "Mayoreo")
            {
                Cmbnumero.Enabled = true;
            }
            else
            {
                Cmbnumero.Text ="1";
                Cmbnumero.Enabled = false;
            }
        }

        protected void RdbHd_CheckedChanged(object sender, EventArgs e)
        {
            Cmbdispositivos.Items.Clear();
            problema = "Hardware";
            RdbSf.Checked = false;
            List<EntDispositivos> Listas = NegIngenieros.listardispositivos(problema);
            foreach (EntDispositivos obj in Listas)
            {
                ListItem item = new ListItem(obj.descripcion);
                Cmbdispositivos.Items.Add(item);

            }
            
        }

        protected void RdbSf_CheckedChanged(object sender, EventArgs e)
        {
            Cmbdispositivos.Items.Clear();
            problema = "Software";
            RdbHd.Checked = false;
            List<EntDispositivos> Listas = NegIngenieros.listardispositivos(problema);
            foreach (EntDispositivos obj in Listas)
            {
                ListItem item = new ListItem(obj.descripcion);
                Cmbdispositivos.Items.Add(item);

            }
            
        }

        protected void Cmbdispositivos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}