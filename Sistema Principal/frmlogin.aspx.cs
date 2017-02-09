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
    public partial class frmlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["usuario"]!=null)
            {
                Response.Redirect("FrmPrincipal.aspx");
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (Txtusuario.Text != "" && Txtpass.Text != "")
            {
                EntUsuario obj = NegUsuario.Login(Txtusuario.Text, Txtpass.Text);
                if (obj != null)
                {
                    Session["usuario"] = obj;
                    Session["perfil"] = obj;
                    Response.Redirect("FrmPrincipal.aspx");
                }
                else
                {
                    LblError.Text = "Usuario o Contraseña invalido";
                    LblError.Visible = true;
                }
            }
            else
            {
                LblError.Text = "Falta agregar datos";
                LblError.Visible = true;
            }
        }
    }
}