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
    public class DaoUsuario
    {
        public static EntUsuario Login(string usuario, string password)
        {
            EntUsuario obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("verificarusuario", cnx);
                cmd.Parameters.AddWithValue("@usuario",usuario);
                cmd.Parameters.AddWithValue("@password",password);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                obj = new EntUsuario();
                dr.Read();
                obj.apellido = dr["apellido"].ToString();
                obj.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                obj.nombre = dr["nombre"].ToString();
                obj.usuario = dr["usuario"].ToString();
                obj.password = dr["password"].ToString();
                obj.perfil = dr["perfil"].ToString();
            }
            catch(Exception e)
            {
                obj = null;
            }  
            finally
            {
                cmd.Connection.Close();
            }
            return obj;
        }
    }
}
