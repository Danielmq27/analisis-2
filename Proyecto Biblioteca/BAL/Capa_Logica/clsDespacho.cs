using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsDespacho
    {
        //Metodo para consultar todos los Despachos
        public List<SELECCIONAR_DESPACHO_TODOResult> ConsultarDespachos()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_DESPACHO_TODOResult> data = dc.SELECCIONAR_DESPACHO_TODO().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para consultar un Despacho
        public List<SELECCIONAR_DESPACHOResult> ConsultarDespacho(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_DESPACHOResult> data = dc.SELECCIONAR_DESPACHO(Id).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Metodo para agregar un Despacho
        public bool AgregarDespacho(string Nombre, string Descripcion)
        {
            try
            {
                int respuesta = 1;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = dc.INSERTAR_DESPACHO(Nombre, Descripcion);
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

        //Metodo para eliminar un Despacho
        public bool EliminarDespacho(int Id)
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                dc.BORRAR_DESPACHO(Id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
