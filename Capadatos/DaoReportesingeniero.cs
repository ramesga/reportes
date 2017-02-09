using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capadatos
{
    public class DaoReportesingeniero
    {

        public static List<EntIngenieros> listarreportesporingeniero(String ingenierocerro, Int32 idmenu)
        {

            List<EntIngenieros> lista = new List<EntIngenieros>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "Select * from folios where ingenierocerro like'%{0}%' and idmenu={1} order by fechafinal DESC", ingenierocerro, idmenu), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    EntIngenieros pp = new EntIngenieros();

                    string fechaactual = "";
                    string actual = "";
                    string tiemporesp = "";
                    if (idmenu == 1)
                    {
                        fechaactual = DateTime.Now.ToShortDateString();

                        pp.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());

                        pp.fechafinal = DateTime.Parse(fechaactual.ToString());

                        actual = DateTime.Now.ToShortDateString();
                        //actual = DateTime.Now.Day.ToString();
                        DateTime fechainicial = Convert.ToDateTime(pp.fechainicio);
                        DateTime fechafinal = Convert.ToDateTime(pp.fechafinal);

                        //TimeSpan dias = fechafinal - fechainicial;
                        actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);
                    }
                    else
                    {
                        pp.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());
                        pp.fechafinal = DateTime.Parse(dr["fechafinal"].ToString());

                        DateTime fechainicial = Convert.ToDateTime(pp.fechainicio);
                        DateTime fechafinal = Convert.ToDateTime(pp.fechafinal);
                        actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);
                    }
                    //string tiemporesp = "";

                    if (Convert.ToInt32(actual) > 2)
                    {
                        tiemporesp = Convert.ToString("Fuera de tiempo");
                    }
                    else
                    {
                        tiemporesp = Convert.ToString("A tiempo");
                    }


                    EntIngenieros p = new EntIngenieros();

                    p.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());

                    p.fechafinal = DateTime.Parse(dr["fechafinal"].ToString());


                    string areacompleta = "";
                    areacompleta = dr["area"].ToString();
                    if (areacompleta == "Auto Servicio" | areacompleta == "Mayoreo" | areacompleta == "Mostrador" | areacompleta == "Kiosco")
                    {
                        areacompleta = areacompleta + " " + dr["numeromaquina"].ToString();
                    }

                    p.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                    p.ingenierocerro = dr["ingenierocerro"].ToString();
                    //p.atencion = dr["atencion"].ToString();
                    p.atendioreporte = dr["atendioreporte"].ToString();
                    p.cerroreporte = dr["cerroreporte"].ToString();
                    p.cordinadorzona = dr["cordinadorzona"].ToString();
                    p.dispositivofalla = dr["dispositivofalla"].ToString();
                    p.folio = Convert.ToInt32(dr["folio"].ToString());
                    p.observaciones = dr["observaciones"].ToString();
                    //p.prioridad = dr["prioridad"].ToString();
                    p.reporta = dr["reporta"].ToString();
                    p.solicitud = dr["solicitud"].ToString();
                    //p.status = dr["status"].ToString();
                    p.ubicacion = dr["ubicacion"].ToString();
                    p.diastrancurridos = Convert.ToInt32(actual);
                    //p.diastrancurridos = Convert.ToInt32(dr["diastrancurridos"].ToString());
                    p.statusreporte = dr["statusreporte"].ToString();
                    p.tiemporespuesta = tiemporesp;
                    p.solucion = dr["solucion"].ToString();
                    p.idubicacion = Convert.ToInt32(dr["idubicacion"].ToString());
                    p.idingenieros = Convert.ToInt32(dr["idingenieros"].ToString());
                    p.iddispositivo = Convert.ToInt32(dr["iddispositivo"].ToString());
                    p.fechaasignado = DateTime.Parse(dr["fechaasignado"].ToString());
                    p.area = areacompleta;
                    lista.Add(p);
                }
                cn.Close();
                return lista;
            }


        }

        public static List<EntIngenieros> listarreportesporingenieroabiertos(String asignado, Int32 idmenu)
        {

            List<EntIngenieros> lista = new List<EntIngenieros>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "Select * from folios where ingenierocerro like'%{0}%' and idmenu={1} order by fechainicio", asignado, idmenu), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    EntIngenieros pp = new EntIngenieros();

                    string fechaactual = "";
                    string actual = "";
                    string tiemporesp = "";
                    if (idmenu == 1)
                    {
                        fechaactual = DateTime.Now.ToShortDateString();

                        pp.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());

                        pp.fechafinal = DateTime.Parse(fechaactual.ToString());

                        actual = DateTime.Now.ToShortDateString();
                        //actual = DateTime.Now.Day.ToString();
                        DateTime fechainicial = Convert.ToDateTime(pp.fechainicio);
                        DateTime fechafinal = Convert.ToDateTime(pp.fechafinal);

                        //TimeSpan dias = fechafinal - fechainicial;
                        actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);
                    }
                    else
                    {
                        pp.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());
                        pp.fechafinal = DateTime.Parse(dr["fechafinal"].ToString());

                        DateTime fechainicial = Convert.ToDateTime(pp.fechainicio);
                        DateTime fechafinal = Convert.ToDateTime(pp.fechafinal);
                        actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);
                    }
                    //string tiemporesp = "";

                    if (Convert.ToInt32(actual) > 2)
                    {
                        tiemporesp = Convert.ToString("Fuera de tiempo");
                    }
                    else
                    {
                        tiemporesp = Convert.ToString("A tiempo");
                    }


                    EntIngenieros p = new EntIngenieros();

                    p.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());

                    p.fechafinal = DateTime.Parse(dr["fechafinal"].ToString());

                    string areacompleta = "";
                    areacompleta = dr["area"].ToString();
                    if (areacompleta == "Auto Servicio" | areacompleta == "Mayoreo" | areacompleta == "Mostrador" | areacompleta == "Kiosco")
                    {
                        areacompleta = areacompleta + " " + dr["numeromaquina"].ToString();
                    }

                    p.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                    p.ingenierocerro = dr["ingenierocerro"].ToString();
                    //p.atencion = dr["atencion"].ToString();
                    p.atendioreporte = dr["atendioreporte"].ToString();
                    p.cerroreporte = dr["cerroreporte"].ToString();
                    p.cordinadorzona = dr["cordinadorzona"].ToString();
                    p.dispositivofalla = dr["dispositivofalla"].ToString();
                    p.folio = Convert.ToInt32(dr["folio"].ToString());
                    p.observaciones = dr["observaciones"].ToString();
                    //p.prioridad = dr["prioridad"].ToString();
                    p.reporta = dr["reporta"].ToString();
                    p.solicitud = dr["solicitud"].ToString();
                    //p.status = dr["status"].ToString();
                    p.ubicacion = dr["ubicacion"].ToString();
                    p.diastrancurridos = Convert.ToInt32(actual);
                    //p.diastrancurridos = Convert.ToInt32(dr["diastrancurridos"].ToString());
                    p.statusreporte = dr["statusreporte"].ToString();
                    p.tiemporespuesta = tiemporesp;
                    p.solucion = dr["solucion"].ToString();
                    p.idubicacion = Convert.ToInt32(dr["idubicacion"].ToString());
                    p.idingenieros = Convert.ToInt32(dr["idingenieros"].ToString());
                    p.iddispositivo = Convert.ToInt32(dr["iddispositivo"].ToString());
                    p.fechaasignado = DateTime.Parse(dr["fechaasignado"].ToString());
                    p.area = areacompleta;

                    lista.Add(p);
                }
                cn.Close();
                return lista;
            }


        }

    }
}
