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
        public List<SELECCIONAR_AUDITORIA_PrestamoEquipo_TODOResult> ConsultarAuditoriasPrestamoEquipo()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_PrestamoEquipo_TODOResult> data = dc.SELECCIONAR_AUDITORIA_PrestamoEquipo_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una auditoria de Prestamo Equipo
        public List<SELECCIONAR_AUDITORIA_PrestamoEquipoResult> ConsultarAuditoriaPrestamoEquipo(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_PrestamoEquipoResult> data = dc.SELECCIONAR_AUDITORIA_PrestamoEquipo(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
