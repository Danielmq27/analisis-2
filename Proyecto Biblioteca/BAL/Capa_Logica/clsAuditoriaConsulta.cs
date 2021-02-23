using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsAuditoriaConsulta
    {
        //Metodo para consultar todas las Auditorias de Consulta
        public List<SELECCIONAR_TODO_AUDITORIA_CONSULTAResult> ConsultarAuditoriasConsulta()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_TODO_AUDITORIA_CONSULTAResult> data = dc.SELECCIONAR_TODO_AUDITORIA_CONSULTA().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una Auditoria de Consulta
        public List<SELECCIONAR_AUDITORIA_CONSULTAResult> ConsultarAuditoriaConsulta(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_CONSULTAResult> data = dc.SELECCIONAR_AUDITORIA_CONSULTA(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para restaurar un formulario eliminado por medio de la auditoria
        public bool RestaurarConsulta(string Codigo, string Cedula, string Nombre, string Apellido1, string Apellido2,
            int Telefono, string Email, string Asunto, string Descripcion, string Respuesta,
            string MetodoIngreso, string Genero, DateTime FechaIngreso, DateTime FechaRespuesta,
            string Estado, string NombreArchivo, string TipoArchivo, string Extension, byte[] Archivo, string Referido)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.RESTAURAR_CONSULTA(Codigo, Cedula, Nombre, Apellido1, Apellido2, Telefono, Email, Asunto,
                    Descripcion, Respuesta, MetodoIngreso, Genero, FechaIngreso, FechaRespuesta, Estado, NombreArchivo,
                    TipoArchivo, Extension, Archivo, Referido);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
