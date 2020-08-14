using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsPrestamoEquipo
    {
        //Metodo para consultar todos los Prestamos de Equipo
        public List<SELECCIONAR_PrestamoEquipo_TODOResult> ConsultarPrestamosEquipo()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_PrestamoEquipo_TODOResult> data = dc.SELECCIONAR_PrestamoEquipo_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar un Prestamo de Equipo
        public List<SELECCIONAR_PrestamoEquipoResult> ConsultarPrestamoEquipo(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_PrestamoEquipoResult> data = dc.SELECCIONAR_PrestamoEquipo(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar un Prestamo de Equipo
        public bool AgregarPrestamoEquipo(string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante,
            string Cedula, string Departamento, string TipoEquipo, string Implementos, string EspecificacionImplementos,
            string GeneroSolicitante, DateTime FechaIngreso, DateTime FechaRespuesta, string Estado, string CedulaUsuario,
            string Nombre, string Apellido1, string Apellido2)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_PrestamoEquipo(NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante, Cedula, 
                    Departamento, TipoEquipo, Implementos, EspecificacionImplementos, GeneroSolicitante, FechaIngreso, FechaRespuesta, 
                    Estado, CedulaUsuario, Nombre, Apellido1, Apellido2);
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

        //Metodo para actualizar un Prestamo de Equipo
        public bool ActualizarPrestamoEquipo(int Id, string CodigoPrestamoEquipo, string NombreSolicitante, string Apellido1Solicitante,
            string Apellido2Solicitante, string Cedula, string Departamento, string TipoEquipo, string Implementos, 
            string EspecificacionImplementos, string GeneroSolicitante, DateTime FechaIngreso, DateTime FechaRespuesta, 
            string Estado, string CedulaUsuario, string Nombre, string Apellido1, string Apellido2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.ACTUALIZAR_PrestamoEquipo(Id, CodigoPrestamoEquipo, NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante, 
                    Cedula, Departamento, TipoEquipo, Implementos, EspecificacionImplementos, GeneroSolicitante, FechaIngreso,
                    FechaRespuesta, Estado, CedulaUsuario, Nombre, Apellido1, Apellido2);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para eliminar un Prestamo de Equipo
        public bool EliminarPrestamoEquipo(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_PrestamoEquipo(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
