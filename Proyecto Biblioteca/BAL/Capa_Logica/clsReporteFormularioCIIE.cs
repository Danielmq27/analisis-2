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
        public List<CANTIDAD_TIPO_USUARIO_INGRESO_CIIEResult> CantidadTipoUsuarioFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_TIPO_USUARIO_INGRESO_CIIEResult> data = dc.CANTIDAD_TIPO_USUARIO_INGRESO_CIIE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CANTIDAD_TIPO_USUARIO_RESPUESTA_CIIEResult> CantidadTipoUsuarioFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_TIPO_USUARIO_RESPUESTA_CIIEResult> data = dc.CANTIDAD_TIPO_USUARIO_RESPUESTA_CIIE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CANTIDAD_TIPO_USUARIO_FROM_TO_CIIEResult> CantidadTipoUsuarioFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_TIPO_USUARIO_FROM_TO_CIIEResult> data = dc.CANTIDAD_TIPO_USUARIO_FROM_TO_CIIE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
