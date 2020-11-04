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
        public List<SELECCIONAR_AUDITORIA_AUDIOVISUAL_TODOResult> ConsultarAuditoriasPrestamoAudiovisual()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_AUDIOVISUAL_TODOResult> data = dc.SELECCIONAR_AUDITORIA_AUDIOVISUAL_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una auditoria de Prestamo Audiovisual
        public List<SELECCIONAR_AUDITORIA_AUDIOVISUALResult> ConsultarAuditoriaPrestamoAudiovisual(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_AUDIOVISUALResult> data = dc.SELECCIONAR_AUDITORIA_AUDIOVISUAL(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para restaurar un formulario eliminado por medio de la auditoria
        public bool RestaurarAudiovisual(string Codigo, string Nombre, string Apellido1, string Apellido2,
            int Telefono, string Departamento, string NombreActividad, string Categoria, string EspecificacionCategoria,
            string Ubicacion, DateTime FechaIngreso, DateTime FechaRespuesta, string Descripcion, string EquipoRequerido,
            int Aforo, string Genero, string Cedula, string UNombre, string UApellido1, string UApellido2)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.RESTAURAR_AUDIOVISUAL(Codigo, Nombre, Apellido1, Apellido2, Telefono, Departamento, NombreActividad,
                    Categoria, EspecificacionCategoria, Ubicacion, FechaIngreso, FechaRespuesta, Descripcion, EquipoRequerido,
                    Aforo, Genero, Cedula, UNombre, UApellido1, UApellido2);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
