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
    public class DaoTotalcerrados
    {
        public static List<EntIngenieros> totalreportescerrados()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("totalreportescerrados", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntIngenieros>();
                while (dr.Read())
                {
                    EntIngenieros c = new EntIngenieros();
                    //c.fechaasignado = DateTime.Parse(dr["fechaasignado"].ToString());
                    c.fechafinal = DateTime.Parse(dr["fechafinal"].ToString());
                    //c.idingenieros = Convert.ToInt32(dr["idingenieros"].ToString());
                    //c.idmenu = Convert.ToInt32(dr["idmenu"].ToString());


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
    }
}
