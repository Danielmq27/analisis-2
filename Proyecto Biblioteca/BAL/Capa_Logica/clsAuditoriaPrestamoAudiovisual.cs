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
    }
}
