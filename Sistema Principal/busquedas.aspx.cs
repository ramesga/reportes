using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistema_Principal
{
    public partial class busquedas : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<EntUbicacion> lista = NegUbicacion.listarubicacion();
                foreach (EntUbicacion obj in lista)
                {
                    ListItem item = new ListItem(obj.ubicacion, obj.idubicacion.ToString());
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
                    
                    Cmbarea.Items.Add(itemm);
                }
                Cmbarea.Items.Insert(0, "Todas");
                Cldfinal.Visible = false;
                Cldinicio.Visible = false;
                Lblcontador.Visible = false;
                Txtcontador.Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Cldinicio.Visible)
            {
                Cldinicio.Visible = false;
            }
            else
            {
                Cldinicio.Visible = true;
            }
        }

        

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (Cldfinal.Visible)
            {
                Cldfinal.Visible = false;
            }
            else
            {
                Cldfinal.Visible = true;
            }
        }

        protected void Cldinicio_SelectionChanged(object sender, EventArgs e)
        {
            // Txtfechainicio.Text = Cldinicio.SelectedDate.ToString();

            var _O1 = Cldinicio.SelectedDate;
            
            TextBox1.Text = _O1.ToString("MM'/'dd'/'yyyy");

            string dia = Cldinicio.SelectedDate.Day.ToString();
            string mes = Cldinicio.SelectedDate.Month.ToString();
            string year = Cldinicio.SelectedDate.Year.ToString();
            TextBox1.Text = _O1.ToString("dd'/'MM'/'yyyy");
            Txtfechainicio.Text = dia+"/"+mes+"/"+year;
            Cldinicio.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void Cmbubicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbarea.Enabled = true;

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
            Cmbarea.Items.Clear();
            foreach (EntUbicacion oobbjj in listar)
            {
                ListItem item = new ListItem(oobbjj.area);
                Cmbarea.Items.Add(item);
            }
            Cmbarea.Items.Insert(0, "Todas");
        }

        protected void Chcabiertos_CheckedChanged(object sender, EventArgs e)
        {
            if(Txtfechainicio.Text!="" & Txtfechafinal.Text!="")
            {
                Chccerrados.Checked = false;
                string ubi = Cmbubicacion.SelectedItem.Text;
                string ar = Cmbarea.Text;
                Int32 abier = 1;
                var _FormatoIdioma = new CultureInfo("en-US");
                //var _oF1 = DateTime.Parse(TextBox1.Text, _FormatoIdioma);
                //var _oF2 = DateTime.Parse(TextBox2.Text, _FormatoIdioma);

                // MM/dd/yyyy
                var FechaIni = TextBox1.Text.Split('/');
                var FechaFin = TextBox2.Text.Split('/');


                //var _oF1 = new DateTime(Convert.ToInt32(FechaIni[2]), Convert.ToInt32(FechaIni[0]), Convert.ToInt32(FechaIni[1]));
                //var _oF2 = new DateTime(Convert.ToInt32(FechaFin[2]), Convert.ToInt32(FechaFin[0]), Convert.ToInt32(FechaFin[1]));

                
                DateTime _oF1 = Convert.ToDateTime(TextBox1.Text);
                DateTime _oF2 = Convert.ToDateTime(TextBox2.Text);

                //Lbltitulo.Text = "Fecha inicial: "+ _oF1+"   "+"fecha final: "+_oF2;
                Lbltitulo.Text = "Reportes Abiertos o en Proceso";
                if(ar!= "Todas")
                {
                    GridView1.DataSource = NegIngenieros.busquedafechaarea(ubi, ar, _oF1, _oF2, abier);

                }
                else
                {
                    GridView1.DataSource = NegIngenieros.busquedafechaareatotal(ubi, _oF1, _oF2, abier);
                }
                


                GridView1.Columns[11].HeaderText = "Ing. que atendera";
                GridView1.DataBind();
                Lblcontador.Visible = true;
                Lblcontador.Text = "Total de reportes Abiertos:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.GridView1.Rows.Count.ToString();
                if (Convert.ToInt32(Txtcontador.Text) == 0)
                {
                    Lbltitulo.Text = "No se encontraron registros con los datos proporcionados";
                    Chcabiertos.Checked = false;
                    Chccerrados.Checked = false;
                }
                this.GridView1.Columns[8].Visible = false;
                this.GridView1.Columns[10].Visible = false;
                this.GridView1.Columns[14].Visible = false;
                Chcabiertos.Checked = false;
                Chccerrados.Checked = false;
                Txtbandera.Text = "1";
            }
            else
            {
                Lbltitulo.Text = "Falta proporcionar datos";
                Chcabiertos.Checked = false;
                Chccerrados.Checked = false;
            }

            
           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //El siguiente comentario sombrea de amarillo sombre la fila donde pasa el puntero
                // e.Row.Attributes.Add("onmouseover",
                //"this.originalcolor=this.style.backgroundColor;" +
                //" this.style.backgroundColor='yellow';");
                e.Row.Attributes.Add("onmouseout",
                "this.style.backgroundColor=this.originalcolor;");
                string s = Convert.ToString(System.Web.UI.DataBinder.Eval(e.Row.DataItem, "tiemporespuesta"));

                //luego un if para saber que color le queremos dar
                if (s == "Fuera de tiempo")
                {
                    e.Row.ForeColor = Color.Red;

                }
                int index = GetColumnIndexByName(e.Row, "ingenierocerro");
                if (index != -1)
                {
                    if (e.Row.Cells[index].Text == "Pendiente por asignar")
                    {
                        e.Row.Cells[index].ForeColor = Color.Blue;
                        e.Row.Cells[index].Font.Bold = true;
                        //"<img src='/App_Themes/EstadoRojo.png'>" + e.Row.Cells[index].Text;
                    }

                }
            }
        }

        //ESTA FUNCIÓN ES LA QUE RETORNA EL INDEX DE LA COLUMNA SI LA ENCUENTRA, SINO LE HE PUESTO QUE DEVUELVA -1:
        public static int GetColumnIndexByName(GridViewRow row, string columnName)
        {
            int columnIndex = 0;
            bool encontrado = false;

            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.ContainingField is BoundField)
                    if (((BoundField)cell.ContainingField).DataField.Equals(columnName))
                    {
                        encontrado = true;
                        break;
                    }
                columnIndex++;
            }

            if (encontrado == false)
            {
                columnIndex = -1;
            }
            return columnIndex;
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("FrmModificar.aspx?folio=" + GridView1.Rows[GridView1.SelectedIndex].Cells[0].Text);
        }

        protected void Chccerrados_CheckedChanged(object sender, EventArgs e)
        {
            if (Txtfechainicio.Text != "" & Txtfechafinal.Text != "")
            {
                
                Chcabiertos.Checked = false;
                string ubi = Cmbubicacion.SelectedItem.Text;
                string ar = Cmbarea.Text;
                Int32 abier = 2;
                var _FormatoIdioma = new CultureInfo("en-US");
                var _oF1 = DateTime.Parse(TextBox1.Text, _FormatoIdioma);
                var _oF2 = DateTime.Parse(TextBox2.Text, _FormatoIdioma);

                Lbltitulo.Text = "Reportes Cerrados";

                if (ar != "Todas")
                {
                    GridView1.DataSource = NegIngenieros.busquedafechaarea(ubi, ar, _oF1, _oF2, abier);

                }
                else
                {
                    GridView1.DataSource = NegIngenieros.busquedafechaareatotal(ubi, _oF1, _oF2, abier);
                }


                //GridView1.DataSource = NegIngenieros.busquedafechaarea(ubi, ar, _oF1, _oF2, abier);
                GridView1.Columns[11].HeaderText = "Ing. que atendio";
                this.GridView1.Columns[8].Visible = true;
                this.GridView1.Columns[10].Visible = true;
                this.GridView1.Columns[14].Visible = true;
                GridView1.DataBind();
                Lblcontador.Visible = true;
                Lblcontador.Text = "Total de reportes Cerrados:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.GridView1.Rows.Count.ToString();
                
                if (Convert.ToInt32(Txtcontador.Text) == 0)
                {
                    Lbltitulo.Text = "No se encontraron registros con los datos proporcionados";
                    Chcabiertos.Checked = false;
                    Chccerrados.Checked = false;
                }
                
                Chcabiertos.Checked = false;
                Chccerrados.Checked = false;
                Txtbandera.Text = "2";
            }
            else
            {
                Lbltitulo.Text = "Falta proporcionar datos";
                Chcabiertos.Checked = false;
                Chccerrados.Checked = false;
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            if(Convert.ToInt32(Txtbandera.Text)==1)

            {
                GridView1.PageIndex = e.NewPageIndex;

                Chccerrados.Checked = false;
                string ubi = Cmbubicacion.SelectedItem.Text;
                string ar = Cmbarea.Text;
                Int32 abier = 1;
                var _FormatoIdioma = new CultureInfo("en-US");
                var _oF1 = DateTime.Parse(TextBox1.Text, _FormatoIdioma);
                var _oF2 = DateTime.Parse(TextBox2.Text, _FormatoIdioma);

                Lbltitulo.Text = "Reportes Abiertos o en Proceso";
                if (ar != "Todas")
                {
                    GridView1.DataSource = NegIngenieros.busquedafechaarea(ubi, ar, _oF1, _oF2, abier);

                }
                else
                {
                    GridView1.DataSource = NegIngenieros.busquedafechaareatotal(ubi, _oF1, _oF2, abier);
                }



                GridView1.Columns[11].HeaderText = "Ing. que atendera";
                GridView1.DataBind();
                Lblcontador.Visible = true;
                Lblcontador.Text = "Total de reportes Abiertos:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.GridView1.Rows.Count.ToString();
                
                this.GridView1.Columns[8].Visible = false;
                this.GridView1.Columns[10].Visible = false;
                this.GridView1.Columns[14].Visible = false;
                Chcabiertos.Checked = false;
                Chccerrados.Checked = false;
                Txtbandera.Text = "1";

            }

            else
            {
                GridView1.PageIndex = e.NewPageIndex;
                Chcabiertos.Checked = false;
                string ubi = Cmbubicacion.SelectedItem.Text;
                string ar = Cmbarea.Text;
                Int32 abier = 2;
                var _FormatoIdioma = new CultureInfo("en-US");
                var _oF1 = DateTime.Parse(TextBox1.Text, _FormatoIdioma);
                var _oF2 = DateTime.Parse(TextBox2.Text, _FormatoIdioma);

                Lbltitulo.Text = "Reportes Cerrados";

                if (ar != "Todas")
                {
                    GridView1.DataSource = NegIngenieros.busquedafechaarea(ubi, ar, _oF1, _oF2, abier);

                }
                else
                {
                    GridView1.DataSource = NegIngenieros.busquedafechaareatotal(ubi, _oF1, _oF2, abier);
                }


                //GridView1.DataSource = NegIngenieros.busquedafechaarea(ubi, ar, _oF1, _oF2, abier);
                GridView1.Columns[11].HeaderText = "Ing. que atendio";
                this.GridView1.Columns[8].Visible = true;
                this.GridView1.Columns[10].Visible = true;
                this.GridView1.Columns[14].Visible = true;
                GridView1.DataBind();
                Lblcontador.Visible = true;
                Lblcontador.Text = "Total de reportes Cerrados:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.GridView1.Rows.Count.ToString();

                Chcabiertos.Checked = false;
                Chccerrados.Checked = false;
                Txtbandera.Text = "2";

            }

        }

        protected void Cldfinal_SelectionChanged(object sender, EventArgs e)
        {
            var _O1 = Cldfinal.SelectedDate;
            string diafin = Cldfinal.SelectedDate.Day.ToString();
            string mesfin = Cldfinal.SelectedDate.Month.ToString();
            string yearfin = Cldfinal.SelectedDate.Year.ToString();
            Txtfechafinal.Text = diafin+"/"+mesfin+"/"+yearfin; ;
            TextBox2.Text = _O1.ToString("MM'/'dd'/'yyyy");   
            Cldfinal.Visible = false;
        }
    }
}