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
        public List<SELECCIONAR_AUDITORIA_Consulta_TODOResult> ConsultarAuditoriasConsulta()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_Consulta_TODOResult> data = dc.SELECCIONAR_AUDITORIA_Consulta_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una Auditoria de Consulta
        public List<SELECCIONAR_AUDITORIA_ConsultaResult> ConsultarAuditoriaConsulta(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_ConsultaResult> data = dc.SELECCIONAR_AUDITORIA_Consulta(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para restaurar un formulario eliminado por medio de la auditoria
        public bool RestaurarConsulta(string Codigo, string Nombre, string Apellido1, string Apellido2,
            int Telefono, string Email, string Asunto, string Descripcion, string Respuesta,
            string MetodoIngreso, string Genero, DateTime FechaIngreso, DateTime FechaRespuesta,
            string Estado, string Cedula, string UNombre, string UApellido1, string UApellido2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.RESTAURAR_CONSULTA(Codigo, Nombre, Apellido1, Apellido2, Telefono, Email, Asunto,
                    Descripcion, Respuesta, MetodoIngreso, Genero, FechaIngreso, FechaRespuesta, Estado,
                    Cedula, UNombre, UApellido1, UApellido2);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
