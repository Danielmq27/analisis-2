using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsFormularioCIIE
    {
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

        public List<SELECCIONAR_CIIEResult> ConsultarFormularioCIIE(string Id)
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

        public bool AgregarUsuario(string Cedula, string Nombre, string Apellido1, string Apellido2, string Email, string Clave, int IdRol)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_USUARIO(Cedula, Nombre, Apellido1, Apellido2, Email, Clave, IdRol);

                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ActualizarFormularioCIIE(int Id, string codigoCIIE, string Snombre, string Sapellido1, string Sapellido2, int telefono,
            string email, string fraccion, string tipoDespacho, string especificacionDespacho, string tipoConsulta, string especificacionConsulta, string tema,
            string informacionRequerida, string usoInformacion, string generoS, DateTime fechaIngreso, DateTime fechaRespuesta, string estado,
            string cedulaUsuario, string nombre, string apellido1, string apellido2)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.ACTUALIZAR_CIIE(Id, codigoCIIE, Snombre, Sapellido1, Sapellido2, telefono, email, fraccion, tipoDespacho, especificacionDespacho, tipoConsulta,
                    especificacionConsulta, tema, informacionRequerida, usoInformacion, generoS, fechaIngreso, fechaRespuesta, estado, cedulaUsuario, nombre, apellido1, apellido2);
                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarUsuario(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_USUARIO(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
