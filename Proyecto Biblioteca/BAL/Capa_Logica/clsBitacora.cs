using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsBitacora
    {
        public List<SELECCIONAR_BITACORASResult> ConsultarBitacora()
        {
            try
            {
                bibliotecaDataContext dc = new bibliotecaDataContext();
                List<SELECCIONAR_BITACORASResult> data = dc.SELECCIONAR_BITACORAS().ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AgregarBitacora(string Controlador, string Metodo, string Mensaje, string Usuario, int Tipo)
        {
            try
            {
                int respuesta = 0;
                bibliotecaDataContext dc = new bibliotecaDataContext();
                respuesta = Convert.ToInt32(dc.INSERTAR_BITACORA(Controlador, Metodo, Mensaje, Usuario, Tipo));
                return respuesta;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
