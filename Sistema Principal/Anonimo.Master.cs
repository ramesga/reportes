using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Principal
{
    public partial class Anonimo1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EntUsuario obj = (EntUsuario)Session["usuario"];
            EntUsuario objs = (EntUsuario)Session["perfil"];
            if (obj != null)
            {
                NombreUsuario.Text = obj.nombre + " " + obj.apellido;
                Perfil.Text = obj.perfil;
                string nom = obj.nombre;
                if(nom=="Roberto" | nom=="Hector" | nom=="Francisco" | nom=="Segismundo")
                {
                    HplMenu.Enabled = false;
                    HplMenu2.Enabled = false;
                }
                
            }
            else
            {
                Response.Redirect("frmlogin.aspx");
            }
        }

        protected void Lbtlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("frmlogin.aspx");
        }

        protected void Btnagregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmAgregar");
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Frmagregarusuarios");
        }

        protected void Btnbuscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("busquedas.aspx?bus="+1);
            //Hplcordinador11.NavigateUrl = "FrmPrincipal.aspx?men=" + 4;
        }
    }
}