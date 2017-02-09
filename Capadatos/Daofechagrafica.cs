using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capadatos
{
    public class Daofechagrafica
    {
        public static List<EntIngenieros> fechainicialgrafica(DateTime fechaini, DateTime fechafinall)
        {

            List<EntIngenieros> lista = new List<EntIngenieros>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "Select * from folios where fechainicio between \'{0}\' and \'{1}\' order by fechainicio", fechaini.ToString("yyyy''MM''dd"), fechafinall.ToString("yyyy''MM''dd")), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    EntIngenieros pp = new EntIngenieros();

                    string fechaactual = "";
                    string actual = "";
                    string tiemporesp = "";

                    pp.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());
                    pp.fechafinal = DateTime.Parse(dr["fechafinal"].ToString());

                    DateTime fechainicial = Convert.ToDateTime(pp.fechainicio);
                    DateTime fechafinal = Convert.ToDateTime(pp.fechafinal);
                    actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);


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

                    lista.Add(p);
                }
                cn.Close();
                return lista;
            }


        }

        public static List<EntIngenieros> fechafinalgrafica(DateTime fechaini, DateTime fechafinall)
        {

            List<EntIngenieros> lista = new List<EntIngenieros>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "Select * from folios where fechafinal between \'{0}\' and \'{1}\' order by fechafinal", fechaini.ToString("yyyy''MM''dd"), fechafinall.ToString("yyyy''MM''dd")), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    EntIngenieros pp = new EntIngenieros();

                    //string fechaactual = "";
                    string actual = "";
                    string tiemporesp = "";

                    pp.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());
                    pp.fechafinal = DateTime.Parse(dr["fechafinal"].ToString());

                    DateTime fechainicial = Convert.ToDateTime(pp.fechainicio);
                    DateTime fechafinal = Convert.ToDateTime(pp.fechafinal);
                    actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);


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

                    lista.Add(p);
                }
                cn.Close();
                return lista;
            }


        }


        public static List<EntUbicacion> areastrabajo(String donde)
        {

            List<EntUbicacion> lista = new List<EntUbicacion>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                     "Select * from areas where ubicacionn like'%{0}%'  order by area", donde), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    EntUbicacion p = new EntUbicacion();

                    p.area = dr["area"].ToString();


                    lista.Add(p);
                }
                cn.Close();
                return lista;
            }
        }

        public static List<EntDispositivos> buscardispositivos(String problema)
        {

            List<EntDispositivos> lista = new List<EntDispositivos>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                     "Select * from dispositivos where prioridad like'%{0}%'  order by descripcion", problema), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    EntDispositivos p = new EntDispositivos();

                    p.descripcion = dr["descripcion"].ToString();


                    lista.Add(p);
                }
                cn.Close();
                return lista;
            }
        }


        public static List<EntDispositivos> buscarid(String iddispositiv)
        {

            List<EntDispositivos> lista = new List<EntDispositivos>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                     "Select * from dispositivos where descripcion like'%{0}%'  order by descripcion", iddispositiv), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    EntDispositivos p = new EntDispositivos();

                    p.iddispositivo =Convert.ToInt32(dr["iddispositivo"].ToString());


                    lista.Add(p);
                }
                cn.Close();
                return lista;
            }
        }




        public static List<EntUbicacion> areastrabajovalor(String id)
        {

            List<EntUbicacion> lista = new List<EntUbicacion>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                     "Select * from areas where area like'%{0}%'  order by area", id), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    EntUbicacion p = new EntUbicacion();

                    p.area = dr["area"].ToString();
                    p.idarea = Convert.ToInt32(dr["idarea"].ToString());

                    lista.Add(p);
                }
                cn.Close();
                return lista;
            }
        }


        public static List<EntUbicacion> areastrabaall(String ubica)
        {

            List<EntUbicacion> lista = new List<EntUbicacion>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                     "Select * from areas where ubicacionn like'%{0}%'  order by area", ubica), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    EntUbicacion p = new EntUbicacion();

                    p.area = dr["area"].ToString();
                    p.idarea = Convert.ToInt32(dr["idarea"].ToString());

                    lista.Add(p);
                }
                cn.Close();
                return lista;
            }
        }


        public static List<EntIngenieros> busquedafechaarea(String ubic,String are, DateTime fechainic, DateTime fechafin,Int32 abi)
        {

            List<EntIngenieros> lista = new List<EntIngenieros>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "Select * from folios where fechainicio between \'{0}\' and \'{1}\' and ubicacion like'%{2}%' and area like'%{3}%' and idmenu like'%{4}%' order by fechainicio", fechainic.ToString("yyyy''MM''dd"), fechafin.ToString("yyyy''MM''dd"),ubic,are,abi), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    EntIngenieros pp = new EntIngenieros();

                    string fechaactual = "";
                    string actual = "";
                    string tiemporesp = "";
                    int final = 0;

                    pp.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());
                    pp.fechafinal = DateTime.Parse(dr["fechafinal"].ToString());

                    DateTime fechainicial = Convert.ToDateTime(pp.fechainicio);
                    DateTime fechafinal = Convert.ToDateTime(pp.fechafinal);
                    if(fechafinal== Convert.ToDateTime("10/10/1999 12:00:00 a.m."))
                    {
                        fechaactual = DateTime.Now.ToShortDateString();
                        DateTime convertir = Convert.ToDateTime(fechaactual);
                        actual = Convert.ToString(convertir.Subtract(fechainicial).Days);
                    }
                    

                    if (abi==2)
                    {
                        actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);
                    }
                    else
                    {
                        final = Convert.ToInt32(actual);
                    }
                   

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


        public static List<EntIngenieros> busquedafechaareatotal(String ubic,DateTime fechainic, DateTime fechafin, Int32 abi)
        {

            List<EntIngenieros> lista = new List<EntIngenieros>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "Select * from folios where fechainicio between \'{0}\' and \'{1}\' and ubicacion like'%{2}%' and idmenu like'%{3}%' order by fechainicio", fechainic.ToString("yyyy''MM''dd"), fechafin.ToString("yyyy''MM''dd"), ubic,abi), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    EntIngenieros pp = new EntIngenieros();

                    string fechaactual = "";
                    string actual = "";
                    string tiemporesp = "";
                    int final = 0;
                    int idme = 0;

                    pp.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());
                    pp.fechafinal = DateTime.Parse(dr["fechafinal"].ToString());
                    pp.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                    idme = pp.idmenu;
                    DateTime fechainicial = Convert.ToDateTime(pp.fechainicio);
                    DateTime fechafinal = Convert.ToDateTime(pp.fechafinal);

                    if (idme == 1)
                    {
                        fechaactual = DateTime.Now.ToShortDateString();
                        DateTime convertir = Convert.ToDateTime(fechaactual);
                        actual = Convert.ToString(convertir.Subtract(fechainicial).Days);
                    }


                    if (abi == 2)
                    {
                        actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);
                    }
                    else
                    {
                        final = Convert.ToInt32(actual);
                    }


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
                    p.atendioreporte = dr["atendioreporte"].ToString();
                    p.cerroreporte = dr["cerroreporte"].ToString();
                    p.cordinadorzona = dr["cordinadorzona"].ToString();
                    p.dispositivofalla = dr["dispositivofalla"].ToString();
                    p.folio = Convert.ToInt32(dr["folio"].ToString());
                    p.observaciones = dr["observaciones"].ToString();
                    p.reporta = dr["reporta"].ToString();
                    p.solicitud = dr["solicitud"].ToString();
                    p.ubicacion = dr["ubicacion"].ToString();
                    p.diastrancurridos = Convert.ToInt32(actual);
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
