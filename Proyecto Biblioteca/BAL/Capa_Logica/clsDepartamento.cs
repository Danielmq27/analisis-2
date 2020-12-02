using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsDepartamento
    {
        //Metodo para consultar todos los Departamentos
        public List<SELECCIONAR_DEPARTAMENTO_TODOResult> ConsultarDepartamentos()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_DEPARTAMENTO_TODOResult> data = dc.SELECCIONAR_DEPARTAMENTO_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar un Departamento
        public List<SELECCIONAR_DEPARTAMENTOResult> ConsultarDepartamento(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_DEPARTAMENTOResult> data = dc.SELECCIONAR_DEPARTAMENTO(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar un Departamento
        public bool AgregarDepartamento(string Nombre, string Descripcion)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_DEPARTAMENTO(Nombre, Descripcion);
                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para eliminar un Departamento
        public bool EliminarDepartamento(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_DEPARTAMENTO(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
