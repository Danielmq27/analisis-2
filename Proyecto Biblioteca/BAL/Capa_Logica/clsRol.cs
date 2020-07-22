using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsRol
    {
        /*Función para consultar roles*/
        public List<SELECCIONAR_ROL_TODOResult> ConsultarRoles()
        {
            try
            {
                /*Atributo de la base de datos*/
                bibliotecaDataContext dc = new bibliotecaDataContext();
                /*Listado de roles con el procedimiento almacenado de la base de datos*/
                List<SELECCIONAR_ROL_TODOResult> data = dc.SELECCIONAR_ROL_TODO().ToList();
                /*Devuelvame lo que encontro*/
                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*Función para consultar rol*/
        public List<SELECCIONAR_ROLResult> ConsultarRol(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_ROLResult> data = dc.SELECCIONAR_ROL(Id).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
