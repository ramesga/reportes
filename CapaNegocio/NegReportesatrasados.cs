using Capadatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegReportesatrasados
    {
        public static List<Entreportespendientes> reportespendientes(DateTime _of3)
        {
            return Daorepotesatrasadosgeneral.reportespendientes(_of3);
        }

        public static List<Entreportespendientes> checarbandera(Int32 mes,Int32 ano)
        {
            return Daorepotesatrasadosgeneral.checarbandera(mes,ano);
        }

        public static int agregarcantidadpendientes(Entreportespendientes obj)
        {
            return Daorepotesatrasadosgeneral.agregarcantidadpendientes(obj);
        }

        public static List<EntIngenieros> restarreportes(DateTime restardia)

        {
            return Daorepotesatrasadosgeneral.restarreportes(restardia);
        }
    }
}
