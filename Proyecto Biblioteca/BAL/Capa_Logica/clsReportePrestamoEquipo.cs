using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos para generar reportes de prestamo de equipo
    public class clsReportePrestamoEquipo
    {
        //Metodo para generar un reporte de cantidad de departamento por fecha de ingreso
        public List<CANTIDAD_DEPARTAMENTO_INGRESO_PEResult> CantidadDepartamentoFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_DEPARTAMENTO_INGRESO_PEResult> data = dc.CANTIDAD_DEPARTAMENTO_INGRESO_PE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de departamento por fecha de respuesta
        public List<CANTIDAD_DEPARTAMENTO_SALIDA_PEResult> CantidadTipoUsuarioFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_DEPARTAMENTO_SALIDA_PEResult> data = dc.CANTIDAD_DEPARTAMENTO_SALIDA_PE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de departamento por fecha de ingreso y fecha de respuesta
        public List<CANTIDAD_DEPARTAMENTO_FROM_TO_PEResult> CantidadTipoUsuarioFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_DEPARTAMENTO_FROM_TO_PEResult> data = dc.CANTIDAD_DEPARTAMENTO_FROM_TO_PE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso
        public List<CANTIDAD_GENERO_INGRESO_PEResult> CantidadGeneroFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_INGRESO_PEResult> data = dc.CANTIDAD_GENERO_INGRESO_PE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de respuesta
        public List<CANTIDAD_GENERO_SALIDA_PEResult> CantidadGeneroFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_SALIDA_PEResult> data = dc.CANTIDAD_GENERO_SALIDA_PE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso y fecha de respuesta
        public List<CANTIDAD_GENERO_FROM_TO_PEResult> CantidadGeneroFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_FROM_TO_PEResult> data = dc.CANTIDAD_GENERO_FROM_TO_PE(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
