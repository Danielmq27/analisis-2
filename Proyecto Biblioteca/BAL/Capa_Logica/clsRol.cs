using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    //Mapeo de los procedimientos almacenados en metodos para el sistema
    public class clsRol
    {
        //Metodo para consultar todos los Roles
        public List<SELECCIONAR_ROL_TODOResult> ConsultarRoles()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_ROL_TODOResult> data = dc.SELECCIONAR_ROL_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Metodo para consultar un Rol
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
