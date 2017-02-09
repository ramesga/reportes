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
    public class DaoCordinador
    {
        public static EntUbicacion listarcordinador(int cord)
        {
            EntUbicacion objs = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("buscarcordinador", cnx);
                cmd.Parameters.AddWithValue("@idubicacion", cord);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                objs = new EntUbicacion();
                dr.Read();
                objs.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                objs.ubicacion= dr["ubicacion"].ToString();
                objs.region = dr["region"].ToString();                
                objs.idubicacion = Convert.ToInt32(dr["idubicacion"].ToString());

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
