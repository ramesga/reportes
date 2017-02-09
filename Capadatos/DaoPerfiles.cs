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
    public class DaoPerfiles
    {
        public static int agregarusuarios(EntUsuario obj)
        {
            int indicador = 0;
            SqlCommand cmd = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("agregarusuarios", cnx);
                cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                cmd.Parameters.AddWithValue("@apellido", obj.apellido);
                cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                cmd.Parameters.AddWithValue("@password", obj.password);
                cmd.Parameters.AddWithValue("@perfil", obj.perfil);
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

    }
}
