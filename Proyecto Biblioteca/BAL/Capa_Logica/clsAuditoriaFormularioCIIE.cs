using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsAuditoriaFormularioCIIE
    {
        //Metodo para consultar todas las auditorias de Formulario CIIE
        public List<SELECCIONAR_AUDITORIA_CIIE_TODOResult> ConsultarAuditoriasFormularioCIIE()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_CIIE_TODOResult> data = dc.SELECCIONAR_AUDITORIA_CIIE_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una auditoria de Formulario CIIE
        public List<SELECCIONAR_AUDITORIA_CIIEResult> ConsultarAuditoriaFormularioCIIE(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AUDITORIA_CIIEResult> data = dc.SELECCIONAR_AUDITORIA_CIIE(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
