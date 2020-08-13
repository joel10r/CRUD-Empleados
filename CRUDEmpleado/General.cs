using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpleado
{
    static class General
    {
        public static int ReemplazarMascara(string dato)
        {
            dato = dato.Replace("-", "");
            return Convert.ToInt32(dato);
        }


    }
}
