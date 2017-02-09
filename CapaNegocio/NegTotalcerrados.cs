using Capadatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegTotalcerrados
    {
        public static List<EntIngenieros> totalreportescerrados()
        {
            return DaoTotalcerrados.totalreportescerrados();
        }

    }
}
