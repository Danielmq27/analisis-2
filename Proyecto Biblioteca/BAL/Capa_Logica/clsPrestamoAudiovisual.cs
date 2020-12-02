using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsPrestamoAudiovisual
    {
        //Metodo para consultar todos los Prestamos Audiovisual
        public List<SELECCIONAR_AUDIOVISUAL_TODOResult> ConsultarPrestamosAudioVisual()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDIOVISUAL_TODOResult> data = dc.SELECCIONAR_AUDIOVISUAL_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar un Prestamo Audiovisual
        public List<SELECCIONAR_AUDIOVISUALResult> ConsultarPrestamoAudioVisual(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDIOVISUALResult> data = dc.SELECCIONAR_AUDIOVISUAL(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar un Prestamo Audiovisual
        public bool AgregarPrestamoAudioVisual(string Cedula, string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante, int Telefono, string Departamento, string NombreActividad, string Categoria, string EspecificacionCategoria, string Ubicacion, DateTime HoraInicio, DateTime HoraFinal, string Descripcion, string EquipoRequerido, int Aforo, string GeneroSolicitante)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_AUDIOVISUAL(Cedula, NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante, Telefono, Departamento, NombreActividad, Categoria, EspecificacionCategoria, Ubicacion, HoraInicio, HoraFinal, Descripcion, EquipoRequerido, Aforo, GeneroSolicitante);
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

        //Metodo para actualizar un Prestamo Audiovisual
        public bool ActualizarPrestamoAudioVisual(int Id, string Cedula, string CodigoPrestamoAudioVisual, string NombreSolicitante, 
            string Apellido1Solicitante, string Apellido2Solicitante, int Telefono, string Departamento, string NombreActividad,
            string Categoria, string EspecificacionCategoria, string Ubicacion, DateTime HoraInicio, DateTime HoraFinal,
            string Descripcion, string EquipoRequerido, int Aforo, string GneroSolicitante)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.ACTUALIZAR_AUDIOVISUAL(Id, CodigoPrestamoAudioVisual, Cedula, NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante,
                    Telefono, Departamento, NombreActividad, Categoria, EspecificacionCategoria, Ubicacion, HoraInicio, HoraFinal, 
                    Descripcion, EquipoRequerido, Aforo, GneroSolicitante);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para eliminar un Prestamo Audiovisual
        public bool EliminarPrestamoAudioVisual(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_AUDIOVISUAL(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
