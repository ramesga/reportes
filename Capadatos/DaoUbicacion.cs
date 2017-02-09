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
    public class DaoUbicacion
    {
        public static List<EntUbicacion> listarubicacion()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntUbicacion> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("listarubicaciones",cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntUbicacion>();
                while(dr.Read())
                {
                    EntUbicacion c = new EntUbicacion();
                    c.ubicacion = dr["ubicacion"].ToString();
                    c.idubicacion = Convert.ToInt32(dr["idubicacion"]);
                    c.region = dr["region"].ToString();
                    lista.Add(c);
                }
            }
            catch(Exception e)
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
