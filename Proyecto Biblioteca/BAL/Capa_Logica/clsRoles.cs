using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class clsRoles
    {
        public List<ConsultarRolesResult> ConsultarRoles()
        {
            try
            {
                bd_bibliotecaDataContext dc = new bd_bibliotecaDataContext();
                List<ConsultarRolesResult> data = dc.ConsultarRoles().ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<ConsultarRolResult> ConsultaRol(int Codigo)
        {
            try
            {
                bd_bibliotecaDataContext dc = new bd_bibliotecaDataContext();
                List<ConsultarRolResult> data = dc.ConsultarRol(Codigo).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }
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
            catch (Exception)
            {

                throw;
            }
        }
        public bool ActualizarRol(int IdRol, string Nombre_Rol, string Descripcion)
        {
            try
            {
                bd_bibliotecaDataContext dc = new bd_bibliotecaDataContext();
                dc.ActualizarRol(IdRol, Nombre_Rol, Descripcion);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarRol(int IdRol)
        {
            try
            {
                bd_bibliotecaDataContext dc = new bd_bibliotecaDataContext();
                dc.EliminarRol(IdRol);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
