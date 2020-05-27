using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    class Cls_Rol
    {
        public bool AgregarRol(string Nombre_Rol, string Descripcion)
        {
            try
            {
                int respuesta = 1;
                bd_bibliotecaDataContext dc = new bd_bibliotecaDataContext();
                respuesta = Convert.ToInt32(dc.AgregarRol(Nombre_Rol, Descripcion));

                if (respuesta == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
