using Capadatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegUsuario
    {
        public static EntUsuario Login(string usuario, string password)
        {
            return DaoUsuario.Login(usuario, password);
        }
    }
}
