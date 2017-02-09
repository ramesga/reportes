using System.Data.SqlClient;

using System.Configuration;

namespace Capadatos
{
    public class Conexion
    {
        public static SqlConnection conectarr()
        {
            SqlConnection cn = new SqlConnection();
            // cn.ConnectionString = "Data Source=192.168.10.24;initial catalog=reportes;user id=sa;password=Ramesga13;MultipleActiveResultSets=True;";
            // casa 
            //cn.ConnectionString = "data source=SCRESTRADAG; initial catalog=reportes; integrated security=true";
            // Trabajo
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            cn.Open();

            return cn;    
        }

        public  SqlConnection conectar()
        {
            SqlConnection cn = new SqlConnection();
            // cn.ConnectionString = "Data Source=192.168.10.24;initial catalog=reportes;user id=sa;password=Ramesga13;MultipleActiveResultSets=True;";
            // casa
            //cn.ConnectionString = "data source=SCRESTRADAG; initial catalog=reportes; integrated security=true";
            //Trabajo
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


            return cn;
        }
    }
}
