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
    public class Daoidatienden
    {
        public static EntAtienden listaridatienden()
        {
            EntAtienden objs = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("listridatienden", cnx);
                //cmd.Parameters.AddWithValue("@idingenieros", ati);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                objs = new EntAtienden();
                dr.Read();
                objs.idmenu = Convert.ToInt32(dr["idmenu"].ToString());
                objs.nombre = dr["nombre"].ToString();
                objs.idingenieros = Convert.ToInt32(dr["idingenieros"].ToString());

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
