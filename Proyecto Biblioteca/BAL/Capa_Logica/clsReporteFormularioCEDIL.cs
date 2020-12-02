using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsReporteFormularioCEDIL
    {
        //Metodo para generar un reporte de cantidad de tipos de usuario por fecha de ingreso
        public List<CANTIDAD_TIPO_USUARIO_INGRESO_CEDILResult> CantidadTipoUsuarioFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_TIPO_USUARIO_INGRESO_CEDILResult> data = dc.CANTIDAD_TIPO_USUARIO_INGRESO_CEDIL(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de tipos de usuario por fecha de respuesta
        public List<CANTIDAD_TIPO_USUARIO_RESPUESTA_CEDILResult> CantidadTipoUsuarioFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_TIPO_USUARIO_RESPUESTA_CEDILResult> data = dc.CANTIDAD_TIPO_USUARIO_RESPUESTA_CEDIL(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de tipos de usuario por fecha de ingreso y fecha de respuesta
        public List<CANTIDAD_TIPO_USUARIO_FROM_TO_CEDILResult> CantidadTipoUsuarioFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_TIPO_USUARIO_FROM_TO_CEDILResult> data = dc.CANTIDAD_TIPO_USUARIO_FROM_TO_CEDIL(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso
        public List<CANTIDAD_GENERO_INGRESO_CEDILResult> CantidadGeneroFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_INGRESO_CEDILResult> data = dc.CANTIDAD_GENERO_INGRESO_CEDIL(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de respuesta
        public List<CANTIDAD_GENERO_RESPUESTA_CEDILResult> CantidadGeneroFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_RESPUESTA_CEDILResult> data = dc.CANTIDAD_GENERO_RESPUESTA_CEDIL(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso y fecha de respuesta
        public List<CANTIDAD_GENERO_FROM_TO_CEDILResult> CantidadGeneroFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_FROM_TO_CEDILResult> data = dc.CANTIDAD_GENERO_FROM_TO_CEDIL(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
