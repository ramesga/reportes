using Capadatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegPerfiles
    {
        public static int agregarusuarios(EntUsuario obj)
        {
            return DaoPerfiles.agregarusuarios(obj);
        }
    }
}
