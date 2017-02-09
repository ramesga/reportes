using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capadatos
{
    public class Daorepotesatrasadosgeneral
    {

        public static List<Entreportespendientes> reportespendientes(DateTime _of3)
        {

            List<Entreportespendientes> lista = new List<Entreportespendientes>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "Select * from folios where statusreporte like'%{0}%' or statusreporte like'%{1}%' and fechainicio <\'{2}\'", "En proceso","Abierto",_of3.ToString("yyyy''MM''dd")), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entreportespendientes p = new Entreportespendientes();

                    lista.Add(p);
                }

                cn.Close();
                return lista;
            }
        }


        public static List<Entreportespendientes> checarbandera(Int32 mes,Int32 ano)
        {

            List<Entreportespendientes> list = new List<Entreportespendientes>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "Select * from reportespendientes where mes like '%{0}%' and ano like '%{1}%'",mes,ano), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entreportespendientes p = new Entreportespendientes();
                    p.validador = Convert.ToInt32(dr["validador"].ToString());
                    p.cantidad = Convert.ToInt32(dr["cantidad"].ToString());
                    list.Add(p);
                }

                cn.Close();
                return list;
            }

           
        }


        public static List<EntIngenieros> restarreportes(DateTime restardia)

        {
            List<EntIngenieros> lisst = new List<EntIngenieros>();
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format(
                    "Select * from folios where fechainicio = \'{0}\'", restardia.ToString("yyyy''MM'")), cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntIngenieros r = new EntIngenieros();
                    r.fechainicio = DateTime.Parse(dr["fechainicio"].ToString());
                   
                    lisst.Add(r);
                }

                cn.Close();
                return lisst;
            }
        }

        public static int agregarcantidadpendientes(Entreportespendientes obj)
        {

            int retorno = 0;
            using (SqlConnection cn = Conexion.conectarr())
            {
                SqlCommand cmd = new SqlCommand(string.Format("Insert Into reportespendientes(mes,cantidad,validador,ano,ingeniero)values('{0}','{1}','{2}','{3}','{4}')",
                    obj.mes, obj.cantidad, obj.validador, obj.ano, obj.ingeniero), cn);

                retorno = cmd.ExecuteNonQuery();

            }
            return retorno;
            
        }


    }
}
