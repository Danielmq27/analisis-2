using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos para generar reportes del Formulario CIIE
    public class clsReporteFormularioCIIE
    {
        //Metodo para generar un reporte de cantidad de tipos de usuario por fecha de ingreso
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

        //Metodo para generar un reporte de cantidad de tipos de usuario por fecha de respuesta
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

        //Metodo para generar un reporte de cantidad de tipos de usuario por fecha de ingreso y fecha de respuesta
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

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso
        public List<CANTIDAD_GENERO_INGRESO_CIIEResult> CantidadGeneroFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_INGRESO_CIIEResult> data = dc.CANTIDAD_GENERO_INGRESO_CIIE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de respuesta
        public List<CANTIDAD_GENERO_RESPUESTA_CIIEResult> CantidadGeneroFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_RESPUESTA_CIIEResult> data = dc.CANTIDAD_GENERO_RESPUESTA_CIIE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso y fecha de respuesta
        public List<CANTIDAD_GENERO_FROM_TO_CIIEResult> CantidadGeneroFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_FROM_TO_CIIEResult> data = dc.CANTIDAD_GENERO_FROM_TO_CIIE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
