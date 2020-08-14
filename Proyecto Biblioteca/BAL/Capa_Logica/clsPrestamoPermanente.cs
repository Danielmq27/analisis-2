using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsPrestamoPermanente
    {
        //Metodo para consultar todos los Prestamos Permanentes
        public List<SELECCIONAR_PrestamoPermanente_TODOResult> ConsultarPrestamosPermanente()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_PrestamoPermanente_TODOResult> data = dc.SELECCIONAR_PrestamoPermanente_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar un Prestamo Permanente
        public List<SELECCIONAR_PrestamoPermanenteResult> ConsultarPrestamoPermanente(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_PrestamoPermanenteResult> data = dc.SELECCIONAR_PrestamoPermanente(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar un Prestamo Permanente
        public bool AgregarPrestamoPermanente(string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante, string Despacho, int Telefono, string Extension, string InformacionAdicional, string GeneroSolicitante, DateTime FechaPrestamo, string Estado, string CedulaUsuario, string Nombre, string Apellido1, string Apellido2)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_PrestamoPermanente(NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante, Despacho, Telefono, Extension, InformacionAdicional, GeneroSolicitante, FechaPrestamo, Estado, CedulaUsuario, Nombre, Apellido1, Apellido2);
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

        //Metodo para actualizar un Prestamo Permanente
        public bool ActualizarPrestamoPermanente(int Id, string CodigoPrestamoPermanente, string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante, string Despacho, int Telefono, string Extension, string InformacionAdicional, string GeneroSolicitante, DateTime FechaPrestamo, string Estado)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.ACTUALIZAR_PrestamoPermanente(Id, CodigoPrestamoPermanente, NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante, Despacho, Telefono, Extension, InformacionAdicional, GeneroSolicitante, FechaPrestamo, Estado);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para eliminar un Prestamo Permanente
        public bool EliminarPrestamoPermanente(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_PrestamoPermanenete(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
