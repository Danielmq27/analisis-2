using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsFraccion
    {
        //Metodo para consultar todas las Fracciones
        public List<SELECCIONAR_FRACCION_TODOResult> ConsultarFracciones()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_FRACCION_TODOResult> data = dc.SELECCIONAR_FRACCION_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una Fraccion
        public List<SELECCIONAR_FRACCIONResult> ConsultarFraccion(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_FRACCIONResult> data = dc.SELECCIONAR_FRACCION(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar una Fraccion
        public bool AgregarFraccion(string Nombre, string Descripcion)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_FRACCION(Nombre, Descripcion);
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

        //Metodo para eliminar una Fraccion
        public bool EliminarFraccion(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_FRACCION(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
