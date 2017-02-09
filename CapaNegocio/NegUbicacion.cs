using Capadatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegUbicacion
    {
        public static List<EntUbicacion> listarubicacion()
        {
            return DaoUbicacion.listarubicacion();
        }

        public static List<EntUbicacion> areastrabajo(String donde)
        {
            return Daofechagrafica.areastrabajo(donde);
        }
        public static List<EntUbicacion> areastrabajovalor(String id)
        {
            return Daofechagrafica.areastrabajovalor(id);
        }

        public static List<EntUbicacion> areastrabaall(String ubica)
        {
            return Daofechagrafica.areastrabaall(ubica);
        }
    }  
}

    
