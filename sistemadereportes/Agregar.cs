using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemadereportes
{
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                EntIngenieros obj = new EntIngenieros();
                obj.reporta = reporta.Text;
                obj.ubicacion = ubicacion.Text;
                obj.solicitud = solicitud.Text;
                obj.observaciones = observaciones.Text;
                obj.cerroreporte = usuariocerro.Text;
                obj.ingenierocerro = ingcerro.Text;
                obj.idmenu = 1;
                if(NegIngenieros.agregarrreporte(obj)>0)
                {
                    MessageBox.Show("Agregado con exito");
                    principal p = new principal();
                    this.Dispose(false);
                    p.Visible = true;
                }
                else
                {
                    MessageBox.Show("Error al agregar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Datos erroneos");
            }
        }
    }
}
