using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsControl
    {
        public bool Eliminar_Tabla(string psTabla, string psTabla1, string psTabla2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_TABLAS(psTabla, psTabla1, psTabla2);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
