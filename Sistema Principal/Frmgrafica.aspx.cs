using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;



namespace Sistema_Principal
{
    public partial class Frmgrafica : System.Web.UI.Page
    {
        public string fecha = "";
        public int convertirentero = 0;
        public int fecha2 = 1;
        public int mes = 0;
        public int totalre = 0;
        public int diademes = 0;
        public int diademess = 0;
        public int abiertoacumulado = 0;
        public int cerradoacumulado=0;
        public int pendientesatender = 0;
        public double eficienciahoy = 0;
        public double eficienciaacum = 0;
        public int verificar = 0;
        public int año = 0;
        public TableRow fila;
        public TableCell celda;
        public int ii = 0;
        public int j = 0;
        public int[] totalreportes =new int [33];
        public int[] totalreportescerrados = new int[33];
        public int[] acumuladoreportesabiertos = new int[33];
        public int[] acumuladoreportescerrados = new int[33];
        public int contador = 0;
        public int atrasados = 0;
        public int restaratrasados = 0;
        public int rellenardias = 0;
        public DateTime diadehoy = DateTime.Now;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string mesactuall = DateTime.Now.Month.ToString();
                string anoactual = DateTime.Now.Year.ToString();
                int year = Convert.ToInt32(anoactual) - 2000;
                

                cmbmes.SelectedValue = mesactuall;
                cmbano.SelectedValue = Convert.ToString(year);
            }
               
            
        }

        private void generadatos()
        {
            for (ii = 0; ii < 8; ii++)
            {
                fila = new TableRow();
                for (j = 0; j < 33; j++)
                {
                    celda = new TableCell();
                    if (ii == 0)
                    {
                        if (j == 0)
                        {

                            celda = new TableCell();
                            celda.Text = "Dias del mes";
                            fila.Cells.Add(celda);
                            diademess = diademess + 1;
                            mes = Convert.ToInt32(cmbmes.SelectedValue);
                            
                        }
                        else
                        {

                            if (mes == 1 | mes == 3 | mes == 5 | mes == 7 | mes == 8 | mes == 10 | mes == 12)
                            {

                                if(j==31)
                                {
                                    j = 33;
                                    mes = 0;
                                }
                                
                                inicializarinterfaz();
                               
                                
                            } 
                            else
                            {
                                inicializarinterfaz();
                                if(j==30)
                                {
                                    j = 33;
                                    mes = 0;
                                }
                            }  
                        }
                    }
                    if (ii == 1)
                    {
                        if (j == 0)
                        {

                            celda = new TableCell();
                            celda.Text = "Reportes asignados a Soporte Hardware hoy";
                            fila.Cells.Add(celda);


                            //pintarfila();
                        }
                        else
                        {
                            

                            inicializarinterfaz1();
                            diademess = 1;
                            j = 33;
                        }

                    }
                    if (ii == 2)
                    {
                        if (j == 0)
                        {
                            celda.Text = "Reportes acumulados en el área";
                            fila.Cells.Add(celda);
                            pintarfila();
                        }
                        else
                        {
                            if (j <= fecha2)
                            {
                                acumuladosabiertos();
                            }
                            else
                            {
                                j = 33;
                                diademess = 1;
                            }

                        }

                    }
                    if (ii == 3)
                    {
                        
                        if (j == 0)
                        {
                            celda.Text = "Reportes cerrados hoy";
                            fila.Cells.Add(celda);
                            //pintarfila();
                        }
                        else
                        {

                            reportescerrados();
                            diademess = 1;
                            j = 33;
                        }

                    }
                    if (ii == 4)
                    {
                        if (j == 0)
                        {
                            celda.Text = "Reportes cerrados acumulados en el área";
                            fila.Cells.Add(celda);
                            //pintarfila();
                        }
                        else
                        {
                            if (j <= fecha2)
                            {
                                acumuladoscerrados();
                            }
                            else
                            {
                                diademess = 1;
                                j = 33;
                            }

                        }

                    }
                    if (ii == 5)
                    {
                        if (j == 0)
                        {
                            celda.Text = "Reportes pendientes por atender";
                            fila.Cells.Add(celda);
                        }
                        else
                        {
                            if (j <= fecha2)
                            {
                                pendientesporatender();
                            }
                            else
                            {
                                diademess = 1;
                                j = 33;
                            }

                        }

                    }
                    if (ii == 6)
                    {
                        if (j == 0)
                        {
                            celda.Text = "% Eficiencia hoy (Cerrados hoy/Asig.hoy)";
                            fila.Cells.Add(celda);
                        }

                        else
                        {
                            if (j <= fecha2)
                            {
                                eficienciahoyy();
                            }
                            else
                            {
                                diademess = 1;
                                convertirentero = 0;
                                j = 33;
                            }

                        }

                    }
                    if (ii == 7)
                    {
                        if (j == 0)
                        {
                            celda.Text = "% Eficiencia acumulada (Rep.Cerr.Acum/Rep.Acum)";
                            fila.Cells.Add(celda);
                        }
                        else
                        {
                            if (j <= fecha2)
                            {
                                eficienciaacumulada();
                            }
                            else
                            {
                                diademess = 1;
                                j = 33;
                            }

                        }

                    }
                    
                    Tblreportes.Rows.Add(fila);
                    pintarfila();
                }
            }
            generagrafica();
        }

        private void generagrafica()
        {
           // this.Chart1.Titles.Add("Reportes Totales (Abiertos y cerrados)");
            
            for (int i = 1; i < 31; i++)
            {
                Chart1.Series["Abiertos"].Points.AddXY(i, totalreportes[i]);
                Chart1.Series["Cerrados"].Points.AddXY(i, totalreportescerrados[i]);

            }

           
        }
        private void inicializarinterfaz1()
        {

            
            string mess = "";
            string añño = "";
            diademes = 0;
            diademess = 1;

            var _FormatoIdioma = new CultureInfo("en-US");
            var _oF1 = DateTime.Parse(Txtfecha.Text, _FormatoIdioma);
            var _oF2 = DateTime.Parse(Txfinal.Text, _FormatoIdioma);

            List<EntIngenieros> lista = NegTotalreportes.fechainicialgrafica(_oF1, _oF2);

            if ((lista.Count) == 0)
            {

                
                if(Convert.ToString(diadehoy.Month)==cmbmes.Text & Convert.ToString(diadehoy.Year)=="20"+cmbano.Text )
                {
                    if (diadehoy.Day == 1 | diadehoy.Day == 2 | diadehoy.Day == 3)
                    {
                        List<Entreportespendientes> list = NegReportesatrasados.checarbandera(diadehoy.Month, diadehoy.Year);

                        if ((list.Count) == 0)
                        {
                        }
                        else
                        {
                            celda = new TableCell();
                            foreach (Entreportespendientes obj in list)
                            {

                                celda.Text =Convert.ToString(obj.cantidad);
                            }
                            
                            celda.Width = 300;
                            fila.Cells.Add(celda);
                            totalreportes[diademess] = Convert.ToInt32(celda.Text);
                            fila.HorizontalAlign = HorizontalAlign.Center;
                            fila.VerticalAlign = VerticalAlign.Bottom;
                            pintarfila();
                            diademess = diademess + 1;
                            totalre = 0;
                            
                        }
                    }
                }
                else
                {
                    Lblsindados.Visible = true;
                    Lblsindados.Text = "No se cuenta con registros del mes y año seleccionados";
                    ii = 8;
                    j = 32;
                    Panel1.Visible = false;
                    ddlChartTypes.Visible = false;
                    Chart1.Visible = false;
                    Lblatrasados.Visible = false;
                    Lblatrasadoss.Visible = false;
                }
                
            }
            else
            {

                
                List<Entreportespendientes> list = NegReportesatrasados.checarbandera(Convert.ToInt32(cmbmes.Text),Convert.ToInt32(cmbano.Text));
                if ((list.Count) == 0)
                {
                }
                else
                {
                    foreach (Entreportespendientes obj in list)
                    {

                        atrasados = obj.cantidad;
                    }

                }
                
                Lblatrasados.Visible = true;
                Lblatrasadoss.Text = Convert.ToString(atrasados);
                Lblatrasadoss.Visible = true;


                foreach (EntIngenieros obj in lista)
                {
                    fecha = obj.fechainicio.Day.ToString();
                    mess = obj.fechainicio.Month.ToString();
                    añño = obj.fechainicio.Year.ToString();
                    año = Convert.ToInt32(añño);
                    mes = Convert.ToInt32(mess);
                    if (mes == 1 | mes == 3 | mes == 5 | mes == 7 | mes == 8 | mes == 10 | mes == 12)
                    {
                        rellenardias = 31;
                        for (contador = 0; contador < 32; contador++)
                        {
                            if (diademess == Convert.ToInt32(fecha))
                            {
                                contador = 32;
                                diademess = Convert.ToInt32(fecha);
                                fecha2 = diademess;
                            }
                            else
                            {
                                celda = new TableCell();
                                if (diademess==1)

                                {
                                    totalre = totalre + atrasados;
                                    celda.Text = Convert.ToString(totalre);
                                }
                                else
                                {
                                    celda.Text = Convert.ToString(totalre);
                                }
                                
                                celda.Width = 300;
                                fila.Cells.Add(celda);
                                totalreportes[diademess] = Convert.ToInt32(celda.Text);
                                fila.HorizontalAlign = HorizontalAlign.Center;
                                fila.VerticalAlign = VerticalAlign.Bottom;
                                pintarfila();
                                diademess = diademess + 1;
                                totalre = 0;
                                
                            }
                        }

                        if (fecha2 == Convert.ToInt32(fecha))
                        {
                            totalre = totalre + 1;

                        }
                        else
                        {
                            celda = new TableCell();
                            if (diademess == 1)

                            {
                                totalre = totalre + atrasados;
                                celda.Text = Convert.ToString(totalre);
                            }
                            else
                            {
                                celda.Text = Convert.ToString(totalre);
                            }
                            
                            celda.Width = 300;
                            fila.Cells.Add(celda);
                            totalreportes[diademess] = Convert.ToInt32(celda.Text);
                            fila.HorizontalAlign = HorizontalAlign.Center;
                            fila.VerticalAlign = VerticalAlign.Bottom;
                            pintarfila();
                            fecha2 = Convert.ToInt32(fecha);
                            totalre = 0;
                          
                        }
                    }

                    else
                    {
                        rellenardias = 30;
                        for (contador = 0; contador < 31; contador++)
                        {
                            if (diademess == Convert.ToInt32(fecha))
                            {
                                contador = 32;
                                diademess = Convert.ToInt32(fecha);
                                fecha2 = diademess;
                            }
                            else
                            {
                                celda = new TableCell();
                                if (diademess == 1)

                                {
                                    totalre = totalre + atrasados;
                                    celda.Text = Convert.ToString(totalre);
                                }
                                else
                                {
                                    celda.Text = Convert.ToString(totalre);
                                }
                                
                                celda.Width = 300;
                                fila.Cells.Add(celda);
                                totalreportes[diademess] = Convert.ToInt32(celda.Text);
                                fila.HorizontalAlign = HorizontalAlign.Center;
                                fila.VerticalAlign = VerticalAlign.Bottom;
                                pintarfila();
                                diademess = diademess + 1;
                                totalre = 0;
                               
                            }
                        }

                        if (fecha2 == Convert.ToInt32(fecha))
                        {
                            totalre = totalre + 1;
                        }
                        else
                        {
                            celda = new TableCell();
                            if (diademess == 1)

                            {
                                totalre = totalre + atrasados;
                                celda.Text = Convert.ToString(totalre);
                            }
                            else
                            {
                                celda.Text = Convert.ToString(totalre);
                            }
                            
                            celda.Width = 300;
                            fila.Cells.Add(celda);
                            totalreportes[diademess] = Convert.ToInt32(celda.Text);
                            fila.HorizontalAlign = HorizontalAlign.Center;
                            fila.VerticalAlign = VerticalAlign.Bottom;
                            pintarfila();
                            fecha2 = Convert.ToInt32(fecha);
                            totalre = 0;
                            celda = new TableCell();
                        }

                    }


                }

                if (diademess == 1)

                {
                    celda = new TableCell();
                    totalre = totalre + atrasados;
                    celda.Text = Convert.ToString(totalre);
                    celda.Width = 300;
                    fila.Cells.Add(celda);
                    totalreportes[diademess] = Convert.ToInt32(celda.Text);
                    fila.HorizontalAlign = HorizontalAlign.Center;
                    fila.VerticalAlign = VerticalAlign.Bottom;
                    pintarfila();
                }
               else
                {
                    celda = new TableCell();
                    celda.Text = Convert.ToString(totalre);
                    celda.Width = 300;
                    fila.Cells.Add(celda);
                    totalreportes[diademess] = Convert.ToInt32(celda.Text);
                    fila.HorizontalAlign = HorizontalAlign.Center;
                    fila.VerticalAlign = VerticalAlign.Bottom;
                    pintarfila();
                }
                if(diademess==diadehoy.Day)
                {

                }
                else
                {
                    diademess = diademess + 1;

                    if(diadehoy.Month == Convert.ToInt32(cmbmes.Text))
                    {
                        if (diadehoy.Year == Convert.ToInt32("20" + cmbano.Text))
                        {
                            for (contador = 0; contador < 31; contador++)
                            {
                                if (diademess <= diadehoy.Day)

                                {


                                    celda = new TableCell();
                                    celda.Text = "0";
                                    celda.Width = 300;
                                    fila.Cells.Add(celda);
                                    totalreportes[diademess] = Convert.ToInt32(celda.Text);
                                    fila.HorizontalAlign = HorizontalAlign.Center;
                                    fila.VerticalAlign = VerticalAlign.Bottom;
                                    pintarfila();
                                    fecha2 = Convert.ToInt32(fecha);
                                    diademess = diademess + 1;

                                }
                                else
                                {
                                    diademess = diademess - 1;
                                    contador = 32;
                                }
                            }

                        }

                    }

                    else
                    {

                        string prueba1 = "1/" + cmbmes.Text + "/" + cmbano.Text;
                        string prueba2 = DateTime.Now.ToShortDateString();
                        prueba2 = "1/" + diadehoy.Month + "/" + diadehoy.Year;
                        var _FormatoIdiomas = new CultureInfo("en-US");
                        var _oF11 = DateTime.Parse(prueba1, _FormatoIdioma);
                        var _oF22 = DateTime.Parse(prueba2, _FormatoIdioma);

                        if (_oF11 < _oF22)
                        {
                            for (contador = diademess; contador <= rellenardias; contador++)

                            {
                                celda = new TableCell();
                                celda.Text = "0";
                                celda.Width = 300;
                                fila.Cells.Add(celda);
                                totalreportes[diademess] = Convert.ToInt32(celda.Text);
                                fila.HorizontalAlign = HorizontalAlign.Center;
                                fila.VerticalAlign = VerticalAlign.Bottom;
                                pintarfila();
                                fecha2 = Convert.ToInt32(fecha);

                                diademess = diademess + 1;
                            }

                        }
                            
                        diademess = diademess - 1;
                    }
     
                }
            
                
                fecha2 = diademess;
                totalre = 0;
                diademess = 1;

            }


        }

        private void inicializarinterfaz()
        {
            
            celda.Width = 300;
            celda.Text =Convert.ToString(diademess);
            fila.Cells.Add(celda);
            fila.HorizontalAlign = HorizontalAlign.Center;
            fila.VerticalAlign = VerticalAlign.Bottom;
            pintarfila();
            diademess = diademess + 1;
            totalre = 0;
        }

        private void acumuladosabiertos()
        {
            if (diademess == 1)
            {
                abiertoacumulado = totalreportes[diademess];
                celda.Text = Convert.ToString(totalreportes[diademess]);
                acumuladoreportesabiertos[diademess]=totalreportes[diademess];
                celda.Width = 300;
                fila.Cells.Add(celda);
                fila.HorizontalAlign = HorizontalAlign.Center;
                fila.VerticalAlign = VerticalAlign.Bottom;

                pintarfila();
                diademess = diademess + 1;
                totalre = 0;
                celda = new TableCell();
            }
            else
            {

                abiertoacumulado = abiertoacumulado + totalreportes[diademess];
                celda.Text = Convert.ToString(abiertoacumulado);
                acumuladoreportesabiertos[diademess] = abiertoacumulado;
                celda.Width = 300;
                fila.Cells.Add(celda);
                fila.HorizontalAlign = HorizontalAlign.Center;
                fila.VerticalAlign = VerticalAlign.Bottom;

                pintarfila();
                diademess = diademess + 1;
                totalre = 0;
                celda = new TableCell();
            }
        }

        private void reportescerrados()
        {
            mes = 0;
            string mess = "";
            diademes = 0;
            diademess = 1;
            string mesactual= DateTime.Now.Month.ToString();
            string añoactual = DateTime.Now.Year.ToString();
            string diaactual = DateTime.Now.Day.ToString();
            var _FormatoIdioma = new CultureInfo("en-US");
            var _oF1 = DateTime.Parse(Txtfecha.Text, _FormatoIdioma);
            var _oF2 = DateTime.Parse(Txfinal.Text, _FormatoIdioma);

            List<EntIngenieros> lista = NegTotalreportes.fechafinalgrafica(_oF1,_oF2);
            if((lista.Count)==0)
            {
                if (diadehoy.Month == Convert.ToInt32(cmbmes.Text))
                {
                    if (diadehoy.Year == Convert.ToInt32("20" + cmbano.Text))
                    {
                        for (int x = 1; x <= Convert.ToInt32(diaactual); x++)
                        {
                            celda.Text = Convert.ToString(totalre);
                            celda.Width = 300;
                            fila.Cells.Add(celda);
                            totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                            fila.HorizontalAlign = HorizontalAlign.Center;
                            fila.VerticalAlign = VerticalAlign.Bottom;
                            pintarfila();
                            diademess = diademess + 1;
                            totalre = 0;
                            celda = new TableCell();
                        }
                        diademess = diademess - 1;
                        fecha2 = diademess;
                    }
                }

                else
                {

                    string prueba1 = "1/" + cmbmes.Text + "/" + cmbano.Text;
                    string prueba2 = DateTime.Now.ToShortDateString();
                    prueba2 = "1/" + diadehoy.Month + "/" + diadehoy.Year;
                    var _FormatoIdiomas = new CultureInfo("en-US");
                    var _oF11 = DateTime.Parse(prueba1, _FormatoIdioma);
                    var _oF22 = DateTime.Parse(prueba2, _FormatoIdioma);

                    if (_oF11 < _oF22)
                    {
                        for (contador = diademess; contador <= rellenardias; contador++)

                        {
                            celda = new TableCell();
                            celda.Text = "0";
                            celda.Width = 300;
                            fila.Cells.Add(celda);
                            totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                            fila.HorizontalAlign = HorizontalAlign.Center;
                            fila.VerticalAlign = VerticalAlign.Bottom;
                            pintarfila();
                            fecha2 = Convert.ToInt32(fecha);

                            diademess = diademess + 1;
                        }

                    }

                    diademess = diademess - 1;
                    fecha2 = diademess;

                }


            }

            else
            {
                foreach (EntIngenieros obj in lista)
                {
                    fecha = obj.fechafinal.Day.ToString();
                    mess = obj.fechafinal.Month.ToString();
                    mes = Convert.ToInt32(mess);
                    if (mes == 1 | mes == 3 | mes == 5 | mes == 7 | mes == 8 | mes == 10 | mes == 12)

                    {
                        for (contador = 0; contador < 31; contador++)
                        {
                            if (diademess == Convert.ToInt32(fecha))
                            {
                                contador = 31;
                                diademess = Convert.ToInt32(fecha);
                                fecha2 = diademess;
                            }
                            else
                            {
                                celda.Text = Convert.ToString(totalre);
                                celda.Width = 300;
                                fila.Cells.Add(celda);
                                totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                                fila.HorizontalAlign = HorizontalAlign.Center;
                                fila.VerticalAlign = VerticalAlign.Bottom;
                                pintarfila();
                                diademess = diademess + 1;
                                totalre = 0;
                                celda = new TableCell();
                            }
                        }

                        if (fecha2 == Convert.ToInt32(fecha))
                        {
                            totalre = totalre + 1;

                        }
                        else
                        {
                            celda.Text = Convert.ToString(totalre);
                            celda.Width = 300;
                            fila.Cells.Add(celda);
                            totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                            fila.HorizontalAlign = HorizontalAlign.Center;
                            fila.VerticalAlign = VerticalAlign.Bottom;
                            pintarfila();
                            fecha2 = Convert.ToInt32(fecha);
                            totalre = 0;
                            celda = new TableCell();
                        }
                    }

                    else if(mes==2)
                    {
                        for (contador = 0; contador < 29; contador++)
                        {
                            if (diademess == Convert.ToInt32(fecha))
                            {
                                contador = 31;
                                diademess = Convert.ToInt32(fecha);
                                fecha2 = diademess;
                            }
                            else
                            {
                                celda.Text = Convert.ToString(totalre);
                                celda.Width = 300;
                                fila.Cells.Add(celda);
                                totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                                fila.HorizontalAlign = HorizontalAlign.Center;
                                fila.VerticalAlign = VerticalAlign.Bottom;
                                pintarfila();
                                diademess = diademess + 1;
                                totalre = 0;
                                celda = new TableCell();
                            }
                        }

                        if (fecha2 == Convert.ToInt32(fecha))
                        {
                            totalre = totalre + 1;
                        }
                        else
                        {
                            celda.Text = Convert.ToString(totalre);
                            celda.Width = 300;
                            fila.Cells.Add(celda);
                            totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                            fila.HorizontalAlign = HorizontalAlign.Center;
                            fila.VerticalAlign = VerticalAlign.Bottom;
                            pintarfila();
                            fecha2 = Convert.ToInt32(fecha);
                            totalre = 0;
                            celda = new TableCell();
                        }
                    }

                    else
                    {
                        for (contador = 0; contador < 30; contador++)
                        {
                            if (diademess == Convert.ToInt32(fecha))
                            {
                                contador = 31;
                                diademess = Convert.ToInt32(fecha);
                                fecha2 = diademess;
                            }
                            else
                            {
                                celda.Text = Convert.ToString(totalre);
                                celda.Width = 300;
                                fila.Cells.Add(celda);
                                totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                                fila.HorizontalAlign = HorizontalAlign.Center;
                                fila.VerticalAlign = VerticalAlign.Bottom;
                                pintarfila();
                                diademess = diademess + 1;
                                totalre = 0;
                                celda = new TableCell();
                            }
                        }

                        if (fecha2 == Convert.ToInt32(fecha))
                        {
                            totalre = totalre + 1;
                        }
                        else
                        {
                            celda.Text = Convert.ToString(totalre);
                            celda.Width = 300;
                            fila.Cells.Add(celda);
                            totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                            fila.HorizontalAlign = HorizontalAlign.Center;
                            fila.VerticalAlign = VerticalAlign.Bottom;
                            pintarfila();
                            fecha2 = Convert.ToInt32(fecha);
                            totalre = 0;
                            celda = new TableCell();
                        }
                    }
                }

               

                celda.Text = Convert.ToString(totalre);
                celda.Width = 300;
                fila.Cells.Add(celda);
                totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                fila.HorizontalAlign = HorizontalAlign.Center;
                fila.VerticalAlign = VerticalAlign.Bottom;
                pintarfila();
                fecha2 = Convert.ToInt32(fecha);
                totalre = 0;
                celda = new TableCell();
                


                diademess = diademess + 1;
                if (diadehoy.Month == Convert.ToInt32(cmbmes.Text))
                {
                    if (diadehoy.Year == Convert.ToInt32("20" + cmbano.Text))
                    {
                        for (contador = 0; contador < 31; contador++)
                        {
                            if (diademess <= diadehoy.Day)

                            {
                                celda = new TableCell();
                                celda.Text = "0";
                                celda.Width = 300;
                                fila.Cells.Add(celda);
                                totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                                fila.HorizontalAlign = HorizontalAlign.Center;
                                fila.VerticalAlign = VerticalAlign.Bottom;
                                pintarfila();
                                fecha2 = Convert.ToInt32(fecha);
                                diademess = diademess + 1;
                            }
                            else
                            {
                                diademess = diademess - 1;
                                fecha2 = diademess;
                                contador = 32;
                            }
                        }

                    }

                }

                else
                {
                    string prueba1 = "1/" + cmbmes.Text + "/" + cmbano.Text;
                    string prueba2 = DateTime.Now.ToShortDateString();
                    prueba2 = "1/" + diadehoy.Month + "/" + diadehoy.Year;
                    var _FormatoIdiomas = new CultureInfo("en-US");
                    var _oF11 = DateTime.Parse(prueba1, _FormatoIdioma);
                    var _oF22 = DateTime.Parse(prueba2, _FormatoIdioma);

                    if (_oF11 < _oF22)
                    {
                        for (contador = diademess; contador <= rellenardias; contador++)

                        {
                            celda = new TableCell();
                            celda.Text = "0";
                            celda.Width = 300;
                            fila.Cells.Add(celda);
                            totalreportescerrados[diademess] = Convert.ToInt32(celda.Text);
                            fila.HorizontalAlign = HorizontalAlign.Center;
                            fila.VerticalAlign = VerticalAlign.Bottom;
                            pintarfila();
                            fecha2 = Convert.ToInt32(fecha);

                            diademess = diademess + 1;
                        }

                    }

                    diademess = diademess - 1;

                }

                fecha2 = diademess;
                diademess = 1;


            }

            
        }

        private void acumuladoscerrados()
        {
            if (diademess == 1)
            {
                cerradoacumulado = totalreportescerrados[diademess];
                celda.Text = Convert.ToString(totalreportescerrados[diademess]);
                acumuladoreportescerrados[diademess] = cerradoacumulado;
                celda.Width = 300;
                fila.Cells.Add(celda);
                fila.HorizontalAlign = HorizontalAlign.Center;
                fila.VerticalAlign = VerticalAlign.Bottom;

                pintarfila();
                diademess = diademess + 1;
                celda = new TableCell();
            }
            else
            {

                cerradoacumulado = cerradoacumulado + totalreportescerrados[diademess];
                celda.Text = Convert.ToString(cerradoacumulado);
                acumuladoreportescerrados[diademess] = cerradoacumulado;
                celda.Width = 300;
                fila.Cells.Add(celda);
                fila.HorizontalAlign = HorizontalAlign.Center;
                fila.VerticalAlign = VerticalAlign.Bottom;

                pintarfila();
                diademess = diademess + 1;
                totalre = 0;
                celda = new TableCell();
            }
        }

        private void pendientesporatender()
        {
            if (diademess == 1)
            {
                pendientesatender = acumuladoreportesabiertos[diademess] - acumuladoreportescerrados[diademess];
                
                celda.Text = Convert.ToString(pendientesatender);
                celda.Width = 300;
                fila.Cells.Add(celda);
                fila.HorizontalAlign = HorizontalAlign.Center;
                fila.VerticalAlign = VerticalAlign.Bottom;

                pintarfila();
                diademess = diademess + 1;
                celda = new TableCell();
            }
            else
            {

                pendientesatender = acumuladoreportesabiertos[diademess] - acumuladoreportescerrados[diademess];

                celda.Text = Convert.ToString(pendientesatender);
                celda.Width = 300;
                fila.Cells.Add(celda);
                fila.HorizontalAlign = HorizontalAlign.Center;
                fila.VerticalAlign = VerticalAlign.Bottom;

                pintarfila();
                diademess = diademess + 1;
                totalre = 0;
                celda = new TableCell();
            }
        }

        private void eficienciahoyy()
        {
            
            double x = 0;
            x = Convert.ToDouble(totalreportescerrados[diademess]);
            double y = 0;
            y = Convert.ToDouble(totalreportes[diademess]);
            if(x==0 | y==0)
            {
                convertirentero = 0;
            }
            else
            {
                eficienciahoy = x / y;
                eficienciahoy = eficienciahoy * 100;
                convertirentero = Convert.ToInt32(eficienciahoy);
            }
               
            celda.Text = Convert.ToString(convertirentero);
            celda.Width = 300;
            fila.Cells.Add(celda);
            fila.HorizontalAlign = HorizontalAlign.Center;
            fila.VerticalAlign = VerticalAlign.Bottom;

            pintarfila();
            diademess = diademess + 1;
            celda = new TableCell();
                
        }

        private void eficienciaacumulada()
        {

            double x = 0;
            x = Convert.ToDouble(acumuladoreportescerrados[diademess]);
            double y = 0;
            y = Convert.ToDouble(acumuladoreportesabiertos[diademess]);
            if (x == 0 | y == 0)
            {
                
            }
            else
            {
                eficienciaacum = x / y;
                eficienciaacum = eficienciaacum * 100;
                convertirentero = Convert.ToInt32(eficienciaacum);
            }

            celda.Text = Convert.ToString(convertirentero);
            celda.Width = 300;
            fila.Cells.Add(celda);
            fila.HorizontalAlign = HorizontalAlign.Center;
            fila.VerticalAlign = VerticalAlign.Bottom;

            pintarfila();
            diademess = diademess + 1;
            celda = new TableCell();

        }


        private void pintarfila()
        {

            if (ii == 0 | ii == 2 | ii == 4 | ii == 6)
            {
                fila.BackColor = System.Drawing.ColorTranslator.FromHtml("#CCCCFF");
                
            }
            else
            {
                fila.BackColor = System.Drawing.ColorTranslator.FromHtml("#99CCFF");
            }

        }

        protected void ddlChartTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            if(ddlChartTypes.Text== "---Seleccione tipo de grafica---")
            {
                
            }
            else
            {
                Panel1.Visible = true;
                ddlChartTypes.Visible = true;
                Chart1.Visible = true;
                Lblerror.Visible = false;
                generadatos();

                Chart1.Series["Abiertos"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlChartTypes.SelectedItem.Text);
                if (Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedBar | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedBar100 | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.RangeBar | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Radar | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Polar | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Renko | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Funnel | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.ThreeLineBreak | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Kagi | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.PointAndFigure | Chart1.Series["Abiertos"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Pyramid)
                {
                    Lblerror.Visible = true;
                    Lblerror.Text = "Ese tipo de grafica no soporta los valores que se muestran, favor de seleccionar otra opción";
                    Chart1.Series["Abiertos"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                }
                Chart1.Series["Cerrados"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), ddlChartTypes.SelectedItem.Text);
                if (Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedBar | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedBar100 | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.RangeBar | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Radar | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Polar | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Renko | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Funnel | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.ThreeLineBreak | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Kagi | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.PointAndFigure | Chart1.Series["Cerrados"].ChartType == System.Web.UI.DataVisualization.Charting.SeriesChartType.Pyramid)
                {
                    Lblerror.Visible = true;
                    Lblerror.Text = "Ese tipo de grafica no soporta los valores que se muestran, favor de seleccionar otra opción";
                    Chart1.Series["Cerrados"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
                }
            }
            
        }

        protected void Btngenerar_Click(object sender, EventArgs e)
        {

            Lblsindados.Visible = false;
            Array ChartTypes = Enum.GetValues(typeof(SeriesChartType));

            foreach (var item in ChartTypes)
            {
                ddlChartTypes.Items.Add(item.ToString());
            }

            ddlChartTypes.Items.Insert(0, "---Seleccione tipo de grafica---");

            Txtfecha.Text = (cmbmes.Text) + "/" + 01 + "/20" + (cmbano.Text);
            if(Convert.ToInt32(cmbmes.SelectedValue) == 4| Convert.ToInt32(cmbmes.SelectedValue) == 6 | Convert.ToInt32(cmbmes.SelectedValue) == 9| Convert.ToInt32(cmbmes.SelectedValue) == 11)
            {
            Txfinal.Text = (cmbmes.Text)+"/"+30 + "/20" + (cmbano.Text);
            }
            else if(Convert.ToInt32(cmbmes.SelectedValue) == 2 )
            {
                Txfinal.Text = (cmbmes.Text) + "/" + 28 + "/20" + (cmbano.Text);

            }
            else
            {
                Txfinal.Text = (cmbmes.Text) + "/" + 31 + "/20" + (cmbano.Text);
            }
            
            generadatos();
            if(Lblsindados.Visible==true)
            {

            }
            else
            {
                Panel1.Visible = true;
                ddlChartTypes.Visible = true;
                Chart1.Visible = true;
                ddlChartTypes.Enabled = true;
            }
            
        }

        private void buscaratrasados()
        {

        }





    }
}