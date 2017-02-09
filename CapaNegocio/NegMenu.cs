using Capadatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegMenu
    {
        public static List<EntMenu> listarmenu()
        {
            return DaoMenu.listarmenu();
        }
    }
}
