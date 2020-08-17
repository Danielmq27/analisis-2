using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos para generar reportes de prestamo permanente
    public class clsReportePrestamoPermanente
    {
        //Metodo para generar un reporte de cantidad de departamento por fecha de ingreso
        public List<CANTIDAD_DESPACHO_INGRESO_PPResult> CantidadDespachoFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_DESPACHO_INGRESO_PPResult> data = dc.CANTIDAD_DESPACHO_INGRESO_PP(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para generar un reporte de cantidad de genero de usuario por fecha de ingreso
        public List<CANTIDAD_GENERO_INGRESO_PPResult> CantidadGeneroFechaIngreso(DateTime Fecha1, DateTime Fecha2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<CANTIDAD_GENERO_INGRESO_PPResult> data = dc.CANTIDAD_GENERO_INGRESO_PP(Fecha1, Fecha2).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
