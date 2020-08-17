using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos para generar reportes de consultas
    public class clsReporteConsulta
    {
        //Metodo para generar un reporte de cantidad de metodos de ingreso por fecha de ingreso
        public List<CANTIDAD_METODO_INGRESO_CONSULTAResult> CantidadMetodoIngresoFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_METODO_INGRESO_CONSULTAResult> data = dc.CANTIDAD_METODO_INGRESO_CONSULTA(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de metodos de ingreso por fecha de respuesta
        public List<CANTIDAD_METODO_INGRESO_CONSULTA_RESPUESTAResult> CantidadMetodoIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_METODO_INGRESO_CONSULTA_RESPUESTAResult> data = dc.CANTIDAD_METODO_INGRESO_CONSULTA_RESPUESTA(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de metodos de ingreso por fecha de ingreso y fecha de respuesta
        public List<CANTIDAD_METODO_INGRESO_CONSULTA_FROM_TOResult> CantidadMetodoIngresoFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_METODO_INGRESO_CONSULTA_FROM_TOResult> data = dc.CANTIDAD_METODO_INGRESO_CONSULTA_FROM_TO(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso
        public List<CANTIDAD_GENERO_INGRESO_CONSULTAResult> CantidadGeneroFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_INGRESO_CONSULTAResult> data = dc.CANTIDAD_GENERO_INGRESO_CONSULTA(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de respuesta
        public List<CANTIDAD_GENERO_RESPUESTA_CONSULTAResult> CantidadGeneroFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_RESPUESTA_CONSULTAResult> data = dc.CANTIDAD_GENERO_RESPUESTA_CONSULTA(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso y fecha de respuesta
        public List<CANTIDAD_GENERO_FROM_TO_CONSULTAResult> CantidadGeneroFechaIngresoFechaRespuesta(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_FROM_TO_CONSULTAResult> data = dc.CANTIDAD_GENERO_FROM_TO_CONSULTA(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
