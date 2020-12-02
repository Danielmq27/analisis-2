using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsArea
    {
        //Metodo para consultar todas las Areas
        public List<SELECCIONAR_AREA_TODOResult> ConsultarAreas()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AREA_TODOResult> data = dc.SELECCIONAR_AREA_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar una Area
        public List<SELECCIONAR_AREAResult> ConsultarArea(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_AREAResult> data = dc.SELECCIONAR_AREA(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar una Area
        public bool AgregarArea(string Nombre, string Descripcion)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_AREA(Nombre, Descripcion);
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

        //Metodo para eliminar una Area
        public bool EliminarArea(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_AREA(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
