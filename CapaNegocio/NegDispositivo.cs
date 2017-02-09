using Capadatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegDispositivo
    {
        public static EntDispositivos listardispositivos(int iddispo)
        {
            return Daodispositivo.listardispositivos(iddispo);
        }

        public static List<EntDispositivos> buscarid(String iddispositiv)
        {
            return Daofechagrafica.buscarid(iddispositiv);
        }
    }
}
