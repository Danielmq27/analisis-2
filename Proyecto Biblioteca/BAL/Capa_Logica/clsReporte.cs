using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsReporte
    {
        public List<CANTIDAD_TIPO_USUARIO_INGRESO_CIIEResult> CantidadTipoUsuarioIngreso(DateTime fechaFrom, DateTime fechaTo)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_TIPO_USUARIO_INGRESO_CIIEResult> data = dc.CANTIDAD_TIPO_USUARIO_INGRESO_CIIE(fechaFrom, fechaTo).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
