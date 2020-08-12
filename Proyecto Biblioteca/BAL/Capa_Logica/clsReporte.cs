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
        public List<CantidadTipoUsuarioIngresoResult> CantidadTipoUsuarioIngreso(DateTime fechaFrom, DateTime fechaTo)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CantidadTipoUsuarioIngresoResult> data = dc.CantidadTipoUsuarioIngreso(fechaFrom, fechaTo).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
