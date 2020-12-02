using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsAuditoriaPrestamoEquipo
    {
        //Metodo para consultar todas las auditorias de Prestamo Equipo
        public List<SELECCIONAR_TODO_AUDITORIA_PEResult> ConsultarAuditoriasPrestamoEquipo()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_TODO_AUDITORIA_PEResult> data = dc.SELECCIONAR_TODO_AUDITORIA_PE().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una auditoria de Prestamo Equipo
        public List<SELECCIONAR_AUDITORIA_PEResult> ConsultarAuditoriaPrestamoEquipo(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_PEResult> data = dc.SELECCIONAR_AUDITORIA_PE(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para restaurar un formulario eliminado por medio de la auditoria
        public bool RestaurarPrestamoEquipo(string Codigo, string UCedula, string Nombre, string Apellido1, string Apellido2,
            string Cedula, string Departamento, string TipoEquipo, string Implementos, string EspecificacionImplementos,
            string Genero, DateTime FechaIngreso, DateTime FechaRespuesta, string Estado)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.RESTAURAR_PrestamoEquipo(Codigo, UCedula, Nombre, Apellido1, Apellido2, Cedula, Departamento, TipoEquipo,
                    Implementos, EspecificacionImplementos, Genero, FechaIngreso, FechaRespuesta, Estado);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
