using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Sistema_Principal
{
    
    public partial class Principal : System.Web.UI.Page
    {
        int paginacion = 0;
        int atrasados = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                
                if (Request.QueryString["men"] != null)
                {
                    
                    int men = Convert.ToInt32(Request.QueryString["men"]);
                    
                    if(men==1)
                    {

                        Lblreporte.Text = "Reportes Abiertos o en Proceso General";
                        grvreportes.DataSource = NegIngenieros.listaringenieros(1);
                        grvreportes.Columns[11].HeaderText = "Ing. que atendera";   
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes Abiertos:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                        this.grvreportes.Columns[8].Visible = false;
                        this.grvreportes.Columns[10].Visible = false;
                        this.grvreportes.Columns[14].Visible = false;
                        
                    }

                    if(men==2)
                    {

                        Lblreporte.Text = "Reportes Cerrados General";
                        grvreportes.DataSource = NegTotalreportes.listarreportescerradoss(2);
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes cerrados:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

                    }

                    if (men==3 )
                    {

                        Lblreporte.Text = "Reportes Abiertos o en Proceso Zona Roberto Cortez";
                        grvreportes.DataSource = NegIngenieros.reportesroberto(1);
                        grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes Abiertos:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                        paginacion = 3;
                        this.grvreportes.Columns[8].Visible = false;
                        this.grvreportes.Columns[10].Visible = false;
                        this.grvreportes.Columns[14].Visible = false;

                    }
                    if(men==4)
                    {

                        Lblreporte.Text = "Reportes Cerrados Zona Roberto Cortez";
                        Txcord.Text = "Roberto Cortez";
                        grvreportes.DataSource = NegTotalreportes.listarreportescerrados(Txcord.Text, 2);
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes cerrados:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

                    }

                    if (men == 5)
                    {

                        Lblreporte.Text = "Reportes Abiertos o en Proceso Zona Hector Ruiz";
                        grvreportes.DataSource = NegIngenieros.reporteshector(1);
                        grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes Abiertos:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                        paginacion = 5;
                        this.grvreportes.Columns[8].Visible = false;
                        this.grvreportes.Columns[10].Visible = false;
                        this.grvreportes.Columns[14].Visible = false;

                    }

                    if (men == 6)
                    {

                        Lblreporte.Text = "Reportes Cerrados Zona Hector Ruiz";
                        Txcord.Text = "Hector Ruiz";
                        grvreportes.DataSource = NegTotalreportes.listarreportescerrados(Txcord.Text, 2);
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes cerrados:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

                    }

                    if (men == 7)
                    {

                        Lblreporte.Text = "Reportes Abiertos o en Proceso Francisco Nonato";
                        grvreportes.DataSource = NegIngenieros.reportesfrancisco(1);
                        grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes Abiertos:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                        this.grvreportes.Columns[8].Visible = false;
                        this.grvreportes.Columns[10].Visible = false;
                        this.grvreportes.Columns[14].Visible = false;

                    }

                    if (men == 8)
                    {

                        Lblreporte.Text = "Reportes Cerrados Francisco Nonato";
                        Txcord.Text = "Francisco Nonato";
                        grvreportes.DataSource = NegTotalreportes.listarreportesporingeniero(Txcord.Text, 2);
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes cerrados:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

                    }

                    if (men == 9)
                    {

                        Lblreporte.Text = "Reportes Abiertos o en Proceso Segismundo Mateos";
                        grvreportes.DataSource = NegIngenieros.reportessegismundo(1);
                        grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes Abiertos:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                        this.grvreportes.Columns[8].Visible = false;
                        this.grvreportes.Columns[10].Visible = false;
                        this.grvreportes.Columns[14].Visible = false;

                    }

                    if (men == 10)
                    {

                        Lblreporte.Text = "Reportes Cerrados Segismundo Mateos";
                        Txcord.Text = "Segismundo Mateos";
                        grvreportes.DataSource = NegTotalreportes.listarreportesporingeniero(Txcord.Text, 2);
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes cerrados:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

                    }

                    if (men == 11)
                    {

                        Lblreporte.Text = "Reportes Abiertos o en Proceso Roberto Cortez";
                        Txcord.Text = "Roberto Cortez";
                        grvreportes.DataSource = NegTotalreportes.listarreportesporingenieroabiertos(Txcord.Text, 1);
                        grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes Abiertos:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                        this.grvreportes.Columns[8].Visible = false;
                        this.grvreportes.Columns[10].Visible = false;
                        this.grvreportes.Columns[14].Visible = false;

                    }

                    if (men == 12)
                    {

                        Lblreporte.Text = "Reportes Cerrados Roberto Cortez";
                        Txcord.Text = "Roberto Cortez";
                        grvreportes.DataSource = NegTotalreportes.listarreportesporingeniero(Txcord.Text, 2);
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes cerrados:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

                    }

                    if (men == 13)
                    {

                        Lblreporte.Text = "Reportes Abiertos o en Proceso Hector Ruiz";
                        Txcord.Text = "Hector Ruiz";
                        grvreportes.DataSource = NegTotalreportes.listarreportesporingenieroabiertos(Txcord.Text, 1);
                        grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes Abiertos:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                        this.grvreportes.Columns[8].Visible = false;
                        this.grvreportes.Columns[10].Visible = false;
                        this.grvreportes.Columns[14].Visible = false;

                    }

                    if (men == 14)
                    {

                        Lblreporte.Text = "Reportes Cerrados Hector Ruiz";
                        Txcord.Text = "Hector Ruiz";
                        grvreportes.DataSource = NegTotalreportes.listarreportesporingeniero(Txcord.Text, 2);
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes cerrados:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

                    }

                    if (men == 15)
                    {

                        Lblreporte.Text = "Reportes Abiertos o en Proceso Angel Cordero";
                        Txcord.Text = "Angel Cordero";
                        grvreportes.DataSource = NegTotalreportes.listarreportesporingenieroabiertos(Txcord.Text, 1);
                        grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes Abiertos:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                        this.grvreportes.Columns[8].Visible = false;
                        this.grvreportes.Columns[10].Visible = false;
                        this.grvreportes.Columns[14].Visible = false;

                    }

                    if (men == 16)
                    {

                        Lblreporte.Text = "Reportes Cerrados Angel Cordero";
                        Txcord.Text = "Angel Cordero";
                        grvreportes.DataSource = NegTotalreportes.listarreportesporingeniero(Txcord.Text, 2);
                        grvreportes.DataBind();
                        Lblcontador.Text = "Total de reportes cerrados:";
                        Txtcontador.Visible = true;
                        Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

                    }


                }
                else
                {

                }
                buscaratrasados();
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmAgregar");
        }

        protected void grvreportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("FrmModificar.aspx?folio=" + grvreportes.Rows[grvreportes.SelectedIndex].Cells[0].Text);
        }

        protected void grvreportes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            paginacion = 0;
            
            paginacion = Convert.ToInt32(Request.QueryString["men"]);

            if (paginacion == 1)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegIngenieros.listaringenieros(1);
                grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes Abiertos:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                this.grvreportes.Columns[8].Visible = false;
                this.grvreportes.Columns[10].Visible = false;
                this.grvreportes.Columns[14].Visible = false;
            }

            if (paginacion == 2)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegTotalreportes.listarreportescerradoss(2);
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes cerrados:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

            }

            if (paginacion == 3)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegIngenieros.reportesroberto(1);
                grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes Abiertos:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                this.grvreportes.Columns[8].Visible = false;
                this.grvreportes.Columns[10].Visible = false;
                this.grvreportes.Columns[14].Visible = false;

            }
            if (paginacion == 4)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegTotalreportes.listarreportescerrados(Txcord.Text, 2);
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes cerrados:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

            }

            if (paginacion == 5)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegIngenieros.reporteshector(1);
                grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes Abiertos:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                this.grvreportes.Columns[8].Visible = false;
                this.grvreportes.Columns[10].Visible = false;
                this.grvreportes.Columns[14].Visible = false;

            }

            if (paginacion == 6)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegTotalreportes.listarreportescerrados(Txcord.Text, 2);
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes cerrados:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

            }

            if (paginacion == 7)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegIngenieros.reportesfrancisco(1);
                grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes Abiertos:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                this.grvreportes.Columns[8].Visible = false;
                this.grvreportes.Columns[10].Visible = false;
                this.grvreportes.Columns[14].Visible = false;

            }

            if (paginacion == 8)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegTotalreportes.listarreportesporingeniero(Txcord.Text, 2);
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes cerrados:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

            }

            if (paginacion == 9)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegIngenieros.reportessegismundo(1);
                grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes Abiertos:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                this.grvreportes.Columns[8].Visible = false;
                this.grvreportes.Columns[10].Visible = false;
                this.grvreportes.Columns[14].Visible = false;

            }

            if (paginacion == 10)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegTotalreportes.listarreportesporingeniero(Txcord.Text, 2);
                grvreportes.DataBind();
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

            }


            if (paginacion == 11)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegIngenieros.reportesrobert(1);
                grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes Abiertos:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                this.grvreportes.Columns[8].Visible = false;
                this.grvreportes.Columns[10].Visible = false;
                this.grvreportes.Columns[14].Visible = false;

            }

            if (paginacion == 12)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegTotalreportes.listarreportesporingeniero(Txcord.Text, 2);
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes cerrados:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

            }

            if (paginacion == 13)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegIngenieros.reporteshetor(1);
                grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes Abiertos:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                this.grvreportes.Columns[8].Visible = false;
                this.grvreportes.Columns[10].Visible = false;
                this.grvreportes.Columns[14].Visible = false;

            }

            if (paginacion == 14)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegTotalreportes.listarreportesporingeniero(Txcord.Text, 2);
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes cerrados:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

            }



            if (paginacion == 15)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegIngenieros.reportesangel(1);
                grvreportes.Columns[11].HeaderText = "Ing. que atendera";
                grvreportes.DataBind();
                //Lblcontador.Text = "Total de reportes Abiertos:";
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
                this.grvreportes.Columns[8].Visible = false;
                this.grvreportes.Columns[10].Visible = false;
                this.grvreportes.Columns[14].Visible = false;

            }

            if (paginacion == 16)
            {

                grvreportes.PageIndex = e.NewPageIndex;
                grvreportes.DataSource = NegTotalreportes.listarreportesporingeniero(Txcord.Text, 2);
                grvreportes.DataBind();
                Txtcontador.Visible = true;
                Txtcontador.Text = this.grvreportes.Rows.Count.ToString();

            }


            //if (paginacion==5)
            //{
            //  grvreportes.PageIndex = e.NewPageIndex;
            //grvreportes.DataSource = NegIngenieros.reporteshector(1);
            //grvreportes.DataBind();
            //Txtcontador.Visible = true;
            //Txtcontador.Text = this.grvreportes.Rows.Count.ToString();
            //}            

        }

        protected void grvreportes_RowDataBound(object sender, GridViewRowEventArgs e)
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
                int index =  GetColumnIndexByName(e.Row, "ingenierocerro");
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


        private void buscaratrasados()
        {

            DateTime resta = DateTime.Now;
            //var _FormatoIdioma = new CultureInfo("en-US");
            var _oF3 = new DateTime(resta.Year, resta.Month, 1, 0, 0, 0);



            if (resta.Day == 1 | resta.Day == 2 | resta.Day == 3)
            {
                //List<EntIngenieros> liist = NegReportesatrasados.restarreportes(_oF3);
                //if ((liist.Count) == 0)
                //{
                //}
                //else
                //{
                //  foreach (EntIngenieros objs in liist)
                //{
                //  restaratrasados = restaratrasados + 1;
                //}
                //}

                List<Entreportespendientes> list = NegReportesatrasados.checarbandera(resta.Month, resta.Year);

                if ((list.Count) == 0)
                {
                    Entreportespendientes objj = new Entreportespendientes();
                    objj.mes = Convert.ToInt32(resta.Month);

                    List<Entreportespendientes> lista = NegReportesatrasados.reportespendientes(_oF3);

                    if ((lista.Count) == 0)
                    {
                        atrasados = 0;
                    }
                    else
                    {
                        foreach (Entreportespendientes obj in lista)
                        {

                            atrasados = atrasados + 1;
                        }

                        // atrasados = atrasados - restaratrasados;
                    }

                    objj.cantidad = atrasados;
                    objj.validador = 1;
                    objj.ano = Convert.ToInt32(resta.Year);
                    objj.ingeniero = "General";
                    if (NegReportesatrasados.agregarcantidadpendientes(objj) == 1)
                    {
                        // Response.Redirect("FrmPrincipal.aspx");
                    }
                    else
                    {
                        //  LblError.Text = "No se pudo Agregar";
                        //LblError.Visible = true;
                    }



                }
                //else
                //{

                //  foreach (Entreportespendientes obj in list)
                //{
                //  verificar = obj.validador;
                //atrasados = obj.cantidad;
                //}

                //}

            }


        }
    //}

    }
}