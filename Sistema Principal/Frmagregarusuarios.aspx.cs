using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Principal
{
    public partial class Frmagregarusuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                EntUsuario Obj = (EntUsuario)Session["perfil"];
                string verificar = "";
                if (Obj != null)
                {

                    verificar = Obj.perfil;

                }
                if (verificar != "ADMINISTRADOR")
                {
                    Btnguardar.Enabled = false;
                }

            }
        }

        protected void Btnguardar_Click(object sender, EventArgs e)
        {
            if (Txtnombre.Text!="" && Txtapellido.Text!="" && Txtusuario.Text!="" && Txtpass.Text!="")
            {
                EntUsuario obj = new EntUsuario();

                obj.nombre = Txtnombre.Text;
                obj.apellido = Txtapellido.Text;
                obj.usuario = Txtusuario.Text;
                obj.password = Txtpass.Text;
                obj.perfil = cmbusuario.Text;

                if (CapaNegocio.NegPerfiles.agregarusuarios(obj) ==1)
                {
                    Response.Redirect("FrmPrincipal.aspx");
                }
                else
                {
                    Lblerror.Text = "No se pudo Agregar";
                    Lblerror.Visible = true;
                }
            }
            else
            {
                Lblerror.Text = "Falta proporcionar datos";
                Lblerror.Visible = true;
            }
        }
    }
}