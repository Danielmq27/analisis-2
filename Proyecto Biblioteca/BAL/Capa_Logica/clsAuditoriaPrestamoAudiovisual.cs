using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsAuditoriaPrestamoAudiovisual
    {
        //Metodo para consultar todas las auditorias de Prestamo Audiovisual
        public List<SELECCIONAR_TODO_AUDITORIA_PAResult> ConsultarAuditoriasPrestamoAudiovisual()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_TODO_AUDITORIA_PAResult> data = dc.SELECCIONAR_TODO_AUDITORIA_PA().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una auditoria de Prestamo Audiovisual
        public List<SELECCIONAR_AUDITORIA_PAResult> ConsultarAuditoriaPrestamoAudiovisual(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_PAResult> data = dc.SELECCIONAR_AUDITORIA_PA(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para restaurar un formulario eliminado por medio de la auditoria
        public bool RestaurarAudiovisual(string Codigo, string Cedula, string Nombre, string Apellido1, string Apellido2,
            int Telefono, string Departamento, string NombreActividad, string Categoria, string EspecificacionCategoria,
            string Ubicacion, DateTime FechaIngreso, DateTime FechaRespuesta, string Descripcion, string EquipoRequerido,
            int Aforo, string Genero)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.RESTAURAR_AUDIOVISUAL(Codigo, Cedula, Nombre, Apellido1, Apellido2, Telefono, Departamento, NombreActividad,
                    Categoria, EspecificacionCategoria, Ubicacion, FechaIngreso, FechaRespuesta, Descripcion, EquipoRequerido,
                    Aforo, Genero);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
