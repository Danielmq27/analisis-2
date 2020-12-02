using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsFormularioCEDIL
    {
        //Metodo para consultar todos los Formularios del CEDIL
        public List<SELECCIONAR_CEDIL_TODOResult> ConsultarFormulariosCEDIL()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_CEDIL_TODOResult> data = dc.SELECCIONAR_CEDIL_TODO().ToList();
                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar un Formulario del CEDIL
        public List<SELECCIONAR_CEDILResult> ConsultarFormularioCEDIL(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_CEDILResult> data = dc.SELECCIONAR_CEDIL(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar un Formulario del CIIE
        public bool AgregarFormularioCEDIL(string Cedula, string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante,
            int Telefono, string Procedencia, string Ubicacion, string TipoSolicitud, string InformacionRequerida, 
            string UsoInformacion, string GeneroSolicitante, DateTime FechaIngreso, DateTime FechaRespuesta, 
            string Estado)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_CEDIL(Cedula, NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante, 
                    Telefono, Procedencia, Ubicacion, TipoSolicitud, InformacionRequerida, UsoInformacion,
                    GeneroSolicitante, FechaIngreso, FechaRespuesta, Estado);
                if (respuesta == 0)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para actualizar un Formulario del CIIE
        public bool ActualizarFormularioCEDIL(int Id, string CodigoCEDIL, string Cedula, string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante,
            int Telefono, string Procedencia, string Ubicacion, string TipoSolicitud, string InformacionRequerida,
            string UsoInformacion, string GeneroSolicitante, DateTime FechaIngreso, DateTime FechaRespuesta,
            string Estado)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.ACTUALIZAR_CEDIL(Id, CodigoCEDIL, Cedula, NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante,
                    Telefono, Procedencia, Ubicacion, TipoSolicitud, InformacionRequerida, UsoInformacion,
                    GeneroSolicitante, FechaIngreso, FechaRespuesta, Estado);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para eliminar un Formulario del CIIE
        public bool EliminarFormularioCEDIL(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_CEDIL(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
