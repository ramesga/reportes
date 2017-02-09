using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capadatos
{
    public class DaoIngenieros
    {
        public static List<EntIngenieros> listaringenieros(int idmenu)
        {
            
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                
                cmd = new SqlCommand("listarmenuingenieros", cnx);
                cmd.Parameters.AddWithValue("@idmenu", idmenu);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntIngenieros>();
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
                    p.fechaasignado =DateTime.Parse(dr["fechaasignado"].ToString());
                    p.area = areacompleta;
                    
                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public static EntIngenieros buscarreporte(int folio)
        {
            EntIngenieros obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("detallereportes", cnx);
                cmd.Parameters.AddWithValue("@folio", folio);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntIngenieros();
                dr.Read();
                obj.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());
                obj.fechafinal = DateTime.Parse(dr["fechafinal"].ToString());
                obj.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                obj.ingenierocerro = dr["ingenierocerro"].ToString();
                //obj.atencion = dr["atencion"].ToString();
                obj.atendioreporte = dr["atendioreporte"].ToString();
                obj.cerroreporte = dr["cerroreporte"].ToString();
                obj.cordinadorzona = dr["cordinadorzona"].ToString();
                obj.diastrancurridos =Convert.ToInt32(dr["diastrancurridos"].ToString());
                obj.dispositivofalla = dr["dispositivofalla"].ToString();
                obj.folio = Convert.ToInt32(dr["folio"].ToString());
                obj.observaciones = dr["observaciones"].ToString();
                //obj.prioridad = dr["prioridad"].ToString();
                obj.reporta = dr["reporta"].ToString();
                obj.solicitud = dr["solicitud"].ToString();
                obj.solucion = dr["solucion"].ToString();
                //obj.status = dr["status"].ToString();
                obj.ubicacion = dr["ubicacion"].ToString();
                obj.idubicacion = Convert.ToInt32(dr["idubicacion"].ToString());
                obj.idingenieros = Convert.ToInt32(dr["idingenieros"].ToString());
                obj.iddispositivo = Convert.ToInt32(dr["iddispositivo"].ToString());
                obj.fechaasignado =DateTime.Parse(dr["fechaasignado"].ToString());
                obj.area = dr["area"].ToString();
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return obj;
        }

        public static int modificarreporte(EntIngenieros obj)
        {
            int indicador = 0;
            SqlCommand cmd = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("modificarreporte",cnx);
                cmd.Parameters.AddWithValue("@reporta", obj.reporta);
                cmd.Parameters.AddWithValue("@ubicacion", obj.ubicacion);
                cmd.Parameters.AddWithValue("@solicitud", obj.solicitud);
                cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                cmd.Parameters.AddWithValue("@cerroreporte", obj.cerroreporte);
                cmd.Parameters.AddWithValue("@idmenu", obj.idmenu);
                cmd.Parameters.AddWithValue("@ingenierocerro", obj.ingenierocerro);
                cmd.Parameters.AddWithValue("@fechainicio", obj.fechainicio);
                cmd.Parameters.AddWithValue("@dispositivofalla", obj.dispositivofalla);
                cmd.Parameters.AddWithValue("@atendioreporte", obj.atendioreporte);
                cmd.Parameters.AddWithValue("@cordinadorzona", obj.cordinadorzona);
                cmd.Parameters.AddWithValue("@fechafinal", obj.fechafinal);
                cmd.Parameters.AddWithValue("@diastranscurridos", obj.diastrancurridos);
                cmd.Parameters.AddWithValue("@statusreporte", obj.statusreporte);
                cmd.Parameters.AddWithValue("@tiemporespuesta", obj.tiemporespuesta);
                cmd.Parameters.AddWithValue("@solucion", obj.solucion);
                cmd.Parameters.AddWithValue("@idubicacion", obj.idubicacion);
                cmd.Parameters.AddWithValue("@idingenieros", obj.idingenieros);
                cmd.Parameters.AddWithValue("@iddispositivo", obj.iddispositivo);
                cmd.Parameters.AddWithValue("@folio",obj.folio);
                cmd.Parameters.AddWithValue("@fechaasignado", obj.fechaasignado);
                cmd.Parameters.AddWithValue("area", obj.area);
                cmd.Parameters.AddWithValue("idarea", obj.idarea);
                cmd.Parameters.AddWithValue("numeromaquina", obj.numeromaquina);

                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cmd.ExecuteNonQuery();
                indicador = 1;
            }
            catch(Exception e)
            {
                indicador = 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return indicador;
        }

        public static int agregarrreporte(EntIngenieros obj)
        {
            int indicador = 0;
            SqlCommand cmd = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("agregarreporte", cnx);
                cmd.Parameters.AddWithValue("@reporta", obj.reporta);
                cmd.Parameters.AddWithValue("@ubicacion", obj.ubicacion);
                cmd.Parameters.AddWithValue("@solicitud", obj.solicitud);
                cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                cmd.Parameters.AddWithValue("@cerroreporte", obj.cerroreporte);
                cmd.Parameters.AddWithValue("@idmenu", obj.idmenu);
                cmd.Parameters.AddWithValue("@ingenierocerro", obj.ingenierocerro);
                cmd.Parameters.AddWithValue("@fechainicio", obj.fechainicio);
                cmd.Parameters.AddWithValue("@dispositivofalla", obj.dispositivofalla);
                cmd.Parameters.AddWithValue("@atendioreporte", obj.atendioreporte);
                cmd.Parameters.AddWithValue("@cordinadorzona", obj.cordinadorzona);
                cmd.Parameters.AddWithValue("@fechafinal", obj.fechafinal);
                cmd.Parameters.AddWithValue("@diastranscurridos",obj.diastrancurridos);
                cmd.Parameters.AddWithValue("@statusreporte", obj.statusreporte);
                cmd.Parameters.AddWithValue("@tiemporespuesta", obj.tiemporespuesta);
                cmd.Parameters.AddWithValue("@solucion", obj.solucion);
                cmd.Parameters.AddWithValue("@idubicacion", obj.idubicacion);
                cmd.Parameters.AddWithValue("@idingenieros", obj.idingenieros);
                cmd.Parameters.AddWithValue("@iddispositivo", obj.iddispositivo);
                cmd.Parameters.AddWithValue("@fechaasignado", obj.fechaasignado);
                cmd.Parameters.AddWithValue("@area", obj.area);
                cmd.Parameters.AddWithValue("@idarea", obj.idarea);
                cmd.Parameters.AddWithValue("numeromaquina", obj.numeromaquina);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cmd.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                indicador = 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return indicador;
        }

        public static List<EntAtienden> buscarati()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntAtienden> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("buscaratienden", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntAtienden>();
                while(dr.Read())
                {
                    EntAtienden c = new EntAtienden();
                    c.nombre = dr["nombre"].ToString();
                    c.idingenieros = Convert.ToInt32(dr["idingenieros"].ToString());
                    c.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                    lista.Add(c);
                }
            }
            catch (Exception e)
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public static List<EntUbicacion> listarubicaciones()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntUbicacion> listas = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("listarubicaciones", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                listas = new List<EntUbicacion>();
                while (dr.Read())
                {
                    EntUbicacion c = new EntUbicacion();
                    c.ubicacion = dr["ubicacion"].ToString();
                    c.region = dr["region"].ToString();
                    c.idubicacion = Convert.ToInt32(dr["idubicacion"].ToString());
                    c.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                    listas.Add(c);
                }
            }
            catch (Exception e)
            {
                listas = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return listas;
        }


        public static List<EntAtienden> listaridingenieros()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntAtienden> listas = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("listridatienden", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                listas = new List<EntAtienden>();
                while (dr.Read())
                {
                    EntAtienden c = new EntAtienden();
                    c.nombre = dr["nombre"].ToString();
                    c.idingenieros = Convert.ToInt32(dr["idingenieros"].ToString());
                    c.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                    listas.Add(c);
                }
            }
            catch (Exception e)
            {
                listas = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return listas;
        }

        public static List<EntDispositivos> listardispositivos()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntDispositivos> Listas = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("listardispositivos", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                Listas = new List<EntDispositivos>();
                while (dr.Read())
                {
                    EntDispositivos c = new EntDispositivos();
                    c.descripcion = dr["descripcion"].ToString();
                    c.iddispositivo = Convert.ToInt32(dr["iddispositivo"].ToString());
                    c.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                    c.prioridad = dr["prioridad"].ToString();
                    Listas.Add(c);
                }
            }
            catch (Exception e)
            {
                Listas = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return Listas;
        }

        public static List<EntIngenieros> listarreportesabiertos()
        {
            
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> Lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("listarreportesabiertos", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                Lista = new List<EntIngenieros>();
                while (dr.Read())
                {


                    EntIngenieros pp = new EntIngenieros();

                    string fechaactual = "";

                    fechaactual = DateTime.Now.ToShortDateString();

                    pp.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());
                    pp.fechafinal = DateTime.Parse(fechaactual.ToString());

                    string actual = "";
                    actual = DateTime.Now.ToShortDateString();

                    DateTime fechainicial = Convert.ToDateTime(pp.fechainicio);
                    DateTime fechafinal = Convert.ToDateTime(pp.fechafinal);

                    TimeSpan dias = fechafinal - fechainicial;
                    actual = Convert.ToString(fechafinal.Subtract(fechainicial).Days);

                    string tiemporesp = "";

                    if(Convert.ToInt32(actual) > 2)
                    {
                        tiemporesp = Convert.ToString("Fuera de tiempo");
                    }
                    else
                    {
                        tiemporesp =Convert.ToString("A tiempo");
                    }

                        
                    EntIngenieros p = new EntIngenieros();

                    string areacompleta = "";
                    areacompleta = dr["area"].ToString();
                    if (areacompleta == "Auto Servicio" | areacompleta == "Mayoreo" | areacompleta == "Mostrador" | areacompleta == "Kiosco")
                    {
                        areacompleta = areacompleta + " " + dr["numeromaquina"].ToString();
                    }

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
                    p.fechaasignado = DateTime.Parse(dr["fechaasignado"].ToString());
                    p.area = areacompleta;

                    Lista.Add(p);
                }
            }
            catch (Exception e)
            {
                Lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return Lista;
        }


        
        public static List<EntIngenieros> reportesroberto(int idmenu)
        {
            
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                
                cmd = new SqlCommand("listarreportesabiertosroberto", cnx);
                cmd.Parameters.AddWithValue("@idmenu", idmenu);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntIngenieros>();
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
                        //string actual = "";
                        actual = DateTime.Now.ToShortDateString();

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
                    string areacompleta = "";
                    areacompleta = dr["area"].ToString();
                    if (areacompleta == "Auto Servicio" | areacompleta == "Mayoreo" | areacompleta == "Mostrador" | areacompleta == "Kiosco")
                    {
                        areacompleta = areacompleta + " " + dr["numeromaquina"].ToString();
                    }

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
                    p.fechaasignado=DateTime.Parse(dr["fechaasignado"].ToString());
                    p.area = areacompleta;

                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public static List<EntIngenieros> reporteshector(int idmenu)
        {
            
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();

                cmd = new SqlCommand("listarreporteshector", cnx);
                cmd.Parameters.AddWithValue("@idmenu", idmenu);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntIngenieros>();
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
                        //string actual = "";
                        actual = DateTime.Now.ToShortDateString();

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
                    string areacompleta = "";
                    areacompleta = dr["area"].ToString();
                    if (areacompleta == "Auto Servicio" | areacompleta == "Mayoreo" | areacompleta == "Mostrador" | areacompleta == "Kiosco")
                    {
                        areacompleta = areacompleta + " " + dr["numeromaquina"].ToString();
                    }

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
                    p.area = areacompleta;

                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public static List<EntIngenieros> reportesfrancisco(int idmenu)
        {
            
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();

                cmd = new SqlCommand("listarreportesfrancisco", cnx);
                cmd.Parameters.AddWithValue("@idmenu", idmenu);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntIngenieros>();
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
                        //string actual = "";
                        actual = DateTime.Now.ToShortDateString();

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
                    string areacompleta = "";
                    areacompleta = dr["area"].ToString();
                    if (areacompleta == "Auto Servicio" | areacompleta == "Mayoreo" | areacompleta == "Mostrador" | areacompleta == "Kiosco")
                    {
                        areacompleta = areacompleta + " " + dr["numeromaquina"].ToString();
                    }

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
                    p.area = areacompleta;

                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }

        public static List<EntIngenieros> reportessegismundo(int idmenu)
        {
            
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();

                cmd = new SqlCommand("listarreportessegismundo", cnx);
                cmd.Parameters.AddWithValue("@idmenu", idmenu);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntIngenieros>();
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
                        //string actual = "";
                        actual = DateTime.Now.ToShortDateString();

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
                    string areacompleta = "";
                    areacompleta = dr["area"].ToString();
                    if (areacompleta == "Auto Servicio" | areacompleta == "Mayoreo" | areacompleta == "Mostrador" | areacompleta == "Kiosco")
                    {
                        areacompleta = areacompleta + " " + dr["numeromaquina"].ToString();
                    }

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
                    p.area = areacompleta;

                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }


        public static List<EntIngenieros> reportesangel(int idmenu)
        {

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();

                cmd = new SqlCommand("listarreportesangel", cnx);
                cmd.Parameters.AddWithValue("@idmenu", idmenu);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntIngenieros>();
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
                        //string actual = "";
                        actual = DateTime.Now.ToShortDateString();

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
                    string areacompleta = "";
                    areacompleta = dr["area"].ToString();
                    if (areacompleta == "Auto Servicio" | areacompleta == "Mayoreo" | areacompleta == "Mostrador" | areacompleta == "Kiosco")
                    {
                        areacompleta = areacompleta + " " + dr["numeromaquina"].ToString();
                    }

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
                    p.area = areacompleta;

                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }


        public static List<EntIngenieros> reportesrobert(int idmenu)
        {

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();

                cmd = new SqlCommand("listarreportesrobert", cnx);
                cmd.Parameters.AddWithValue("@idmenu", idmenu);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntIngenieros>();
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
                        //string actual = "";
                        actual = DateTime.Now.ToShortDateString();

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
                    string areacompleta = "";
                    areacompleta = dr["area"].ToString();
                    if (areacompleta == "Auto Servicio" | areacompleta == "Mayoreo" | areacompleta == "Mostrador" | areacompleta == "Kiosco")
                    {
                        areacompleta = areacompleta + " " + dr["numeromaquina"].ToString();
                    }

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
                    p.area = areacompleta;

                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }


        public static List<EntIngenieros> reporteshetor(int idmenu)
        {

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();

                cmd = new SqlCommand("listarreporteshetor", cnx);
                cmd.Parameters.AddWithValue("@idmenu", idmenu);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntIngenieros>();
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
                        //string actual = "";
                        actual = DateTime.Now.ToShortDateString();

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
                    string areacompleta = "";
                    areacompleta = dr["area"].ToString();
                    if (areacompleta == "Auto Servicio" | areacompleta == "Mayoreo" | areacompleta == "Mostrador" | areacompleta == "Kiosco")
                    {
                        areacompleta = areacompleta + " " + dr["numeromaquina"].ToString();
                    }

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
                    p.area = areacompleta;

                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }


    }
}
