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
    public class DaoMenu
    {
        public static List<EntMenu> listarmenu()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<EntMenu> lista = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection cnx = cn.conectar();
                cmd = new SqlCommand("listarmenus",cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cmd.ExecuteReader();
                lista = new List<EntMenu>();
                while(dr.Read())
                {
                    EntMenu c = new EntMenu();
                    c.descripcion = dr["descripcion"].ToString();
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
    }
}
