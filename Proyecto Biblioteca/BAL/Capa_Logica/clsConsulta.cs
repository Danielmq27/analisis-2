using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsConsulta
    {
        //Metodo para consultar todas las Consultas
        public List<SELECCIONAR_CONSULTA_TODOResult> ConsultarConsultas()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_CONSULTA_TODOResult> data = dc.SELECCIONAR_CONSULTA_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una Consulta
        public List<SELECCIONAR_CONSULTAResult> ConsultarConsulta(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_CONSULTAResult> data = dc.SELECCIONAR_CONSULTA(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar una Consulta
        public bool AgregarConsulta(string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante, int Telefono, string Email, string Asunto, string Descripcion, string Respuesta, string MetodoIngreso, string GeneroSolicitante, DateTime FechaIngreso, DateTime FechaRespuesta, string Estado)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_CONSULTA(NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante, Telefono, Email, Asunto, Descripcion, Respuesta, MetodoIngreso, GeneroSolicitante, FechaIngreso, FechaRespuesta, Estado);
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

        //Metodo para actualizar una Consulta
        public bool ActualizarConsulta(int Id, string CodigoConsulta, string NombreSolicitante, string Apellido1Solicitante, string Apellido2Solicitante, int Telefono, string Email, string Asunto, string Descripcion, string Respuesta, string MetodoIngreso, string GeneroSolicitante, DateTime FechaIngreso, DateTime FechaRespuesta, string Estado)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.ACTUALIZAR_CONSULTA(Id, CodigoConsulta, NombreSolicitante, Apellido1Solicitante, Apellido2Solicitante, Telefono, Email, Asunto, Descripcion, Respuesta, MetodoIngreso, GeneroSolicitante, FechaIngreso, FechaRespuesta, Estado);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para eliminar una Consulta
        public bool EliminarConsulta(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_CONSULTA(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
