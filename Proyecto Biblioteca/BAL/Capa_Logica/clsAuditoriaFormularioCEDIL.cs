using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsAuditoriaFormularioCEDIL
    {
        //Metodo para consultar todas las auditorias de Formulario CEDIL
        public List<SELECCIONAR_AUDITORIA_CEDIL_TODOResult> ConsultarAuditoriasFormularioCEDIL()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_CEDIL_TODOResult> data = dc.SELECCIONAR_AUDITORIA_CEDIL_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una auditoria de Formulario CEDIL
        public List<SELECCIONAR_AUDITORIA_CEDILResult> ConsultarAuditoriaFormularioCEDIL(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_CEDILResult> data = dc.SELECCIONAR_AUDITORIA_CEDIL(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para restaurar un formulario eliminado por medio de la auditoria
        public bool RestaurarCEDIL(string CodigoCEDIL, string Cedula, string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante,
            int Telefono, string Procedencia, string Ubicacion, string TipoSolicitud, string InformacionRequerida,
            string UsoInformacion, string GeneroSolicitante, DateTime FechaIngreso, DateTime FechaRespuesta,
            string Estado)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.RESTAURAR_CEDIL(CodigoCEDIL, Cedula, NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante,
                    Telefono, Procedencia, Ubicacion, TipoSolicitud, InformacionRequerida, UsoInformacion,
                    GeneroSolicitante, FechaIngreso, FechaRespuesta, Estado);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
