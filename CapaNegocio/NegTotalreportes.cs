using Capadatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegTotalreportes
    {
        public static List<EntIngenieros> totalreportes()
        {
            return DaoTotalreportes.totalreportes();
        }

        public static List<EntIngenieros> listarreportescerrados(String cordinadorzona, Int32 idmenu)
        {
            return Daoreportescerrados.listarreportescerrados(cordinadorzona, idmenu);
        }
        public static List<EntIngenieros> listarreportesporingeniero(String ingenierocerro, Int32 idmenu)
        {
            return DaoReportesingeniero.listarreportesporingeniero(ingenierocerro, idmenu);
        }

        public static List<EntIngenieros> listarreportescerradoss(Int32 idmenu)
        {
            return Daototalcerradoss.listarreportescerradoss(idmenu);
        }

        public static List<EntIngenieros> listarreportesporingenieroabiertos(String asignado, Int32 idmenu)
        {
            return DaoReportesingeniero.listarreportesporingenieroabiertos(asignado, idmenu);
        }

        public static List<EntIngenieros> fechainicialgrafica(DateTime fechaini, DateTime fechafinall)
        {
            return Daofechagrafica.fechainicialgrafica(fechaini, fechafinall);
        }

        public static List<EntIngenieros> fechafinalgrafica(DateTime fechaini, DateTime fechafinall)
        {
            return Daofechagrafica.fechafinalgrafica(fechaini, fechafinall);
        }
    }
}
