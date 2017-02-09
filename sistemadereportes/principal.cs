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
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            inicializarinterfaz();
        }

        private void arbol_DoubleClick(object sender, EventArgs e)
        {
            if (!arbol.SelectedNode.Name.Equals(""))
                
            {
                EntIngenieros obj = NegIngenieros.buscarreporte(Convert.ToInt32(arbol.SelectedNode.Name));
                reporta.Text = obj.reporta;
                ubicacion.Text = obj.ubicacion;
                solicitud.Text = obj.solicitud;
                observaciones.Text = obj.observaciones;
                usuariocerro.Text = obj.cerroreporte;

            }
        }

        private void inicializarinterfaz()
        {
           
            List<EntMenu> listac = NegMenu.listarmenu();
            foreach (EntMenu c in listac)
            {
                TreeNode padre = new TreeNode(c.descripcion);
                List<EntIngenieros> listap = NegIngenieros.listaringenieros(c.idmenu);

                foreach (EntIngenieros p in listap)
                {
                    TreeNode hijo = new TreeNode(p.ingenierocerro);
                    hijo.Name = p.idmenu.ToString();
                    padre.Nodes.Add(hijo);

                }
                arbol.Nodes.Add(padre);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntIngenieros obj = new EntIngenieros();
            try
            {
                obj.reporta = reporta.Text;
                obj.ubicacion = ubicacion.Text;
                obj.solicitud = solicitud.Text;
                obj.observaciones = observaciones.Text;
                obj.cerroreporte = usuariocerro.Text;
                obj.folio = Convert.ToInt32(arbol.SelectedNode.Name.ToString());
                if (NegIngenieros.modificarreporte(obj) > 0)
                {
                    MessageBox.Show("Modificado con exito");
                    arbol.Nodes.Clear();
                    inicializarinterfaz();
                }
                else
                {
                    MessageBox.Show("Error al modificar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Datos erroneos");
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Agregar ap = new Agregar();
            ap.Visible = true;
            this.Dispose(false);
        }
    }
}
