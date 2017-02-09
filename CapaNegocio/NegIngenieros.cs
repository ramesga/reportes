using Capadatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegIngenieros
    {
        public static List<EntIngenieros> listaringenieros(int idmenu)
        {
            return DaoIngenieros.listaringenieros(idmenu);
        }

        public static EntIngenieros buscarreporte(int folio)
        {
            return DaoIngenieros.buscarreporte(folio);
        }

        public static int modificarreporte(EntIngenieros obj)
        {
            return DaoIngenieros.modificarreporte(obj);
        }
        public static int agregarrreporte(EntIngenieros obj)
        {
            return DaoIngenieros.agregarrreporte(obj);
        }
        public static List<EntAtienden> buscarati()
        {
            return DaoIngenieros.buscarati();
        }
        public static List<EntUbicacion> listarubicaciones()
        {
            return DaoIngenieros.listarubicaciones();
        }
        public static List<EntDispositivos> listardispositivos(String problema)
        {
            return Daofechagrafica.buscardispositivos(problema);
        }

        public static List<EntDispositivos> listardispositivos()
        {
            return DaoIngenieros.listardispositivos();
        }
        public static List<EntIngenieros> listarreportesabiertos()
        {
            return DaoIngenieros.listarreportesabiertos();
        }

        public static List<EntAtienden> listaridingenieros()
        {
            return DaoIngenieros.listaridingenieros();
        }

        public static List<EntIngenieros> reportesroberto(int idmenu)
        {
            return DaoIngenieros.reportesroberto(idmenu);
        }
        public static List<EntIngenieros> reporteshector(int idmenu)
        {
            return DaoIngenieros.reporteshector(idmenu);
        }
        public static List<EntIngenieros> reportesfrancisco(int idmenu)
        {
            return DaoIngenieros.reportesfrancisco(idmenu);
        }
        public static List<EntIngenieros> reportessegismundo(int idmenu)
        {
            return DaoIngenieros.reportessegismundo(idmenu);
        }

        public static List<EntIngenieros> reportesangel(int idmenu)
        {
            return DaoIngenieros.reportessegismundo(idmenu);
        }


        public static List<EntIngenieros> reportesrobert(int idmenu)
        {
            return DaoIngenieros.reportesrobert(idmenu);
        }

        public static List<EntIngenieros> reporteshetor(int idmenu)
        {
            return DaoIngenieros.reporteshetor(idmenu);
        }

        public static List<EntIngenieros> busquedafechaarea(String ubic, String are, DateTime fechainic, DateTime fechafin, Int32 abi)
        {
            return Daofechagrafica.busquedafechaarea(ubic, are, fechainic, fechafin, abi);
        }

        public static List<EntIngenieros> busquedafechaareatotal(String ubic, DateTime fechainic, DateTime fechafin, Int32 abi)
        {
            return Daofechagrafica.busquedafechaareatotal(ubic, fechainic, fechafin, abi);
        }

    }
}

