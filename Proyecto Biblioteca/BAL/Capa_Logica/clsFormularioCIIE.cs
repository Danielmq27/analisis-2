using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsFormularioCIIE
    {
        //Metodo para consultar todos los Formularios del CIIE
        public List<SELECCIONAR_CIIE_TODOResult> ConsultarFormulariosCIIE()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_CIIE_TODOResult> data = dc.SELECCIONAR_CIIE_TODO().ToList();
                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar un Formulario del CIIE
        public List<SELECCIONAR_CIIEResult> ConsultarFormularioCIIE(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_CIIEResult> data = dc.SELECCIONAR_CIIE(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar un Formulario del CIIE
        public bool AgregarFormularioCIIE(string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante, int Telefono, string Email, string TipoDespacho, string Fraccion, string EspecificacionDespacho, string TipoConsulta, string EspecificacionConsulta, string Tema, string InformacionRequerida, string UsoInformacion, string GeneroSolicitante, DateTime FechaIngreso, DateTime FechaRespuesta, string Estado, string Cedula, string Nombre, string Apellido1, string Apellido2)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_CIIE(NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante, Telefono, Email, TipoDespacho, Fraccion, EspecificacionDespacho, TipoConsulta, EspecificacionConsulta, Tema, InformacionRequerida, UsoInformacion, GeneroSolicitante, FechaIngreso, FechaRespuesta, Estado, Cedula, Nombre, Apellido1, Apellido2);
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
        public bool ActualizarFormularioCIIE(int Id, string CodigoCIIE, string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante, int Telefono, string Email, string TipoDespacho, string Fraccion, string EspecificacionDespacho, string TipoConsulta, string EspecificacionConsulta, string Tema, string InformacionRequerida, string UsoInformacion, string GeneroSolicitante, DateTime FechaIngreso, DateTime FechaRespuesta, string Estado)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.ACTUALIZAR_CIIE(Id, CodigoCIIE, NombreSolicitante,Apellido1Solicitante, Apellido2Solicitante, Telefono, Email, TipoDespacho, Fraccion, EspecificacionDespacho, TipoConsulta, EspecificacionConsulta, Tema, InformacionRequerida, UsoInformacion, GeneroSolicitante, FechaIngreso, FechaRespuesta, Estado);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para eliminar un Formulario del CIIE
        public bool EliminarFormularioCIIE(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_CIIE(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
