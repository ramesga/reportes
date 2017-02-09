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
    public class Daodispositivo
    {
        public static EntDispositivos listardispositivos(int disposi)
        {
            EntDispositivos objs = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("buscardispositivo", cnx);
                cmd.Parameters.AddWithValue("@iddispositivo", disposi);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                objs = new EntDispositivos();
                dr.Read();
                objs.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                objs.descripcion = dr["descripcion"].ToString();
                objs.prioridad = dr["prioridad"].ToString();
                objs.iddispositivo = Convert.ToInt32(dr["iddispositivo"].ToString());

            }
            catch (Exception e)
            {
                objs = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return objs;
        }

    }
}
