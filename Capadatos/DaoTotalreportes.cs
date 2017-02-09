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
    public class DaoTotalreportes
    {
        public static List<EntIngenieros> totalreportes()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntIngenieros> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("totalreportes", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntIngenieros>();
                while (dr.Read())
                {
                    EntIngenieros c = new EntIngenieros();
                    c.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());
                    c.fechafinal=DateTime.Parse(dr["fechafinal"].ToString());
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
