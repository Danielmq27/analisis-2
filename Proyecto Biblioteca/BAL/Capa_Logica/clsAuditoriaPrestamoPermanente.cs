using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsAuditoriaPrestamoPermanente
    {
        //Metodo para consultar todas las auditorias de Prestamo Permanente
        public List<SELECCIONAR_AUDITORIA_PrestamoPermanente_TODOResult> ConsultarAuditoriasPrestamoPermanente()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_PrestamoPermanente_TODOResult> data = dc.SELECCIONAR_AUDITORIA_PrestamoPermanente_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una auditoria de Prestamo Permanente
        public List<SELECCIONAR_AUDITORIA_PrestamoPermanenteResult> ConsultarAuditoriaPrestamoPermanente(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_PrestamoPermanenteResult> data = dc.SELECCIONAR_AUDITORIA_PrestamoPermanente(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
