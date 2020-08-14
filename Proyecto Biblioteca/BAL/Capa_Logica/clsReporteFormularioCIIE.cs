using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsReporteFormularioCIIE
    {
        public List<CantidadTipoUsuarioIngresoResult> CantidadTipoUsuarioFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CantidadTipoUsuarioIngresoResult> data = dc.CantidadTipoUsuarioIngreso(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CantidadTipoUsuarioRespuestaResult> CantidadTipoUsuarioFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CantidadTipoUsuarioRespuestaResult> data = dc.CantidadTipoUsuarioRespuesta(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CantidadTipoUsuarioFromToResult> CantidadTipoUsuarioFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CantidadTipoUsuarioFromToResult> data = dc.CantidadTipoUsuarioFromTo(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
