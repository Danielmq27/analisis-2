using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos para generar reportes de prestamo audiovisual
    public class clsReportePrestamoAudiovisual
    {
        //Metodo para generar un reporte de cantidad de departamento por fecha de ingreso
        public List<CANTIDAD_DEPARTAMENTO_INGRESO_PAResult> CantidadDepartamentoFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_DEPARTAMENTO_INGRESO_PAResult> data = dc.CANTIDAD_DEPARTAMENTO_INGRESO_PA(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de departamento por fecha de respuesta
        public List<CANTIDAD_DEPARTAMENTO_Salida_PAResult> CantidadDepartamentoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_DEPARTAMENTO_Salida_PAResult> data = dc.CANTIDAD_DEPARTAMENTO_Salida_PA(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de departamento por fecha de ingreso y fecha de respuesta
        public List<CANTIDAD_DEPARTAMENTO_FROM_TOResult> CantidadDepartamentoFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_DEPARTAMENTO_FROM_TOResult> data = dc.CANTIDAD_DEPARTAMENTO_FROM_TO(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso
        public List<CANTIDAD_GENERO_INGRESO_PAResult> CantidadGeneroFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_INGRESO_PAResult> data = dc.CANTIDAD_GENERO_INGRESO_PA(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de respuesta
        public List<CANTIDAD_GENERO_FIN_PAResult> CantidadGeneroFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_FIN_PAResult> data = dc.CANTIDAD_GENERO_FIN_PA(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso y fecha de respuesta
        public List<CANTIDAD_GENERO_FROM_TO_PAResult> CantidadGeneroFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_FROM_TO_PAResult> data = dc.CANTIDAD_GENERO_FROM_TO_PA(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
