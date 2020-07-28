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
    }
}
